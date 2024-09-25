using Microsoft.Practices.Unity;
using Prism.Events;
using SEWSE.H1.UX.Infrastructure.Core.Events;
using SEWSE.H1.UX.Infrastructure.Core.Notifications;
using SEWSE.H1.UX.Infrastructure.Core.Services;
using System.Collections.Generic;

namespace SEWSE.H1.UX.Infrastructure.Core.Helpers
{
    public static class StartupHelper
    {

        public static void Start(IEventAggregator eventAggregator, IUnityContainer container)
        {
            eventAggregator.GetEvent<ModuleLoadedEvent>().Publish(new ModuleLoadedEvent { Message = "Checking User Credentials" });
            var notificationHelper = container.Resolve<NotificationHelper>();
            container.RegisterInstance(notificationHelper);

            Commercial.UX.Infrastructure.Core.Services.ServiceHelper.CreateClient();

            //Initialize the User and check preferences from the service
            UserPreferenceSetupHelper.InitializeUser();

#if (!DEBUG)
                UserPreferenceSetupHelper.GetGroups();
#endif

            eventAggregator.GetEvent<ModuleLoadedEvent>().Publish(new ModuleLoadedEvent { Message = "Loading Resources" });
            //Create resource file based on user
            if (UserPreferenceSetupHelper.CurrentUser != null)
            {
                string userPreferenceLanguage = UserPreferenceSetupHelper.CurrentUser.PreferredLanguage; //"English";
                new ResourceLabelProvider().GenerateResxFileFromService(userPreferenceLanguage);
            }

            ServiceHelper.ServiceDictionary = new Dictionary<string, bool>
            {
                {"Material", true},
                {"UnitOfMeasure", true },
                {"SourceApplication", true},
                {"MaterialAssociation", true },
                {"SupplierMaterialAssociation", true },
                {"PurchasingSupplierMaterial", true },
                {"SupplierMaterialPOPricing", true },
                {"SupplierSelection", true },
                {"UnitOfMeasureAssociation/GetUOMAssociationFiltered", true}
            };
            Commercial.UX.Infrastructure.Core.Services.ServiceHelper.ServiceDictionary = new Dictionary<string, bool>
            {
                {"Performance", true },
                {"SupplierSelection", true },
                {"H1ConfigurationSetting", true},
                {"H1ServiceConfigurationSetting", true},
            };
        }
    }
}
