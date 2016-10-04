using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace GitMultiUpdate
{
    class CommandExecutor
    {
        private IList<StreamWriter> processInputStreams;
        private Queue<string> commands = new Queue<string>();
        private Thread commandExecutorThread;
        private bool processCommands = true;

        public CommandExecutor(int maxConcurrentProcesses)
        {
            for (var i = 0; i < maxConcurrentProcesses; i++)
            {
                processes.Add(CreateProcess());
            }

            commandExecutorThread = new Thread(GetCommandExecutorDelegate(maxConcurrentProcesses));
            commandExecutorThread.Start();
        }

        ~CommandExecutor()
        {
            processCommands = false;
            commandExecutorThread.Abort();
        }

        public void AddCommand(string command)
        {
            commands.Enqueue(command);
        }

        private Process getAvailableProcess()
        {
            foreach (var process in processes)
            {
                process
            }
        }

        private ThreadStart GetCommandExecutorDelegate(int maxConcurrentProcesses)
        {
            return async delegate
            {
                var semaphore = new SemaphoreSlim(maxConcurrentProcesses);

                while (processCommands)
                {
                    try
                    {
                        while (commands.Any())
                        {
                            await semaphore.WaitAsync();

                            try
                            {
                                await ProcessCommand(null, commands.Dequeue());
                            }
                            finally
                            {
                                semaphore.Release();
                            }
                        }
                    }
                    catch (ThreadAbortException)
                    {
                        break;
                    }
                }
            };
        }

        private async Task ProcessCommand(StreamWriter processWriter, string command)
        {
            await processWriter.WriteLineAsync(command);
            //await process.WaitForExitAsync();
        }

        private Process CreateProcess()
        {
            var process = new Process();
            var startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            process.Start();

            return process;
        }
        
        /*
         var semaphore = new SemaphoreSlim(concurrentDownloads);
            var failedDownloads = new List<string>();

            var tasks = urlTuples.Select(async urlTuple =>
            {
                await semaphore.WaitAsync();

                try
                {
                    var result = await DownloadVideoAsync(urlTuple);

                    if (result != string.Empty)
                    {
                        failedDownloads.Add(result);
                    }
                }
                finally
                {
                    semaphore.Release();
                }
            }).ToArray();

            Task.WaitAll(tasks);
         
         */


    }
}
