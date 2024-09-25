using System;
using System.Collections.Specialized;
using Infragistics.Windows.Ribbon;
using Prism.Regions;
using SEWSE.H1.UX.Infrastructure.Core.Behaviors;

namespace SEWSE.H1.UX.Infrastructure.Core.RegionAdapters
{
    public class XamRibbonRegionAdapter : RegionAdapterBase<XamRibbon>
    {
        public XamRibbonRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, XamRibbon regionTarget)
        {
            if (region == null) throw new ArgumentNullException("region");
            if (regionTarget == null) throw new ArgumentNullException("regionTarget");

            region.Views.CollectionChanged += (s, args) =>
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        {
                            foreach (object view in args.NewItems)
                            {
                                AddViewToRegion(view, regionTarget);
                            }
                            break;
                        }
                    case NotifyCollectionChangedAction.Remove:
                        {
                            foreach (object view in args.OldItems)
                            {
                                RemoveViewFromRegion(view, regionTarget);
                            }
                            break;
                        }
                    default:
                        {
                            // Do nothing.
                            break;
                        }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

        static void AddViewToRegion(object view, XamRibbon xamRibbon)
        {

            var ribbonTabItem = view as RibbonTabItem;
            if (ribbonTabItem != null)
            {
                xamRibbon.Tabs.Add(ribbonTabItem);
                xamRibbon.SelectedTab = ribbonTabItem;
            }

            var applicationMenu = view as ApplicationMenu;
            if (applicationMenu != null)            
                xamRibbon.ApplicationMenu = applicationMenu;
            

            var applicationMenu2010 = view as ApplicationMenu2010;
            if (applicationMenu2010 != null)            
                xamRibbon.ApplicationMenu2010 = applicationMenu2010;
            

            var qatMenu = view as QuickAccessToolbar;
            if (qatMenu != null)            
                xamRibbon.QuickAccessToolbar = qatMenu;
            
        }

        static void RemoveViewFromRegion(object view, XamRibbon xamRibbon)
        {  
            var ribbonTabItem = view as RibbonTabItem;
            if (ribbonTabItem != null)
                xamRibbon.Tabs.Remove(ribbonTabItem);

        }
    }
}