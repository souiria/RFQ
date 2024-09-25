using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Common.UX.Wpf.Contracts.Interfaces;
using Infragistics.Windows.DockManager;
using Infragistics.Windows.DockManager.Events;
using Prism.Regions;
using SEWSE.H1.UX.Shell.Behaviours;

namespace SEWSE.H1.UX.Shell.Adapters
{
    public class TabGroupPaneRegionAdapter : RegionAdapterBase<TabGroupPane>
    {
        /// <summary>
        /// Used to determine what views were injected and ContentPanes were generated for
        /// </summary>
        private static readonly DependencyProperty IsGeneratedProperty = DependencyProperty.RegisterAttached("IsGenerated", typeof(bool), typeof(TabGroupPaneRegionAdapter), null);

        /// <summary>
        /// Used to track the region that a ContentPane belongs to so that we can access the region from within the ContentPane.Closed event handler
        /// </summary>
        private static readonly DependencyProperty RegionProperty = DependencyProperty.RegisterAttached("Region", typeof(IRegion), typeof(TabGroupPaneRegionAdapter), null);

        public TabGroupPaneRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, TabGroupPane regionTarget)
        {
            if (regionTarget.ItemsSource != null)
                throw new InvalidOperationException("ItemsSource property is not empty. This control is being associated with a region, but the control is already bound to something else. If you did not explicitly set the control's ItemSource property, this exception may be caused by a change in the value of the inherited RegionManager attached property.");

            SynchronizeItems(region, regionTarget);

            region.Views.CollectionChanged += (sender, e) =>
            {
                OnViewsCollectionChanged(sender, e, region, regionTarget);
            };
        }

        protected override void AttachBehaviors(IRegion region, TabGroupPane regionTarget)
        {
            base.AttachBehaviors(region, regionTarget);

            if (!region.Behaviors.ContainsKey(TabGroupPaneRegionActiveAwareBehavior.BehaviorKey))
                region.Behaviors.Add(TabGroupPaneRegionActiveAwareBehavior.BehaviorKey, new TabGroupPaneRegionActiveAwareBehavior { HostControl = regionTarget });
        }

        protected override IRegion CreateRegion()
        {
            return new SingleActiveRegion();
        }

        private void OnViewsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e, IRegion region, TabGroupPane regionTarget)
        {
            Console.WriteLine("\r\nTabGroupPaneRegionAdapter:: OnViewsCollectionChanged:: Started Collection Changed actions");
            var stopwatch = Stopwatch.StartNew();

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                //we want to add them behind any previous views that may have been manually declare in XAML or injected
                int startIndex = e.NewStartingIndex;
                foreach (object newItem in e.NewItems)
                {
                    ContentPane contentPane = PrepareContainerForItem(newItem, region);

                    if (regionTarget.Items.Count != startIndex)
                        startIndex = 0;

                    //we must make sure we bring the TabGroupPane into view.  If we don't a System.StackOverflowException will occur in 
                    //UIAutomationProvider.dll if trying to add a ContentPane to a TabGroupPane that is not in view. 
                    //This is most common when using nested TabGroupPane regions. If you don't this, you can comment it out.
                    regionTarget.BringIntoView();
                    regionTarget.Items.Insert(startIndex, contentPane);
                    contentPane.Closing += ContentPane_Closing;
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"\r\nTabGroupPaneRegionAdapter:: OnViewsCollectionChanged:: Finished Collection Changed actions:: Time Elapsed: {stopwatch.Elapsed}");
        }

        private async void ContentPane_Closing(object sender, PaneClosingEventArgs e)
        {
            var dc = ResolveDataContext(sender);
            if (dc is IViewModel viewModel)
            {
                var close = viewModel.OnClosing();
                e.Cancel = !close;
            }
            else if (dc is IViewModelAsync viewModelAsync)
            {
                var close = await viewModelAsync.OnClosing();
                e.Cancel = !close;
            }

            if (e.Cancel) return;
            if (!(sender is ContentPane contentPane)) return;
            contentPane.Closing -= ContentPane_Closing;
            //contentPane.ExecuteCommand(ContentPaneCommands.Close);
            if (!(contentPane.GetValue(RegionProperty) is IRegion region) || !(contentPane.Content is UserControl userControl)) return;
            
            region.Remove(userControl);
            ClearContainerForItem(contentPane); //reduce memory leaks
        }

        /// <summary>
        /// Takes all the views that were declared in XAML manually and merges them with the region.
        /// </summary>
        private void SynchronizeItems(IRegion region, TabGroupPane regionTarget)
        {
            if (regionTarget.Items.Count > 0)
            {
                foreach (object item in regionTarget.Items)
                {
                    PrepareContainerForItem(item, region);
                    region.Add(item);
                }
            }
        }

        /// <summary>
        /// Prepares a view being injected as a ContentPane
        /// </summary>
        /// <param name="item">the view</param>
        /// <param name="region"></param>
        /// <returns>The injected view as a ContentPane</returns>
        protected ContentPane PrepareContainerForItem(object item, IRegion region)
        {
            if (!(item is ContentPane container))
            {
                var userControl = item as UserControl;
                var result = ResolveDataContext(userControl);

                object datacontext = null;
                if (result is IViewModel)
                    datacontext = result as IViewModel;
                else if (result is IViewModelAsync)
                    datacontext = result as IViewModelAsync;

                container = new ContentPane
                {
                    Content = userControl,
                    DataContext = datacontext
                };

                //Binding binding = new Binding($"Labels[{datacontext.View}]");
                //container.SetBinding(HeaderedContentControl.HeaderProperty, binding);


                //the content is the item being injected
                //make sure the dataContext is the same as the item. Most likely a ViewModel
                container.SetValue(IsGeneratedProperty, true); //we generated this one
                CreateDockAwareBindings(container);
            }

            container.SetValue(RegionProperty, region); //let's keep track of which region the container belongs to
            container.CloseAction = PaneCloseAction.RemovePane; //make it easy on ourselves and have the pane manage removing itself from the XamDockManager
                                                                //container.Closed += Container_Closed;

            return container;
        }

        /// <summary>
        /// Checks to see if the item being injected implements the IDockAware interface and creates the necessary data bindings.
        /// </summary>
        /// <remarks>
        /// First we will check if the ContentPane.Content property implements the IDockAware interface. Depending on the type of item being injected,
        /// this may be a View or a ViewModel. If no IDockAware interface is found to create a binding, we next move to the ContentPane.DataContext property, which will 
        /// most likely be a ViewModel.
        /// </remarks>
        /// <param name="contentPane"></param>
        void CreateDockAwareBindings(ContentPane contentPane)
        {
            Binding binding = new Binding("Header");

            //let's first check the item that was injected for IDockAware. This may be a View or ViewModel
            if (contentPane.Content is IDockAware dockAwareContent)
                binding.Source = dockAwareContent;

            //nothing was found on the item being injected, let's check the DataContext
            if (binding.Source == null)
            {
                //fall back to data context of the content pane, which is most likely a ViewModel
                if (contentPane.DataContext is IDockAware dockAwareDataContext)
                    binding.Source = dockAwareDataContext;
            }

            contentPane.SetBinding(ContentPane.TabHeaderProperty, binding);
        }

        /// <summary>
        /// Sets the Content property of a generated ContentPane to null.
        /// </summary>
        /// <param name="contentPane">The ContentPane</param>
        protected void ClearContainerForItem(ContentPane contentPane)
        {
            if (IsGeneratedProperty == null || contentPane == null ||
                !(bool)contentPane.GetValue(IsGeneratedProperty)) return;
            contentPane.ClearValue(ContentPane.TabHeaderProperty); //remove any bindings
            contentPane.Content = null;
            BindingOperations.ClearAllBindings(contentPane);
        }

        /// <summary>
        /// Finds the DataContext of an item.
        /// </summary>
        /// <remarks>
        /// If we are injecting a View, the result will be the Views DataContext. If we are injecting a ViewModel, the result will be the ViewModel.
        /// </remarks>
        /// <param name="item">The item</param>
        /// <returns>A Views DataContext or a ViewModel</returns>
        private object ResolveDataContext(object item)
        {
            return !(item is FrameworkElement frameworkElement) ? item : frameworkElement.DataContext;
        }
    }
}