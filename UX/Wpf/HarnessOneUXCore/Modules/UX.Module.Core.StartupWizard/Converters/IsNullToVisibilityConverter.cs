using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SEWSE.H1.UX.Module.Core.StartupWizard.Converters
{
    public class IsNullToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string s)
            {
                if (!string.IsNullOrEmpty(s))
                    return Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
