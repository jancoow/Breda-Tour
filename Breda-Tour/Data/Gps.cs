using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Devices.AllJoyn;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;
using Breda_Tour.MapScreen;

namespace Breda_Tour.Data
{
    public class Gps
    {
        private MapPage mapPage;
        private Geolocator geolocator;

        private Geoposition _position;
        public Geoposition Position
        {
            get { return _position; }
        }

        public List<BasicGeoposition> History { get; set; }


        private PositionStatus _status;
        public PositionStatus Status
        {
            get { return _status; }
        }

        public Gps(MapPage mapPage)
        {
            History = new List<BasicGeoposition>();
            this.mapPage = mapPage;
        }

        public async void Start()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    geolocator = new Geolocator{DesiredAccuracy = PositionAccuracy.High,MovementThreshold = 3};
                    // Subscribe events
                    geolocator.StatusChanged += OnStatusChanged;
                    geolocator.PositionChanged += OnPositionChanged;
                    // Get position
                    _position = await geolocator.GetGeopositionAsync();
                    break;
                case GeolocationAccessStatus.Denied:
                    _status = PositionStatus.NotAvailable;
                    geolocator = null;
                    bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
                    Start();
                    break;
                case GeolocationAccessStatus.Unspecified:
                    _status = PositionStatus.NotAvailable;
                    break;
            }
        }

        private void OnPositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            _position = args.Position;
            mapPage.ShowLocaton(_position.Coordinate.Point);
            //For route history line
            BasicGeoposition BasicG = _position.Coordinate.Point.Position;
            History.Add(BasicG);
            if (History.Count >= 2)
            {
                mapPage.DrawWalkingPath(History);
            }
        }

        private void OnStatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            if (args.Status == PositionStatus.Disabled)
            {
                _position = null;
            }
        }

        public async void Refresh()
        {
            if (geolocator != null)
            {
                _position = await geolocator.GetGeopositionAsync();
                mapPage.ShowLocaton(_position.Coordinate.Point);
            }
        }
    }
}