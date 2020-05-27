﻿using Engine.States;
using Microsoft.Xna.Framework;
using SadConsole;
using System;

namespace Tests
{
    class MockGame
    {
        public static DebuggingState DebugState { get; private set; }
        public static MenuState Menu { get; private set; }
        public static BasicEntity Player { get; private set; }

        public MockGame(Action<GameTime> update)
        {
            SadConsole.Game.Create("font-sample.json", Engine.Settings.GameWidth, Engine.Settings.GameHeight);
            SadConsole.Global.Fonts.Remove("IBM_16x8");// = new Dictionary<string, FontMaster>();
            SadConsole.Global.Fonts.Remove("IBM_16x8_ext");// = new Dictionary<string, FontMaster>();
            SadConsole.Game.OnInitialize = Init;
            SadConsole.Game.OnUpdate = update;
        }
        internal static void Start()
        {
            SadConsole.Game.Instance.Run();
        }

        internal static void RunOnce()
        {
            SadConsole.Game.Instance.RunOneFrame();
        }

        internal static void Stop()
        {
            SadConsole.Game.Instance.Exit();
            SadConsole.Game.Instance.Dispose();
        }

        protected static void Init()
        {
            SadConsole.Global.Fonts.Remove("IBM_16x8");// = new Dictionary<string, FontMaster>();
            SadConsole.Global.Fonts.Remove("IBM_16x8_ext");// = new Dictionary<string, FontMaster>();
            DebugState = new DebuggingState();
            SadConsole.Global.CurrentScreen = DebugState;
            Player = DebugState.Map.ControlledGameObject;
            Player.AddGoRogueComponent(new MockComponent());
        }
    }
}
