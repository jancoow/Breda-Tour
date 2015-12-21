using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Breda_Tour.CustomControls
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DefaultPivotControl : UserControl
    {

        public enum Tab
        {
            RouteSelected,
            Map,
            Settings
        }

        public void SetCheckedButton(Tab selected)
        {
            switch (selected)
            {
                case Tab.Map:
                    MapRadioButton.IsChecked = true;
                    break;
                case Tab.RouteSelected:
                    RouteSelectRadioButton.IsChecked = true;
                    break;
                case Tab.Settings:
                    SettingsRadioButton.IsChecked = true;
                    break;
            }
        }

        public DefaultPivotControl()
        {
            this.InitializeComponent();
        }

        private void RouteSelectRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void MapRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
