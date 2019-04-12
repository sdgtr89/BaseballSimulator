using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseballSimulator.Objects.Events;
using BaseballSimulator.Objects.Utilities;

namespace BaseballSimulator.Objects.Objects
{
    public class AtBat
    {
        public string Name { get; private set;  }
        public int BasesValue { get; private set; }
        public double Probability { get; private set; }
        public bool IsBattedBall { get; private set; }

        public delegate void BattedBallEventHandler(object sender, EventArgs e);
        public event BattedBallEventHandler BattedBall;
        public delegate void NonBattedBallEventHandler(object sender, EventArgs e);
        public event NonBattedBallEventHandler NonBattedBall;

        public static AtBat[] Events { get; }

        public AtBat()
        {
        }

        private AtBat(string name, int basesValue, double probability, bool isBattedBall)
        {
            Name = name;
            BasesValue = basesValue;
            Probability = probability;
            IsBattedBall = isBattedBall;
        }        

        static AtBat()
        {
            Events = new AtBat[]
            {
                 new AtBat("Triple",3, 0.004,true),
                 new AtBat("Home-run",4, 0.033,true),
                 new AtBat("Double",2, 0.045, true),
                 new AtBat("Reach On Error",1, 0.06, true),
                 new AtBat("Hit By Pitch",1, 0.0095, false),
                 new AtBat("Walk",1, 0.085,false),
                 new AtBat("Fly Out",0, 0.09,true),
                 new AtBat("Single",1, 0.145,true),
                 new AtBat("Line Out",0, 0.13,true),
                 new AtBat("Ground Out",0, 0.1825,true),
                 new AtBat("Strikeout",0, 0.216,false)
            };
        }
        
        public void GenerateRandomPlateAppearance()
        {
            var baseballEvent = new AtBat("", 0, 0.0, false);

            var r = new Random();
            //gets a random double 
            var probability = r.NextDouble();
            //used to create pseudo weighted probability
            var cumulative = 0.0;

            for (var i = 0; i < AtBat.Events.Length; i++)
            {
                AtBat.Events.Shuffle();
                var item = AtBat.Events[i];

                //adds the event probability from the dictionary value
                cumulative += item.Probability;

                //establishes if the event probability is above the random number
                if (!(probability < cumulative)) continue;

                baseballEvent = item;
                break;
            }

            AssignNewAtBatData(baseballEvent);
            
            if (this.IsBattedBall)
            {
                OnBattedBallEvent();
            }
            else
            {
                OnNonBattedBallEvent();
            }            
        }

        private void AssignNewAtBatData(AtBat randAtBat)
        {
            this.Name = randAtBat.Name;
            this.BasesValue = randAtBat.BasesValue;
            this.Probability = randAtBat.Probability;
            this.IsBattedBall = randAtBat.IsBattedBall;
        }
        
        protected virtual void OnBattedBallEvent()
        {
            BattedBall?.Invoke(this, new BattedBallEvent(this.Name));
        }

        protected virtual void OnNonBattedBallEvent()
        {
            NonBattedBall?.Invoke(this, new NonBattedBallEvent(this.Name));
        }

        public override string ToString()
        {
            return $"Result: {Name} \nBases Earned: {BasesValue}";
        }
    }
}
