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
        private string SelectedBorderName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            GameController = new Controller.GameController(this);
            SelectedBorderName = "";
        }

        private void Square_Click(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is Border))
                return;

            if (SelectedBorderName != "")
            {
                //if valid move
                //move
            }
            else
                SelectBorder((Border)sender);
            //System.Windows.Forms.MessageBox.Show("You clicked "+((Border)sender).Name+"!");
        }

        private void SelectBorder(Border border)
        {
            SelectedBorderName = border.Name;
            border.BorderThickness = new Thickness(5, 5, 5, 5);
            border.BorderBrush = System.Windows.Media.Brushes.Aquamarine;
        }

        private void UnselectCurrentSelectedBorder()
        {
            object squareBorder = this.FindName(SelectedBorderName);
            if (squareBorder is Border)
            {
                ((Border)squareBorder).BorderThickness = new Thickness(0,0,0,0);
                SelectedBorderName = "";
            }
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

        private void StartNewGame(object sender, RoutedEventArgs e)
        {
            GameController.SetupGame();
            GameController.StartGame();
        }
    }
}
