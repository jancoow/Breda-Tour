﻿using Breda_Tour.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Breda_Tours.SettingsScreen;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Breda_Tour.MapScreen;
using Breda_Tour.RouteSelectScreen;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Breda_Tour
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static Frame f;

        public MainPage()
        {
            this.InitializeComponent();
            f = this.rootFrame;
            f.Navigate(typeof(RouteSelectPage));
        }

        public static Frame RootFrame {
            get { return f; }
        }

    }
}
