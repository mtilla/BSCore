using System;

namespace BSCore.IO.Input
{
    class FileInputHandler : IInputEventHandler
    {
        public void HandleEvent(InputEvent inputEvent)
        {
            // Do stuff
            // ANd forward to next
            Console.WriteLine(inputEvent.Timestamp + ": " + inputEvent.Id);
            Console.WriteLine(inputEvent.Args.EventType + ": " + inputEvent.Args.Path);

        }
    }
}
