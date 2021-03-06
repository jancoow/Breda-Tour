﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Breda_Tour.Data
{
    class RouteDatabase
    {
        public List<Route> Routes;
        
        public RouteDatabase()
        {
            Routes = new List<Route>();
            readRoutes();
        }

        private void readRoutes()
        {

            string json = File.ReadAllText("Storage/Routes/routes.json");
            JObject JsonObject = JObject.Parse(json);
            IList<JToken> JsonList = JsonObject["Routes"].ToList();
            foreach (JToken route in JsonList)
            {
                Routes.Add(JsonConvert.DeserializeObject<Route>(route.ToString()));
            }
        }

        public ObservableCollection<Route> GetCurrentRoutes()
        {
            ObservableCollection<Route> routes = new ObservableCollection<Route>();
            foreach (var route in Routes)
            {
                if (route.Language == App.Language)
                    routes.Add(route);
            }
            return routes;
        }
    }
}
