using System;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using SEWSE.H1.UX.Infrastructure.Core.Helpers;

namespace SEWSE.H1.UX.Infrastructure.Core.Converters
{
    public class RoleToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Todo: Remove example usage once shown to team
            var exampleUsage = UserPreferenceSetupHelper.CurrentUser;
            //Example property setting
            UserPreferenceSetupHelper.CurrentUser.PreferredLanguage = "English";

            var principal = Thread.CurrentPrincipal;
            var activeDirectoryGroup = value.ToString();
            if (principal != null)
            {
                var toReturn = principal.IsInRole(activeDirectoryGroup) ? Visibility.Visible : Visibility.Collapsed;
                return toReturn;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}