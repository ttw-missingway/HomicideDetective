﻿using GoRogue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Extensions
{
    public static class CoordExtensions
    {
        public static List<Coord> Neighbors(this Coord here)
        {
            List<Coord> neighbors = new List<Coord>();
            neighbors.Add(new Coord(here.X - 1, here.Y));
            neighbors.Add(new Coord(here.X + 1, here.Y));
            neighbors.Add(new Coord(here.X, here.Y+1));
            neighbors.Add(new Coord(here.X, here.Y-1));
            return neighbors;
        }
    }
}
