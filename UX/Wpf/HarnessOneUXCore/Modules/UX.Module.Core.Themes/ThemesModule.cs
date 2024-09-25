using Infragistics.Themes;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using SEWSE.H1.UX.Module.Core.Themes.Themes;
using System.Collections.Generic;
using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Contracts.Models;
using Common.UX.Wpf.Helpers;
namespace SEWSE.H1.UX.Module.Core.Themes
{
    [Roles("H1 Users")]
    [Module(ModuleName = "Themes, v1.0.0.0", OnDemand = false)]
    public class ThemesModule : IModule
    {
        private readonly IRegionManager _manager;
        private readonly IUnityContainer _container;

        public ThemesModule(IEventAggregator eventAggregator, IRegionManager manager, IUnityContainer container)
        {
            _manager = manager;
            _container = container;
        }

        public void Initialize()
        {
#if !UAT
            string prefTheme;
            if (string.IsNullOrEmpty(UserPreferenceSetupHelper.CurrentUser?.PreferredTheme))
                prefTheme = "Corporate Blue";
            else
                prefTheme = UserPreferenceSetupHelper.CurrentUser.PreferredTheme;

            var l = GetThemeList();
            foreach (ThemeModel t in l)
            {
                if (t.ThemeName == prefTheme)
                {
                    ThemeManager.ApplicationTheme = t;
                    UserPreferenceSetupHelper.CurrentUser.PreferredTheme = t.ThemeName;
                    break;
                }
            }
            if (ThemeManager.ApplicationTheme == null)
            {
                ThemeManager.ApplicationTheme = l[0];
                UserPreferenceSetupHelper.CurrentUser.PreferredTheme = l[0].ThemeName;
            }
#else
            {
                ThemeManager.ApplicationTheme = new UATTheme();
            }
#endif
        }

        public static List<ThemeModel> GetThemeList()
        {
            List<ThemeModel> themes = new List<ThemeModel>();
#if !UAT
            themes.Add(new CorporateBlueTheme());
            themes.Add(new CorporateGreyTheme());
            themes.Add(new CorporatePurpleTheme());
            themes.Add(new CorporateGreenTheme());
            themes.Add(new CorporateWhiteTheme());
#endif
            return themes;
        }
    }
}