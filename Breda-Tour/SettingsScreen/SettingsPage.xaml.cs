using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Breda_Tour;

using Breda_Tour.HelpScreen;
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

            HelpItems = new ObservableCollection<HelpItem>();
            for (int i = 0; i < 10; i++)
                HelpItems.Add(new HelpItem
                {
                    Title = "HelpItem" + i
                });
            DataContext = this;
        }

    }
}
