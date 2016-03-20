using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace MUST
{
    public class RegistryChangeEventArgs : EventArgs
    {
        public RegistryChangeEventArgs(RegistryChangeMonitor monitor)
        {
            this.Monitor = monitor;
        }
        
        public RegistryChangeMonitor Monitor { get; }

        public Exception Exception { get; set; }

        public bool Stop { get; set; }
    }
}