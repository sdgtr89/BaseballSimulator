using System;
using System.Linq;

namespace BaseballSimulator.Objects.Objects
{
    /// <summary>
    /// Represents the actual bases on a baseball diamond. 
    /// </summary>
    public class Bases : IEquatable<byte[]>
    {
        /// <summary>
        /// Three element byte[] to represent the bases. Index 0 = First Base, 
        /// Index 1 = Second Base, Index 2 = Third Base
        /// </summary>
        public byte[] RunnerPosition { get; set; }

        /// <summary>
        /// Creates a Bases object with no runners assigned
        /// </summary>
        public Bases()
        {
            AssignRunnersToBase();
        }

        /// <summary>
        /// Creates a Bases object with runners assigned to specific bases
        /// </summary>
        /// <param name="baseNumbers">Valid numbers: 1, 2 or 3 in any order</param>
        public Bases(params int[] baseNumbers)
        {
            AssignRunnersToBase(baseNumbers);
        }

        /// <summary>
        /// String representation of where the runners are located
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var runnerPositionString = "";

            for (var i = 0; i < RunnerPosition.Length; i++)
                runnerPositionString += (IsBaseOccupied(i)) ? $"{i + 1}B: Occupied\n" : $"{i + 1}B: Empty\n";

            return runnerPositionString;
        }

        public int RunnerCount => RunnerPosition.Count(runner => runner != 0);

        /// <summary>
        /// Assigns runners to the bases specified. Between 1 and 3 parameters can be passed.
        /// </summary>
        /// <param name="baseNumber">Valid numbers: 1, 2 or 3 in any order</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void AssignRunnersToBase(params int[] baseNumber)
        {
            RunnerPosition = new byte[3];

            if (baseNumber.Length <= 3 && baseNumber.Length >= 0)
            {
                Array.Sort(baseNumber);
                foreach (var v in baseNumber)
                {
                    RunnerPosition[v - 1] = 1;
                }
            }
            else throw new ArgumentOutOfRangeException("Cannot set more than three values");
        }

        /// <summary>
        /// Returns a boolean value indicating whether the requested base is occupied.
        /// </summary>
        /// <param name="baseIndex">0(1st), 1(2nd) or 2(3rd)</param>
        /// <returns></returns>
        private bool IsBaseOccupied(int baseIndex)
        {
            return (RunnerPosition[baseIndex] == 1);
        }

        /// <summary>
        /// Advances the runners ahead the amount of bases specified
        /// </summary>
        /// <param name="numberOfBases">Amount of bases to advance</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Advance(int numberOfBases)
        {
            if (numberOfBases > 4) throw new ArgumentException("Cannot earn more than 4 bases");

            var newRunnerPosition = new byte[3];
            var count = 0;

            MoveRunners(newRunnerPosition, numberOfBases, count);
            AssignBatterToBase(numberOfBases);
        }

        /// <summary>
        /// Self referential function that advances runners up to two bases
        /// </summary>
        /// <param name="newRunnerPosition">Array to assign new values</param>
        /// <param name="n">Number of bases</param>
        /// <param name="count">Iteration counter</param>
        private void MoveRunners(byte[] newRunnerPosition, int n, int count)
        {
            if(++count > 2) return;

            newRunnerPosition[1] = RunnerPosition[0];
            newRunnerPosition[2] = RunnerPosition[1];
            newRunnerPosition[0] = RunnerPosition[2];

            RunnerPosition = newRunnerPosition;

            //Ensures that the method only calls its self once
            if (n == 2) MoveRunners(new byte[3], n, count);
        }

        /// <summary>
        /// Based on the number of bases earned, assigns the batter to the 
        /// required base.
        /// </summary>
        /// <param name="numberOfBases">Number of bases earcned</param>
        private void AssignBatterToBase(int numberOfBases)
        {
            switch (numberOfBases)
            {
                case 1:
                    RunnerPosition[0] = 1;
                    break;
                case 2:
                    RunnerPosition[0] = 0;
                    RunnerPosition[1] = 1;
                    break;
                case 3:
                    Array.Clear(RunnerPosition, 0, RunnerPosition.Length);
                    AssignRunnersToBase(3);
                    break;
                case 4:
                    Array.Clear(RunnerPosition, 0, RunnerPosition.Length);
                    break;
            }
        }       

        /// <inheritdoc />
        /// <summary>
        /// Compares the current RunnerPosition[] with another Bases object RunnerPosition[]
        /// </summary>
        /// <param name="compare">otherBasesObject.RunnerPosition[]</param>
        /// <returns></returns>
        public bool Equals(byte[] compare)
        {
            return (this.RunnerPosition[0] == compare[0])
                && (this.RunnerPosition[1] == compare[1])
                && (this.RunnerPosition[2] == compare[2]);
        }       
    }
}
