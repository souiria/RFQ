using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for DynamicUniformGrid.xaml
    /// </summary>
    public partial class DynamicUniformGrid : UniformGrid
    {
        public static DependencyProperty DesiredColumnWidthProperty;
        public static DependencyProperty DesiredRowHeightProperty;

        static DynamicUniformGrid()
        {
            DesiredColumnWidthProperty = DependencyProperty.Register("DesiredColumnWidth", typeof(double), typeof(DynamicUniformGrid));
            DesiredRowHeightProperty = DependencyProperty.Register("DesiredRowHeight", typeof(double), typeof(DynamicUniformGrid));
        }

        public DynamicUniformGrid()
        {
            InitializeComponent();
            Loaded += (sender, e) =>
            {
                ((FrameworkElement)VisualTreeHelper.GetParent(this)).SizeChanged += DynamicUniformGrid_SizeChanged;
                DynamicUniformGrid_SizeChanged(null, null);

            };
            Unloaded += (sender, e) =>
            {
                ((FrameworkElement)VisualTreeHelper.GetParent(this)).SizeChanged -= DynamicUniformGrid_SizeChanged;
            };
        }

        private void DynamicUniformGrid_SizeChanged(object sender, RoutedEventArgs e)
        {         
            if (DesiredColumnWidth > 0)
            {
                var parentWidth = (double)VisualTreeHelper.GetParent(this).GetValue(ActualWidthProperty);
                var columns = Math.Floor(parentWidth / DesiredColumnWidth);
                //Width = columns * DesiredColumnWidth;
                Columns = (int)columns;
            }

            if (DesiredRowHeight > 0)
            {
                var parentHeight = (double)VisualTreeHelper.GetParent(this).GetValue(ActualHeightProperty);
                var rows = Math.Floor(parentHeight / DesiredRowHeight);
                //Height = rows * DesiredRowHeight;
                Rows = (int)rows;
            }
        }

        public double DesiredColumnWidth
        {
            get => (double)GetValue(DesiredColumnWidthProperty);
            set => SetValue(DesiredColumnWidthProperty, value);
        }

        public double DesiredRowHeight
        {
            get => (double)GetValue(DesiredRowHeightProperty);
            set => SetValue(DesiredRowHeightProperty, value);
        }
    }
}
