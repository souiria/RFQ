using System;
using System.Globalization;
using System.Windows.Data;
using Common.Core.Contracts.Interfaces.Administration.Security;
using Common.UX.Wpf.Contracts.Models;

namespace Common.UX.Wpf.Converters
{
    public class LabelCodeToTextConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(values[0] is ObservableDictionary<string, string> dic) ||
                !(values[1] is ISecurityModel model)) return null;

            try
            {                    
                var returnString = "";
                if (values.Length >= 5 && values[4] != null && values[4] is int grandparentId)
                    returnString += $"{grandparentId}.";
                if (values.Length >= 4 && values[3] != null && values[3] is int parentId)
                    returnString += $"{parentId}.";
                if (values.Length >= 3 && values[2] != null && values[2] is int id)
                    returnString += $"{id}.";

                if (!string.IsNullOrEmpty(model.LabelKey) && dic.ContainsKey(model.LabelKey))
                {
                    if (!string.IsNullOrEmpty(returnString))
                        returnString += $" {dic[model.LabelKey]}";
                    else
                        returnString = dic[model.LabelKey];
                    if (model.DisplayLabel == null)
                        model.DisplayLabel = returnString;
                    return returnString;
                }

                else if (!string.IsNullOrEmpty(model.DisplayName))
                {
                    if (!string.IsNullOrEmpty(returnString))
                        returnString += $" {model.DisplayName}";
                    else
                        returnString = model.DisplayName;
                    return returnString;
                }
            }
            catch
            {
                return !string.IsNullOrEmpty(model.DisplayName) ? model.DisplayName : null;
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
