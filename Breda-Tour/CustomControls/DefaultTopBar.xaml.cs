using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Breda_Tour.CustomControls
{
    public sealed partial class DefaultTopBar : UserControl
    {
        public string MySymbol {
            get { return (string)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

            public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("MySymbol", typeof(string), typeof(DefaultTopBar), null);

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(DefaultTopBar), null);

        public DefaultTopBar()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
    }
}
