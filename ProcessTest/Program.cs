using System;
using System.Diagnostics;

namespace ProcessTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Test start");

            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.CreateNoWindow = true;
            var process = Process.Start(startInfo);

            Console.WriteLine("Started");

            process.StandardInput.WriteLine(@"cd S:\GitHub\PathFindingVisualization");
            process.StandardInput.WriteLine("\"C:\\Program Files\\Git\\bin\\git.exe\" pull");
            process.StandardInput.WriteLine("exit");
            process.StandardInput.Flush();
            Console.WriteLine($"\"{process.StandardOutput.ReadToEnd()}\" tatattt");
            Console.WriteLine("Test end");
            //process.CloseMainWindow();

            Console.ReadLine();

            //process.WaitForInputIdle();

            

        }
    }
}
