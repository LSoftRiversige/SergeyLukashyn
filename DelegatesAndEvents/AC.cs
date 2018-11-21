using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public class AC
    {
        public AC(States state)
        {
            State = state;
        }

        public States State { get; set; }

        public void SwitchOn()
        {
            if (State != States.On)
            {
                Console.WriteLine("Air conditioner switched on");
                State = States.On;
            }
        }

        public void SwitchOff()
        {

            if (State != States.Off)
            {
                Console.WriteLine("Air conditioner switched off");
                State = States.Off;
            }
        }
                
    }
}
