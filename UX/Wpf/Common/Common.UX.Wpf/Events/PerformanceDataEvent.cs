using Common.Core.Contracts.Models.Administration.Maintenance;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEWSE.H1.Common.Infrastructure.Events
{
    public class PerformanceDataEvent : PubSubEvent<PerformanceData> { }
}
