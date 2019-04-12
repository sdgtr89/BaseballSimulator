using BaseballSimulator.Objects.Objects;
using System;
using BaseballSimulator.Objects.Utilities;

namespace BaseballSimulator.ConsoleClient
{
    class Program
    {
        public static void PlayOneHalfInning(Bases bases, int outs)
        {
            var testAtBat = new AtBat();
            testAtBat.GenerateRandomPlateAppearance();
            if (testAtBat.BasesValue > 0) bases.Advance(testAtBat.BasesValue);
            else ++outs;

            Console.WriteLine($"{testAtBat.Name} Advance {testAtBat.BasesValue}:");
            Console.WriteLine($"{bases}\nOuts: {outs}");
            Console.ReadLine();

            if (outs < 3) PlayOneHalfInning(bases, outs);
        }

        static void Main(string[] args)
        {
            var player = new Player("Steve", "Driscoll", DateTime.Parse("11/21/1989"), PlayerPosition.ReliefPitcher);
            Console.WriteLine(player.ToString());
            Console.ReadLine();

            player.ChangePlayerPosition(PlayerPosition.DesignatedHitter);
            Console.WriteLine(player.ToString());
            Console.ReadLine();

            var bases = new Bases();
            Console.WriteLine("Start of Inning:");
            Console.WriteLine(bases.ToString());

            int outs = 0;

            PlayOneHalfInning(bases, outs);

            Console.WriteLine("End of Inning");
            Console.ReadLine();

        }
    }
}

