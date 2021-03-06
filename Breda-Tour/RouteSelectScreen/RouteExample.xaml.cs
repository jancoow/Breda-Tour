﻿using Breda_Tour.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;
using Breda_Tour.MapScreen;

namespace Breda_Tour.RouteSelectScreen
{
    public sealed partial class RouteExample : Page
    {
        Route route;
        public string WaypointsText { get; set; }
        public string RouteTijdText { get; set; }
        public string LoopafstandText { get; set; }
        public static bool fromRouteExamp;
        public static MapRouteView routeView;

        public RouteExample()
        {
            MapService.ServiceToken =
                "P4P2fAwXuk7ndsVIsaaV~uYjur55RgwmLsiwFwd72bQ~ApDRixf1L-0o_kMY8EtBBDm8xe7G2oz1k2-u0HQIATvSp-iiKr5KLNkYc1HF5D5e";
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        
            route = e.Parameter as Route;
            ShowRouteInfo();
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
            fromRouteExamp = true;
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
            Debug.Write("Finder status: " + finder.Status);
            if (finder.Status == MapRouteFinderStatus.Success)
            {
                //Create route for mapPage
                routeView = new MapRouteView(finder.Route);
                routeView.RouteColor = Colors.Firebrick;
                routeView.OutlineColor = Colors.Black;
                //route duration
                int tijd = ((int) finder.Route.EstimatedDuration.TotalMinutes);
                RouteTijdText = $"Tijdsduur: {tijd} min";
                RouteBlok.Text = RouteTijdText;
                //Route distance
                LoopafstandText = $"Loopafstand: {(Convert.ToInt32(finder.Route.LengthInMeters/1000))} km";
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
            Tuple<Waypoint, Route> t = new Tuple<Waypoint, Route>(wp, route);
            MainPage.RootFrame.Navigate(typeof(WpDetailPage),t);
        }
    }
}
