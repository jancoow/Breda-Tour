using Windows.UI.Xaml.Controls;
using System;
using Windows.UI.Core;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Breda_Tour.Data;

namespace Breda_Tour.MapScreen
{
    public sealed partial class ImageViewPage : Page
    {
        Waypoint previouswaypoint;
        public ImageViewPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Tuple<ImageSource, Waypoint> parameters = (Tuple<ImageSource, Waypoint>)e.Parameter;
            this.Image.Source = parameters.Item1;
            previouswaypoint = parameters.Item2;
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            SystemNavigationManager.GetForCurrentView().BackRequested -= MainPage_BackRequested;
            MainPage.RootFrame.Navigate(typeof (WpDetailPage), previouswaypoint);
        }
    }
}
