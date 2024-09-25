using System;
using System.Globalization;
using System.Windows.Data;

namespace Common.UX.Wpf.Converters
{
    public class RelativeDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is DateTime v))
            {
                return value;
            }

            return Convert(v, culture);
        }

        public static string Convert(DateTime v, CultureInfo culture)
        {
            var d = v.Date;
            var today = DateTime.Today;
            var diff = today - d;
            if (diff.Days == 0)
            {
                return "Today";
            }

            if (diff.Days == 1)
            {
                return "Yesterday";
            }

            if (diff.Days < 7)
            {
                return d.DayOfWeek.ToString();
            }

            if (diff.Days < 14)
            {
                return "Last week";
            }

            if (d.Year == today.Year && d.Month == today.Month)
            {
                return "This month";
            }

            var lastMonth = today.AddMonths(-1);
            if (d.Year == lastMonth.Year && d.Month == lastMonth.Month)
            {
                return "Last month";
            }

            if (d.Year == today.Year)
            {
                return "This year";
            }

            return d.Year.ToString(culture);
        }

        //public static int Compare(DateTime a, DateTime b)
        //{
        //    return Convert(a) == Convert(b) ? 0 : a.CompareTo(b);
        //}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
