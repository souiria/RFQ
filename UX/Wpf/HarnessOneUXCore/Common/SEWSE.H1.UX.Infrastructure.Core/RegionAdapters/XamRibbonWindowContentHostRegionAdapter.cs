using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Infragistics.Windows.Ribbon;
using Prism.Regions;

namespace SEWSE.H1.UX.Infrastructure.Core.RegionAdapters
{
    public class RibbonWindowContentHostRegionAdapter : RegionAdapterBase<RibbonWindowContentHost>
    {
        public RibbonWindowContentHostRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        private XamRibbon FindRibbonOnView(object view)
        {
            if (!(view is DependencyObject viewAsDependency))
            {
                return null;
            }
            var children = LogicalTreeHelper.GetChildren(viewAsDependency);
            foreach (object child in children)
            {
                if (child is XamRibbon)
                {
                    return child as XamRibbon;
                }
                var result = FindRibbonOnView(child);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        protected override void Adapt(IRegion region, RibbonWindowContentHost regionTarget)
        {
            region.Views.CollectionChanged +=
                (sender, e) =>
                {
                    if (e.Action == NotifyCollectionChangedAction.Add && !region.ActiveViews.Any())
                    {
                        XamRibbon menu = FindRibbonOnView(region.Views.FirstOrDefault());
                        if (menu == null)
                        {
                            throw new InvalidOperationException("No XamRibbon found in view.");
                        }
                        if (menu.Parent is Panel panel)
                        {
                            panel.Children.Remove(menu);
                            regionTarget.Ribbon = menu;
                            region.Activate(e.NewItems[0]);
                        }
                        else
                        {
                            throw new InvalidOperationException("Parent of the XamRibbon must be a Panel.");
                        }
                    }
                };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }

    }
}