using Windows.Devices.Geolocation;

namespace Breda_Tour.Data_
{
    public class WayPoint
    {
        private Geopoint position;
        private string title;
        public string description { get; set; }
        public int number;

        public WayPoint(Geopoint position, string title, int number)
        {
            this.position = position;
            this.title = title;
            this.number = number;
        }

        public WayPoint(double latitude, double longitude, string title, int number)
        {
            position = new Geopoint(new BasicGeoposition() { Altitude = 0, Latitude = latitude, Longitude = longitude });
            this.title = title;
            this.number = number;
        }

    }
}