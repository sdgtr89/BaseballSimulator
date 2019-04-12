
using System;
using System.Collections.Generic;
using System.Text;
using BaseballSimulator.Objects.Objects;

namespace BaseballSimulator.Objects.Utilities
{
    public static class BaseballEvents
    {
        public static List<AtBat> Events { get; }

        static BaseballEvents()
        {
            Events = new List<AtBat>
            {
                { new AtBat("Triple",3, 0.004,true)},
                { new AtBat("Home-run",4, 0.033,true)},
                { new AtBat("Double",2, 0.045, true)},
                { new AtBat("Reach On Error",1, 0.06, true)},
                { new AtBat("Hit By Pitch",1, 0.0095, false)},
                { new AtBat("Walk",1, 0.085,false)},
                { new AtBat("Fly Out",0, 0.09,true)},
                { new AtBat("Single",1, 0.145,true)},
                { new AtBat("Line Out",0, 0.13,true)},
                { new AtBat("Ground Out",0, 0.1825,true)},
                { new AtBat("Strikeout",0, 0.216,false)}
            };
        }
    }
}
