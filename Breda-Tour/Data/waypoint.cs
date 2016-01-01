using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.Devices.Geolocation;

namespace Breda_Tour.Data
{
    public class Waypoint
    {
        private Geopoint _position;
        public Geopoint Position
        {
            get { return _position; }
        }

        public String Title { get; private set; }
        public String Description { get; private set; }
        public List<Picture> Pictures { get; private set; }

        public Waypoint(double Lat, double Long, String Title, String Description, List<string> pictures)
        {
            this._position = new Geopoint(new BasicGeoposition() { Altitude = 0, Latitude = Lat, Longitude = Long });
            this.Title = Title;
            this.Description = Description;
            this.Pictures = new List<Picture>();
            foreach (var imageSource in pictures)
            {
                string newSource = "ms-appx:///Assets/" + imageSource;
                Pictures.Add(new Picture(newSource));
            }
        }
    }
}
