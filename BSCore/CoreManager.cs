using BSCore.Error;
using BSCore.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCore
{
    public class CoreManager
    {
        public  ErrorManager ErrorManager { get; set; }
        public  LogManager LogManager { get; set; }
    }
}
