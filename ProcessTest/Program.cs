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

            Console.WriteLine("Testd");

            var process = new Process();
            var startInfo = new ProcessStartInfo();
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            process.StartInfo = startInfo;
            process.Start();

            process.StandardInput.WriteLine("ping www.google.com");
            process.StandardInput.WriteLine("ping www.google.com");
            process.StandardInput.WriteLine("ping www.google.com");
            Console.WriteLine("Test");
            process.CloseMainWindow();

            //process.WaitForInputIdle();

            

        }
    }
}
