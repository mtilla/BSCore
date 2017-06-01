using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using BSCore.Log;
using BSCore.Shared;

namespace BSCore.IO.Input
{
    #region InspireCLIHelper
    class InspireCLIHelper : IInputEventHandler
    {
        private InspireWorkflowConfiguration WorkflowConfiguration;
        private LogManager LogManager = new LogManager(new FileLogOutputSource(Environment.CurrentDirectory + "inspirecli.log"));

        public InspireCLIHelper(InspireWorkflowConfiguration config)
        {
            WorkflowConfiguration = config;
        }
        public void HandleEvent(InputEvent inputEvent, BackgroundWorker worker)
        {
            // Do stuff
            // ANd forward to next
            //Console.WriteLine(inputEvent.Timestamp + ": " + inputEvent.Id);
            //Console.WriteLine(inputEvent.Args.IOEventType + ": " + inputEvent.Args.Path);
            //
            //Create a background worker thread that ReportsProgress &
            //SupportsCancellation
            // Hook up the appropriate events.

            worker.DoWork += ExecuteInspireCLI;
            //backgroundWorker1.ProgressChanged += ProgressChanged;
            worker.RunWorkerCompleted += (sender, args) =>
            {
                worker.Dispose();
            };


            worker.RunWorkerAsync(inputEvent);
            //backgroundWorker1.WorkerReportsProgress = true;
            //backgroundWorker1.WorkerSupportsCancellation = true;
            
            
            //proc.CloseMainWindow();
            //proc.Close();
            


        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InspireCLIComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();

        }

        private void ExecuteInspireCLI(object sender, DoWorkEventArgs e)
        {
            InputEvent inputEvent = (InputEvent) e.Argument;
            string output = GenerateFilename(inputEvent);//OutputPath + inputEvent.Id + "." + InspireEngine.ToString().ToLower();
            
            String CLI = InspireCLILocater.InspireLCIPath();
            string inputFile = inputEvent.Args.Path;
            //string cParams = WFDPath + " -e " + InspireEngine + " -difXMLDataInput1 " + inputFile + " -f " + output;//+ " -o Output1"; // TODO: Fix building params
            string param = InspireCLIParamBuilder(WorkflowConfiguration, inputFile);
            //string cParams = wfd + " -e " + InspireEngine + inputFile + output;//+ " -o Output1";
            if (FileOperations.FileIsReady(inputFile))
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = CLI,
                        Arguments = param,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true,

                    }
                };
                proc.Start();
                Console.WriteLine(LogManager.GetLogSourcePath());
                while (!proc.StandardOutput.EndOfStream)
                {
                    string line = proc.StandardOutput.ReadLine();
                    // do something with line
                    Console.WriteLine(line);
                    if (ShouldLog(line))
                    {
                        LogManager.ToLog(new LogEntry()
                        {
                            Message = line,
                            ErrorCode = 0001
                        });
                    }
                }

                Console.WriteLine(proc.ExitCode); // Create enum for this
                proc.Close();
            }
        }

        private String InspireCLIParamBuilder(InspireWorkflowConfiguration config, string inputFile)
        {
            return 
                config.WFDPath + " -e " + 
                config.InspireEngine + " " + 
                config.InputModule + " " + 
                inputFile + " -f " + 
                config.OutputPath +
                (config.OutputPath ?? " -o " + config.OutputModule)
                ;//+ " -o Output1"; // TODO: Fix building params
        }
        private bool ShouldLog(string line)
        {
            return true;
        }

        private string GenerateFilename(InputEvent inputEvent)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(String.IsNullOrEmpty(WorkflowConfiguration.OutputPath) ? Path.GetDirectoryName(inputEvent.Args.Path) + @"\Out\" : WorkflowConfiguration.OutputPath);
            //Filename pattern here
            sb.Append(Path.GetFileName(inputEvent.Args.Path) + inputEvent.Id.ToString().Substring(0,8));
            sb.Append("." + WorkflowConfiguration.InspireEngine.ToString().ToLower());

            return sb.ToString();
        }
    }
    #endregion

    #region InspireCLI Helper classes
    public enum InspireEngine
    {
        PDF,
        TNO
    }

    public class InspireWorkflowConfiguration
    {
        public string OutputPath { get; set; }
        public string FilenamePattern { get; set; }
        public String WFDPath { get; set; }
        public InspireEngine InspireEngine { get; set; } = InspireEngine.TNO;
        public string InputModule { get; set; } = "-difXMLDataInput1"; // TODO: Fix this
        public string OutputModule { get; set; }


        /// <summary>
        /// Initiate a workflowconfiguration with most basic settings
        /// </summary>
        /// <param name="wfdPath"></param>
        public InspireWorkflowConfiguration(String wfdPath)
        {
            WFDPath = wfdPath;
        }
    }
    #endregion

}
