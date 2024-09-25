using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Security;
using Common.UX.Api;
using Common.UX.Api.Endpoints;
using Common.UX.Wpf.Contracts.Interfaces;
using Common.UX.Wpf.Contracts.Models;
using Common.UX.Wpf.Events;
using Common.UX.Wpf.Helpers;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Prism;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Common.UX.Wpf.Base.Commercial
{
    [Obsolete("This ViewModel is obsolete. Please use BaseViewModel instead.")]
    public abstract class ViewModelBase : BindableBase, INavigationAware, IActiveAware, IDockAware, IViewModel
    {
        #region Properties
        public string Function { get; protected set; }
        public string Module { get; protected set; }
        public string View { get; protected set; }
        public string ViewFallback { get; protected set; }
        public IBusyIndicator BusyIndicator;

        protected bool openWidgetOnActive = true;
        protected bool openContextualOnActive = true;

        private bool _isActive;
        protected StatusBarMessageHelper _statusMessage;
        protected StatusBarMessageHelper StatusBarMessageHelper { get; set; }
        protected CustomDialogHelper CustomDialogHelper { get; set; }
        private string _title;


        //TODO: Remove '_contextualTabs' and '_widgetBarGroups' properties from all ViewModels
        protected IList<RibbonTabItem> _contextualTabs;
        protected IList<OutlookBarGroup> _widgetBarGroups;

        protected IList<string> LabelsNeeded { get; set; }
        protected IEventAggregator _eventAggregator { get; set; }
        protected IRegionManager _regionManager { get; set; }
        protected IDialogService _dialogService { get; set; }

        #region Commands
        public DelegateCommand PageLoadedCommand { get; set; }
        #endregion

        private bool _canUpdate = true;
        public bool CanUpdate
        {
            get => _canUpdate;
            set => SetProperty(ref _canUpdate, value);
        }

        private string _header;
        public string Header
        {
            get => _header;
            set => SetProperty(ref _header, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                SetProperty(ref _isActive, value);
                Title = value ? "Active" : "Not Active";
                OnIsActiveChanged();
            }
        }
        private string _iconSource;
        public string IconSource
        {
            get => _iconSource;
            set
            {
                SetProperty(ref _iconSource, value);
            }
        }

        private ObservableDictionary<string, string> _labels;
        public ObservableDictionary<string, string> Labels
        {
            get => _labels;
            set => SetProperty(ref _labels, value);
        }

        public event EventHandler IsActiveChanged;
        #endregion

        #region Constructors
        protected ViewModelBase(IEventAggregator eventAggregator = null, IRegionManager regionManager = null, IDialogService dialogService = null)
        {
            PageLoadedCommand = new DelegateCommand(PageLoaded);
            LabelsNeeded = new List<string>();

            if (eventAggregator != null)
            {
                _eventAggregator = eventAggregator;
                _statusMessage = new StatusBarMessageHelper(eventAggregator);
                StatusBarMessageHelper = new StatusBarMessageHelper(eventAggregator);
                CustomDialogHelper = new CustomDialogHelper(eventAggregator);
            }

            if (regionManager != null)
                _regionManager = regionManager;

            if (dialogService != null)
                _dialogService = dialogService;
        }
        #endregion

        #region Methods
        public void RefreshTitle()
        {
            RaisePropertyChanged(nameof(Title));
        }

        //TODO: Make abstract and enforce the loading of items in this method
        public virtual async void PageLoaded()
        {
            FillLabelsFromResxFileInUX(LabelsNeeded);
        }

        /// <summary>
        /// This method is called when a request to close a tab has been sent.
        /// </summary>
        /// <returns>Returns a boolean representing whether the tab should continue closing</returns>
        public virtual bool OnClosing()
        {
            return true;
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            StatusBarMessageHelper.DisplayMessage(string.Empty, View, UXNotificationType.DefaultMessage);
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            //Remove any leftover errors from screens which cannot call OnNavigatedFrom
            if (navigationContext.NavigationService.Journal != null)
            {
                if (!navigationContext.NavigationService.Journal.CanGoBack)
                    StatusBarMessageHelper.DisplayMessage(string.Empty, View, UXNotificationType.DefaultMessage);
            }
            Function = navigationContext.Parameters["Function"] as string;
            Module = navigationContext.Parameters["Module"] as string;
            View = navigationContext.Parameters["View"] as string;
            ViewFallback = navigationContext.Parameters["ViewFallback"] as string;

            if (View != null)
                LabelsNeeded.Add(View);
        }

        protected void FillLabelsFromResxFileInUX(IEnumerable<string> labelCodes)
        {
            try
            {
                var result = new ObservableDictionary<string, string>();
                using (var resxSet = new ResXResourceSet(ResourceLabelProvider._resxFile))
                {
                    foreach (var label in labelCodes)
                    {
                        if (label != null)
                            if (!result.ContainsKey(label))
                            {
                                var value = resxSet.GetString(label);
                                if (value != null)
                                    result.Add(label, value);
                            }
                    }
                }

                Labels = result;

                if (View != null)
                    Header = (Labels.ContainsKey(View)) ? Labels[View] : ViewFallback;
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                _statusMessage.DisplayMessage(error, View, UXNotificationType.ErrorMessage);
            }
        }


        protected virtual void OnIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, new EventArgs());
            if (_regionManager != null)
            {
                if (_contextualTabs != null && openContextualOnActive)
                {
                    if (IsActive)
                    {
                        OpenContextualTabs();
                    }
                    else
                    {
                        CloseContextualTabs();
                    }
                }

                if (_widgetBarGroups != null && openWidgetOnActive)
                {
                    if (IsActive)
                    {
                        OpenWidgetBar();
                    }
                    else
                    {
                        CloseWidgetBar();
                    }
                }
            }
        }

        public void OpenWidgetBar()
        {
            foreach (var group in _widgetBarGroups)
                _regionManager.Regions[RegionNames.WidgetBarGroupRegion].Add(group);
        }

        public void CloseWidgetBar()
        {
            foreach (var group in _widgetBarGroups)
                _regionManager.Regions[RegionNames.WidgetBarGroupRegion].Remove(group);
        }
        public void OpenContextualTabs()
        {
            foreach (var tab in _contextualTabs)
                _regionManager.Regions[RegionNames.RibbonTabRegion].Add(tab);
        }

        public void CloseContextualTabs()
        {
            foreach (var tab in _contextualTabs)
                _regionManager.Regions[RegionNames.RibbonTabRegion].Remove(tab);
        }

        /// <summary>
        /// Wraps a method with the busy indicator by placing the execution of a method on a background thread, allowing
        /// the UI thread to act freely.
        /// to operate.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task ShowBusyIndicator(Action action)
        {
            try
            {
                if (BusyIndicator == null)
                    BusyIndicator = new BusyIndicator(_eventAggregator);
                await BusyIndicator.ShowBusyIndicator(action);
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                _statusMessage.DisplayMessage(error, View, UXNotificationType.ErrorMessage);
            }
        }

        protected async Task SecurityOverrides()
        {
            try
            {
                var fieldOverrideFilters = new FieldOverrideRequestModel
                {
                    UserGuid = UserPreferenceSetupHelper.CurrentUser.UserGuid,
                    GroupGuids = UserPreferenceSetupHelper.Groups?.Select(x => x.Id).ToList(),
                    ViewName = ViewFallback
                };
                var securityOverrideValues = await Api.Commercial.ServiceHelper.Post<IEnumerable<FieldOverrideModel>>(ServiceEndpointRoutes.FieldOverrideAccess, fieldOverrideFilters);
                if (securityOverrideValues != null)
                {
                    foreach (var fieldoverride in securityOverrideValues)
                    {
                        var currentVariable = GetType().GetProperty(fieldoverride.VariableName);
                        currentVariable?.SetValue(this, fieldoverride.FieldValue, null);
                    }
                }
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                _statusMessage.DisplayMessage(error, View, UXNotificationType.ErrorMessage);
            }
        }
        #endregion
    }
}