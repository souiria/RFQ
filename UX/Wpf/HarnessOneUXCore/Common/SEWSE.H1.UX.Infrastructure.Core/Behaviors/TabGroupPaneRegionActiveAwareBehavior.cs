using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using Infragistics.Windows.DockManager;
using Prism.Regions;
using Prism.Regions.Behaviors;
using Infragistics.Windows.OutlookBar;
using System.Collections.Generic;
using SEWSE.H1.Common.Contracts;
using System.Diagnostics;
using System;
using System.Linq;

namespace SEWSE.H1.UX.Infrastructure.Core.Behaviors
{
    public class TabGroupPaneRegionActiveAwareBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        public const string BehaviorKey = "TabGroupPaneRegionActiveAwareBehavior";

        XamDockManager _parentDockManager;

        TabGroupPane _hostControl;
        public DependencyObject HostControl
        {
            get => _hostControl;
            set => _hostControl = value as TabGroupPane;
        }

        protected override void OnAttach()
        {
            _parentDockManager = XamDockManager.GetDockManager(_hostControl);
            if (_parentDockManager != null)
                _parentDockManager.ActivePaneChanged += DockManager_ActivePaneChanged;

            Region.ActiveViews.CollectionChanged += ActiveViews_CollectionChanged;
        }

        void DockManager_ActivePaneChanged(object sender, RoutedPropertyChangedEventArgs<ContentPane> e)
        {
            if (e.OldValue != null)
            {
                var item = e.OldValue;

                //are we dealing with a ContentPane directly
                if (Region.Views.Contains(item) && Region.ActiveViews.Contains(item))
                {
                    Region.Deactivate(item);
                }
                else
                {
                    //now check to see if we have any views that were injected
                    var contentControl = item as ContentControl;
                    if (contentControl != null)
                    {
                        var injectedView = contentControl.Content;
                        if (Region.Views.Contains(injectedView) && Region.ActiveViews.Contains(injectedView) && e.NewValue != null) 
                            Region.Deactivate(injectedView);
                    }
                }
            }

            if (e.NewValue != null)
            {
                var item = e.NewValue;

                ////are we dealing with a ContentPane directly
                //if (Region.Views.Contains(item) && !Region.ActiveViews.Contains(item))
                //{
                //    Region.Activate(item);

                //}
                //else
                //{
                    //now check to see if we have any views that were injected
                    var contentControl = item as ContentControl;
                    if (contentControl != null)
                    {
                        var injectedView = contentControl.Content as UserControl;
                        if (Region.Views.Contains(injectedView) && !Region.ActiveViews.Contains(injectedView))
                        {
                            Region.Activate(injectedView);
                            FocusOutlookBar(injectedView);
                        }
                    }
                //}
            }
        }

        void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("\r\nTabGroupPaneRegionActiveAwareBehaviour:: ActiveViewsCollectionChanged:: Started Collection Changed actions");
            var stopwatch = Stopwatch.StartNew();

            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                //are we dealing with a view
                if (e.NewItems[0] is FrameworkElement frameworkElement)
                {
                    ContentPane contentPane = frameworkElement as ContentPane ?? frameworkElement.Parent as ContentPane;

                    if (contentPane != null && !contentPane.IsActivePane)
                    {
                        contentPane.Activate();
                    }
                }
                else
                {
                    //must be a viewmodel
                    object viewModel = e.NewItems[0];
                    var contentPane = GetContentPaneFromFromViewModel(viewModel);
                    contentPane?.Activate();
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"\r\nTabGroupPaneRegionActiveAwareBehaviour:: ActiveViewsCollectionChanged:: Finished Collection Changed actions:: Elapsed: {stopwatch.Elapsed}");
        }

        /// <summary>
        /// Focuses the item on the outlookbar by enumerating through the menu. This will only work if the 'Function' and 'Module' parameters in the viewModel of the current view have been given the same tag as the header of the menus items.
        /// </summary>
        /// <param name="currentView"> The current view as a UserControl</param>
        void FocusOutlookBar(UserControl currentView)
        {
            try
            {
                bool viewFound = false; //Breakout paramter for if the view has already been found

                //Get the outlookbar from its region
                var enumerator = Region.RegionManager.Regions[RegionNames.OutlookBarRegion].ActiveViews.GetEnumerator();
                enumerator.MoveNext();
                var outlookBar = enumerator.Current as XamOutlookBar;
                dynamic outlookBarViewModel = outlookBar.DataContext;

                //Get the viewModel of the view to compare the 'Function' and 'Module' parameters in it
                dynamic currentViewModel = currentView.DataContext;

                //If parameters aren't properly set, return
                if (string.IsNullOrEmpty(currentViewModel.Function) || string.IsNullOrEmpty(currentViewModel.Module)
                    || string.IsNullOrEmpty(currentViewModel.View)) { outlookBarViewModel.SelectedView = null; return; }

                foreach (var group in outlookBar.Groups)
                {   
                    var function = (FunctionSecurityModel)group.DataContext;

                    //Enumerate over each group and check if it matches the tag put in the viewModel
                    if (function.LabelKey != null && function.LabelKey.Equals(currentViewModel.Function) && !viewFound)
                    {
                        //Select the group in the outlookbar
                        outlookBar.SelectedGroup = group;

                        IEnumerable<ModuleSecurityModel> modules = outlookBar.SelectedGroupContent as IEnumerable<ModuleSecurityModel>;
                        foreach (ModuleSecurityModel module in modules)
                        {
                            //Enumerate over each module in the group and check if it matches the tag put in the viewModel
                            if (module.LabelKey != null && module.LabelKey.Equals(currentViewModel.Module) && !viewFound)
                            {
                                foreach (var view in module.Views)
                                {
                                    if (currentViewModel.View == null)
                                        break;

                                    //Enumerate over each view in the module and check if it matches the tag put in the viewModel
                                    if (view.LabelKey.Equals(currentViewModel.View))
                                    {
                                        //Get the outlookbar viewmodel and selected the view
                                        
                                        outlookBarViewModel.SelectedView = view;

                                        //Expands the collapsable menu if it was previously closed
                                        module.IsExpanded = true;

                                        viewFound = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (!viewFound)
                {
                    Debug.WriteLine("There was an issue focusing the outlook bar. " +
                        "Please check that the tab header (the usercontrol tag) and outlook bar menu item name are the same or" +
                        "that the module and function tags in the viewModel match with the menu");
                    outlookBarViewModel.SelectedView = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error occured while attempting focus on the outlook bar. " + ex.Message);
            }
        }

        ContentPane GetContentPaneFromFromViewModel(object viewModel)
        {
            var panes = XamDockManager.GetDockManager(_hostControl).GetPanes(PaneNavigationOrder.VisibleOrder);
            foreach (ContentPane contentPane in panes)
            {
                if (contentPane.DataContext == viewModel)
                    return contentPane;
            }
            return null;
        }
    }

}