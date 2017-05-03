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
        private FileStream _fileStream;
        public FileLogOutputSource(string filepath)
        {
            _logFilePath = filepath;
            _fileStream = File.Open(_logFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
        }

        public void Write(Loggable loggable)
        {
            
            
                byte[] textBytes = Encoding.ASCII.GetBytes(loggable.ToLogString() + Environment.NewLine);
                _fileStream.Write(textBytes, 0, textBytes.Length);
            _fileStream.Flush();
                //_fileStream.Close();
           
        }

        public string GetLogPath()
        {
            return _logFilePath;
        }

    }
}
