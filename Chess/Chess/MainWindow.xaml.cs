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
using Chess.Model;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller.GameController GameController { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            GameController = new Controller.GameController(this);
            GameController.SetupGame();
            GameController.StartGame();
        }

        private void Square_Click(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is Border))
                return;

            GameController.SelectSquare(((Border)sender).Name);
            /*if (SelectedBorderName != "")
            {
            }
            else
                SelectBorder();*/

            //System.Windows.Forms.MessageBox.Show("You clicked "+((Border)sender).Name+"!");
        }

        public void SelectSquare(string squareName)
        {
            object squareBorder = this.FindName(squareName);
            if (squareBorder is Border)
            {
                ((Border)squareBorder).BorderThickness = new Thickness(5, 5, 5, 5);
                ((Border)squareBorder).BorderBrush = System.Windows.Media.Brushes.Aquamarine;
            }
        }

        public void UnselectSquare(string squareName)
        {
            object squareBorder = this.FindName(squareName);
            if (squareBorder is Border)
            {
                ((Border)squareBorder).BorderThickness = new Thickness(0,0,0,0);
            }
        }

        public void DrawPiece(IPiece piece, string squareName)
        {
            switch (piece.Type)
            {
                case Model.PieceType.Bishop:
                    if (piece.Color == Model.PieceColor.White) WriteInSquare("♗", squareName);
                    if (piece.Color == Model.PieceColor.White) WriteInSquare("♗", squareName);
                    else if (piece.Color == Model.PieceColor.Black) WriteInSquare("♝", squareName);
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

        public void ClearSquare(string squareName)
        {
            object squareBorder = this.FindName(squareName);
            if (squareBorder is Border)
            {
                //MainGrid.Children.Remove(((Border)squareBorder).Child);
                ((Border)squareBorder).Child = null;
            }
        }

        public void UpdateCurrentPlayerLabel(string currentPlayer)
        {
            CurrentPlayerLabel.Content = currentPlayer;
        }

        public void UpdateWarning(string warningMessage)
        {
            WarningLabel.Content = warningMessage;
            WarningLabel.Visibility = Visibility.Visible;
        }

        private void StartNewGame(object sender, RoutedEventArgs e)
        {
            GameController.SetupGame();
            GameController.StartGame();
        }
    }
}
