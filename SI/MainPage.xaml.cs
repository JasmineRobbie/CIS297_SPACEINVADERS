using Microsoft.Graphics.Canvas.UI.Xaml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SI
{

    public sealed partial class MainPage : Page
    {
        Play play;

        public MainPage()
        {
            this.InitializeComponent();
            play = new Play();

            Window.Current.CoreWindow.KeyDown += Canvas_KeyDown;
            Window.Current.CoreWindow.KeyUp += Canvas_KeyUp;
        }

        private void Canvas_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            play.DrawGame(args.DrawingSession);
        }

        private void Canvas_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
        {
            if(e.VirtualKey == Windows.System.VirtualKey.Left)
            {
                play.SetPaddleTravelingLeftward(true);
            }
            else if(e.VirtualKey == Windows.System.VirtualKey.Right)
            {
                play.SetPaddleTravelingLeftward(true);
            }
        }

        private void Canvas_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs e)
        {
            if (e.VirtualKey == Windows.System.VirtualKey.Left)
            {
                play.SetPaddleTravelingLeftward(false);
            }
            else if (e.VirtualKey == Windows.System.VirtualKey.Right)
            {
                play.SetPaddleTravelingLeftward(false);
            }
        }

        private void Canvas_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        {
            play.Update();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
