using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MUST.Properties;

namespace MUST
{
    public class SettingsReader
    {
        private readonly Regex _whitelistFormat = new Regex("^([0-9a-f];?)*$");

        public List<string> WhitelistedLocaleIDs { get; set; } 

        public SettingsReader()
        {
            WhitelistedLocaleIDs = new List<string>();

            UpdateWhitelist();

            Properties.Settings.Default.PropertyChanged += DefaultOnPropertyChanged;    
        }

        private void DefaultOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (!propertyChangedEventArgs.PropertyName.Equals(nameof(Settings.Default.WhitelistedLocaleIDs))) return;

            UpdateWhitelist();
        }

        private void UpdateWhitelist()
        {
            if (!_whitelistFormat.IsMatch(Settings.Default.WhitelistedLocaleIDs)) return;

            WhitelistedLocaleIDs = Settings.Default.WhitelistedLocaleIDs.Split(';').ToList();
        }
    }
}
