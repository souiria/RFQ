/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name           :   OutlookBarViewModel.cs
Function            :   Showing Menu - Function/Module/View listing
Created By          :   Joe
Created on          :   01-Jun-2018
Revision History    :   Ajay: 26-Aug-2019
                        [ ]: Comment Search NPR & Transfer NPR
                        [ ]: Search NPR already incorporated in NPR & NPR Backlog
                        [ ]: Transfer NPR will not be separate menu item any more
                    :   [18-Feb-2020] Pawan
                    :   [] : Changes done to display username in Menu
                    :   [07-Apr-2020] Amit
                    :   [] : Loggind added w.r.t GZip error
                    :   [01-Jul-2021] Shivam Dhingra
                    :   [] : Added new service calling for Loading H1 Menu
                    :   [01-Dec-2022] Vishwadeep Singh
                    :   [] : Added new Method Check for update IsUpdateAvailable
****************************************************************************************************/
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Common.Core.Contracts.Models.Administration.Security;
using Common.UX.Api.Commercial;
using Common.UX.Api;
using Common.UX.Api.Endpoints;
using Common.UX.Wpf.Base;
using Common.UX.Wpf.Contracts.Models;
using Common.UX.Wpf.Events;
using Common.UX.Wpf.Helpers;
using Microsoft.Practices.ObjectBuilder2;
using System.IO;
using Newtonsoft.Json;
using Common.UX.Logging;
using Common.Core.Contracts.Models.JsoxAudit;
using ServiceHelper = Common.UX.Api.Commercial.ServiceHelper;
using Squirrel;

namespace SEWSE.H1.UX.Module.Core.OutlookBar.ViewModels
{
    public class OutlookBarViewModel : ViewModelBase
    {
        public ApplicationUpdater ApplicationUpdater;//Added By : Vishwadeep on 01-Dec-2022

        private bool _isScreenMinimized;
        public bool IsScreenMinimized
        {
            get => _isScreenMinimized;
            set => SetProperty(ref _isScreenMinimized, value);
        }

        private string _searchMenuText;
        public string SearchMenuText
        {
            get => _searchMenuText;
            set { SetProperty(ref _searchMenuText, value); Views.View.Refresh(); ClearSearchMenuTextCommand.RaiseCanExecuteChanged(); }
        }

        private string _searchMenuNullText;
        public string SearchMenuNullText
        {
            get => _searchMenuNullText;
            set => SetProperty(ref _searchMenuNullText, value);
        }

        private ObservableCollection<FunctionSecurityModel> _outlookBarGroups;
        public ObservableCollection<FunctionSecurityModel> OutlookBarGroups
        {
            get => _outlookBarGroups;
            set => SetProperty(ref _outlookBarGroups, value);
        }

        private CollectionViewSource _views;
        public CollectionViewSource Views
        {
            get => _views;
            set => SetProperty(ref _views, value);
        }

        private ViewSecurityModel _selectedView;
        public ViewSecurityModel SelectedView
        {
            get => _selectedView;
            set { SetProperty(ref _selectedView, value); NavigateToView(_selectedView); }
        }

        public DelegateCommand ClearSearchMenuTextCommand { get; private set; }

        private string _selectedModuleHeader;
        public string SelectedModuleHeader { get { return _selectedModuleHeader; } set { } }

        public OutlookBarViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(eventAggregator, regionManager)
        {
            UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: constructor:: started");
            _eventAggregator.GetEvent<MessageUpdateEvent>().Publish(new MessageUpdateEvent { Message = "Loading OutlookBar Module" });
            _eventAggregator.GetEvent<MaximizeScreenEvent>().Subscribe(MaximizeScreen);
            //_eventAggregator.GetEvent<NavigationEvent>().Subscribe(NavigateToView);
            _eventAggregator.GetEvent<SelectedModuleEvent>().Subscribe(UpdateSelectedModuleText);

            ClearSearchMenuTextCommand = new DelegateCommand(ClearSearchMenuText, () => !string.IsNullOrEmpty(_searchMenuText));
            PageLoadedCommand = new DelegateCommand(ExecuteViewLoad);

            SearchMenuNullText = "";
            ApplicationUpdater = new ApplicationUpdater(_eventAggregator);
            UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: constructor:: ended");
        }

        public async void ExecuteViewLoad()
        {
            UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: ExecuteViewLoad:: started");
            _eventAggregator.GetEvent<LoadingEvent>().Publish(true);

            var task = await Task.Run(LoadMenu).ContinueWith(async (loadTask) =>
            {
                UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: ExecuteViewLoad:: continue with loadTask :: started");
                LabelsNeeded = new List<string>();
                var groups = await loadTask;
                groups.ForEach(x =>
                {
                    x.Modules.ForEach(y =>
                    {
                        y.Views.ForEach(z =>
                        {
                            LabelsNeeded.Add(z.LabelKey);
                        });
                        LabelsNeeded.Add(y.LabelKey);
                    });
                    LabelsNeeded.Add(x.LabelKey);
                });

                FillLabelsFromResxFileInUX(LabelsNeeded);

                _eventAggregator.GetEvent<LoadingEvent>().Publish(false);
                GenerateDisplayLabel(groups);
                UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: ExecuteViewLoad:: continue with loadTask :: ended");
                return groups;
            });

            OutlookBarGroups = new ObservableCollection<FunctionSecurityModel>(await task);
            Views = new CollectionViewSource();
            Views.Source = OutlookBarGroups.SelectMany(x => x.Modules.SelectMany(y => y.Views));
            Views.Filter += Views_Filter;

            UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: ExecuteViewLoad:: ended");
        }

        private void Views_Filter(object sender, FilterEventArgs e)
        {
            if (e.Item is ViewSecurityModel view)
            {
                if (!string.IsNullOrEmpty(SearchMenuText))
                {
                    e.Accepted = view.DisplayLabel.ToLower().Contains(SearchMenuText.ToLower());
                }
                return;
            }
            e.Accepted = false;
        }

        private async Task<List<FunctionSecurityModel>> LoadMenu()
        {
            UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: LoadMenu:: started");
            try
            {
                //Added By : Vishwadeep on 01-Dec-2022 - Start
#if DEBUG
                UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: LoadMenu:: Application running in debug mode.");
#else
                if (IsUpdateAvailable().Result)
                    return new List<FunctionSecurityModel>();
#endif
                //Added By : Vishwadeep on 01-Dec-2022 - End
                bool IsMenuLoaded = false;
                H1UserRegisterReportModel model = new H1UserRegisterReportModel();
                model.ADCommonName = UserPreferenceSetupHelper.CurrentUser.Username;
                model.ADLogon = UserPreferenceSetupHelper.CurrentUser.Logon;
                model.UserGuid = UserPreferenceSetupHelper.CurrentUser.UserGuid;
               // var H1USerRegisterData = await ServiceHelper.Post<H1UserRegisterReportModel>(ServiceEndpointRoutes.GetJSoxH1UserRegitrationIformation, model);
                var UserRemarks = "Success"; //H1USerRegisterData.Remarks;
                if (!string.IsNullOrEmpty(UserRemarks))
                {
                    if (UserRemarks == "Success")
                    {
                        IsMenuLoaded = true;
                        UserPreferenceSetupHelper.UserCommand = "Success";
                        UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: LoadMenu:: Success");
                    }
                    else if (UserRemarks == "Leaver")
                    {
                        UserPreferenceSetupHelper.HomeMessage = $"{ UserPreferenceSetupHelper.CurrentUser.Username } :: As you are leaver, you are not authorized to access HarnessOne";
                        UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: LoadMenu:: { UserPreferenceSetupHelper.HomeMessage }");
                    }
                    else
                    {
                        UserPreferenceSetupHelper.HomeMessage = $"{ UserPreferenceSetupHelper.CurrentUser.Username } :: { UserRemarks }";
                        UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: LoadMenu:: { UserPreferenceSetupHelper.HomeMessage }");
                    }

                }
                if (IsMenuLoaded)
                {
                    _eventAggregator.GetEvent<ModuleLoadedEvent>().Publish(new ModuleLoadedEvent { Message = "Loading Menu Items" });
                    var userID = UserPreferenceSetupHelper.CurrentUser.UserGuid.ToString();
                    //Commented old service used for Loading H1 Menu
                    //List<FunctionSecurityModel> listItems = await ServiceHelper.Get<List<FunctionSecurityModel>>(ServiceEndpointRoutes.Menu, userID); 
                    var data = await NetCoreServiceHelper.PostAndGet<FunctionSecurityModel>(ServiceEndpointRoutes.LoadMenu, null,userID);
                    List<FunctionSecurityModel> listItems = new List<FunctionSecurityModel>();
                    listItems.AddRange(data);
                    UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: LoadMenu:: Menu call completed");

                    if (listItems.Any())
                    {
                        UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: LoadMenu:: FunctionSecurity by userid: { userID } count  { listItems.Count  }");
                        //Disabled until UX notifications has been reworked.
                        listItems.FirstOrDefault(x => x.ActiveDirectoryGroup.ToLower() == "h1 user function").DisplayName = $"{UserPreferenceSetupHelper.CurrentUser.Username}";
                        // return listItems;

                        return GetTestData();
                    }
                    else
                        _statusMessage.DisplayMessage("No Menu Retrieved, please close the application and try again. If the problem persists please contact the IT Helpdesk", "Menu Generation", UXNotificationType.ErrorMessage);

                }
                else
                {
                    _statusMessage.DisplayMessage(UserPreferenceSetupHelper.HomeMessage, "Menu Generation", UXNotificationType.ErrorMessage);
                    return new List<FunctionSecurityModel>();
                }

                //_statusMessage.DisplayMessage("No Menu Retrieved, please close the application and try again. If the problem persists please contact the IT Helpdesk", "Menu Generation", UXNotificationType.ErrorMessage);
#if DEBUG
                return GetTestData();
                //return new List<FunctionSecurityModel>();
#else
                                return new List<FunctionSecurityModel>();
#endif
              //  return new List<FunctionSecurityModel>();
            }
            catch (Exception ex)
            {
                var error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: LoadMenu:: Exception.Message: {  error }");
                _statusMessage.DisplayMessage(error, "Menu Generation", UXNotificationType.ErrorMessage);
                return new List<FunctionSecurityModel>();
#if DEBUG
                return GetTestData();
               // return new List<FunctionSecurityModel>();
#else
                                return new List<FunctionSecurityModel>();
#endif

            }
            finally
            {
                UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: LoadMenu:: ended");
            }
        }

        private void GenerateDisplayLabel(List<FunctionSecurityModel> listItems)
        {

            foreach (var function in listItems)
            {
                var name = (string.IsNullOrEmpty(function.LabelKey)) ? function.DisplayName : Labels[function.LabelKey];
                if (string.IsNullOrEmpty(name)) { name = function.DisplayName; }
                function.DisplayLabel = $"{function.DisplayId}. {name}";

                foreach (var module in function.Modules)
                {
                    name = (string.IsNullOrEmpty(module.LabelKey)) ? module.DisplayName : Labels[module.LabelKey];
                    if (string.IsNullOrEmpty(name)) { name = module.DisplayName; }
                    module.DisplayLabel = $"{function.DisplayId}.{module.DisplayId}. {name}";
                    foreach (var view in module.Views)
                    {
                        name = (string.IsNullOrEmpty(view.LabelKey)) ? view.DisplayName : Labels[view.LabelKey];
                        if (string.IsNullOrEmpty(name)) { name = view.DisplayName; }
                        view.DisplayLabel = $"{function.DisplayId}.{module.DisplayId}.{view.DisplayId}. {name}";
                    }
                }
            }
        }

        private List<FunctionSecurityModel> GetTestData()
        {
            string jsonFile = File.ReadAllText(@".\MenuList.json");
            var menuData = JsonConvert.DeserializeObject<List<FunctionSecurityModel>>(jsonFile);
            menuData.FirstOrDefault(x => x.ActiveDirectoryGroup.ToLower() == "h1 user function").DisplayName = $"{UserPreferenceSetupHelper.CurrentUser.Username}";
            return menuData;
        }

        private void ClearSearchMenuText()
        {
            SearchMenuText = string.Empty;
        }

        private void MaximizeScreen(bool isMinimized)
        {
            IsScreenMinimized = isMinimized;
        }

        private void NavigateToView(ViewSecurityModel viewmenuitem)
        {
            try
            {
                if (viewmenuitem != null)
                {
                    var parameters = new NavigationParameters();

                    parameters.Add("View", viewmenuitem.LabelKey ?? viewmenuitem.DisplayName);
                    if (viewmenuitem.ParentModuleLabelKey != null)
                        parameters.Add("Module", viewmenuitem.ParentModuleLabelKey);
                    if (viewmenuitem.ParentFunctionLabelKey != null)
                        parameters.Add("Function", viewmenuitem.ParentFunctionLabelKey);
                    parameters.Add("ViewFallback", viewmenuitem.DisplayName ?? null);
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, viewmenuitem.ViewName, parameters);
                }
            }
            catch (Exception ex)
            {
                string error = $"{ex.Message}. {Environment.NewLine} {(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";
                StatusBarMessageHelper.DisplayMessage(error, View, UXNotificationType.ErrorMessage);
            }
        }

        private void UpdateSelectedModuleText(string selectedModule)
        {
            _selectedModuleHeader = selectedModule;
            RaisePropertyChanged("SelectedModuleHeader");
        }
        #region Method Check For Update
        //Added By : Vishwadeep on 01-Dec-2022
        /// <summary>
        /// Check for update
        /// </summary>
        /// <returns>true or false</returns>
        private async Task<bool> IsUpdateAvailable()
        {
            UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: IsUpdateAvailable:: Before CheckForUpdate");
            UpdateInfo update = await ApplicationUpdater.CheckForUpdate();
            UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: IsUpdateAvailable:: After CheckForUpdate");

            if (update != null)
            {
                UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: IsUpdateAvailable:: Update Loaded");

                if (update.CurrentlyInstalledVersion != update.FutureReleaseEntry)
                {
                    UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: IsUpdateAvailable:: Update Found");

                    if (update.CurrentlyInstalledVersion != null)
                    {
                        UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: IsUpdateAvailable:: return true");
                        return true;
                    }
                    else
                        UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: IsUpdateAvailable:: CurrentlyInstalledVersion is null");
                }
                else
                    UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: IsUpdateAvailable:: CurrentlyInstalledVersion and FutureReleaseEntry are same.");
            }
            else
                UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: IsUpdateAvailable:: CheckForUpdate return null");

            UXLogger.UXLoggingForDebug($"OutlookBarViewModel :: IsUpdateAvailable:: return false");
            return false;
        }
        #endregion
    }
}