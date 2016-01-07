using System;
using Breda_Tour;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using System.Threading.Tasks;
using Breda_Tour.SplashScreen;

namespace Breda_Tours.SettingsScreen
{
    public sealed partial class SettingsPage : Page
    {
       public SettingsPage()
        {
            this.InitializeComponent();

            DefaultPivot.SetCheckedButton(Breda_Tour.CustomControls.DefaultPivotControl.Tab.Settings);
        }
		
        private async void listViewItemSetupLanguage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (App.Language == App.Languages[0])
            {
                App.Language = App.Languages[1];
                await Task.Delay(TimeSpan.FromMilliseconds(50));
                MainPage.RootFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                App.Language = App.Languages[0];
                await Task.Delay(TimeSpan.FromMilliseconds(50));
                MainPage.RootFrame.Navigate(typeof(SettingsPage));
            }
        }
        private void listViewItemReset_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(SplashPage));

        }
    }
}
