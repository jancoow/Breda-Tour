﻿using System;
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
        public ObservableCollection<HelpItem> HelpItems
        {
            get { return (ObservableCollection<HelpItem>)GetValue(HelpItemProperty); }
            set { SetValue(HelpItemProperty, value); }
        }

        public static readonly DependencyProperty HelpItemProperty =
        DependencyProperty.Register("HelpItems", typeof(ObservableCollection<HelpItem>), typeof(SettingsPage), null);

        public SettingsPage()
        {
            this.InitializeComponent();

            DefaultPivot.SetCheckedButton(Breda_Tour.CustomControls.DefaultPivotControl.Tab.Settings);
            HelpPageDatabase helpDatabase = new HelpPageDatabase();
            HelpItems = helpDatabase.HelpItems;
            
            DataContext = this;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            HelpItem helpitem = (HelpItem)e.ClickedItem;
            MainPage.RootFrame.Navigate(typeof(HelpPage), helpitem);
		}
		
        private void listViewItemSetupLanguage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (App.Language == "nl-NL")
            {
                App.Language = "en-US";
                ApplicationLanguages.PrimaryLanguageOverride = "en-US";
                Debug.WriteLine("my language is:" + ApplicationLanguages.ManifestLanguages.First());
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                App.Language = "nl-NL";
                ApplicationLanguages.PrimaryLanguageOverride = "nl-NL";
                Debug.WriteLine("my language is:" + ApplicationLanguages.ManifestLanguages.First());
                Frame.Navigate(typeof(MainPage));
            }
        }
    }
}
