using System;
using System.Collections.Generic;

namespace Breda_Tour.Data
{
    public class Route
    {
        public String Title { get; private set; }

        public String Language { get; private set; }

        private List<Waypoint> _waypoints;
        public List<Waypoint> Waypoints
        {
            get { return _waypoints; }
        }

        public Route(String Language, String Title, List<Waypoint> Waypoints)
        {
            this.Language = Language;
            this.Title = Title;
            this._waypoints = Waypoints;
        }

    }
}
