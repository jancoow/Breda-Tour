using Breda_Tour.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class HelpScreenPage : Page
    {
        public ObservableCollection<HelpItem> HelpItems
        {
            get { return (ObservableCollection<HelpItem>)GetValue(HelpItemProperty); }
            set { SetValue(HelpItemProperty, value); }
        }
        public static readonly DependencyProperty HelpItemProperty =
        DependencyProperty.Register("HelpItems", typeof(ObservableCollection<HelpItem>), typeof(HelpScreenPage), null);


        public HelpScreenPage()
        {
            this.InitializeComponent();
            DefaultPivot.SetCheckedButton(Breda_Tour.CustomControls.DefaultPivotControl.Tab.Help);
            HelpPageDatabase helpDatabase = new HelpPageDatabase();
            HelpItems = helpDatabase.GetCurrentHelpItems();

            DataContext = this;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            HelpItem helpitem = (HelpItem)e.ClickedItem;
            MainPage.RootFrame.Navigate(typeof(HelpPage), helpitem);
        }
    }
}
