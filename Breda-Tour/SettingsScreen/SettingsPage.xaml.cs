using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Breda_Tour;

using Breda_Tour.HelpScreen;
using Breda_Tour.Data;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Globalization;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Breda_Tours.SettingsScreen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
     public SettingsPage()
        {
            this.InitializeComponent();
            DefaultPivot.SetCheckedButton(Breda_Tour.CustomControls.DefaultPivotControl.Tab.Settings);
        }


		
        private void listViewItemSetupLanguage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (App.Language == App.Languages[0])
            {
                App.Language = App.Languages[1];
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                App.Language = App.Languages[0];
                Frame.Navigate(typeof(MainPage));
            }
        }
    }
}
