using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Collections.Specialized;

namespace SEWSE.H1.UX.Infrastructure.Core.RegionAdapters
{
    public class WizardRegionAdapter : RegionAdapterBase<Window>
    {
        public WizardRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, Window regionTarget)
        {
            if (regionTarget.Content != null || (BindingOperations.GetBinding(regionTarget, System.Windows.Controls.ContentControl.ContentProperty) != null))
                throw new InvalidOperationException();

            region.ActiveViews.CollectionChanged += (sender, e) =>
            {
                OnViewsCollectionChanged(sender, e, region, regionTarget);
            };
        }

        private void OnViewsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e, IRegion region, Window regionTarget)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                //we want to add them behind any previous views that may have been manually declare in XAML or injected
                foreach (object newItem in e.NewItems)
                {
                    regionTarget.Content = newItem;
                }
            }
        }

        protected override IRegion CreateRegion()
        {

            return new SingleActiveRegion(); 
        }
    }
}
