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
        private IInputManager InputManager;
        private IOutputManager OutputManager;
        public IOManager()
        {
            InputManager = new DirectoryScanner("C:\\Scanner");
            FileInputHandler inputHandler = new FileInputHandler();
            InputManager.RegisterEventHandler(inputHandler);
        }

        public IOManager(IInputManager inputManager, IOutputManager outputManager)
        {
            InputManager = inputManager;
            OutputManager = outputManager;
        }
    }
}
