using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace MUST
{
    public class KeyboardLayoutSpy
    {
        public KeyboardLayoutSpy()
        {
        }

        public void Surveillance()
        {
            List<InputLanguage> previousList = new List<InputLanguage>();

            while (true)
            {
                try
                {
                    if (previousList.Count == 0)
                    {
                        previousList = InputLanguage.InstalledInputLanguages.Cast<InputLanguage>().ToList();
                    }
                    var previousSet = new HashSet<InputLanguage>(previousList);

                    var currentSet = new HashSet<InputLanguage>(
                        InputLanguage.InstalledInputLanguages
                            .Cast<InputLanguage>().ToList());
                    if (
                        !previousSet.SetEquals(
                            currentSet))
                    {
                        var difference = currentSet.Where(x => !previousList.Any(y => x.LayoutName.Equals(y.LayoutName))).ToList();

                        Console.WriteLine("New keyboard language appeared:");
                        foreach (var inputLanguage in difference)
                        {
                            Console.WriteLine(inputLanguage.LayoutName);
                            
                            var languageWasDeleted = KeyboardLayoutCleaner.PurgeKeyboardLayout(inputLanguage);
                            if (!languageWasDeleted) continue;

                            currentSet.Remove(inputLanguage);
                            Console.WriteLine($"{inputLanguage.LayoutName} was purged.");
                        }
                    }
                    previousList = currentSet.ToList();
                    Thread.Sleep(100);
                }
                catch (ThreadAbortException e)
                {
                    if ((bool)e.ExceptionState)
                    {
                        return;
                    }
                }
            }
        }
    }
}