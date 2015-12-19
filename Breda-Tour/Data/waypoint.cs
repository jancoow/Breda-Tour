using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breda_Tour.Data
{
    class Waypoint
    {
        public float Lat { get; private set; }
        public float Long { get; private set; }
        public String Title { get; private set; }
        public String Description { get; private set; }

        public Waypoint(float Lat, float Long, String Title, String Description)
        {
            this.Lat = Lat;
            this.Long = Long;
            this.Title = Title;
            this.Description = Description;
        }
    }
}
