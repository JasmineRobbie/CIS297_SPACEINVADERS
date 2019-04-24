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
        }

        private void Canvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            play.DrawGame(args.DrawingSession);
        }
    }
}
