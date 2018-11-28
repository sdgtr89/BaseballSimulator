using System;
using System.Collections.Generic;
using System.Text;

namespace BaseballSimulator.Objects.Objects
{
    public class Game
    {
        public Guid GameId { get; set; }
        public GameStats GameStats { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public Inning CurrentInning { get; set; }
        public Team CurrentTeamAtBat { get; set; }
        public List<Inning> Innings { get; set; }
        public Player PreviousInningLastBatterHome { get; set; }
        public Player PreviousInningLastBatterAway { get; set; }

        public Game(Team homeTeam, Team awayTeam)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
            GameId = Guid.NewGuid();
            GameStats = new GameStats();
            Innings = new List<Inning>();
            CurrentInning = new Inning();
            CurrentTeamAtBat = AwayTeam;
        }
    }
}
