using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SXPS_XAML.Devices
{
    class Printer
    {
        private static List<string> paths = new List<string>();

        public static void Print() 
        {
            List<string> paths = new List<string>();

            foreach(string p in Printer.paths)
            {
                paths.Add((string)p.Clone());
            }

            Printer.paths.Clear();

            foreach (string p in paths)
            {
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    Verb = "print",
                    FileName = p,
                    WindowStyle = ProcessWindowStyle.Hidden,

                };
                process.Start();
            }

            paths.Clear();
        }

        public static void AddPath(string path)
        {
            paths.Add(path);
        }
    }
}
