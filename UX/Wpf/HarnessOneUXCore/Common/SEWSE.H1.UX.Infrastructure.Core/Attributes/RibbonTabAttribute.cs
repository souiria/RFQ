using System;
using Infragistics.Windows.Ribbon;

namespace SEWSE.H1.UX.Infrastructure.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RibbonTabAttribute : Attribute
    {
        public Type Type { get; private set; }

        public RibbonTabAttribute(Type ribbonTabType)
        {
            if (ribbonTabType == null) throw new ArgumentNullException("ribbonTabType");
            if (ribbonTabType.BaseType != typeof(RibbonTabItem))
                throw new ArgumentOutOfRangeException("ribbonTabType", "Ribbon Tab Type does not derive from RibbonTabItem");
            Type = ribbonTabType;
        }
    }
}