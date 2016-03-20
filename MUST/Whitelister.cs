using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MUST.Properties;

namespace MUST
{
    public class Whitelister
    {
        private readonly Regex _whitelistFormat = new Regex("^([0-9];?)*$");

        public List<string> MemoizedWhitelist { get; set; }

        public Whitelister()
        {
            MemoizedWhitelist = new List<string>();
        }

        public List<string> AllowedLocaleIDs()
        {
            if (_whitelistFormat.IsMatch(Settings.Default.WhitelistedLocaleIDs))
            {
                MemoizedWhitelist = Settings.Default.WhitelistedLocaleIDs.Split(';').Where(x => !string.IsNullOrEmpty(x)).ToList();
            }

            return MemoizedWhitelist;
        }
    }
}
