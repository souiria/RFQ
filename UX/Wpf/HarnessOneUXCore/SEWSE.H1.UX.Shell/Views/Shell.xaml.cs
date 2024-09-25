using Infragistics.Themes;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Common.UX.Wpf.Contracts.Interfaces;

namespace SEWSE.H1.UX.Shell.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : IShell
    {
        public Shell()
        {
            InitializeComponent();
            OverrideControlTheme();
        }

        private void OverrideControlTheme()
        {
            //ThemeManager.RegisterControl(typeof(ComboBox));
            ThemeManager.RegisterControl(typeof(ListBox));
            ThemeManager.RegisterControl(typeof(ListBoxItem));
            ThemeManager.RegisterControl(typeof(Button));
            ThemeManager.RegisterControl(typeof(ScrollBar));
            //Ajay: 10-Mar-2018
            ThemeManager.RegisterControl(typeof(Label));
        }

    }
}
