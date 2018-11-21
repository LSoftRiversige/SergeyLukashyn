using System;
using System.Collections.Generic;
using System.Text;

namespace DelegatesAndEvents
{
    public enum States { Unknown, Off, On};
    public class Heater
    {
        public Heater(States state)
        {
            State = state;
        }

        public States State { get; set; }

        public void SwitchOn()
        {
            if (State != States.On)
            {
                Console.WriteLine("Heater switched on");
                State = States.On;
            }
        }

        public void SwitchOff()
        {
            
            if (State != States.Off)
            {
                Console.WriteLine("Heater switched off");
                State = States.Off;
            }
        }
    }
}
