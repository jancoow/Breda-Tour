using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;

namespace Breda_Tour.Data_
{
    public class WayPoint
    {
        private Geopoint _position;
        public Geopoint Position
        {
            get { return _position; }
        }

        private string title;
        public string description { get; set; }
        public int number;
        private Image image;

        public Image Image
        {
            get { return image; }
        }

        public WayPoint(Geopoint position, string title, int number, Image image)
        {
            this._position = position;
            this.title = title;
            this.number = number;
            this.image = image;
        }

        public WayPoint(double latitude, double longitude, string title, int number, Image image)
        {
            _position = new Geopoint(new BasicGeoposition() { Altitude = 0, Latitude = latitude, Longitude = longitude });
            this.title = title;
            this.number = number;
            this.image = image;
        }

    }
}