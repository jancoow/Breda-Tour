using Breda_Tour.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Breda_Tour.MapScreen;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Breda_Tour.RouteSelectScreen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RouteExample : Page
    {
        Route route;
        public string WaypointsText { get; set; }
        public string RouteTijdText { get; set; }
        public string LoopafstandText { get; set; }

        public RouteExample()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (route == null)
            {
                route = e.Parameter as Route;
                ShowRouteInfo();
            }
            //Setting the back button functionality
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += BackRequested;
            
        }

        private void BackRequested(object sender, BackRequestedEventArgs e)
        {
            e.Handled = true;
            SystemNavigationManager.GetForCurrentView().BackRequested -= BackRequested;
            MainPage.RootFrame.Navigate(typeof(RouteSelectPage));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainPage.RootFrame.Navigate(typeof(MapPage), route);
        }

        private async void ShowRouteInfo()
        {
            //Setting the x amount of waypoints text
            WaypointsText = "Aantal waypoints: " + 0;
            if (route.Waypoints.Count != 0)
            {
                WaypointsText = "Aantal waypoints: " + route.Waypoints.Count;
            }
            //Setting the Route distance and time text
            List<Geopoint> geopoints = new List<Geopoint>();
            foreach (Waypoint wayPoint in route.Waypoints)
            {
                geopoints.Add(wayPoint.Position);
            }
            MapRouteFinderResult finder = await MapRouteFinder.GetWalkingRouteFromWaypointsAsync(geopoints);
            if (finder.Status == MapRouteFinderStatus.Success)
            {
                //route duration
                int tijd = ((int)finder.Route.EstimatedDuration.TotalMinutes);
                RouteTijdText = $"Tijdsduur: {tijd} min";
                RouteBlok.Text = RouteTijdText;
                //Route distance
                LoopafstandText = $"Loopafstand: {(finder.Route.LengthInMeters/1000)} km";
                Loopblok.Text = LoopafstandText;
                //Waypoint text
                WaypointsBlok.Text = WaypointsText;
                ProgressRing.Visibility = Visibility.Collapsed;
                StartButton.Visibility = Visibility.Visible;
            }
        }

        private void Waypoints_OnItemClick(object sender, ItemClickEventArgs e)
        {
            Waypoint wp = e.ClickedItem as Waypoint;
            wp.FromPreview = true;
            MainPage.RootFrame.Navigate(typeof(WpDetailPage),wp);
        }
    }
}
