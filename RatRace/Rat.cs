using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace
{
    public class Rat
    {
        public string Name;
        private int _position;
        public int Position
        {
            get { return _position ;}
            set { _position = value; }
        }



        public Rat(string name)
        {
            Name = name;
            Position = 0;
        }

        public void ResetRat()
        {
            _position = 0;
        }

        public int MoveRat()
        {
            return _position;
        }
    }
}
