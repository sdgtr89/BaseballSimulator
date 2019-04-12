using System;
using System.Collections.Generic;
using System.Text;

namespace BaseballSimulator.Objects.Utilities
{
    public static class Extensions
    {
        public static void Shuffle<T>(this T[] collection)
        {
            var randInt = new Random(); 
            var max = collection.Length;

            for (int i = 0; i < max; i++)
            {
                var r = i + randInt.Next(max - i);
                var temp = collection[i];
                collection[i] = temp;
            }
        }
    }
}
