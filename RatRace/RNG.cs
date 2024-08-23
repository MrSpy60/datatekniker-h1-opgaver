using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace
{
    internal static class RNG
    {
        private static Random _rng = new();

        public static int Range(int upper, int lower)
        {
            return _rng.Next(lower, upper);
        }
    }
}
