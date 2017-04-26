using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCore.Log
{
    /// <summary>
    /// LogEntry class 
    /// </summary>
    public class LogEvent
    {
        public string Message { get; set; }
        public Level LogLevel { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }


    /// <summary>
    /// LogLevel definition
    /// 
    /// </summary>
    public enum Level
    {
        /// <summary>
        /// Warning - Processing will continue
        /// </summary>
        Warning,
        /// <summary>
        /// Error - Processing aborted
        /// </summary>
        Error,
        /// <summary>
        /// Development - Processing continued
        /// </summary>
        Development
    }
}
