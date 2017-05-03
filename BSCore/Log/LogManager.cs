using System;

namespace BSCore.Log
{
    
    public class LogManager
    {
        /// <summary>
        /// The final source of the output
        /// </summary>
        private readonly ILogOutputSource _logOutputSource;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logOutputSource"></param>
        public LogManager(ILogOutputSource logOutputSource)
        {
            //Check null
            _logOutputSource = logOutputSource ?? throw new ArgumentNullException(nameof(logOutputSource));
        }

        public void ToLog(Loggable logEntry)
        {
            _logOutputSource.Write(logEntry);
        }

        public string GetLogSourcePath()
        {
            return ((FileLogOutputSource) _logOutputSource).GetLogPath();
        }
    }
}
