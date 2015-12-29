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
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Shapes;
using Breda_Tour.Data_;

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

        public MapPage()
        {
            marker = new MapIcon();
            marker.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Marker.png"));
            marker.NormalizedAnchorPoint = new Point(0.5, 0.5);
            gps = new Gps(this);
            gps.Start();
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
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
            await Map.TrySetViewAsync(point, 15);
        }
    }
}
