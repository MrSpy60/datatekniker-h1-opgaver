﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRace
{
    internal class Track
    {
        public string Name;
        public int TrackLength;

        public Track(string name, int trackLength)
        {
            Name = name;
            TrackLength = trackLength;
        }
    }
}
