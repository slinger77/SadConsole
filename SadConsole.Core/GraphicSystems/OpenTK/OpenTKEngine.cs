#if OPENTK
using OpenTK;
using OpenTK.Graphics;
using System.Collections.Generic;
using System.ComponentModel;

namespace SadConsole
{
    public class TKGame : GameWindow
    {


        internal TKGame(int width, int height): base(width, height, GraphicsMode.Default, "SadConsole Game")
        {

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            Engine.ShutdownEventArgs args = new ShutdownEventArgs();
            Engine.EngineShutdown?.Invoke(null, args);
            e.Cancel = args.BlockShutdown;
        }
    }
    

    public static partial class Engine
    {
        /// <summary>
        /// The window being rendered to.
        /// </summary>
        public static TKGame Device { get; private set; }

        private static void SetupFontAndEffects(string font)
        {
            Fonts = new Dictionary<string, FontMaster>();
            ConsoleRenderStack = new Consoles.ConsoleList();
            RegisterCellEffect<Effects.Blink>();
            RegisterCellEffect<Effects.BlinkGlyph>();
            RegisterCellEffect<Effects.ConcurrentEffect>();
            RegisterCellEffect<Effects.Delay>();
            RegisterCellEffect<Effects.EffectsChain>();
            RegisterCellEffect<Effects.Fade>();
            RegisterCellEffect<Effects.Recolor>();

            // Load the default font and screen size
            DefaultFont = LoadFont(font).GetFont(Font.FontSizes.One);
        }
        private static void SetupInputsAndTimers()
        {
            Mouse.Setup(Device);
            Keyboard.Setup(Device);
            GameTimeDraw.Start();
            GameTimeUpdate.Start();
        }

        private static Consoles.Console SetupStartingConsole(int consoleWidth, int consoleHeight)
        {
            ActiveConsole = new Consoles.Console(consoleWidth, consoleHeight);
            ActiveConsole.TextSurface.DefaultBackground = Color4.Black;
            ActiveConsole.TextSurface.DefaultForeground = ColorAnsi.White;
            ((Consoles.Console)ActiveConsole).Clear();

            ConsoleRenderStack.Add(ActiveConsole);

            return (Consoles.Console)ActiveConsole;
        }

        /// <summary>
        /// Prepares the engine for use by creating a window. This must be the first method you call on the engine.
        /// </summary>
        /// <param name="font">The font to load as the <see cref="DefaultFont"/>.</param>
        /// <param name="consoleWidth">The width of the default root console (and game window).</param>
        /// <param name="consoleHeight">The height of the default root console (and game window).</param>
        /// <returns>The default active console.</returns>
        public static Consoles.Console Initialize(string font, int consoleWidth, int consoleHeight)
        {
            SetupFontAndEffects(font);

            var window = new GameWindow(, OpenTK.Graphics.GraphicsMode.Default, "SadConsole Game");

            window.Closing += (o, e) =>
            {
                
            };

            //window.SetFramerateLimit(60);
            Device = new TKGame(DefaultFont.Size.X * consoleWidth, DefaultFont.Size.Y * consoleHeight);
            
            SetupInputsAndTimers();

            // Create the default console.
            return SetupStartingConsole(consoleWidth, consoleHeight);
        }

        /// <summary>
        /// Prepares the engine for use. This must be the first method you call on the engine.
        /// </summary>
        /// <param name="window">The rendering window.</param>
        /// <param name="font">The font to load as the <see cref="DefaultFont"/>.</param>
        /// <param name="consoleWidth">The width of the default root console (and game window).</param>
        /// <param name="consoleHeight">The height of the default root console (and game window).</param>
        /// <returns>The default active console.</returns>
        public static Consoles.Console Initialize(GameWindow window, string font, int consoleWidth, int consoleHeight)
        {
            Device = window;

            SetupInputsAndTimers();
            SetupFontAndEffects(font);

            DefaultFont.ResizeGraphicsDeviceManager(window, consoleWidth, consoleHeight, 0, 0);


            // Create the default console.
            return SetupStartingConsole(consoleWidth, consoleHeight);
        }

        public static void Run()
        {
            EngineStart?.Invoke(null, System.EventArgs.Empty);

            //CHECK
            while (Device.WindowState == WindowState.Normal)
            {
                
                Device.Clear(ClearFrameColor);

                Update(Device.HasFocus());
                Draw();
                
                Device.Display();
                Device.DispatchEvents();
            }
        }

        public static void Draw()
        {
            GameTimeDraw.Update();
            GameTimeElapsedRender = GameTimeDraw.ElapsedGameTime.TotalSeconds;

            ConsoleRenderStack.Render();
            EngineDrawFrame?.Invoke(null, System.EventArgs.Empty);
        }

        public static void Update(bool windowIsActive)
        {
            GameTimeUpdate.Update();
            GameTimeElapsedUpdate = GameTimeUpdate.ElapsedGameTime.TotalSeconds;

            if (windowIsActive)
            {
                if (UseKeyboard)
                    Keyboard.ProcessKeys(GameTimeUpdate);

                if (UseMouse)
                {
                    Mouse.ProcessMouse(GameTimeUpdate);
                    if (ProcessMouseWhenOffScreen ||
                        (Mouse.ScreenLocation.X >= 0 && Mouse.ScreenLocation.Y >= 0 &&
                         Mouse.ScreenLocation.X < WindowWidth && Mouse.ScreenLocation.Y < WindowHeight))
                    {
                        if (_activeConsole != null && _activeConsole.ExclusiveFocus)
                            _activeConsole.ProcessMouse(Mouse);
                        else
                            ConsoleRenderStack.ProcessMouse(Mouse);
                    }
                    else
                    {
                        // DOUBLE CHECK if mouse left screen then we should stop kill off lastmouse
                        if (LastMouseConsole != null)
                        {
                            Engine.LastMouseConsole.ProcessMouse(Mouse);
                            Engine.LastMouseConsole = null;
                        }
                    }
                }

                if (_activeConsole != null)
                    _activeConsole.ProcessKeyboard(Keyboard);
            }
            ConsoleRenderStack.Update();
            EngineUpdated?.Invoke(null, System.EventArgs.Empty);
        }


    }
}
#endif