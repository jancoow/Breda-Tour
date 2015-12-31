using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace Breda_Tour.Data
{
    class Waypoint
    {
        public float Lat { get; private set; }
        public float Long { get; private set; }
        public String Title { get; private set; }
        public String Description { get; private set; }
        public List<Image> Photos { get; private set; }

        public Waypoint(float Lat, float Long, String Title, String Description, List<string> pictures)
        {
            this.Lat = Lat;
            this.Long = Long;
            this.Title = Title;
            this.Description = Description;
            this.Photos = new List<Image>();
            if (pictures != null)
            {
                Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    foreach (string source in pictures)
                    {
                        Photos.Add(new Image
                        {
                            Source = new BitmapImage(new Uri("file://Storages/images/" + source)),
                            Name = source
                        });
                    }
                    foreach (Image i in Photos)
                    {
                        System.Diagnostics.Debug.WriteLine(i.Name);
                    }
                });
            }
        }
    }
}
