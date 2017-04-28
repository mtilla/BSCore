using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSCore.Log;

namespace BSCore.Log

{
    public class FileLogOutputSource : ILogOutputSource
    {
        private string _logFilePath;

        public FileLogOutputSource(string filepath)
        {
            _logFilePath = filepath;
        }
        
        public void Write(Loggable loggable)
        {
            File.AppendText(_logFilePath).WriteLine(loggable.ToLogString());
        }

        
    }
}
