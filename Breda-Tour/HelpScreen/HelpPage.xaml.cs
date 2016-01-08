using Breda_Tour.Data;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace Breda_Tour.HelpScreen
{

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
                if (App.Language == App.Languages[1])
                {
                    PageNumberTextBlock.Text = "Page " + (currentpage + 1) + " of " + helpitem.HelpItemSteps.Count;
                }
                else if (App.Language == App.Languages[0])
                {
                    PageNumberTextBlock.Text = "Pagina " + (currentpage + 1) + " van " + helpitem.HelpItemSteps.Count;
                }
                else
                {
                    PageNumberTextBlock.Text = "Page " + (currentpage + 1) + " of " + helpitem.HelpItemSteps.Count;
                }
            }
        }

        private void Close_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MainPage.RootFrame.Navigate(typeof(HelpScreenPage));
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
