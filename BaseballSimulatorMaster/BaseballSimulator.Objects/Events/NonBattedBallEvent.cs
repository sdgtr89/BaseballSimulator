using System;
using System.Collections.Generic;
using System.Text;

namespace BaseballSimulator.Objects.Events
{
    public class NonBattedBallEvent : EventArgs
    {
        public string EventName { get; private set; }

        public NonBattedBallEvent(string eventName)
        {
            EventName = eventName;
        }
    }
}
