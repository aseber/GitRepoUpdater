using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System;
using System.IO;

namespace GitMultiUpdate
{
    class CommandExecutor
    {
        private Queue<Process> processes = new Queue<Process>();
        private IEnumerable<string> outputStrings = new List<string>();

        public CommandExecutor(int maxConcurrentProcesses)
        {
            var mutableOutputStrings = new List<string>();

            for (var i = 0; i < maxConcurrentProcesses; i++)
            {
                var outputString = "";
                processes.Enqueue(CreateProcess(outputString));
                mutableOutputStrings.Add(outputString);
            }

            outputStrings = mutableOutputStrings;
        }

        ~CommandExecutor()
        {
            foreach (var process in processes)
            {
                try
                {
                    process.CloseMainWindow();
                } catch (InvalidOperationException) { }
            }
        }

        public void ProcessCommand(string directory, params string[] commands)
        {
            var process = getNextProcess();

            lock (process)
            {
                string output;
                string totalOutput = "";
                totalOutput += $"PID: {process.Id}:\n";

                ProcessCommand(process, $"cd {directory}");
                totalOutput += $"\tDirectory:\n\t\t{directory}\n";
                totalOutput += "\tCommand:\n";

                foreach (var command in commands)
                {
                    totalOutput += $"\t\t{command}\n";
                    ProcessCommand(process, command);
                }

                totalOutput += "\tOutput:\n";

                while ((output = process.StandardOutput.ReadLine()).Length > 0)
                {
                    totalOutput += $"\t\t{output}\n";
                }

                //Console.WriteLine(totalOutput);
            }
        }

        private Process getNextProcess()
        {
            var process = processes.Dequeue();
            processes.Enqueue(process);

            return process;
        }

        private void ProcessCommand(Process process, string command)
        {
            process.StandardInput.WriteLine(command);
            process.StandardInput.Flush();
        }

        private Process CreateProcess(string outputString)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;
            return Process.Start(startInfo);
        }
    }
}