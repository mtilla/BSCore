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
    public class LogEntry : Loggable
    {
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
