﻿using Engine.Components.UI;
using Engine.UI.Components;
using GoRogue;
using Microsoft.Xna.Framework;
using SadConsole;
using SadConsole.Controls;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Engine.UI
{
    public class MenuUi : UserInterface
    {
        //public ScrollingConsole Display { get; private set; } //the main box that covers the screen
        //public BasicEntity ControlledGameObject { get; private set; } //the cursor
        public ScrollingConsole TitleConsole { get; private set; } // H O M I C I D E    D E T E C E T I V E 
        public MenuPanel MainOptions { get; private set; } //the main menu that appears when you pause
        public MenuPanel NewGameOptions { get; private set; } //quickstart / advanced options
        public MenuPanel NewGameAdvancedOptions { get; private set; } //name / color / glyph / option for tutorial
        public MenuPanel SettingsOptions { get; private set; }
        public HelpConsole HelpOptions { get; private set; } //console that holds the search box / cheats menu

        readonly int _width = Game.Settings.GameWidth / 3;
        readonly int _height = Game.Settings.GameHeight / 3;

        readonly Coord middlePosition;
        readonly Coord openSubMenuOffset;
        public MenuUi()
        {
            IsVisible = false;
            IsFocused = false;
            middlePosition = new Coord(_width, _height);
            openSubMenuOffset = new Coord(_width / 2, _height / 2);
            UseMouse = true;
            UseKeyboard = true;
            InitDisplay();
            InitTitleConsole();
            InitControls(Game.Settings.GameWidth, 2 * _height);
            InitMainOptions();
            InitHelpOptions();
            InitNewGameOptions();
            InitNewGameAdvancedOptions();
            InitSettingsOptions();
            InitCursor();
        }


        #region initilization
        private void InitTitleConsole()
        {
            //takes up the top 1/3 of the screen
            TitleConsole = new ScrollingConsole(Game.Settings.GameWidth, _height);
            TitleConsole.IsVisible = true;

            TitleConsole.Position = new Coord(0, 0);
            TitleConsole.FillWithRandomGarbage();//for debugging purposes
            TitleConsole.Print(2, 2, "!!! H O M I C I D E   D E T E C T I V E !!!", Color.White, Color.Black);
            TitleConsole.IsVisible = true;
            Display.Children.Add(TitleConsole);
        }
        protected override void InitControls(int width, int height)
        {
            base.InitControls(Game.Settings.GameWidth, height);
            Controls.Position = new Coord(0, _height);
            Controls.Theme = new MenuControlsTheme();
            Controls.ThemeColors = ThemeColors.Menu;
            Controls.DefaultBackground = Color.Black;
            Controls.DefaultForeground = Color.White;
            List<Cell> cells = new List<Cell>();

            for (int i = 0; i < width * height; i++)
                cells.Add(new Cell(Color.White, Color.Black, ' '));

            Controls.SetSurface(cells.ToArray(), width, height);
        }
        private void InitMainOptions()
        {
            MainOptions = new MenuPanel(_width, _height);
            MainOptions.Add(MakeButton("Continue", ContinueButton_Click));
            MainOptions.Add(MakeButton("New Game", ContinueButton_Click));
            MainOptions.Add(MakeButton("Settings", ContinueButton_Click));
            MainOptions.Add(MakeButton("Help", ContinueButton_Click));
            MainOptions.Position = new Coord(_width, 0);
            MainOptions.Arrange();
            Controls.Children.Add(MainOptions);
        }

        private void InitHelpOptions()
        {
            HelpOptions = new HelpConsole();
            HelpOptions.Position = new Coord(0, _height);
            HelpOptions.IsVisible = false;
            Controls.Children.Add(HelpOptions);
        }        
        
        private void InitNewGameOptions()
        {
            NewGameOptions = new MenuPanel(_width, _height);
            NewGameOptions.Position = new Coord(Controls.Width / 2, 0);
            NewGameOptions.IsVisible = false;
            NewGameOptions.Add(MakeButton("Quickstart", QuickStartButton_Click));
            NewGameOptions.Add(MakeButton("Advanced", AdvancedStartButton_Click));
            NewGameOptions.Arrange();
        }
        private void InitNewGameAdvancedOptions()
        {
            NewGameAdvancedOptions = new MenuPanel(_width, _height);
            NewGameAdvancedOptions.Position = new Coord(2 * Controls.Width / 3, 0);
            NewGameAdvancedOptions.IsVisible = false;
            NewGameAdvancedOptions.Add(MakeButton("Start", AdvancedStartButton_Click));
            NewGameAdvancedOptions.Arrange();
        }
        private void InitSettingsOptions()
        {
            SettingsOptions = new MenuPanel(_width, _height * 2);

            PropertyInfo[] properties = typeof(Settings).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Button btn = MakeButton(property.Name, Except);
                SettingsOptions.Add(btn);
            }
            SettingsOptions.Arrange();
        }
        private void Except(object sender, EventArgs e) => throw new Exception();//temporary

        private BasicEntity MenuSelector(Coord position)
        {
            BasicEntity cursor = new BasicEntity(Color.White, Color.Black, 16, position, 1, true, true);
            cursor.Components.Add(new MenuKeyboardComponent(cursor));
            return cursor;
        }

        private void InitCursor()
        {
            ControlledGameObject = MenuSelector(Controls.Position);
            Controls.Children.Add(ControlledGameObject);
        }
        #endregion

        #region utilties
        public override void Hide()
        {
            base.Hide();
            Global.CurrentScreen = Game.UIManager;
            Game.UIManager.ControlledGameObject.IsFocused = true;
        }
        public override void Show()
        {
            base.Show();
            Global.CurrentScreen = this;
            ControlledGameObject.IsFocused = true;
        }
        #endregion

        #region event handlers

        private void AdvancedStartButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void QuickStartButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void HelpButton_Click(object sender, EventArgs e)
        {
            //open help console
            HelpOptions.IsVisible = true;
            HelpOptions.IsFocused = true;
            //MainOptions.Position = new Coord(Game.Settings.GameWidth / 3, Game.Settings.GameHeight / 3);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            //open settings console
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            // open quickstart or advanced start console
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            //Hide();
            Game.SwitchUserInterface();
        }
        #endregion
    }
}
