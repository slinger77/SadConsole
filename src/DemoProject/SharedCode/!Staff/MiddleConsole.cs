using System;
using Console = SadConsole.Console;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using SadConsole;
using SadConsole.Input;
using StarterProject.CustomConsoles;

namespace StarterProject
{
	class MiddleConsole: Console
	{
		// Size of the console. X - lenght, Y - height
		public MiddleConsole(): base(5,10)
		{
			TextSurface.DefaultBackground = Color.Transparent;
			TextSurface.DefaultBackground = Theme.Green;
		}

		public void SetConsole(IConsoleMetadata console)
		{
			Fill(Theme.Green, Theme.Green, 0);
			Print(1, 0, "zzz", Theme.Yellow);
			Print(1, 1, "xxx", Theme.Gray);
		}
	}

}
