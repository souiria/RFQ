using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Common.UX.Wpf.Converters
{
    public class IsGuidEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Guid g)
            {
                if (g == Guid.Empty)
                    return Visibility.Collapsed;

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
