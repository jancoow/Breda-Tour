using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breda_Tour.Data
{
    class Route
    {
        public String Title {  get; private set; }
        public List<Waypoint> Waypoints { get; private set; }

        public Route(String Title, List<Waypoint> Waypoints)
        {
            this.Title = Title;
            this.Waypoints = Waypoints;
        }


    }
}
