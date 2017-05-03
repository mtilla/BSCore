using System;
using BSCore.IO.Input;

namespace BSCore.IO.Output
{
    #region OutputConnector
    public interface IOutputConnector
    {
        void CreateOutput(OutputEvent outputEvent);
    }

    /// <summary>
    /// Extensions for OutputConnector
    /// </summary>
    public static class OutputConnectorExtensions
    {
        public static void Dostuff(this IOutputConnector outputConnector, Func<string, string> del)
        {
            
        }
    }

    public interface IOutputEventHandler { }
    public class OutputEvent : BaseEvent { }
    public class OutputEventArgs : IOEventArgs { } // TODO: Create own CLass later
    #endregion

    #region OutputConnectorFactory

    public class OutputConnectorFactory
    {
        public static IOutputConnector Create(OutputConnectorType connectorType)
        {
            switch (connectorType)
            {
                    case OutputConnectorType.FileOutput:
                        return new FileOutputConnector();
                default:
                    //Break execution,
                    throw new Exception();
            }
        }
    }

    public enum OutputConnectorType
    {
        FileOutput = 1,
        ByteOutput,

    }

    #endregion
}