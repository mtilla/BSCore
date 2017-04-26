using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSCore.IO.Input
{
    class FileInputHandler : IInputEventHandler
    {
        public void HandleEvent(InputEvent inputEvent)
        {
            // Do stuff
            // ANd forward to next
            Console.WriteLine(inputEvent.Timestamp + ": " + inputEvent.ID);
            Console.WriteLine(inputEvent.Args.EventType + ": " + inputEvent.Args.Path);

        }
    }
}
