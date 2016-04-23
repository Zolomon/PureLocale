using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PureLocale
{
    public class KeyboardLayoutCleaner
    {
        [DllImport("user32.dll")]
        static extern bool UnloadKeyboardLayout(IntPtr hkl);

        [DllImport("user32.dll")]
        static extern IntPtr LoadKeyboardLayout(string pwszKLID, uint Flags);

        public static bool PurgeKeyboardLayout(InputLanguage inputLanguage)
        {
            // Get a handle to the keyboard layout
            IntPtr hkl = inputLanguage.Handle;

            // Purge the threat.
            return UnloadKeyboardLayout(hkl);
        }
    }
}
