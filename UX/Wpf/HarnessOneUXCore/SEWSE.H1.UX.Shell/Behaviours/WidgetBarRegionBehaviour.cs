using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using Common.UX.Wpf.Attributes;
using Common.UX.Wpf.Contracts.Interfaces;
using Common.UX.Wpf.Helpers;
using Infragistics.Windows.OutlookBar;
using Prism;
using Prism.Regions;
using Prism.Regions.Behaviors;

namespace SEWSE.H1.UX.Shell.Behaviours
{
    public class WidgetBarRegionBehaviour : RegionBehavior, IHostAwareRegionBehavior
    {
        Dictionary<Type, List<OutlookBarGroup>> widgetGroupCache = new Dictionary<Type, List<OutlookBarGroup>>();
        List<OutlookBarGroup> activeWidgetGroups;
        bool retainActiveWidget = true;


        public const string BehaviorKey = "WidgetBarRegionBehavior";

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
            if (activeWidgetGroups != null)
            {
                if (!((IActiveAware)((ISupportDataContext)HostControl).DataContext).IsActive)
                    activeWidgetGroups.ForEach(x =>
                    {
                        if (Region.RegionManager.Regions[RegionNames.WidgetBarGroupRegion].Views.Contains(x))
                            Region.RegionManager.Regions[RegionNames.WidgetBarGroupRegion].Remove(x);
                    });
                else if (retainActiveWidget)
                    activeWidgetGroups.ForEach(x => Region.RegionManager.Regions[RegionNames.WidgetBarGroupRegion].Add(x));
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
                    activeWidgetGroups = new List<OutlookBarGroup>();

                    if (widgetGroupCache.ContainsKey(view.GetType()))
                    {
                        activeWidgetGroups = widgetGroupCache[view.GetType()];
                    }
                    else
                    {

                        foreach (var atr in GetCustomAttributes<WidgetGroupAttribute>(view.GetType()))
                        {
                            var group = Activator.CreateInstance(atr.Type) as OutlookBarGroup;
                            group.Header = atr.Header;
                            if (atr.Image != null)
                            {
                                group.SmallImage = new BitmapImage(new Uri(atr.Image));
                                group.LargeImage = new BitmapImage(new Uri(atr.Image));
                            }
                            activeWidgetGroups.Add(group);
                        }

                        if (!widgetGroupCache.ContainsKey(view.GetType()))
                            widgetGroupCache.Add(view.GetType(), activeWidgetGroups);
                    }
                    if (view is ISupportDataContext && ((ISupportDataContext)view).DataContext is IWidgetHandler)
                    {
                        activeWidgetGroups.ForEach(x => ShareDataContext(x, view));
                        retainActiveWidget = false;
                        ((IWidgetHandler)((ISupportDataContext)view).DataContext).OpenWidget += WidgetBarRegionBehaviour_OpenWidget;
                    }
                    else
                        activeWidgetGroups.ForEach(x =>
                        {
                            ShareDataContext(x, view);
                            Region.RegionManager.Regions[RegionNames.WidgetBarGroupRegion].Add(x);
                        });

                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var view in e.OldItems)
                {
                    if (widgetGroupCache.ContainsKey(view.GetType()) && retainActiveWidget)
                        widgetGroupCache[view.GetType()].ForEach(x => Region.RegionManager.Regions[RegionNames.WidgetBarGroupRegion].Remove(x));
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"\r\nWidgetBarRegionBehaviour:: ActiveViewsCollectionChanged:: Finished Collection Changed actions:: Elapsed: {stopwatch.Elapsed}");
        }

        private void WidgetBarRegionBehaviour_OpenWidget(object sender, bool open)
        {
            if (open)
            {
                activeWidgetGroups.ForEach(x => Region.RegionManager.Regions[RegionNames.WidgetBarGroupRegion].Add(x));
                retainActiveWidget = true;
            }
            else
            {
                activeWidgetGroups.ForEach(x => Region.RegionManager.Regions[RegionNames.WidgetBarGroupRegion].Remove(x));
                retainActiveWidget = false;
            }
        }

        private void ShareDataContext(OutlookBarGroup group, object view)
        {
            if (group is ISupportDataContext && view is ISupportDataContext)
                ((ISupportDataContext)group).DataContext = ((ISupportDataContext)view).DataContext;
        }

        static IEnumerable<T> GetCustomAttributes<T>(Type type)
        {
            return type.GetCustomAttributes(typeof(T), true).OfType<T>();
        }
    }
}
