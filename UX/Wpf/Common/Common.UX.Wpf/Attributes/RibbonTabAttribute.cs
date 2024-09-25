using System;
using Infragistics.Windows.Ribbon;

namespace Common.UX.Wpf.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RibbonTabAttribute : Attribute
    {
        public Type Type { get; }

        public RibbonTabAttribute(Type ribbonTabType)
        {
            if (ribbonTabType == null) throw new ArgumentNullException(nameof(ribbonTabType));
            if (ribbonTabType.BaseType != typeof(RibbonTabItem))
                throw new ArgumentOutOfRangeException(nameof(ribbonTabType), "Ribbon Tab Type does not derive from RibbonTabItem");
            Type = ribbonTabType;
        }
    }
}