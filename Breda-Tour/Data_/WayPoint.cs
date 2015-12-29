using Windows.Devices.Geolocation;

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

        public WayPoint(Geopoint position, string title, int number)
        {
            this._position = position;
            this.title = title;
            this.number = number;
        }

        public WayPoint(double latitude, double longitude, string title, int number)
        {
            _position = new Geopoint(new BasicGeoposition() { Altitude = 0, Latitude = latitude, Longitude = longitude });
            this.title = title;
            this.number = number;
        }

    }
}