using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading;
using Microsoft.Win32;

namespace MUST
{
    public delegate void RegistryChangeHandler(object sender, RegistryChangeEventArgs e);

    public class RegistryChangeMonitor : IDisposable
    {
        private readonly string _registryPath;
        private readonly RegNotifyChange _filter;
        private Thread _monitorThread;
        private RegistryKey _monitorKey;

        [DllImport("Advapi32.dll")]
        private static extern int RegNotifyChangeKeyValue(
           IntPtr hKey,
           bool watchSubtree,
           RegNotifyChange notifyFilter,
           IntPtr hEvent,
           bool asynchronous
           );

        [Flags]
        public enum RegNotifyChange : uint
        {
            Name = 0x1,
            Attributes = 0x2,
            LastSet = 0x4,
            Security = 0x8
        }

        public event RegistryChangeHandler Changed;
        public event RegistryChangeHandler Error;

        public static SecurityIdentifier SID
        {
            get
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();

                return identity.User;
            }
        }

        public RegistryChangeMonitor(string registryPath) : this(registryPath, RegNotifyChange.LastSet) {; }
        public RegistryChangeMonitor(string registryPath, RegNotifyChange filter)
        {
            _registryPath = registryPath.ToUpper();
            _filter = filter;
        }
        ~RegistryChangeMonitor()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                GC.SuppressFinalize(this);

            Stop();
        }
        public void Dispose()
        {
            Dispose(true);
        }
        public void Start()
        {
            lock (this)
            {
                if (_monitorThread == null)
                {
                    ThreadStart ts = MonitorThread;
                    _monitorThread = new Thread(ts) { IsBackground = true };
                }

                if (!_monitorThread.IsAlive)
                {
                    _monitorThread.Start();
                }
            }
        }
        public void Stop()
        {
            lock (this)
            {
                Changed = null;
                Error = null;

                if (_monitorThread != null)
                {
                    _monitorThread = null;
                }

                // The "Close()" will trigger RegNotifyChangeKeyValue if it is still listening
                if (_monitorKey != null)
                {
                    _monitorKey.Close();
                    _monitorKey = null;
                }
            }
        }
        private void MonitorThread()
        {
            try
            {
                IntPtr ptr = IntPtr.Zero;

                lock (this)
                {
                    if (_registryPath.StartsWith("HKEY_CLASSES_ROOT"))
                        _monitorKey = Registry.ClassesRoot.OpenSubKey(_registryPath.Substring(18));
                    else if (_registryPath.StartsWith("HKCR"))
                        _monitorKey = Registry.ClassesRoot.OpenSubKey(_registryPath.Substring(5));
                    else if (_registryPath.StartsWith("HKEY_CURRENT_USER"))
                        _monitorKey = Registry.CurrentUser.OpenSubKey(_registryPath.Substring(18));
                    else if (_registryPath.StartsWith("HKCU"))
                        _monitorKey = Registry.CurrentUser.OpenSubKey(_registryPath.Substring(5));
                    else if (_registryPath.StartsWith("HKEY_LOCAL_MACHINE"))
                        _monitorKey = Registry.LocalMachine.OpenSubKey(_registryPath.Substring(19));
                    else if (_registryPath.StartsWith("HKLM"))
                        _monitorKey = Registry.LocalMachine.OpenSubKey(_registryPath.Substring(5));
                    else if (_registryPath.StartsWith("HKEY_USERS"))
                        _monitorKey = Registry.Users.OpenSubKey(_registryPath.Substring(11));
                    else if (_registryPath.StartsWith("HKU"))
                        _monitorKey = Registry.Users.OpenSubKey(_registryPath.Substring(4));
                    else if (_registryPath.StartsWith("HKEY_CURRENT_CONFIG"))
                        _monitorKey = Registry.CurrentConfig.OpenSubKey(_registryPath.Substring(20));
                    else if (_registryPath.StartsWith("HKCC"))
                        _monitorKey = Registry.CurrentConfig.OpenSubKey(_registryPath.Substring(5));

                    // Fetch the native handle
                    if (_monitorKey != null)
                    {
                        object hkey = typeof(RegistryKey).InvokeMember(
                           "hkey",
                           BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic,
                           null,
                           _monitorKey,
                           null
                           );

                        ptr = (IntPtr)typeof(SafeHandle).InvokeMember(
                           "handle",
                           BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic,
                           null,
                           hkey,
                           null);
                    }
                }

                var locales = Registry.CurrentUser.OpenSubKey("Keyboard Layout\\Preload", false);

                if (ptr != IntPtr.Zero)
                {
                    while (true)
                    {
                        // If this._monitorThread is null that probably means Dispose is being called. Don't monitor anymore.
                        if ((_monitorThread == null) || (_monitorKey == null))
                            break;

                        // RegNotifyChangeKeyValue blocks until a change occurs.
                        int result = RegNotifyChangeKeyValue(ptr, true, _filter, IntPtr.Zero, false);

                        if ((_monitorThread == null) || (_monitorKey == null))
                            break;

                        if (result == 0)
                        {
                            if (Changed == null) continue;

                            var args = new RegistryChangeEventArgs(this);
                            Changed(this, args);

                            if (args.Stop) break;
                        }
                        else
                        {
                            if (Error != null)
                            {
                                Win32Exception ex = new Win32Exception();

                                // Unless the exception is thrown, nobody is nice enough to set a good stacktrace for us. Set it ourselves.
                                typeof(Exception).InvokeMember(
                                "_stackTrace",
                                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.SetField,
                                null,
                                ex,
                                new object[] { new StackTrace(true) }
                                );

                                var args = new RegistryChangeEventArgs(this) { Exception = ex };
                                Error(this, args);
                            }

                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Error != null)
                {
                    var args = new RegistryChangeEventArgs(this) { Exception = ex };
                    Error(this, args);
                }
            }
            finally
            {
                Stop();
            }
        }


        public bool Monitoring => _monitorThread != null && _monitorThread.IsAlive;
    }
}
