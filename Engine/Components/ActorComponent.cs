﻿using GoRogue;
using GoRogue.GameFramework.Components;
using GoRogue.Pathing;
using SadConsole;
using SadConsole.Components.GoRogue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Components
{
    internal class ActorComponent : ComponentBase
    {
        private Path _path;
        private BasicEntity _target;
        public void Act()
        {
            //Determine whether or not we have a path
            if (_path == null)
            {

            }
            //just move in a random direction for now
            List<Direction> directions = new List<Direction>();
            directions.Add(Direction.UP);
            directions.Add(Direction.LEFT);
            directions.Add(Direction.RIGHT);
            directions.Add(Direction.DOWN);
            Direction d = directions.RandomItem();
            Parent.MoveIn(d);
        }
        public void Interact(BasicEntity sender)
        {
        }

        public override void ProcessGameFrame()
        {
            throw new NotImplementedException();
        }
    }
}