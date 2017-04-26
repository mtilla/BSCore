using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSCore.IO.Input;
namespace BSCore.IO
{

    public class DirectoryScanner : IInputConnector
    {
        private FileSystemWatcher Watcher;
        public string Path { get; set; }
        public string Filter { get; set; } = "*.*";
        private IInputEventHandler EventHandler;
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
            Watcher = new FileSystemWatcher(Path);
            //Events
            Watcher.Created += WatcherOnCreated;

            //Filters
            
            Watcher.Filter = Filter;
            //Inits
        }

        /// <summary>
        /// Start listening to watcher events
        /// </summary>
        public void Start()
        {
            // Check path exists and handle error
            if (Watcher == null) { InitWatcher(); }
            Watcher.EnableRaisingEvents = true;
        }
        
        /// <summary>
        /// Stop listening to events and Dispose the watcher.
        /// </summary>
        public void Stop()
        {
            Watcher.EnableRaisingEvents = false;
            Watcher.Dispose();
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
                    EventHandler.HandleEvent(new InputEvent(CreateEventArgs(e)));
                    break;
            }
        }

        /// <summary>
        /// Register an eventhandler to handle events fired from this inputmanager
        /// </summary>
        /// <param name="inputEventHandler">The eventhandler to notify</param>
        public void RegisterEventHandler(IInputEventHandler inputEventHandler)
        {
            EventHandler = inputEventHandler;
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
    }
}
