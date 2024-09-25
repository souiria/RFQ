using System.Windows;
using Infragistics.Windows;
using Infragistics.Windows.Controls;
using System.Windows.Controls;

namespace SEWSE.H1.UX.Module.Core.ApplicationMenu.Views
{
    /// <summary>
    /// Interaction logic for ThemePage.xaml
    /// </summary>
    public partial class ThemePage : UserControl
    {
        public ThemePage()
        {
            InitializeComponent();

            Loaded += ThemePage_Loaded;
        }

        private void ThemePage_Loaded(object sender, RoutedEventArgs e)
        {
            double width = 0;
            double.TryParse(this.ThemePageGrid.ActualWidth.ToString(), out width);

            if (width > 0)
            {
                this.ThemePageCarouselView.WidthInInfiniteContainers = width;
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            /*XamCarouselListBox selectedItem = ((XamCarouselListBox)sender);
            int selectedIndex = selectedItem.SelectedIndex;*/
            CarouselListBoxItem carousel = Utilities.GetDescendantFromType(sender as DependencyObject, typeof(CarouselListBoxItem), true) as CarouselListBoxItem;
            /*while (carousel.FirstVisibleItemIndex != selectedIndex)
            {
                if (carousel.FirstVisibleItemIndex < selectedIndex)
                    carousel.ExecuteCommand(XamCarouselPanelCommands.NavigateToNextItem);
                else
                    carousel.ExecuteCommand(XamCarouselPanelCommands.NavigateToPreviousItem);
            }*/
        }
    }
}
