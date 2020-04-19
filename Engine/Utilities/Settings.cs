﻿using GoRogue;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Engine
{
    internal class Settings
    {
        public static bool ShowingMenu { get; private set; }
        internal static int MapWidth { get; set; } = 360;
        internal static int MapHeight { get; set; } = 360;
        internal static int GameWidth { get; set; } = 120;
        internal static int GameHeight { get; set; } = 40;
        internal static bool IsPaused { get; private set; } = false;
        internal static Random Random { get; set; } = new Random();
        internal static Radius FOVRadius { get; set; } = Radius.CIRCLE;
        internal static SadConsole.FontMaster FontMaster { get; set; }
        internal static SadConsole.Font Font { get; set; }

        internal static Dictionary<Keys, Direction> MovementKeyBindings { get; } = new Dictionary<Keys, Direction>
        {
            { Keys.NumPad7, Direction.UP_LEFT },    { Keys.NumPad8, Direction.UP },     { Keys.NumPad9, Direction.UP_RIGHT },
            { Keys.NumPad4, Direction.LEFT },                                           { Keys.NumPad6, Direction.RIGHT },
            { Keys.NumPad1, Direction.DOWN_LEFT },  { Keys.NumPad2, Direction.DOWN },   { Keys.NumPad3, Direction.DOWN_RIGHT },
            { Keys.Up, Direction.UP }, { Keys.Down, Direction.DOWN }, { Keys.Left, Direction.LEFT }, { Keys.Right, Direction.RIGHT }
        };

        internal static Dictionary<Keys, GameActions> KeyBindings { get; } = new Dictionary<Keys, GameActions>
        {
            {Keys.Space, GameActions.TogglePause },
            {Keys.Escape, GameActions.ToggleMenu },
            {Keys.P, GameActions.TakePhotograph },
            {Keys.L, GameActions.LookAtEverythingInSquare },
            {Keys.D, GameActions.DustItemForPrints },
            {Keys.G, GameActions.GetItem },
            {Keys.R, GameActions.RemoveItemFromInventory },
            {Keys.T, GameActions.Talk },
            {Keys.I, GameActions.ToggleInventory },
            {Keys.N, GameActions.ToggleNotes },
            {Keys.A, GameActions.LookAtPerson },
        };

        internal static void ToggleMenu()
        {
            ShowingMenu = !ShowingMenu;
            IsPaused = ShowingMenu;
        }

        internal static void TogglePause()
        {
            IsPaused = !IsPaused;
        }
    }
}
