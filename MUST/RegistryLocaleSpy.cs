using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Security.Principal;
using System.Threading;
using RegistrySpy;
using System.DirectoryServices.AccountManagement;
using System.Web;

namespace MUST
{
    public class RegistryLocaleSpy : ISurveillance
    {

        ManagementEventWatcher watcher;
        WqlEventQuery query;
        private RegistryTreeChange treechange;
        public RegistryLocaleSpy()
        {
           
            
            
        }


        public static SecurityIdentifier SID
        {
            get
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();

                return identity.User;
            }
        }
        

        private void HandleEvent(object sender, EventArrivedEventArgs e)
        {
            Console.WriteLine("Received an event. {0}", e);
        }

        public void Surveillance()
        {
            try
            {
                //treechange = new RegistryTreeChange("HKEY_USERS", new List<string>() { $@"{SID}\Keyboard Layout\Preload"});
                //treechange.RegistryTreeChanged += (sender, args) =>
                //{
                //    Console.WriteLine("DATA CHANGED");
                //};
                //treechange.Start();

                var sid = SID.ToString();

                query = new WqlEventQuery(
                "SELECT * FROM RegistryTreeChangeEvent " +
                $"WHERE Hive = 'HKEY_USERS' AND RootPath='{sid}\\Keyboard Layout\\Preload'");

                watcher = new ManagementEventWatcher(@"\\prime\root\default", query.QueryString);
                Console.WriteLine("Waiting for an event...");

                // Set up the delegate that will handle the change event.
                watcher.EventArrived += HandleEvent;

                // Start listening for events.
                watcher.Start();
            }
            catch (ManagementException managementException)
            {
                Console.WriteLine("An error occurred: " + managementException.Message);
            }
            catch (ThreadAbortException abortException)
            {
                if ((bool)abortException.ExceptionState)
                {
                    // Stop listening for events.
                    watcher.Stop();
                    treechange.Stop();
                }
            }
        }
    }
}
