using System;
using System.Collections.Generic;
using Windows.Devices.AllJoyn;
using Windows.Devices.Geolocation;
using Windows.System;
using Windows.UI.Xaml;
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
        private List<Geoposition> _history;
        public List<Geoposition> History
        {
            get { return _history; }
        }

        private PositionStatus _status;
        public PositionStatus Status
        {
            get { return _status; }
        }

        public Gps(MapPage mapPage)
        {
            _history = new List<Geoposition>();
            this.mapPage = mapPage;
        }

        public async void Start()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();

            switch (accessStatus)
            {
                case GeolocationAccessStatus.Allowed:
                    geolocator = new Geolocator { DesiredAccuracyInMeters = 5, MovementThreshold = 2 };
                    // Subscribe events
                    geolocator.StatusChanged += OnStatusChanged;
                    geolocator.PositionChanged += OnPositionChanged;
                    // Get position
                    _position = await geolocator.GetGeopositionAsync();
                    break;
                case GeolocationAccessStatus.Denied:
                    _status = PositionStatus.NotAvailable;
                    bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
                    break;
                case GeolocationAccessStatus.Unspecified:
                    _status = PositionStatus.NotAvailable;
                    break;
            }
        }

        private void OnPositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            mapPage.ShowLocaton(args.Position.Coordinate.Point);
            _position = args.Position;
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
            if (geolocator == null)
            {
                Start();
            }
            else
            {
                _position = await geolocator.GetGeopositionAsync();
            }
        }
    }
}