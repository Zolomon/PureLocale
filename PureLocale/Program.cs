using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PureLocale
{
    class Program
    {
        static void Main(string[] args)
        {
            LocalePurifier localePurifier = new LocalePurifier();
            localePurifier.BeginSurveillance();

            localePurifier.OnPurify(localePurifier, new PurifyEventArgs());

            Console.ReadKey(false);
            localePurifier.StopSurveillance();

            Console.WriteLine("");
        }
    }
}
