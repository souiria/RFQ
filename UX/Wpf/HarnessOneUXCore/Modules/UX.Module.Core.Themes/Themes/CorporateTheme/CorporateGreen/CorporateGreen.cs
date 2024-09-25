using Common.UX.Wpf.Contracts.Models;
using Infragistics.Themes;

namespace SEWSE.H1.UX.Module.Core.Themes.Themes
{
    public class CorporateGreenTheme : ThemeModel
    {
        private string themeFile = @"\Themes\CorporateTheme\CorporateGreen\CorporateGreen.xaml";
        public CorporateGreenTheme()
        {
            ThemeName = "Corporate Green";
        }

        protected override void ConfigureControlMappings()
        {
            string assemblyFullName = typeof(CorporateGreenTheme).Assembly.FullName;

            //Mappings.Add(ControlMappingKeys.XamDataTree,
            // BuildLocationString(assemblyFullName, @"\Themes\CorporateBlue\Controls\XamDataTree.xaml"));
            Mappings.Add(ControlMappingKeys.XamDialogWindow,
                   BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add("System.Windows.Controls.ListBox",
                    BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add("System.Windows.Controls.ListBoxItem",
                    BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add(ControlMappingKeys.XamDockManager,
                    BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add(ControlMappingKeys.XamRibbon,
                    BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add(ControlMappingKeys.XamOutlookBar,
                    BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add(ControlMappingKeys.XamDataGrid,
                    BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add(ControlMappingKeys.XamDataTree,
                    BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add(ControlMappingKeys.XamBusyIndicator,
                    BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add(ControlMappingKeys.XamGrid,
                    BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add("System.Windows.Controls.Button",
                    BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add("System.Windows.Controls.Primitives.ScrollBar",
                    BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add(ControlMappingKeys.XamRadialGauge,
                BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add(ControlMappingKeys.XamDataChart,
                BuildLocationString(assemblyFullName, themeFile));
            Mappings.Add(ControlMappingKeys.XamLinearGauge,
                BuildLocationString(assemblyFullName, themeFile));
            //    Mappings.Add("System.Windows.Controls.ComboBox",
            //BuildLocationString(assemblyFullName, @"\Themes\CorporateBlue\Controls\ComboBox.xaml"));
            //Ajay: 10-Mar-2018
            //Added Reference for label control
            Mappings.Add("System.Windows.Controls.Label",
        BuildLocationString(assemblyFullName, themeFile));

        }
    }
}
