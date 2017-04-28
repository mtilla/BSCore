using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSCore.Log;

namespace BSCore.Log
{
    /// <summary>
    /// Not actually an outputstream, but a interface for receiving and handling log/error events and writing to the final source
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILogOutputSource
    {
        /// <summary>
        /// Writes the loggable content to the source
        /// </summary>
        /// <param name="loggable">Loggable object containing data to write</param>
        void Write(Loggable loggable);
    }
}
