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
        }

        /// <author>Jannick van Ballegooijen</author>
        /// <desc>Temporary method to navigate to the main screen</desc>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            f.Navigate(typeof(MainPage));
        }
        
    }
}
