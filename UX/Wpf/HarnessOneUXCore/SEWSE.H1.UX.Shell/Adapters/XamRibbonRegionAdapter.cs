using System;
using System.Collections.Specialized;
using Infragistics.Windows.Ribbon;
using Prism.Regions;
using SEWSE.H1.UX.Shell.Behaviours;

namespace SEWSE.H1.UX.Shell.Adapters
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
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

        static void AddViewToRegion(object view, XamRibbon xamRibbon)
        {
            if (view is RibbonTabItem ribbonTabItem)
            {
                xamRibbon.Tabs.Add(ribbonTabItem);
                xamRibbon.SelectedTab = ribbonTabItem;
            }

            if (view is ApplicationMenu applicationMenu)            
                xamRibbon.ApplicationMenu = applicationMenu;


            if (view is ApplicationMenu2010 applicationMenu2010)            
                xamRibbon.ApplicationMenu2010 = applicationMenu2010;


            if (view is QuickAccessToolbar qatMenu)            
                xamRibbon.QuickAccessToolbar = qatMenu;
            
        }

        static void RemoveViewFromRegion(object view, XamRibbon xamRibbon)
        {
            if (view is RibbonTabItem ribbonTabItem)
                xamRibbon.Tabs.Remove(ribbonTabItem);

        }
    }
}