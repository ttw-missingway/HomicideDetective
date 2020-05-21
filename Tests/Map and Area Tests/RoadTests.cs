﻿using Engine.Maps;
using GoRogue;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class RoadTests
    {
        Road road;
        Coord start = new Coord(15, 0);
        Coord stop = new Coord(35, 20);
        [Test]
        public void NewHorizontlRoadTest()
        {
            road = new Road(start, stop, RoadNumbers.Thirteenth);
            Assert.AreEqual(road.Name, RoadNumbers.Thirteenth.ToString());
            Assert.Less(road.OuterPoints.Count, road.InnerPoints.Count);
        }
        [Test]
        public void NewVerticalRoadTest()
        {
            road = new Road(start, stop, RoadNames.ZooFront);
            Assert.AreEqual(road.Name, RoadNames.ZooFront.ToString());
            Assert.Less(road.OuterPoints.Count, road.InnerPoints.Count);
        }
    }
}