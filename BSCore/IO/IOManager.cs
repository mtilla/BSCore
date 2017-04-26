using BSCore.IO.Input;
using BSCore.IO.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCore.IO
{
    public class IOManager
    {
        private IInputConnector InputConnector;
        private IOutputConnector OutputConnector;
        public IOManager()
        {
            InputConnector = new DirectoryScanner("C:\\Scanner");
            FileInputHandler inputHandler = new FileInputHandler();
            InputConnector.RegisterEventHandler(inputHandler);
            InputConnector.Start();
        }

        public IOManager(IInputConnector inConnector, IOutputConnector outConnector)
        {
            InputConnector = inConnector;
            OutputConnector = outConnector;
        }
    }
}
