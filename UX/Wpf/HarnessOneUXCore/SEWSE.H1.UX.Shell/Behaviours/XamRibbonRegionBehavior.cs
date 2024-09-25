using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Contracts.Interfaces;
using Common.UX.Wpf.Helpers;
using Infragistics.Windows.Ribbon;
using Prism;
using Prism.Regions;
using Prism.Regions.Behaviors;

namespace SEWSE.H1.UX.Shell.Behaviours
{
    public class XamRibbonRegionBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        Dictionary<Type, List<RibbonTabItem>> ribbonTabCache = new Dictionary<Type, List<RibbonTabItem>>();
        List<RibbonTabItem> activeRibbonTabs;
        public const string BehaviorKey = "XamRibbonRegionBehavior";

        private DependencyObject _hostControl;
        public DependencyObject HostControl
        {
            get => _hostControl;
            set => _hostControl = value;
        }

        protected override void OnAttach()
        {
            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
            if (HostControl is ISupportDataContext && ((ISupportDataContext)HostControl).DataContext is IActiveAware)
            {
                ((IActiveAware)((ISupportDataContext)HostControl).DataContext).IsActiveChanged += HostControl_IsActiveChanged;
            }
        }

        private void HostControl_IsActiveChanged(object sender, EventArgs e)
        {
            if (activeRibbonTabs != null)
            {
                if (!((IActiveAware)((ISupportDataContext)HostControl).DataContext).IsActive)
                    activeRibbonTabs.ForEach(x =>
                    {
                        if (Region.RegionManager.Regions[RegionNames.RibbonTabRegion].Views.Contains(x))
                            Region.RegionManager.Regions[RegionNames.RibbonTabRegion].Remove(x);
                    });
                else
                    activeRibbonTabs.ForEach(x => Region.RegionManager.Regions[RegionNames.RibbonTabRegion].Add(x));
            }
        }

        void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine($"\r\nWidgetBarRegionBehaviour:: ActiveViewsCollectionChanged:: Started Collection Changed actions");
            var stopwatch = Stopwatch.StartNew();

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var view in e.NewItems)
                {
                    activeRibbonTabs = new List<RibbonTabItem>();

                    if (ribbonTabCache.ContainsKey(view.GetType()))
                    {
                        activeRibbonTabs = ribbonTabCache[view.GetType()];
                    }
                    else
                    {

                        foreach (var atr in GetCustomAttributes<RibbonTabAttribute>(view.GetType()))
                        {
                            var tab = Activator.CreateInstance(atr.Type) as RibbonTabItem;
                            activeRibbonTabs.Add(tab);
                        }

                        if (!ribbonTabCache.ContainsKey(view.GetType()))
                            ribbonTabCache.Add(view.GetType(), activeRibbonTabs);
                    }

                    activeRibbonTabs.ForEach(x =>
                    {
                        ShareDataContext(x, view);
                        Region.RegionManager.Regions[RegionNames.RibbonTabRegion].Add(x);
                    });
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var view in e.OldItems)
                {
                    if (ribbonTabCache.ContainsKey(view.GetType()))
                        ribbonTabCache[view.GetType()].ForEach(x => Region.RegionManager.Regions[RegionNames.RibbonTabRegion].Remove(x));
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"\r\nXamRibbonRegionBehaviour:: ActiveViewsCollectionChanged:: Finished Collection Changed actions:: Elapsed: {stopwatch.Elapsed}");
        }

        static IEnumerable<T> GetCustomAttributes<T>(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }

        private void ShareDataContext(RibbonTabItem tab, object view)
        {
            if (tab is ISupportDataContext && view is ISupportDataContext)
                ((ISupportDataContext)tab).DataContext = ((ISupportDataContext)view).DataContext;
        }
    }
}