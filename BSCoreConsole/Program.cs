using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSCore;
using BSCore.Shared;
namespace BSCoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BSCore.IO.IOManager scanner = new BSCore.IO.IOManager();
            Console.WriteLine(InspireCLILocater.InspireLCIPath());
            while (Console.ReadLine().ToLower() != "exit");
        }
    }
}
