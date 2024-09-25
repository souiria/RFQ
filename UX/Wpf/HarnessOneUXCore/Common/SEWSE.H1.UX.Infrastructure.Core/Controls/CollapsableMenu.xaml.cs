using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SEWSE.H1.UX.Infrastructure.Core.Controls
{
    /// <summary>
    /// Interaction logic for CollapsableMenu.xaml
    /// </summary>
    public partial class CollapsableMenu : ContentControl
    {
        public static DependencyProperty IconProperty;
        public static DependencyProperty HeaderProperty;
        public static DependencyProperty IsExpandedProperty;

        static CollapsableMenu()
        {
            IconProperty = DependencyProperty.Register("Icon", typeof(BitmapImage), typeof(CollapsableMenu));
            HeaderProperty = DependencyProperty.Register("Header", typeof(string), typeof(CollapsableMenu));
            IsExpandedProperty = DependencyProperty.Register("IsExpanded", typeof(bool), typeof(CollapsableMenu), new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        }
    
        public CollapsableMenu()
        {
            InitializeComponent();
        }

        [Bindable(true)]
        public string Header
        {
            get => (string)base.GetValue(HeaderProperty);
            set => base.SetValue(HeaderProperty, value);
        }

        [Bindable(true)]
        public BitmapImage Icon
        {
            get => (BitmapImage)base.GetValue(IconProperty);
            set => base.SetValue(IconProperty, value);
        }

        [Bindable(true)]
        public bool IsExpanded
        {
            get => (bool)base.GetValue(IsExpandedProperty);
            set => base.SetValue(IsExpandedProperty, value);
        }
    }
}
