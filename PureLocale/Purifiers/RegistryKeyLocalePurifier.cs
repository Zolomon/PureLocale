using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Win32;
using PureLocale.Properties;

namespace PureLocale
{
    public class RegistryKeyLocalePurifier : IPurifier
    {
        private SettingsReader SettingsReader { get; }

        public RegistryKeyLocalePurifier(SettingsReader settingsReader)
        {
            SettingsReader = settingsReader;
        }

        private void ReindexValues()
        {
            var locales = Registry.CurrentUser.OpenSubKey("Keyboard Layout\\Preload", true);
            var values = locales.GetValueNames().ToList().Select(x => Convert.ToInt32(x)).ToList();
            values.Sort();

            var maxValue = values.Max();

            // How it looks like in HKEY_CURRENT_USER\\Keyboard Layout\\Preload:
            // 1 -> 00000809  
            // 2 -> 00000401
            // // 3 -> ..... // DELETED
            // 4 -> 0000040c

            // We want it to turn out like this at the end of this call:
            // 1 -> 00000809  
            // 2 -> 00000401
            // 3 -> 0000040c

            if (maxValue <= 2) return;

            Console.WriteLine("Reindexing values");

            for (int i = 0; i < values.Count - 1; i++)
            {
                if (values[i + 1] - values[i] <= 1) continue;

                // Create a new value with the name of previousName+1 with current value.
                var newValue = locales.GetValue(values[i + 1].ToString());
                var name = (values[i] + 1).ToString();

                locales.SetValue(name, newValue);
                Console.WriteLine($"Moving [{values[i + 1]}] to [{values[i] + 1}]");

                // Delete current value.
                locales.DeleteValue(values[i + 1].ToString());
                Console.WriteLine("Deleting old value.");

                // Update array with new value.
                values[i + 1] = Convert.ToInt32(name);
            }

            locales.Close();
        }

        public void Purify()
        {
            try
            {
                var locales = Registry.Users.OpenSubKey($@"{Utilities.SID}\Keyboard Layout\Preload", true);

                if (locales == null) return;

                var valueNames = locales.GetValueNames();
                var dictionaryOfInstalledIDs = valueNames.ToDictionary(valueName => valueName, valueName => locales.GetValue(valueName).ToString());

                var blacklistedIDs = dictionaryOfInstalledIDs
                    .Where(kvp => !SettingsReader.WhitelistedLocaleIDs.Contains(kvp.Value))
                    .Select(kvp => kvp.Key).ToList();

                //(from whitelistedId in SettingsReader.WhitelistedLocaleIDs
                //from registryValueName in valueNames
                //where !dictionaryOfInstalledIDs.Equals(whitelistedId)
                //select registryValueName).ToList();

                foreach (var blacklistedValueName in blacklistedIDs)
                {
                    Console.WriteLine($"{blacklistedValueName} is not a whitelisted locale. Deleting.");

                    locales.DeleteValue(blacklistedValueName);
                }

                ReindexValues();

                locales.Close();
            }
            catch (Exception exception)
            {

                Console.WriteLine($"Error: {exception.Message}");
            }
        }
    }
}
