using System;
using System.Collections.Generic;
using System.Text;

namespace BaseballSimulator.Objects.Objects
{
    public class Inning
    {
        public double InningValue { get; set; }
        public int Outs { get; set; }
        public int Runs { get; set; }
        public int Hits { get; set; }

        public Inning(double inningValue = 1.0)
        {
            InningValue = inningValue;
            Outs = 0;
            Runs = 0;
        }

        public void AddOut()
        {
            Outs++;
        }

        public void AddHit()
        {
            Hits++;
        }

        public void AddRuns(int runs)
        {
            Runs += runs;
        }
    }
}
