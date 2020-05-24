﻿using GoRogue;
using System;
using SadConsole;
using Console = SadConsole.Console;
using Color = Microsoft.Xna.Framework.Color;
using Engine.Extensions;

namespace Engine.UI
{
    public class SpeechConsole : Console
    {
        private ColoredString _message;
        private Color fore;
        private Color back;
        private Coord coord;

        public SpeechConsole(Font voice, string statement, Coord position) : base(statement.Length, 1, voice)//for now
        {
            Position = position;
            fore = Color.White;
            back = Color.Black;
            IsFocused = true;
            IsVisible = true;
            _message = new ColoredString(statement, fore, back);
            Print(0,0,_message);
        }

        public SpeechConsole(int width, int height, Coord coord) : base(width, height)
        {
            this.coord = coord;
        }

        public override void Update(TimeSpan timeElapsed)
        {
            fore = fore.FadeOut();
            back = back.FadeOut();
            _message.SetForeground(fore);
            _message.SetBackground(back);
            Clear();
            Print(0, 0, _message);
            base.Update(timeElapsed);
        }
    }
}
