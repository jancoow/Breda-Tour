using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Breda_Tour.Data
{
    class RouteDatabase
    {
        public List<Route> Routes;
        
        public RouteDatabase()
        {
            Routes = new List<Route>();
            //readRoutes();
        }

        public void readRoutes()
        {
            //Task.Run(() =>
           // {
                string json = File.ReadAllText("Storage/Routes/routes.json");
                JObject JsonObject = JObject.Parse(json);
                IList<JToken> JsonList = JsonObject["Routes"].ToList();
                foreach (JToken route in JsonList){
                   Routes.Add(JsonConvert.DeserializeObject<Route>(route.ToString()));
                    Debug.Write($"Routes toegevoegd: groote is: {Routes.Count}");
                }
       // });
        }
    }
}
