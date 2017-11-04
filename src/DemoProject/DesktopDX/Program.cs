﻿using System;
using SadConsole;
using Microsoft.Xna.Framework;
using SadConsole.Input;
using Console = SadConsole.Console;
using Microsoft.Xna.Framework.Graphics;
using SadConsole.StringParser;
using SadConsole.Surfaces;

namespace StarterProject
{
	// Main class
	class Program
	{
		private static Windows.CharacterViewer _characterWindow;
		public static Container MainConsole;

		public static ShitClass zz;

		// Main method
		static void Main(string[] args)
		{
			zz = new ShitClass();
			zz.ShitMethod();


			//SadConsole.Settings.UnlimitedFPS = true;
			//SadConsole.Settings.UseHardwareFullScreen = true;

			// Setup the engine and creat the main window.
			SadConsole.Game.Create("Fonts/IBM.font", 80, 25);
			//SadConsole.Engine.Initialize("IBM.font", 80, 25, (g) => { g.GraphicsDeviceManager.HardwareModeSwitch = false; g.Window.AllowUserResizing = true; });

			// Hook the start event so we can add consoles to the system.
			SadConsole.Game.OnInitialize = Init;

			// Hook the update event that happens each frame so we can trap keys and respond.
			SadConsole.Game.OnUpdate = Update;

			// Hook the "after render" even though we're not using it.
			SadConsole.Game.OnDraw = DrawFrame;

			// Start the game.
			SadConsole.Game.Instance.Run();

			//
			// Code here will not run until the game has shut down.
			//

			
		}

		private static void DrawFrame(GameTime time)
		{
			// Custom drawing. You don't usually have to do this.

		}

		private static void Update(GameTime time)
		{

			// Called each logic update.
			if (!_characterWindow.IsVisible)
			{
				// This block of code cycles through the consoles in the SadConsole.Engine.ConsoleRenderStack, showing only a single console
				// at a time. This code is provided to support the custom consoles demo. If you want to enable the demo, uncomment one of the lines
				// in the Initialize method above.
				if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F1))
				{
					MainConsole.MoveNextConsole();
				}
				else if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F2))
				{
					_characterWindow.Show(true);
				}
				else if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F3))
				{
				}
				else if (SadConsole.Global.KeyboardState.IsKeyReleased(Microsoft.Xna.Framework.Input.Keys.F5))
				{
					SadConsole.Settings.ToggleFullScreen();
				}
			}
		}

		private static void Init()
		{
			// Any setup
			if (Settings.UnlimitedFPS)
				SadConsole.Game.Instance.Components.Add(new SadConsole.Game.FPSCounterComponent(SadConsole.Game.Instance));

			// Setup our custom theme.
			Theme.SetupThemes();

			SadConsole.Game.Instance.Window.Title = "DemoProject DirectX";

			// We'll instead use our demo consoles that show various features of SadConsole.
			MainConsole = new Container();
			Global.CurrentScreen = MainConsole;

			

			// Initialize the windows
			_characterWindow = new Windows.CharacterViewer();
		}
	}
}