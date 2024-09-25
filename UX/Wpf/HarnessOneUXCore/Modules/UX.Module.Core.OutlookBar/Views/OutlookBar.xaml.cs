using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using Infragistics.Controls.Editors;
using Infragistics.Controls.Menus;
using Prism.Events;
using System.Windows.Threading;
using Common.Core.Contracts.Models.Administration.Security;
using Common.UX.Wpf.Events;

namespace SEWSE.H1.UX.Module.Core.OutlookBar.Views
{
    /// <summary>
    /// Interaction logic for OutlookBar.xaml
    /// </summary>
    public partial class OutlookBar
    {
        private XamMaskedInput _outlookFilter { get; set; }

        private XamDataTree _filterDataTree { get; set; }
        private ObservableCollection<ViewSecurityModel> _outlookDataTree { get; set; }

        private bool _isLoaded;
        private IEventAggregator _eventAggregator;

        public OutlookBar(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            InitializeComponent();
            _outlookDataTree = new ObservableCollection<ViewSecurityModel>();
        }

        private void LeftOutlookBar_Loaded(object sender, RoutedEventArgs e)
        {
            new DispatcherTimer(//It will not wait after the application is idle.
                      TimeSpan.Zero,
                      //It will wait until the application is idle
                      DispatcherPriority.ApplicationIdle,
                      //It will call this when the app is idle
                      dispatcherTimer_Tick,
                      //On the UI thread
                      Application.Current.Dispatcher);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (Groups.Count > 0)
                this.SelectedGroup = Groups[0];

            _outlookFilter = FindFilter();
            _filterDataTree = FindDataTree("FilterDataTree");
            (sender as DispatcherTimer).Stop();
        }

        private void LeftOutlookBar_SelectedGroupChanged(object sender, RoutedEventArgs e)
        {
            if (_isLoaded)
                ClearFilter();
            var selectedGroup = ((OutlookBar)sender).SelectedGroup;
            if (selectedGroup?.Header != null)
                _eventAggregator.GetEvent<SelectedModuleEvent>().Publish((string)selectedGroup.Header);
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            ClearFilter();
        }

        private void ClearFilter()
        {
            if (_outlookFilter != null)
                _outlookFilter.Text = "";
        }

        private void OutlookFilter_TextChanged(object sender, System.EventArgs e)
        {
            if (_outlookFilter != null)
            {
                ObservableCollection<ViewSecurityModel> filteredList = null;
                if (_outlookFilter.Text != "")
                {
                    _filterDataTree.Visibility = Visibility.Visible;
                    filteredList = new ObservableCollection<ViewSecurityModel>();
                    foreach (ViewSecurityModel item in _outlookDataTree)
                    {
                        if (!string.IsNullOrWhiteSpace(item.DisplayLabel))
                            if (item.DisplayLabel.ToLower().Contains(_outlookFilter.Text.ToLower()))
                                filteredList.Add(item);
                    }
                }
                else
                    _filterDataTree.Visibility = Visibility.Collapsed;
                _filterDataTree.ItemsSource = filteredList;
            }
        }

        private XamMaskedInput FindFilter()
        {
            var maskedInputChildren = FindVisualChildren<XamMaskedInput>(LeftOutlookBar);
            if (maskedInputChildren != null)
                foreach (var child in maskedInputChildren)
                {
                    if (child.Name == "OutlookFilter")
                        return child;
                }
            return null;
        }

        private XamDataTree FindDataTree(string dataTreeName)
        {
            var maskedInputChildren = FindVisualChildren<XamDataTree>(LeftOutlookBar);
            if (maskedInputChildren != null)
                foreach (var child in maskedInputChildren)
                {
                    if (child.Name == dataTreeName)
                        return child;
                }
            return null;
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void AddOutlookItemsToList()
        {
            foreach (var group in LeftOutlookBar.Groups)
            {
                var groupContent = (ObservableCollection<ModuleSecurityModel>)group.Content;
                foreach (var module in groupContent)
                {
                    var moduleContent = module.Views;
                    foreach (var view in moduleContent)
                    {
                        _outlookDataTree.Add(view);
                    }
                }
            }
        }

        private void OutlookFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            AddOutlookItemsToList();
        }

        private void OutlookFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            _outlookDataTree = new ObservableCollection<ViewSecurityModel>();
        }
    }
}
