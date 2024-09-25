using System;
using Infragistics.Windows.OutlookBar;

namespace Common.UX.Wpf.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class WidgetGroupAttribute : Attribute
    {
        public Type Type { get; }
        public string Header { get; }
        public string Image { get; }

        public WidgetGroupAttribute(Type widgetGroupType, string header)
        {
            if (widgetGroupType == null) throw new ArgumentNullException(nameof(widgetGroupType));
            if (widgetGroupType.BaseType != typeof(OutlookBarGroup))
                throw new ArgumentOutOfRangeException(nameof(widgetGroupType), "Widget Group Type does not derive from OutlookBarGroup");
            Type = widgetGroupType;
            Header = header;
        }

        public WidgetGroupAttribute(Type widgetGroupType, string header, string image)
        {
            if (widgetGroupType == null) throw new ArgumentNullException(nameof(widgetGroupType));
            if (widgetGroupType.BaseType != typeof(OutlookBarGroup))
                throw new ArgumentOutOfRangeException(nameof(widgetGroupType), "Widget Group Type does not derive from OutlookBarGroup");
            Type = widgetGroupType;
            Header = header;
            Image = image;
        }
    }
}
