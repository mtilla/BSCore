using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCore
{
    public abstract class BaseEvent
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Timestamp of the event
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.Now;

    }
}
