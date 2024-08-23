using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace
{
    internal class RaceManager
    {
        public List<Track> Tracks = new();
        public List<Player> Players = new();
        public List<Race> Races = new();
        public List<Rat> Rats = new();

        public Race CreateRace(int raceID, List<Rat> rats, Track track)
        {
            return new Race(raceID, rats, track);
        }

        public Track CreateTrack(string name, int trackLength)
        {
            return new Track(name , trackLength);
        }

        public void ConductRace(Race race)
        {

        }

        public string ViewRaceReport(Race race)
        {
            return race.GetRaceReport();
        }

        public Rat createRat(string name)
        {
            return new Rat(name);
        }

        public Player CreatePlayer(string name, int money)
        {
            return new Player(name, money);
        }
    }
}
