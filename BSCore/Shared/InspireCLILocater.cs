using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCore.Shared
{
    public class InspireCLILocater
    {
        private const string InspireCLIFilename = "InspireCLI.exe";
        public static string InspireLCIPath()
        {
            //TODO: Implement real Locator for InspireCLI

            String CLI = @"C:\Program Files\GMC\Inspire Designer\InspireCLI.exe";
            return CLI;
        }
    }
}
