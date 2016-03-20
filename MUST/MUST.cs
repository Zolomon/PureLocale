using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MUST
{
    public class MUST
    {
        private readonly RegistryChangeMonitor _registryChangeMonitor;
        private readonly KeyboardLayoutSpy _keyboardLayoutSpy;
        private readonly RegistryLocaleSpy _registryLocaleSpy;
        private Thread KeyboardSurveillanceThread { get; set; }
        private Thread RegistryLocaleSurveillanceThread { get; set; }
        public MUST()
        {
            _keyboardLayoutSpy = new KeyboardLayoutSpy();
            KeyboardSurveillanceThread = new Thread(_keyboardLayoutSpy.Surveillance);

            _registryLocaleSpy = new RegistryLocaleSpy();
            RegistryLocaleSurveillanceThread = new Thread(_registryLocaleSpy.Surveillance);

            _registryChangeMonitor = new RegistryChangeMonitor("HKEY_USERS\\"+RegistryLocaleSpy.SID+"\\Keyboard Layout\\Preload");
            _registryChangeMonitor.Changed += (sender, args) =>
            {
                Console.WriteLine("Registry changed!");
            };
        }

        public void BeginSurveillance()
        {
            KeyboardSurveillanceThread.Start();
            //RegistryLocaleSurveillanceThread.Start();
            _registryChangeMonitor.Start();
        }

        public void StopSurveillance()
        {
            KeyboardSurveillanceThread.Abort(true);
            //RegistryLocaleSurveillanceThread.Abort(true);
            _registryChangeMonitor.Stop();
        }
    }
}
