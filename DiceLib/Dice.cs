using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceLib
{
    public class Dice
    {
        private int _NumberOfSides;
        public int NumberOfSides
        {
            get { return _NumberOfSides; }
        }
        private int _LastRoll;
        public int LastRoll
        {
            get { return _LastRoll; }
        }
        private Random rnd = new Random();

        public Dice()
        {
            _NumberOfSides = 6;
        }

        public Dice(int numberOfSides)
        {
            _NumberOfSides = numberOfSides;
        }

        public int RollDie()
        {
            _LastRoll = rnd.Next(1,NumberOfSides +1);
            return LastRoll;
        }
    }
}
