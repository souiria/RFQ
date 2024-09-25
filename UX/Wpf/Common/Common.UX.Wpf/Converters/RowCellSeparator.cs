using System;
using System.Globalization;
using System.Windows.Data;

namespace Common.UX.Wpf.Converters
{
	public class RowCellSeparator : IMultiValueConverter
	{
		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return values.Clone();
		}
		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
