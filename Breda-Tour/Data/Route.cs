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

        //public void CreateTestWaypoints()
        //{
        //    _waypoints.Add(new Waypoint(51.530805, 4.498676, "Test1", 1, new Image("ms-appx:///Assets/1.jpg"))); { description = "4. Als u de brug overgaat, ziet u aan uw linkerhand het Nassau-Baroniemonument. Bij de ingang van het stadspark, het Valkenberg, staat een monument dat u iets vertelt over de wordings- geschiedenis van de stad Breda, maar vooral over de Heren van de stad uit het Huis van Nassau en de 500-jarige band tussen Breda en het Huis van Nassau. Op 3 juli 1905 werd het Nassau-Baronie- monument, zoals het officieel heet, met  veel feestelijk vertoon door Koningin Wilhelmina onthuld. Het beeld herinnert aan het feit, dat in 1404 Graaf Engelbert, de eerste Bredase Nassau en zijn gemalin, Johanna van Polanen, werden ingehuldigd als Heer en Vrouwe van Breda. De ontwerper is de welbekende dr. P.J.H. Cuypers, die o.m. het Rijksmuseum en het Centraal Station in Amsterdam ontwierp. Op dit monument zijn niet alleen de wapenschilden van twintig gemeenten in en rond de Baronie aangebracht maar ook de Leeuw van Nassau die boven alles uittorent met koningskroon, zwaard en wapenschild. In de drie reliëfs is de 'blijde incomste' van Graaf Engelbert en zijn gemalin afgebeeld. De poortersbieden de sleutel van de stad aan." });
        //    _waypoints.Add(new Waypoint(51.533461, 4.492711, "Test2", 2, null));
        //    _waypoints.Add(new Waypoint(51.536998, 4.477862, "Test3", 3, null));
        //    _waypoints.Add(new Waypoint(51.531285, 4.475394, "Test4", 4, null));
        //    _waypoints.Add(new Waypoint(51.531566, 4.466747, "Test5", 5, null));
        //}
    }
}
