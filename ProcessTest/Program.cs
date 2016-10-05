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

            var outputString = "";

            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.CreateNoWindow = true;
            var process = Process.Start(startInfo);
            process.EnableRaisingEvents = true;
            process.BeginOutputReadLine();
            process.OutputDataReceived += GenerateOutputEventHandler(outputString);

            Console.WriteLine("Started");

            process.StandardInput.WriteLine(@"cd S:\GitHub\PathFindingVisualization");
            process.StandardInput.WriteLine("\"C:\\Program Files\\Git\\bin\\git.exe\" pull");
            process.StandardInput.WriteLine("\"C:\\Program Files\\Git\\bin\\git.exe\" pull");
            process.StandardInput.WriteLine("\"C:\\Program Files\\Git\\bin\\git.exe\" pull");
            process.StandardInput.WriteLine("\"C:\\Program Files\\Git\\bin\\git.exe\" pull");
            process.StandardInput.WriteLine("exit");
            process.StandardInput.Flush();
            Console.WriteLine("Test end");

            process.WaitForExit(1000);

            Console.WriteLine(outputString.Length);

            Console.ReadLine();
        }

        private static DataReceivedEventHandler GenerateOutputEventHandler(string outputString)
        {
            return (sender, e) =>
            {
                outputString += e.Data;
            };
        }
    }
}
