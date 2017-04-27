using BSCore.IO.Input;
using BSCore.IO.Output;

namespace BSCore.IO
{
    public class IOManager
    {
        private IInputConnector _inputConnector;
        private IOutputConnector _outputConnector;
        public IOManager()
        {
            _inputConnector = new DirectoryScanner("C:\\Scanner");
            FileInputHandler inputHandler = new FileInputHandler();
            _inputConnector.RegisterEventHandler(inputHandler);
            _inputConnector.Start();
        }

        public IOManager(IInputConnector inConnector, IOutputConnector outConnector)
        {
            _inputConnector = inConnector;
            _outputConnector = outConnector;
        }
    }
}
