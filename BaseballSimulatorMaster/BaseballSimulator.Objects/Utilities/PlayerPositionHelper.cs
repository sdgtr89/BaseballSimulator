using System.Collections.Generic;

namespace BaseballSimulator.Objects.Utilities
{
    public static class PlayerPositionHelper
    {
        private static readonly Dictionary<PlayerPosition, string> PlayerPositionDictionary;

        static PlayerPositionHelper()
        {
            PlayerPositionDictionary = new Dictionary<PlayerPosition, string>
            {
                {PlayerPosition.Catcher, "Catcher" },
                {PlayerPosition.FirstBase, "First Base" },
                {PlayerPosition.SecondBase, "Second base" },
                {PlayerPosition.ShortStop, "Shortstop" },
                {PlayerPosition.ThirdBase, "Third Base" },
                {PlayerPosition.RightField, "Right Field" },
                {PlayerPosition.CenterField, "Center Field" },
                {PlayerPosition.LeftField, "Left Field" },
                {PlayerPosition.DesignatedHitter, "Designated Hitter" },
                {PlayerPosition.Outfield, "Outfield" },
                {PlayerPosition.Infield, "Infield" },
                {PlayerPosition.Utility, "Utility" },
                {PlayerPosition.StartingPitcher, "Starting Pitcher" },
                {PlayerPosition.ReliefPitcher, "Relief Pitcher" },
                {PlayerPosition.Closer, "Close" }
            };
        }

        public static string GetPlayerPositionString(PlayerPosition playerPosition)
        {
            return PlayerPositionDictionary[playerPosition];
        }
    }
}