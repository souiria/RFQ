using System;
using System.Globalization;
using System.Windows.Data;

namespace Common.UX.Wpf.Converters
{
    public class InvertBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return !b;
            }

            throw new ArgumentException($"{nameof(value)} is not a Boolean value and cannot be inverted.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return !b;
            }

            throw new ArgumentException($"{nameof(value)} is not a Boolean value and cannot be inverted.");
        }
    }
}
