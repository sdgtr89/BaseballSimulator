using System;
using System.Collections.Generic;
using System.Text;

namespace BaseballSimulator.Objects.Objects
{
    public class Team
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamAbbreviation { get; set; }
        public List<Player> Players { get; set; }
        public SortedList<int,Player> BattingOrder { get; set; }
        public SortedList<int, Player> PitchingRotation { get; set; }
        public SortedList<int, Player> BullpenRotation { get; set; }

        public Team()
        {
            TeamId = Guid.NewGuid();
        }

        public Team(string teamName, string teamAbbreviation)
        {
            TeamId = Guid.NewGuid();
            TeamName = teamName;
            TeamAbbreviation = teamAbbreviation;
        }
    }
}
