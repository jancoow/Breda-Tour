﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Breda_Tour.Data
{
    class RouteDatabase
    {
        private List<Route> Routes;
        
        public RouteDatabase()
        {
            Routes = new List<Route>();
            readRoutes();
        }

        private void readRoutes()
        {
            Task.Run(() =>
            {
                string json = File.ReadAllText("Storage/Routes/routes.json");
                JObject JsonObject = JObject.Parse(json);
                IList<JToken> JsonList = JsonObject["Routes"].ToList();
                foreach (JToken route in JsonList){
                   Routes.Add(JsonConvert.DeserializeObject<Route>(route.ToString()));
                }
        });
        }
    }
}