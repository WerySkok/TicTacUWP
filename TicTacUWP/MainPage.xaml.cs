using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace TicTacUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int[,] gameArea = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        bool whoPlays = true; // true = first player, false = second player
        bool gameEnded = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        void SetMark(int x, int y)
        {
            if(gameArea[x, y] == 0 && gameEnded == false)
            {
                if(whoPlays)
                {
                    gameArea[x, y] = 1;
                    Button clickedButton = this.FindName("Button" + x + y) as Button;
                    clickedButton.Content = new Image { Source = new BitmapImage { UriSource = new Uri("ms-appx:///Assets/x.bmp") }  };
                    SetStatusBarText("O player's turn.");
                    whoPlays = false;
                }
                else
                {
                    gameArea[x, y] = 2;
                    Button clickedButton = this.FindName("Button" + x + y) as Button;
                    clickedButton.Content = new Image { Source = new BitmapImage { UriSource = new Uri("ms-appx:///Assets/o.bmp") } };
                    SetStatusBarText("X player's turn.");
                    whoPlays = true;
                }
                CheckForWinner();
            }
        }

        void CheckForWinner()
        {
            for(int i = 1; i <= 2; i++)
            {
                if(gameArea[0,0] == i && gameArea[0,1] == i && gameArea[0,2] == i ||
                    gameArea[1,0] == i && gameArea[1,1] == i && gameArea[1,2] == i ||
                    gameArea[2,0] == i && gameArea[2,1] == i && gameArea[2,2] == i ||
                    gameArea[0,0] == i && gameArea[1,1] == i && gameArea[2,2] == i ||
                    gameArea[0,2] == i && gameArea[1,1] == i && gameArea[2,0] == i ||
                    gameArea[0,0] == i && gameArea[1,0] == i && gameArea[2,0] == i ||
                    gameArea[0,1] == i && gameArea[1,1] == i && gameArea[2,1] == i ||
                    gameArea[0,2] == i && gameArea[1,2] == i && gameArea[2,2] == i)
                {
                    string winner;
                    if(i == 1)
                    {
                        winner = "X is the winner!";
                    }
                    else
                    {
                        winner = "O is the winner!";
                    }
                    SetStatusBarText("Start a new game.");
                    new ContentDialog { Title = "Tic-Tac-Toe", Content = winner, PrimaryButtonText = "OK", Width=218 }.ShowAsync();
                    gameEnded = true;
                }
            }
        }

        void SetStatusBarText(string text)
        {
            StatusBar.Text = text;
        }

        private void Button00_Click(object sender, RoutedEventArgs e)
        {
            SetMark(0, 0);
        }

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            SetMark(0, 1);
        }

        private void Button02_Click(object sender, RoutedEventArgs e)
        {
            SetMark(0, 2);
        }

        private void Button10_Click(object sender, RoutedEventArgs e)
        {
            SetMark(1, 0);
        }

        private void Button11_Click(object sender, RoutedEventArgs e)
        {
            SetMark(1, 1);
        }

        private void Button12_Click(object sender, RoutedEventArgs e)
        {
            SetMark(1, 2);
        }

        private void Button20_Click(object sender, RoutedEventArgs e)
        {
            SetMark(2, 0);
        }

        private void Button21_Click(object sender, RoutedEventArgs e)
        {
            SetMark(2, 1);
        }

        private void Button22_Click(object sender, RoutedEventArgs e)
        {
            SetMark(2, 2);
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            ClearGameArea();
        }

        void ClearGameArea()
        {
            gameArea = new [,]{ { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            gameEnded = false;
            for(int i = 0; i <= 2; i++)
            {
                for(int a = 0; a <= 2; a++)
                {
                    Button ChosenButton = this.FindName("Button" + a + i) as Button;
                    ChosenButton.Content = null;
                }
            }
            if(whoPlays)
                SetStatusBarText("X player's turn.");
            else
                SetStatusBarText("O player's turn.");
        }
    }
}
