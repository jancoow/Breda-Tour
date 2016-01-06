using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Shapes;
using Breda_Tour.CustomControls;
using System.Diagnostics;
using Breda_Tour.Data;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Breda_Tour.MapScreen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        private MapIcon marker;
        private Geopoint point;
        private Gps gps;
        private Route route;

        public MapPage()
        {
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
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            DefaultPivot.SetCheckedButton(DefaultPivotControl.Tab.Map);
            if (this.route == null)
            {
                route = e.Parameter as Route;
            }
        }

        public async void ShowLocaton(Geopoint point)
        {
            this.point = point;
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
            ShowWaypoints(route);
            ShowRoute(route);
        }

        public async void ShowRoute(Route route)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                List<Geopoint> geopoints = new List<Geopoint>();
                foreach (Waypoint wayPoint in route.Waypoints)
                {
                    geopoints.Add(wayPoint.Position);
                }
                MapRouteFinderResult finder = await MapRouteFinder.GetWalkingRouteFromWaypointsAsync(geopoints);
                if (finder.Status == MapRouteFinderStatus.Success)
                {
                    MapRouteView routeView = new MapRouteView(finder.Route);
                    routeView.RouteColor = Colors.Firebrick;
                    routeView.OutlineColor = Colors.Black;
                    Map.Routes.Add(routeView);
                }
            });
        }

        public async void ShowWaypoints(Route route)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                for (int x = 0; x < route.Waypoints.Count; x++)
                {
                    Waypoint wayp = route.Waypoints.ElementAt(x);
                    MapIcon wp = new MapIcon { Location = wayp.Position, Title = (x + 1).ToString() };
                    Map.MapElements.Add(wp);
                }
                //foreach (var waypoint in route.WayPoints)
                //{
                //    MapIcon wp = new MapIcon() {Location = waypoint.Position, Title = waypoint.number.ToString()};
                //    Map.MapElements.Add(wp);
                //}
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
                        MainPage.RootFrame.Navigate(typeof (WpDetailPage), route.Waypoints.ElementAt(x));
                    }
                }
            }
            //foreach (var waypoint in route.WayPoints)
            //{
            //    if (Icon.Title != "")
            //    {
            //        if (waypoint.number == int.Parse(Icon.Title))
            //        {
            //            MainPage.RootFrame.Navigate(typeof(WpDetailPage), waypoint);
            //        }
            //    }
            //}
        }
    }
}
