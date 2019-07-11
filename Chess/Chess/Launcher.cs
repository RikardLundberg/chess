using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Launcher
    {
        [STAThread]
        public static void Main(string[] args)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Controller.GameController gc = new Controller.GameController(window);
            gc.StartGame();
        }
    }
}
