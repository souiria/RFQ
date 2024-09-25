using Prism.Events;
using Prism.Regions;

namespace SEWSE.H1.UX.Infrastructure.Core.Helpers
{
    public class PrismEventHelper
    {
        public static IRegionManager PrismRegion { get; set; }
        public static IEventAggregator PrismEvent { get; set; }
    }
}