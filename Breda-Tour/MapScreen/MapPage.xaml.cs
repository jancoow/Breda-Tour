﻿using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls.Maps;
using Breda_Tour.CustomControls;
using Windows.Devices.Geolocation.Geofencing;
using Windows.UI.Xaml;
using Breda_Tour.Data;
using Breda_Tour.RouteSelectScreen;

namespace Breda_Tour.MapScreen
{
    public sealed partial class MapPage : Page
    {
        private MapIcon marker;
        private Gps gps;
        private Route route;

        public MapPage()
        {
            GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChange;
            this.NavigationCacheMode = NavigationCacheMode.Enabled;
            marker = new MapIcon();
            marker.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Marker.png"));
            marker.NormalizedAnchorPoint = new Point(0.5, 0.5);
            gps = new Gps(this);
            gps.Start();
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppViewBackButtonVisibility.Collapsed;
            DefaultPivot.SetCheckedButton(DefaultPivotControl.Tab.Map);
            if (RouteExample.fromRouteExamp)
            {
                RouteExample.fromRouteExamp = false;
                route = e.Parameter as Route;
                Map.MapElements.Clear();
                gps.History.Clear();
                gps.Refresh();
                ShowWaypoints(route);
                ShowRoute();
            }
        }

        public async void ShowLocaton(Geopoint _point)
        {
            Geopoint point = _point;
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Map.Center = point;
                if (!Map.MapElements.Contains(marker))
                {
                    Map.MapElements.Add(marker);
                }
                marker.Location = point;
            });
            await Map.TrySetViewAsync(point, 17);
        }

        private async void ShowRoute()
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Map.Routes.Add(RouteExample.routeView);
            });
        }

        private async void ShowWaypoints(Route route)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                GeofenceMonitor.Current.Geofences.Clear();
                for (int x = 0; x < route.Waypoints.Count; x++)
                {
                    //Waypoints handeling
                    Waypoint wayp = route.Waypoints.ElementAt(x);
                    MapIcon wp = new MapIcon { Location = wayp.Position, Title = (x + 1).ToString(), Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/poi.png")) };
                    Map.MapElements.Add(wp);
                    //Geofencing handeling
                    string name = (x + 1).ToString();
                    if (name == "45")
                    {
                        GeofenceMonitor.Current.Geofences.Add(new Geofence(name,
                            new Geocircle(wayp.Position.Position, 25),
                            MonitoredGeofenceStates.Entered, false, TimeSpan.FromSeconds(3)));
                    }
                    else
                    {
                        GeofenceMonitor.Current.Geofences.Add(new Geofence(name, new Geocircle(wayp.Position.Position, 25),
                        MonitoredGeofenceStates.Entered, true, TimeSpan.FromSeconds(3)));
                    }
                }
            });
        }

        private void Map_OnMapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            MapIcon Icon = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;
            for (int x = 0; x < route.Waypoints.Count; x++)
            {
                if (Icon.Title != "")
                {
                    if (x + 1 == int.Parse(Icon.Title))
                    {
                        MainPage.RootFrame.Navigate(typeof(WpDetailPage), new Tuple < Waypoint, Route >(route.Waypoints.ElementAt(x), route));
                    }
                }
            }
        }

        public async void DrawWalkingPath(List<BasicGeoposition> positions)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                MapPolyline mapPolyline = new MapPolyline();
                mapPolyline.StrokeColor = Colors.Blue;
                mapPolyline.StrokeThickness = 3;
                mapPolyline.Path = new Geopath(positions);
                Map.MapElements.Add(mapPolyline);
            });
        }

        private async void OnGeofenceStateChange(GeofenceMonitor sender, object args)
        {
            var reports = sender.ReadReports();
            foreach (GeofenceStateChangeReport report in reports)
            {
                GeofenceState state = report.NewState;
                Geofence geofence = report.Geofence;

                if (state == GeofenceState.Entered)
                {
                    foreach (var waypoint in route.Waypoints)
                    {
                        int index = waypoint.Title.IndexOf(".");
                        string number = "";
                        if (index > 0)
                        {
                            number = waypoint.Title.Substring(0, index);
                        }
                        if (geofence.Id == number)
                        {
                            new Notification("Waypoint", waypoint.Title);
                        }
                    }
                    if (geofence.Id == "45")
                    {
                        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                        {
                            ButtonPanel.Visibility = Visibility.Visible;
                        });
                    }
                }
            }
        }

        private void YesButton_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Visibility = Visibility.Collapsed;
            MainPage.RootFrame.Navigate(typeof (RouteSelectPage));
            Map.MapElements.Clear();
            Map.Routes.Clear();
            gps.History.Clear();
        }

        private void NoButton_OnClick(object sender, RoutedEventArgs e)
        {
            ButtonPanel.Visibility = Visibility.Collapsed;
        }
    }
}
