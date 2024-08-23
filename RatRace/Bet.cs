using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace
{
    internal class Bet
    {
        private int _money;
        private Player _player;
        private Race _race;
        private Rat _rat;

        public Bet(Race race, Rat rat, Player player, int money)
        {
            _race = race;
            _rat = rat;
            _player = player;
            _money = money;
        }

        public void PayWinnings()
        {

        }
    }
}
