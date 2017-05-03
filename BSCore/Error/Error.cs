using System;

namespace BSCore.Error
{
    /// <summary>
    /// Error class definition 
    /// </summary>
    public class Error
    {
        public String Message { get; set; }
        public Type Type { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;

        /// <summary>
        /// Instantiate a new default Error with timestamp
        /// </summary>
        public Error()
        {
            //Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Instantiate a new Error object
        /// </summary>
        /// <param name="type">Type of error</param>
        /// <param name="timestamp">Time of error</param>
        /// <param name="message">Error message</param>
        public Error(Type type, DateTime timestamp, String message)
        {
            Timestamp = timestamp;
            Type = type;
            Message = message;
        }
    }

    /// <summary>
    /// ErrorType definition
    /// </summary>
    public enum Type
    {
        /// <summary>
        /// Warning - Processing will continued
        /// </summary>
        Warning,
        /// <summary>
        /// Error - Processing aborted
        /// </summary>
        Error,
        /// <summary>
        /// Severe - Severe error, processing aborted
        /// </summary>
        Severe
    }

    //TODO: Implement Error messages
    //TODO: Implement Translation Library
}
