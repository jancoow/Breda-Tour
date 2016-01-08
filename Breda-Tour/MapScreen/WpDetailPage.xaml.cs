using System;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Breda_Tour.Data;
using Breda_Tour.RouteSelectScreen;

namespace Breda_Tour.MapScreen
{
    public sealed partial class WpDetailPage : Page
    {
        private Waypoint wp;
        private Route route;
        public double Width { get; }

        public WpDetailPage()
        {
            this.InitializeComponent();
            Width = ApplicationView.GetForCurrentView().VisibleBounds.Width;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Tuple<Waypoint, Route> t = (Tuple < Waypoint, Route>) e.Parameter;
            wp = t.Item1;
            route = t.Item2;
            this.DataContext = wp;
            if (wp.FromPreview)
            {
                SystemNavigationManager.GetForCurrentView().BackRequested += RouteExample_BackRequested;
            }
            else
            {
                SystemNavigationManager.GetForCurrentView().BackRequested += MainPage_BackRequested;
            }
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            wp.FromPreview = false;
        }

        private void RouteExample_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            SystemNavigationManager.GetForCurrentView().BackRequested -= RouteExample_BackRequested;
            MainPage.RootFrame.Navigate(typeof(RouteExample), route);
        }

        private void MainPage_BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            SystemNavigationManager.GetForCurrentView().BackRequested -= MainPage_BackRequested;
            MainPage.RootFrame.Navigate(typeof(MapPage));
        }

        private void Image_PointerPressed(object sender, TappedRoutedEventArgs e)
        {
            Image i = (Image)sender;
            MainPage.RootFrame.Navigate(typeof(ImageViewPage), new Tuple<ImageSource, Waypoint>(i.Source, wp));
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}

