using Windows.UI.ViewManagement;

namespace Breda_Tour.Data_
{
    public class Image
    {
        private string _source;

        public string Source
        {
            get { return _source; }
        }

        public double Width
        {
            get { return ApplicationView.GetForCurrentView().VisibleBounds.Width; }
        }

        public Image(string source)
        {
            _source = source;
        }
    }
}