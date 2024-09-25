using System.Collections.Generic;

namespace SEWSE.H1.UX.Infrastructure.Core.Contracts
{
    public interface IViewBase
    {
        IViewModel ViewModel { get; set; }
        IList<IRibbonTabItem> RibbonTabs { get; }
    }
}