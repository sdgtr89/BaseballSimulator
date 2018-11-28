using System;
using System.Collections.Generic;
using System.Text;

namespace BaseballSimulator.Objects.Objects
{
    public class GameStats
    {
        public int HomeHits { get; set; }
        public int AwayHits { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int HomeErrors { get; set; }
        public int AwayErrors { get; set; }

        public override string ToString()
        {
            return $"Away Team Stats: \nRuns: {AwayScore} \nHits: {AwayHits} \nErrors: {AwayErrors}\n" +
                $"\nHome Team Stats: \nRuns: {HomeScore} \nHits: {HomeHits} \nErrors: {HomeErrors}";
        }
    }
}
