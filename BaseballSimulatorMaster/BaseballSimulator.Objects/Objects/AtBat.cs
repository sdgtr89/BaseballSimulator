using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BaseballSimulator.Objects.Utilities;

namespace BaseballSimulator.Objects.Objects
{
    public class AtBat
    {
        public string Name { get; }
        public int BasesValue { get; }
        public double Probability { get; }

        public AtBat(string name, int baseValue, double probability)
        {
            Name = name;
            BasesValue = baseValue;
            Probability = probability;
        }
        public static AtBat RandomAtBatEvent()
        {
            var baseballEvent = new AtBat("", 0, 0.0);

            var r = new Random();
            //gets a random double 
            var probability = r.NextDouble();
            //used to create pseudo weighted probability
            var cumulative = 0.0;

            for (var i = 0; i < BaseballEvents.Events.Count; i++)
            {
                var item = BaseballEvents.Events[i];

                //adds the event probability from the dictionary value
                cumulative += item.Probability;

                //establishes if the event probability is above the random number
                if (!(probability < cumulative)) continue;

                baseballEvent = item;
                break;
            }

            return baseballEvent;
        }

        

        public static AtBat SimulateOneAtBat(Bases bases, ref int outs)
        {
            var testAtBat = AtBat.RandomAtBatEvent();
            if (testAtBat.BasesValue > 0) bases.Advance(testAtBat.BasesValue);
            else ++outs;

            return testAtBat;
        }

        public override string ToString()
        {
            return $"Result: {Name} \nBases Earned: {BasesValue}";
        }
    }
}
