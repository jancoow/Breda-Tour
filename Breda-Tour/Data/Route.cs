using System;
using System.Collections.Generic;

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
