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
        private Thread KeyboardSurveillanceThread { get; set; }
        private Thread RegistryLocaleSurveillanceThread { get; set; }
        private readonly IPurifier _registryPurifier;
        private readonly IPurifier _inputLanguagePurifier;
        private readonly SettingsReader _settingsReader;

        public MUST()
        {
            _settingsReader = new SettingsReader();

            _registryPurifier = new RegistryKeyLocalePurifier(_settingsReader);
            _inputLanguagePurifier = new InputLanguagePurifier(_settingsReader);

            _keyboardLayoutSpy = new KeyboardLayoutSpy();
            KeyboardSurveillanceThread = new Thread(_keyboardLayoutSpy.Surveillance);

            _registryChangeMonitor = new RegistryChangeMonitor(
                $@"HKEY_USERS\{Utilities.SID}\Keyboard Layout\Preload");

            _registryChangeMonitor.Changed += (sender, args) =>
            {
                Console.WriteLine("Registry changed!");

                _inputLanguagePurifier.Purify();
                _registryPurifier.Purify();
            };
        }

        public void BeginSurveillance()
        {
            //KeyboardSurveillanceThread.Start();

            _registryChangeMonitor.Start();
        }

        public void StopSurveillance()
        {
            //KeyboardSurveillanceThread.Abort(true);

            _registryChangeMonitor.Stop();
        }
    }
}
