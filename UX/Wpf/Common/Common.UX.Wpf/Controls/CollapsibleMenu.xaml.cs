using System.ComponentModel;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Common.UX.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for CollapsibleMenu.xaml
    /// </summary>
    public partial class CollapsibleMenu
    {
        public static DependencyProperty IconProperty;
        public static DependencyProperty HeaderProperty;
        public static DependencyProperty IsExpandedProperty;

        static CollapsibleMenu()
        {
            IconProperty = DependencyProperty.Register("Icon", typeof(BitmapImage), typeof(CollapsibleMenu));
            HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(CollapsibleMenu));
            IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(CollapsibleMenu), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        }
    
        public CollapsibleMenu()
        {
            InitializeComponent();
        }

        [Bindable(true)]
        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        [Bindable(true)]
        public BitmapImage Icon
        {
            get => (BitmapImage)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        [Bindable(true)]
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }
    }
}
