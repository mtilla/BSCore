using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCore.Shared
{
    /// <summary>
    /// Automatic search for installed GMC Inspire Command Line Interface
    /// </summary>
    public class InspireCLILocater
    {
        private const string InspireCLIFilename = "InspireCLI.exe";
        public static string InspireLCIPath()
        {
            // TODO: Implement real Locator for InspireCLI
            String CLI = @"C:\Program Files\GMC\Inspire Designer\InspireCLI.exe";
            // TODO: Search in Program Files, Program Files x86

            // TODO: return path with inspirecli.exe
            return CLI;
        }
    }
}
