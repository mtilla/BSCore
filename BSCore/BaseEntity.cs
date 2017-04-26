using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCore
{
    /// <summary>
    /// Base class for adding ID and Timestamp to objects
    /// </summary>
    public class BaseEntity
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
