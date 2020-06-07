using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Диалоговое окно содержимого" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace TicTacUWP
{
    public sealed partial class About : ContentDialog
    {
        DispatcherTimer dispatcherTimer;

        int text1Offset = -20;
        bool text1Right = true;
        int text2Offset = -10;
        bool text2Right = true;
        int text3Offset = 0;
        bool text3Right = true;
        int text4Offset = 10;
        bool text4Right = true;
        int text5Offset = 20;
        bool text5Right = false;

        public About()
        {
            this.InitializeComponent();
            setMargins();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimerSetup();
        }

        public void DispatcherTimerSetup()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 5);
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            checkDirections();
            if(text1Right)
            {
                text1Offset += 1;
            }
            else
            {
                text1Offset -= 1;
            }
            if(text2Right)
            {
                text2Offset += 1;
            }
            else
            {
                text2Offset -= 1;
            }
            if(text3Right)
            {
                text3Offset += 1;
            }
            else
            {
                text3Offset -= 1;
            }
            if(text4Right)
            {
                text4Offset += 1;
            }
            else
            {
                text4Offset -= 1;
            }
            if(text5Right)
            {
                text5Offset += 1;
            }
            else
            {
                text5Offset -= 1;
            }
            setMargins();
        }

        void checkDirections()
        {
            if(text1Right && text1Offset >= 20)
            {
                text1Right = false;
            }
            else if(!text1Right && text1Offset <= -20)
            {
                text1Right = true;
            }
            if(text2Right && text2Offset >= 20)
            {
                text2Right = false;
            }
            else if(!text2Right && text2Offset <= -20)
            {
                text2Right = true;
            }
            if(text3Right && text3Offset >= 20)
            {
                text3Right = false;
            }
            else if(!text3Right && text3Offset <= -20)
            {
                text3Right = true;
            }
            if(text4Right && text4Offset >= 20)
            {
                text4Right = false;
            }
            else if(!text4Right && text4Offset <= -20)
            {
                text4Right = true;
            }
            if(text5Right && text5Offset >= 20)
            {
                text5Right = false;
            }
            else if(!text5Right && text5Offset <= -20)
            {
                text5Right = true;
            }
        }
        void setMargins()
        {
            TextRow1.Margin = new Thickness(text1Offset, 0, 0, 0);
            TextRow2.Margin = new Thickness(text2Offset, 0, 0, 0);
            TextRow3.Margin = new Thickness(text3Offset, 0, 0, 0);
            TextRow4.Margin = new Thickness(text4Offset, 0, 0, 0);
            TextRow5.Margin = new Thickness(text5Offset, 0, 0, 0);
        }
    }
}
