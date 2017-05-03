using System;
using BSCore.IO.Input;
using BSCore.IO.Output;

namespace BSCore.IO
{
    public class IOManager : IDisposable
    {
        private IInputConnector _inputConnector;
        private IOutputConnector _outputConnector;
        private IInputEventHandler _inputEventHandler;
        private IOutputEventHandler _outputEventHandler;
        public IOManager()
        {
            _inputConnector = new DirectoryScanner(@"C:\Scanner");
            _inputEventHandler = new InspireCLIHelper(new InspireWorkflowConfiguration(@"C:\Bestrong\Automation\ESV\ESV.wfd"));
            _inputConnector.RegisterEventHandler(_inputEventHandler);
            _inputConnector.Start(); 
        }

        public IOManager(IInputConnector inConnector, IOutputConnector outConnector)
        {
            _inputConnector = inConnector;
            _outputConnector = outConnector;
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~IOManager()
        {
            ReleaseUnmanagedResources();
        }
    }
}
