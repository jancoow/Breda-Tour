using Windows.UI.ViewManagement;

namespace Breda_Tour.Data
{
    public class Picture
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

        public Picture(string source)
        {
            _source = source;
        }
    }
}