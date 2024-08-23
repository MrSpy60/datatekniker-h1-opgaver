using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace
{
    internal class Player
    {
        public string Name { get; set; }
        public int Money;
        List<Bet> Bets = new();

        public Player(string name, int money)
        {
            Name = name;
            Money = money;
        }
    }
}
