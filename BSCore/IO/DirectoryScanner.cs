using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSCore.IO.Input;
namespace BSCore.IO
{

    public class DirectoryScanner : IInputConnector, IDisposable
    {
        private FileSystemWatcher _watcher;
        public string Path { get; set; }
        public string Filter { get; set; } = "*.*";
        private IInputEventHandler _eventHandler;
        public DirectoryScanner(String directory)
        {
            Path = directory;
            InitWatcher();
        }

        /// <summary>
        /// Initialize watcher settings.
        /// </summary>
        private void InitWatcher()
        {
            //Create new
            _watcher = new FileSystemWatcher(Path);
            //Events
            _watcher.Created += WatcherOnCreated;

            //Filters
            
            _watcher.Filter = Filter;
            //Inits
        }

        /// <summary>
        /// Start listening to watcher events
        /// </summary>
        public void Start()
        {
            // Check path exists and handle error
            if (_watcher == null) { InitWatcher(); }
            _watcher.EnableRaisingEvents = true;
        }
        
        /// <summary>
        /// Stop listening to events and Dispose the watcher.
        /// </summary>
        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
            _watcher.Dispose();
        }

        /// <summary>
        /// Fired when a files is created in the wathced directory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WatcherOnCreated(object sender, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    // new File
                    //Send event to eventhandler
                    _eventHandler.HandleEvent(new InputEvent(CreateEventArgs(e)));
                    break;
            }
        }

        /// <summary>
        /// Register an eventhandler to handle events fired from this inputmanager
        /// </summary>
        /// <param name="inputEventHandler">The eventhandler to notify</param>
        public void RegisterEventHandler(IInputEventHandler inputEventHandler)
        {
            _eventHandler = inputEventHandler;
        }

        /// <summary>
        /// Convert System eventargs to InputEventArgs
        /// </summary>
        /// <param name="args">Original event args</param>
        /// <returns></returns>
        private InputEventArgs CreateEventArgs(FileSystemEventArgs args)
        {
            InputEventArgs eventArgs = new InputEventArgs();
            eventArgs.EventType = InputEventType.Created; // Set dynamic later
            eventArgs.Path = args.FullPath;
            return eventArgs;
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DirectoryScanner() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
