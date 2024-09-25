using SEWSE.H1.UX.Infrastructure.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEWSE.H1.UX.Infrastructure.Core.Contracts
{
    public interface IWidgetHandler
    {
        event WidgetOpenEventHandler OpenWidget;
    }
}
