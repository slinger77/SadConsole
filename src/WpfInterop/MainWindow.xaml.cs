using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfInterop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SadConsoleMonoGame_ControlLoaded(object sender, MerjTek.WpfIntegration.GraphicsDeviceEventArgs e)
        {
            SadConsole.Engine.Initialize(e.GraphicsDevice, "IBM.font", 20, 20);
        }

        private void SadConsoleMonoGame_Render(object sender, MerjTek.WpfIntegration.GraphicsDeviceEventArgs e)
        {
            e.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);
            SadConsole.Engine.Update(new Microsoft.Xna.Framework.GameTime() { ElapsedGameTime = new TimeSpan(200), TotalGameTime = new TimeSpan(200) }, true);
            SadConsole.Engine.Draw(new Microsoft.Xna.Framework.GameTime() { ElapsedGameTime = new TimeSpan(200), TotalGameTime = new TimeSpan(200) });
        }
    }
}
