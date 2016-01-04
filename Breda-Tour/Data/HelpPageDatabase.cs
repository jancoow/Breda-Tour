using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breda_Tour.Data
{ 

    class HelpPageDatabase
    {
        private List<HelpItem> HelpItems;
        public HelpPageDatabase()
        {
            HelpItems = new List<HelpItem>();
            readHelpItems();

        }
        private void readHelpItems()
        {
            Task.Run(() =>
            {
                string json = File.ReadAllText("Storage/helpitems/helpitems.json");
                JObject JsonObject = JObject.Parse(json);
                IList<JToken> JsonList = JsonObject["HelpItems"].ToList();
                foreach (JToken helpitem in JsonList)
                {
                    HelpItems.Add(JsonConvert.DeserializeObject<HelpItem>(helpitem.ToString()));
                }
                System.Diagnostics.Debug.WriteLine(HelpItems[0].HelpItemSteps[0].Title);

            });
        }
    }
}
