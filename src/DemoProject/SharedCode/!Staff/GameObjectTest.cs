using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ColorHelper = Microsoft.Xna.Framework.Color;

using Console = SadConsole.Console;
using SadConsole;
using SadConsole.Surfaces;

namespace StarterProject
{
    class GameObjectTest : Console, IConsoleMetadata
    {
		private SadConsole.GameHelpers.GameObject fallingText;

		public ConsoleMetadata Metadata
		{
			get
			{
				return new ConsoleMetadata() { Title = "game test", Summary = "game object test" };
			}
		}

		public GameObjectTest() : base(80, 23)
		{
			var textAnimation = new AnimatedSurface("default",14,5); // Animated surface size. 14,5
			fallingText = new SadConsole.GameHelpers.GameObject(textAnimation);

			var editor = new SadConsole.Surfaces.SurfaceEditor(new SadConsole.Surfaces.BasicSurface(1,1));

			for (int line = 0; line < 5; line++)
			{
				var frame = textAnimation.CreateFrame();
				editor.TextSurface = frame;
				editor.Fill(Color.Purple, Color.DarkGray, 178, null); // 219 178
				editor.Print(1, line, "Hello World!");
			}

			textAnimation.AnimationDuration = 1; // Set it to -1 to make it faster than 1 sec
			textAnimation.Repeat = true;

			textAnimation.Start();

			fallingText.Animation = textAnimation;
			//fallingText.Position = new Point(1,1);

			Children.Add(fallingText);
			
		}
	}
}
