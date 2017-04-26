using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCore.IO.Input
{
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
        void HandleEvent(InputEvent inputEvent);
        
    }

    /// <summary>
    /// InputEvent class containing information and arguments
    /// </summary>
    public class InputEvent : BaseEntity
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

    /// <summary>
    /// Inputevent arguments 
    /// </summary>
    public class InputEventArgs
    {
        public InputEventType EventType { get; set; }
        public string Path { get; set; }
        public byte[] Data { get; set; }
    }

    /// <summary>
    /// InputEventType 
    /// </summary>
    public enum InputEventType
    {
        Created = 1,
    }
}
