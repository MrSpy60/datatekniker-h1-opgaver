using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace
{
    internal class Bookmaker
    {
        public List<Bet> Bets { get; set; }

        public Bet PlaceBet(Race race, Rat rat, Player player, int money)
        {
            return new Bet(race, rat, player, money);
        }

        public void PayOutWinnings(Bet bet)
        {
            bet.PayWinnings();
        }
    }
}
