using Breda_Tour.Data;
using Breda_Tours.SettingsScreen;
using System;
using System.Collections.Generic;
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

namespace Breda_Tour.HelpScreen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HelpPage : Page
    {
        HelpItem helpitem;
        int currentpage;

        public HelpPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            helpitem = ((HelpItem)e.Parameter);
            SetPage(0);
            Topbar.Header = helpitem.Title;
        }

        private void SetPage(int pagenumber)
        {
            if(pagenumber >= 0 && pagenumber < helpitem.HelpItemSteps.Count)
            {
                currentpage = pagenumber;
                this.DataContext = helpitem.HelpItemSteps[currentpage];
                PageNumberTextBlock.Text = "Page " + (currentpage+1) + " of " + helpitem.HelpItemSteps.Count;
            }
        }

        private void Close_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage.RootFrame.Navigate(typeof(SettingsPage));
        }

        private void PageBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SetPage(currentpage - 1);
        }
        private void PageForward_Tapped(object sender, TappedRoutedEventArgs e)
        {
            SetPage(currentpage + 1);
        }
    }
}
