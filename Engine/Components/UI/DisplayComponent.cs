﻿using Engine.Maps.Areas;
using Engine.UI;
using GoRogue;
using System;
using Color = Microsoft.Xna.Framework.Color;
using Console = SadConsole.Console;

namespace Engine.Components.UI
{
    public class DisplayComponent<T> : ComponentBase where T : ComponentBase 
    {
        public Console Display;
        internal T Component => Parent.GetComponent<T>();
         
        public DisplayComponent(Coord position) : base(true, false, true, false)
        {
            Display = new Console(24, 36)
            {
                DefaultBackground = Color.Transparent,
                Position = position,
                IsVisible = true,
            };


        }

        public override void ProcessGameFrame()
        {
            //do nothing... ?
        }



        public void Print(string[] text)
        {

            Display.Fill(Color.Blue, Color.Tan, '_');
            //Display.Fill(Color.Transparent, Display.DefaultBackground, 0);
            for (int i = 0; i < text.Length; i++)
            {
                Display.Print(1, i, new SadConsole.ColoredString(text[i].ToString(), Color.DarkBlue, Color.Transparent));
            }
        }
        public void Print(Area[] areas)
        {
            Display.Fill(Color.Blue, Color.Tan, '_');
            //Display.Fill(Color.Transparent, Display.DefaultBackground, 0);
            for (int i = 0; i < areas.Length; i++)
            {
                Display.Print(0, i, new SadConsole.ColoredString(areas[i].Name, Color.DarkBlue, Color.Transparent));
            }
        }
    }
}
