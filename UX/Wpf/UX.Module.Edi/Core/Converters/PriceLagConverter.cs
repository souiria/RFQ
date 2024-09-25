using System;
using System.Windows.Data;
using Infragistics.Windows.DataPresenter;
using UX.Module.Edi.Core.Dto;

namespace UX.Module.Edi.Core.Converters
{
    public class PriceLagConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (parameter != null)
                {
                    var row = (DataRecord)parameter;
                    var item = row.DataItem as EdiInvoiceInformationDto;
                    return (DateTime.Now - item.DispatchDate).Days;
                }
                else
                    return 0;
                //var item = (EdiInvoiceInformationAggregate)value;
                //return (DateTime.Now - item.DispatchDate).Days;
            }
            catch
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
