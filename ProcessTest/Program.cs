using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();

            for (var i = 0; i < 1000; i++)
            {
                Console.WriteLine(process.StartTime);
            }

            process.StandardInput.WriteLine("ping www.google.com");
            process.WaitForInputIdle();

            while (true)
            {
                Console.WriteLine("Ta");
            }
        }
    }
}
