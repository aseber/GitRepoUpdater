using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace GitMultiUpdate
{
    class CommandExecutor
    {
        private Queue<Process> processes = new Queue<Process>();

        public CommandExecutor(int maxConcurrentProcesses)
        {
            for (var i = 0; i < maxConcurrentProcesses; i++)
            {
                processes.Enqueue(CreateProcess());
            }
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

        public async Task ProcessCommand(string command)
        {
            var process = getNextProcess();
            await ProcessCommand(process, command);
        }

        private Process getNextProcess()
        {
            var process = processes.Dequeue();
            processes.Enqueue(process);

            return process;
        }

        private async Task ProcessCommand(Process process, string command)
        {
            await process.StandardInput.WriteLineAsync(command);
        }

        private Process CreateProcess()
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardInput = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.Start();

            return process;
        }
    }
}
