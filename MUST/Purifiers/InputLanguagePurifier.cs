using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MUST
{
    public class InputLanguagePurifier : IPurifier
    {
        public SettingsReader SettingsReader { get; set; }

        public InputLanguagePurifier(SettingsReader settingsReader)
        {
            SettingsReader = settingsReader;
        }

        public void Purify()
        {
            var currentInputLanguages = InputLanguage.InstalledInputLanguages.Cast<InputLanguage>().ToList();

            var blacklistedIDs =
                currentInputLanguages.Where(x => SettingsReader.WhitelistedLocaleIDs.All(y => Convert.ToInt32(y.TrimStart('0'), 16) != x.Culture.LCID));
                
            Console.WriteLine("New keyboard language appeared:");
            foreach (var inputLanguage in blacklistedIDs)
            {
                Console.WriteLine(inputLanguage);

                var languageWasDeleted = KeyboardLayoutCleaner.PurgeKeyboardLayout(inputLanguage);
                if (!languageWasDeleted) continue;
                
                Console.WriteLine($"{inputLanguage.LayoutName} was purged.");
            }

        }
    }
}
