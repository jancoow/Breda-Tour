using System;
using Windows.UI.Xaml.Data;

namespace Breda_Tour.RouteSelectScreen
{
    class BoolToString : IValueConverter
    {
        private object GetString(object value)
        {
            if (!(value is bool))
                return "ms-appx:///Assets/UitklapIcon1.png";
            bool objValue = (bool)value;
            if (objValue)
            {
                return "ms-appx:///Assets/UitklapIcon2.png";
            }
            return "ms-appx:///Assets/UitklapIcon1.png";
        }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return GetString(value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
