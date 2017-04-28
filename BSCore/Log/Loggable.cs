using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCore.Log
{
    /// <summary>
    /// Base class for loggable objects
    /// </summary>
    public abstract class Loggable
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; }
        public Level LogLevel { get; set; }
        public int ErrorCode { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        private const string StartBracket = "[";
        private const string EndBracket = "]";
        public override string ToString()
        {
            return Id.ToString();
        }

        /// <summary>
        /// Creates a formatted string that is ready to be sent to output.
        /// </summary>
        /// <returns></returns>
        public string ToLogString()
        {
            // [Timestamp] [Level] [ErrorCode] [Message]
            StringBuilder sb = new StringBuilder();
            sb.Append(BracketString(Timestamp.ToString()));
            sb.Append(BracketString(LogLevel.ToString()));
            sb.Append(BracketString(ErrorCode.ToString()));
            sb.Append(BracketString(Message));
            return sb.ToString();

        }

        /// <summary>
        /// Brackets a string
        /// </summary>
        /// <param name="stringTobracket"></param>
        /// <param name="whiteSpaceAfter"></param>
        /// <returns>Bracketed string</returns>
        private string BracketString(string stringTobracket, Boolean whiteSpaceAfter = true)
        {
            // 

            StringBuilder sb = new StringBuilder();
            sb.Append(StartBracket);
            sb.Append(stringTobracket);
            sb.Append(EndBracket);
            if (whiteSpaceAfter){ sb.Append(" "); } // Add space as default
            return sb.ToString();
        }


    }
}
