using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MUST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(77,41);
            Console.BufferHeight = 77;
            
            LogoSplash.ConsoleWriteImage(new Bitmap("nsa.png"));

            MUST must = new MUST();
            must.BeginSurveillance();

            Console.ReadKey(false);
            must.StopSurveillance();

            Console.WriteLine("");
        }
    }
}
