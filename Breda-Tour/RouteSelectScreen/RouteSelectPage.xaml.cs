using Breda_Tour.Data;
using System.Collections.ObjectModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Breda_Tour.RouteSelectScreen
{
    public sealed partial class RouteSelectPage : Page
    {
        RouteDatabase AllRoutes;

        public ObservableCollection<Route> CurrentRoutes
        {
            get { return (ObservableCollection<Route>)GetValue(HelpItemProperty); }
            set { SetValue(HelpItemProperty, value); }
        }
        public static readonly DependencyProperty HelpItemProperty =
        DependencyProperty.Register("CurrentRoutes", typeof(ObservableCollection<Route>), typeof(RouteSelectPage), null);

        public RouteSelectPage()
        {
            AllRoutes = new RouteDatabase();
            CurrentRoutes = AllRoutes.GetCurrentRoutes();
            this.InitializeComponent();
            DefaultPivot.SetCheckedButton(CustomControls.DefaultPivotControl.Tab.RouteSelected);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            CurrentRoutes = AllRoutes.GetCurrentRoutes();
        }

        private void Routes_ItemClick(object sender, ItemClickEventArgs e)
        {
            Route route = e.ClickedItem as Route;
            MainPage.RootFrame.Navigate(typeof(RouteExample), route);
        }

        private void Page_GotFocus(object sender, RoutedEventArgs e)
        {
            CurrentRoutes = AllRoutes.GetCurrentRoutes();
        }
    }
}