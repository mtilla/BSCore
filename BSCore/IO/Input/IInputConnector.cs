using System;
using System.ComponentModel;

namespace BSCore.IO.Input
{
    #region Input
    /// <summary>
    /// Manager for monitoring incoming events of interest.
    /// Implementers are responsible for deleting/moving/copying files in case of DirScans/FileSystemWatchers
    /// And provide Data if available
    /// </summary>
    public interface IInputConnector
    {
        /// <summary>
        /// Start this Handler to handle/scan input events
        /// </summary>
        void Start();
        /// <summary>
        /// Stop this Handler and Dispose
        /// </summary>
        void Stop();
        /// <summary>
        /// Subscribe to this handler to receive events
        /// </summary>
        /// <param name="inputEventHandler">eventhandler</param>
        void RegisterEventHandler(IInputEventHandler inputEventHandler);
    }

    public interface IInputEventHandler
    {
        void HandleEvent(InputEvent inputEvent, BackgroundWorker worker = null);
    }

    public abstract class Worker
    {
        public abstract void DoWork();
    }

    /// <summary>
    /// InputEvent class containing information and arguments
    /// </summary>
    public class InputEvent : BaseEvent
    {
        /// <summary>
        /// Arguments for this Event
        /// </summary>
        public InputEventArgs Args { get; set; }
        public InputEvent(InputEventArgs args)
        {
            Args = args;
        }
    }

    public class IOEventArgs
    {
        /// <summary>
        /// Type of event
        /// </summary>
        public IOEventType IOEventType { get; set; }
        /// <summary>
        /// Path/URI
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Data if existing
        /// </summary>
        public byte[] Data { get; set; }
    }
    /// <summary>
    /// Inputevent arguments 
    /// </summary>
    public class InputEventArgs : IOEventArgs
    {
        
    }
    #endregion

    /// <summary>
    /// InputEventType 
    /// </summary>
    public enum IOEventType
    {
        /// <summary>
        /// A input/output file has been created
        /// </summary>
        Created = 1,
        /// <summary>
        /// A input/output file has been processed (not created yet)
        /// </summary>
        //Processed = 2,
        /// <summary>
        /// Input/Output canceld
        /// </summary>
        //Canceled = 3,
        /// <summary>
        /// Input/Output Aborted
        /// </summary>
        //Aborted = 4,
        /// <summary>
        /// Input arrived 
        /// </summary>
        Arrived = 5,
        /// <summary>
        /// Processing is complete, all input are finalized and output created
        /// </summary>
        Completed
    }

    #region InputHandlerFactory

    
    /// <summary>
    /// InputConnector Factory
    /// 
    /// </summary>
    public class InputHandlerFactory
    {
        /// <summary>
        /// Creates a new instance of the specified connector type
        /// </summary>
        /// <param name="connectorType"></param>
        /// <returns></returns>
        static IInputConnector Create(InputConnectorType connectorType)
        {
            switch (connectorType)
            {
                case InputConnectorType.DirectoryScanner:
                    return new DirectoryScanner();
                default:
                    //No type, throw // Break execution
                    throw new Exception();
            }
        }
    }

    public enum InputConnectorType
    {
        DirectoryScanner = 1,
    }
    #endregion

}
