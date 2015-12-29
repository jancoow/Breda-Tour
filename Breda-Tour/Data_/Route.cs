using System.Collections.Generic;
using System.Linq;

namespace Breda_Tour.Data_
{
    public class Route
    {
        private string _name;
        private string description;
        private List<WayPoint> _wayPoints;
        public List<WayPoint> WayPoints
        {
            get { return _wayPoints; }
        }

        public Route(string name, string description)
        {
            _name = name;
            this.description = description;
            _wayPoints = new List<WayPoint>();
        }

        public void Add(WayPoint waypoint)
        {
            _wayPoints.Add(waypoint);
        }

        public WayPoint Get(int index)
        {
            return _wayPoints.ElementAt(index);
        }

        public void Remove(WayPoint waypoint)
        {
            _wayPoints.Remove(waypoint);
        }

        public void CreateTestWaypoints()
        {
            _wayPoints.Add(new WayPoint(51.530805, 4.498676, "Test1", 1));
            _wayPoints.Add(new WayPoint(51.533461, 4.492711, "Test2", 2));
            _wayPoints.Add(new WayPoint(51.536998, 4.477862, "Test3", 3));
            _wayPoints.Add(new WayPoint(51.531285, 4.475394, "Test4", 4));
            _wayPoints.Add(new WayPoint(51.531566, 4.466747, "Test5", 5));
        }
    }
}