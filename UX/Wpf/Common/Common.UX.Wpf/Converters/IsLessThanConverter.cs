using System;
using System.Globalization;
using System.Windows.Data;

namespace Common.UX.Wpf.Converters
{
    public class IsLessThanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int intParam = 0;
            if (value is double x && int.TryParse(parameter as string, out intParam))
            {
                return x < intParam;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
