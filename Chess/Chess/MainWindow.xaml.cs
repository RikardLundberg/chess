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

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Controller.GameController.SetupGame(this);
            Controller.GameController.StartGame();
        }

        private void Square_Click(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is Border))
                return;
            System.Windows.Forms.MessageBox.Show("You clicked "+((Border)sender).Name+"!");
        }

        public void DrawPiece(Model.IPiece piece)
        {
            switch (piece.Type)
            {
                case Model.PieceType.Bishop:
                    if (piece.Color == Model.PieceColor.White) WriteInSquare("♗", piece.Square.Name);
                    else if (piece.Color == Model.PieceColor.Black) WriteInSquare("♝", piece.Square.Name);
                    break;
            }
        }

        private void WriteInSquare(string pieceName, string squareName)
        {
            object squareBorder = this.FindName(squareName);
            if (squareBorder is Border)
            {
                Label label = new Label
                {
                    Content = pieceName,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    HorizontalAlignment = HorizontalAlignment.Right,
                    Height = 68,
                    Width = 58,
                    FontSize = 50,
                    Margin = new Thickness(0, 0, 0, 0)
                };
                ((Border)squareBorder).Child = label;
            }
        }

        public void ClearSquare(Model.Square square)
        {

        }

    }
}
