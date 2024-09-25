/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   StartupHelper.cs
Function           :   
Created By         :   
Created on         :   
Revision History   :   [17-Sep-2020] : Srashti Gupta
*                  :   [] : Commented the creation of dictionary code for {NewPartRequest} service
****************************************************************************************************/
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.JsoxAudit;
using Common.UX.Api;
using Common.UX.Api.Endpoints;
using Common.UX.Wpf.Events;
using Microsoft.Practices.Unity;
using Prism.Events;

namespace Common.UX.Wpf.Helpers
{
    public static class StartupHelper
    {
        public static Task GetUserTask { get; set; }
        public static Task GetGroupsTask { get; set; }
        public static Task<LaunchStatus> GetLaunchStatusTask { get; set; }

        public static async void Start(IEventAggregator eventAggregator, IUnityContainer container)
        {
            CreateServiceDictionary();
            eventAggregator.GetEvent<ModuleLoadedEvent>().Publish(new ModuleLoadedEvent { Message = "Checking User Credentials" });

            Api.Commercial.ServiceHelper.CreateClient();

            var notificationHelper = container.Resolve<NotificationHelper>();
            container.RegisterInstance(notificationHelper);

            //Initialize the User and check preferences from the service
            Task.Run(UserPreferenceSetupHelper.InitializeUser).Wait();
#if (!DEBUG)
            //GetLaunchStatusTask = Task.Run(UserPreferenceSetupHelper.GetUserLaunchStatus);
            //GetGroupsTask = Task.Run(UserPreferenceSetupHelper.GetGroups);
            GetGroupsTask = Task.FromResult(0);
            GetLaunchStatusTask = Task.FromResult(LaunchStatus.Completed);
#else
            GetGroupsTask = Task.FromResult(0);
            GetLaunchStatusTask = Task.FromResult(LaunchStatus.Completed);
           // GetLaunchStatusTask = Task.Run(UserPreferenceSetupHelper.GetUserLaunchStatus);
           // GetGroupsTask = Task.Run(UserPreferenceSetupHelper.GetGroups);
            //GetGroupsTask = Task.FromResult(0);
            //GetLaunchStatusTask = Task.FromResult(LaunchStatus.Completed);
#endif

            eventAggregator.GetEvent<ModuleLoadedEvent>().Publish(new ModuleLoadedEvent { Message = "Loading Resources" });

            //Create resource file based on user
            if (UserPreferenceSetupHelper.CurrentUser == null) return;
           

            var userPreferenceLanguage = UserPreferenceSetupHelper.CurrentUser.PreferredLanguage; //"English";
            new ResourceLabelProvider().GenerateResxFileFromService(userPreferenceLanguage);
        }

        private static void CreateServiceDictionary()
        {
            ServiceHelper.ServiceDictionary = new Dictionary<string, bool>
            {
                {"Material", true},
                {"SupplierMaterialAssociation", true },
                {"PurchasingSupplierMaterial", true },
                {"SupplierMaterialPOPricing", true },
                {"SupplierSelection", true },
                {"UnitOfMeasureAssociation/GetUOMAssociationFiltered", true},
                {"SupplierMaterialOriginException", true},
                //{"NewPartRequest", true},
                {"MaterialHierarchy", true},
                {"CustomerBusinessHierarchy", true}
            };

            Api.Commercial.ServiceHelper.ServiceDictionary = new Dictionary<string, bool>
            {
                {"Performance", true },
                {"SupplierSelection", true },
                {"H1ConfigurationSetting", true},
                {"H1ServiceConfigurationSetting", true},
            };

            NetCoreServiceHelper.ServiceDictionary = new Dictionary<string, bool>
            {
                {"CentralPurchasing/api/SF.CentralPurchasing.CoreMaterialHierarchy/CoreMaterialHierarchy", true },
                 {"H1.CentralPurchasing/SF.CentralPurchasing.CoreMaterialHierarchy/CoreMaterialHierarchy", true }
            };
        }
    }
}
