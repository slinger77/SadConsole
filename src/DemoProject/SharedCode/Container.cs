﻿using System;
using Console = SadConsole.Console;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using SadConsole;
using SadConsole.Input;
using StarterProject.CustomConsoles;

namespace StarterProject
{
	class Container : ConsoleContainer
	{
		private int currentConsoleIndex = -1;
		private IConsoleMetadata selectedConsole;
		private HeaderConsole headerConsole; // Console on top of the screen

		public MiddleConsole middleConsolel; // My test console
		public GameObjectTest gameObjectConsole; // My game object console

		public IConsoleMetadata[] consoles;

		public Container()
		{
			headerConsole = new HeaderConsole();

			middleConsolel = new MiddleConsole(); // My middle console instance
			gameObjectConsole = new GameObjectTest(); // My game object instance

			//var console1 = new Console(10, 10, Serializer.Load<FontMaster>("Fonts/Cheepicus12.font").GetFont(Font.FontSizes.Two));
			//console1.Fill(Color.BlueViolet, Color.Yellow, 7);
			//var consoleReal = new StretchedConsole();
			//consoleReal.TextSurface = console1.TextSurface;

			consoles = new IConsoleMetadata[] {
                
                //new CustomConsoles.MouseRenderingDebug(),
                //new CustomConsoles.AutoTypingConsole(),
                //new CustomConsoles.SerializationTests(),
                //new CustomConsoles.SplashScreen() { SplashCompleted = () => MoveNextConsole() },
                //new CustomConsoles.StringParsingConsole(),
                //new CustomConsoles.TextCursorConsole(),
                //new CustomConsoles.ViewsAndSubViews(),
                //new CustomConsoles.ControlsTest(),
                //new CustomConsoles.SubConsoleCursor(),
                new CustomConsoles.DOSConsole(),
                //new CustomConsoles.GameObjectConsole(),
                //new CustomConsoles.SceneProjectionConsole(),
                //new CustomConsoles.AnsiConsole(),
                //new CustomConsoles.StretchedConsole(),
                //new CustomConsoles.WorldGenerationConsole(),
                //new CustomConsoles.RandomScrollingConsole(),
            };

			MoveNextConsole();
		}

		public void MoveNextConsole()
		{
			currentConsoleIndex++;

			if (currentConsoleIndex >= consoles.Length)
				currentConsoleIndex = 0;

			selectedConsole = consoles[currentConsoleIndex];

			Children.Clear();
			Children.Add(selectedConsole);
			Children.Add(headerConsole); // Header console

			Children.Add(middleConsolel); // Middle console
			Children.Add(gameObjectConsole); // Game object added

			selectedConsole.IsVisible = true;
			selectedConsole.IsFocused = true;
			selectedConsole.Position = new Point(0, 2); // Main console position. 2 Points down from the top

			middleConsolel.Position = new Point(20, 5); // Set position of middleConsole
			gameObjectConsole.Position = new Point(40, 5); // Set position of game object

			Global.FocusedConsoles.Set(selectedConsole);
			headerConsole.SetConsole(selectedConsole);
			middleConsolel.SetConsole(selectedConsole);
		}

		//public override bool ProcessKeyboard(Keyboard state)
		//{
		//    return selectedConsole.ProcessKeyboard(state);
		//}

		//public override bool ProcessMouse(MouseConsoleState state)
		//{
		//    return selectedConsole.ProcessMouse(state);
		//}
	}
}