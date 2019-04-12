using System;
using System.Collections.Generic;
using System.Text;

namespace BaseballSimulator.Objects.Events
{
    public class BattedBallEvent : EventArgs
    {
        public string EventName { get; private set; }

        public BattedBallEvent(string eventName)
        {
            EventName = eventName;
        }
    }
}
