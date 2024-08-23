using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace
{
    internal class Race
    {
        public int RaceID;
        public List<Rat> Rats = new();
        public Track RaceTrack;
        private Rat _winner;
        private string _log;

        public Race(int raceID, List<Rat> rats, Track track)
        {

        }

        public void ConductRace()
        {
            //WE RACING BOYS!
        }

        public Rat GetWinner()
        {
            return _winner;
        }
        public string GetRaceReport()
        {
            return _log;
        }

        private void logRace()
        {

        }
    }
}
