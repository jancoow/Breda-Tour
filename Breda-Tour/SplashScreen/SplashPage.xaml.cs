using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Breda_Tour.SplashScreen
{
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
