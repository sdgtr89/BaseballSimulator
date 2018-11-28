
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
                { new AtBat("Triple",3, 0.004)},
                { new AtBat("Home-run",4, 0.033)},
                { new AtBat("Double",2, 0.045)},
                { new AtBat("Reach On Error",1, 0.06)},
                { new AtBat("Hit By Pitch",1, 0.0095)},
                { new AtBat("Walk",1, 0.085)},
                { new AtBat("Fly Out",0, 0.09)},
                { new AtBat("Single",1, 0.145)},
                { new AtBat("Line Out",0, 0.13)},
                { new AtBat("Ground Out",0, 0.1825)},
                { new AtBat("Strikeout",0, 0.216)}
            };
        }
    }
}
