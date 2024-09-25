using Infragistics.Windows.OutlookBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEWSE.H1.UX.Infrastructure.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class WidgetGroupAttribute : Attribute
    {
        public Type Type { get; private set; }
        public string Header { get; private set; }
        public string Image { get; private set; }

        public WidgetGroupAttribute(Type widgetGroupType, string header)
        {
            if (widgetGroupType == null) throw new ArgumentNullException("widgetGroupType");
            if (widgetGroupType.BaseType != typeof(OutlookBarGroup))
                throw new ArgumentOutOfRangeException("widgetGroupType", "Widget Group Type does not derive from OutlookBarGroup");
            Type = widgetGroupType;
            Header = header;
        }

        public WidgetGroupAttribute(Type widgetGroupType, string header, string image)
        {
            if (widgetGroupType == null) throw new ArgumentNullException("widgetGroupType");
            if (widgetGroupType.BaseType != typeof(OutlookBarGroup))
                throw new ArgumentOutOfRangeException("widgetGroupType", "Widget Group Type does not derive from OutlookBarGroup");
            Type = widgetGroupType;
            Header = header;
            Image = image;
        }
    }
}
