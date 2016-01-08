using Breda_Tour.Data;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Breda_Tour.HelpScreen
{
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
