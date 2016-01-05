using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breda_Tour.Data
{ 

    public class HelpPageDatabase
    {
        public ObservableCollection<HelpItem> HelpItems;
        public HelpPageDatabase()
        {
            HelpItems = new ObservableCollection<HelpItem>();
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
