using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Breda_Tour.CustomControls
{
    public sealed partial class DefaultPivotControl : UserControl
    {

        public enum Tab
        {
            RouteSelected,
            Map,
            Settings,
            Help
        }

        public void SetCheckedButton(Tab selected)
        {
            switch (selected)
            {
                case Tab.Map:
                    MapRadioButton.IsChecked = true;
                    break;
                case Tab.RouteSelected:
                    RouteSelectRadioButton.IsChecked = true;
                    break;
                case Tab.Settings:
                    SettingsRadioButton.IsChecked = true;
                    break;
                case Tab.Help:
                    HelpRadioButton.IsChecked = true;
                    break;
            }
        }

        public DefaultPivotControl()
        {
            this.InitializeComponent();
        }

        private void RouteSelectRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.RootFrame.Navigate(typeof(RouteSelectScreen.RouteSelectPage));
        }

        private void MapRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.RootFrame.Navigate(typeof (MapScreen.MapPage));
        }

        private void SettingsRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.RootFrame.Navigate(typeof(Breda_Tours.SettingsScreen.SettingsPage));
        }

        private void HelpRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.RootFrame.Navigate(typeof(HelpScreen.HelpScreenPage));
        }
    }
}
