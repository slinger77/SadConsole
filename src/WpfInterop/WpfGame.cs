//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using MonoGame.Framework.WpfInterop;
//using MonoGame.Framework.WpfInterop.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WpfInterop
//{
//    public class MyGame : WpfGame
//    {
//        private IGraphicsDeviceService _graphicsDeviceManager;
//        private WpfKeyboard _keyboard;
//        private WpfMouse _mouse;

//        protected override void Initialize()
//        {
//            // must be initialized. required by Content loading and rendering (will add itself to the Services)
//            _graphicsDeviceManager = new WpfGraphicsDeviceService(this);

//            // wpf and keyboard need reference to the host control in order to receive input
//            // this means every WpfGame control will have it's own keyboard & mouse manager which will only react if the mouse is in the control
//            _keyboard = new WpfKeyboard(this);
//            _mouse = new WpfMouse(this);
            

//            // must be called after the WpfGraphicsDeviceService instance was created
//            base.Initialize();

//            var console = SadConsole.Engine.Initialize(_graphicsDeviceManager.GraphicsDevice, "IBM.font", 20, 20);
//            console.FillWithRandomGarbage();

//        }

//        protected override void Update(GameTime time)
//        {
//            // every update we can now query the keyboard & mouse for our WpfGame
//            var mouseState = _mouse.GetState();
//            var keyboardState = _keyboard.GetState();

//            SadConsole.Engine.Update(time, true);
//        }

//        protected override void Draw(GameTime time)
//        {
//            GraphicsDevice.Clear(Color.Yellow);

//            SadConsole.Engine.Draw(time);
//        }
//    }
//}
