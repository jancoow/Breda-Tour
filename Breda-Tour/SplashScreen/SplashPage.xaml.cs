using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Windows.Globalization;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Breda_Tour.SplashScreen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplashPage : Page
    {
        //get current frame
        Frame f = (Frame)Window.Current.Content;

        public SplashPage()
        {
            this.InitializeComponent();
            new Notification("Hallo", "Test");
        }

        /// <author>Jannick van Ballegooijen</author>
        /// <desc>Temporary method to navigate to the main screen</desc>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            f.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// <author>Bart Reedijk</author>
        /// Go to MainPage with English as the language
        /// </summary>
        private void Button_English_Click(object sender, RoutedEventArgs e)
        {
            App.Language = App.Languages[1];
            f.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// <author>Bart Reedijk</author>
        /// Go to MainPage with Dutch as the language
        /// </summary>
        private void Button_Dutch_Click(object sender, RoutedEventArgs e)
        {
            App.Language = App.Languages[0];
            f.Navigate(typeof(MainPage));
        }

    }
}
