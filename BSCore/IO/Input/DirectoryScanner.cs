using System;
using System.ComponentModel;
using System.IO;

namespace BSCore.IO.Input
{

    public class DirectoryScanner : IInputConnector, IDisposable
    {
        private FileSystemWatcher _watcher;
        public string Path { get; set; }
        public string Filter { get; set; } = "*.*";
        public Boolean BackupOriginal = false;
        private IInputEventHandler _eventHandler;
        /// <summary>
        /// Empty Constructor - Set params manually
        /// </summary>
        public DirectoryScanner() { }
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

            //Settings

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
                    // Logga file received
                    InputEvent inEvent = new InputEvent(CreateEventArgs(e, IOEventType.Created));
                    BackgroundWorker worker = new BackgroundWorker();
                    _eventHandler.HandleEvent(inEvent, worker);

                    //Logga dirscan stage complete

                    //Remove file
                    // Worker
                    worker.RunWorkerCompleted += (o, args) =>
                    {
                        if (BackupOriginal)
                        {
                            FileOperations.BackupFile(inEvent.Args.Path);
                        }
                        else
                        {
                            File.Delete(inEvent.Args.Path);
                        }
                    };
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
        /// <param name="eventType"></param>
        /// <returns></returns>
        private InputEventArgs CreateEventArgs(FileSystemEventArgs args, IOEventType eventType)
        {
            InputEventArgs eventArgs = new InputEventArgs
            {
                IOEventType = eventType,
                Path = args.FullPath
            };
            // Set dynamic later
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
                    Stop();
                }

                Stop();
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

        public delegate Boolean CreateOutput(InputEvent inputEvent);
    }
}
