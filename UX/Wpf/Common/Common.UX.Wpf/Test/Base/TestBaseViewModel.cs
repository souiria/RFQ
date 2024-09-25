/**************************************************************************************************
(C) 2019 SEWS-E Ltd., All rights reserved
File Name          :   TestBaseViewModel.cs
Function           :   BaseClass For TestCases.
Created By         :   Sai Kiran
Created on         :   14-Mar-2019
Revision History   :   [28-Mar-2019] : Dharmendra
*                  :   [ ] : Add Load Complete action
*                  :   [15-Apr-2019] : Yati
*                  :   [ ] : Added PageReLoadOperation action      
*                  :   [20-May-2020] : Shivam Dhingra
*                  :   [ ] : Added new Mock object mockNetCoreService for NetCoreServices
*                  
****************************************************************************************************/
using Common.Core.Contracts.Models.User;
using Common.UX.Api;
using Common.UX.Contracts.Interfaces.Core;
using Common.UX.Logging;
using Common.UX.Wpf.Contracts.Models;
using Common.UX.Wpf.Contracts.Models.Dialog;
using Common.UX.Wpf.Events;
using Common.UX.Wpf.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using Prism.Regions;
using System;

namespace Common.UX.Wpf.Test.Base
{
    public class TestBaseViewModel<M>
    {
        protected Mock<IEventAggregator> moqEventAggregator;
        protected Mock<IRegionManager> moqRegionManager;
        protected Mock<IServiceApiProxy> mockService;
        protected Mock<INetCoreServiceApiProxy> mockNetCoreService;

        protected M viewModel;
        protected PrivateObject pViewModel;

        protected bool ErrorMsgDisplay;
        protected bool YesNoCancelConfirmation;
        protected bool? DailogReturn;
        protected int StatusBarEventCall;
        protected string statusMessage;
        protected bool ExcelEventRaiseCall;

        public string ExportExcelEndpoint = "";

        public string UserGuid = "11111111-2222-3333-4444-555555555555";
        public string UserPrincipalGuid = "66666666-7777-8888-9999-111111111111";

        private bool _isUXLoggerMockingRequired = false;

        public bool IsUXLoggerMockingRequired
        {
            set
            {
                _isUXLoggerMockingRequired = value;
                if (_isUXLoggerMockingRequired)
                {
                    Mock<IUXLogger> log = new Mock<IUXLogger>();
                    log.Setup(x => x.UXLoggingForDebug(It.IsAny<string>()));
                    UXLogger.UXLoggerProxyInstance = log.Object;
                }
            }
        }


        public TestBaseViewModel()
        {
            moqEventAggregator = new Mock<IEventAggregator>();
            moqRegionManager = new Mock<IRegionManager>();

            UserPreferenceSetupHelper.CurrentUser = new UserPreferenceModel { UserGuid = Guid.Parse(UserGuid), GivenName = "GivenName_Test", Surname = "Surname_Test" };
            UserPreferenceSetupHelper.UserPrincipalGuid = Guid.Parse(UserPrincipalGuid);

            mockService = new Mock<IServiceApiProxy>();
            mockNetCoreService = new Mock<INetCoreServiceApiProxy>();

            //SetCurrentDirectory();
            MockBasicEvents();
            MockBasicServices();
        }

        protected void SetCurrentDirectory()
        {
            var path = Environment.CurrentDirectory;
            var pathsplit = path.Split('\\');
            path = "";
            for (int i = 0; i < pathsplit.Length - 5; i++)
            {
                path = path + pathsplit[i] + "\\";
            }
            Environment.CurrentDirectory = path + @"UXCore\HarnessOneUXCore\SEWSE.H1.UX.Shell\bin\Debug";
        }
        protected void MockBasicEvents()
        {
            moqEventAggregator.Setup(it => it.GetEvent<LoadingEvent>()).Returns(new LoadingEvent { });
            moqEventAggregator.Setup(it => it.GetEvent<StatusBarNotificationChangedEvent>()).Returns(new StatusBarNotificationChangedEvent { });
            moqEventAggregator.Object.GetEvent<StatusBarNotificationChangedEvent>().Subscribe(StatusBarEventReturn);

            moqEventAggregator.Setup(it => it.GetEvent<ShellDialogEvent<UXCustomDialogBase>>()).Returns(new ShellDialogEvent<UXCustomDialogBase>());
            moqEventAggregator.Object.GetEvent<ShellDialogEvent<UXCustomDialogBase>>().Subscribe(ShowDialog);

            moqEventAggregator.Setup(it => it.GetEvent<ExportGridDataEvent>()).Returns(new ExportGridDataEvent());
            moqEventAggregator.Object.GetEvent<ExportGridDataEvent>().Subscribe(ExcelEventRaise);

        }
        protected void StatusBarEventReturn(UXStatusBarNotification obj)
        {
            StatusBarEventCall += 1;
            statusMessage = obj.Message;
        }
        protected void ShowDialog(UXCustomDialogBase dialogObj)
        {
            switch (dialogObj.Type)
            {
                case UXDialogTypes.Error:
                    ErrorMsgDisplay = true;
                    break;
                case UXDialogTypes.YesNoConfirmation:
                case UXDialogTypes.YesNoCancelConfirmation:
                    YesNoCancelConfirmation = true;
                    ((UXConfirmationDialog)dialogObj).ActionHandler(DailogReturn);
                    break;
                default:
                    break;
            }
        }
        protected void ExcelEventRaise(string obj)
        {
            if (obj == ExportExcelEndpoint)
                ExcelEventRaiseCall = true;
        }
        protected void MockBasicServices()
        {
            mockService = new Mock<IServiceApiProxy>();
            ServiceHelper.ServiceApiProxy = mockService.Object;
            mockNetCoreService = new Mock<INetCoreServiceApiProxy>();
            NetCoreServiceHelper.NetCoreServiceApiProxy = mockNetCoreService.Object;
        }

        protected bool UnsubscribeExport = false;
        protected bool databind = false;
        protected bool ClearFilter = false;
        protected bool LoadComplete = false;
        protected bool pageReloadOperation = false;
        protected void dummy_UnsubscribeExport()
        {
            UnsubscribeExport = true;
        }
        protected void dummy_DataBindCompleted()
        {
            databind = true;
        }

        protected void dummy_PageReLoadOperation()
        {
            pageReloadOperation = true;
        }
        protected void dummy_ClearFilter()
        {
            ClearFilter = true;
        }

        protected void dummy_LoadCompleted()
        {
            LoadComplete = true;
        }

    }
}
