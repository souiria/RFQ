using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.Core
{
    public interface IUtilities : IService
    {
        #region CoreFramework

        Task<Uri> InitializeEmail();
        Task<Uri> InitializeNotifications();
        Task<Uri> InitializeLogging();
        Task<Uri> InitializeServiceConfiguration();
        Task<Uri> InitializeSecurity();
        Task<Uri> InitializeUser();

        Task<Uri> InitializeH1ConfigurationSetting();
        Task<Uri> InitializeH1ServiceConfigurationSetting();

        #endregion

        #region GlobalMasters
        Task<Uri> InitializeSupplierType();
        Task<Uri> InitializeSupplierGroup();
        Task<Uri> InitializeSite();
        Task<Uri> InitializeSiteType();
        Task<Uri> InitializeCountrySecurityFilter();
        Task<Uri> InitializeMaterial();
        Task<Uri> InitializeSupplier();
        Task<Uri> InitializeMaterialType();
        Task<Uri> InitializeUnitOfMeasure();
        Task<Uri> InitializeCommodity();
        Task<Uri> InitializeCountry();
        Task<Uri> InitializeContact();
        Task<Uri> InitializeContactType();
        Task<Uri> InitializeCurrency();
        Task<Uri> InitializePaymentTerms();
        Task<Uri> InitializeIncoterms();
        Task<Uri> InitializeTariffCode();
        Task<Uri> InitializeSourceApplication();
        Task<Uri> InitializeBusinessUnit();
        Task<Uri> InitializeBusinessUnitType();
        Task<Uri> InitializeCountryRegions();
        Task<Uri> InitializeCustomer();
        Task<Uri> InitializeVehicle();
        Task<Uri> InitializeFacility();
        Task<Uri> InitializeApplicationArticle();
        Task<Uri> InitializeProcurementUnit();
        Task<Uri> InitializeGIStore();
        Task<Uri> InitializeExchangeRate();
        Task<Uri> InitializeOriginStatus();
        Task<Uri> InitializeReason();
        Task<Uri> InitializeReasonH1FunctionAssociation();
        Task<Uri> InitializeSupplierApprovalStatus();
        Task<Uri> InitializeCustomerBusinessHierarchy();

        #endregion

        #region GlobalMastersAssociation
        Task<Uri> InitializeSupplierMaterialAssociation();
        Task<Uri> InitializeSupplierAssociation();
        Task<Uri> InitializeMaterialAssociation();
        Task<Uri> InitializeValidationsGlobalMastersAssociation();
        Task<Uri> InitializeSourceApplicationArticleAssociation();
        Task<Uri> InitializeUnitOfMeasureAssociation();
        Task<Uri> InitializeCountryRegionsAssociation();
        Task<Uri> InitializeProcurementUnitBusinessUnitAssociation();
        Task<Uri> InitializeCurrencyExchangeRate();
        Task<Uri> InitializeProjectEngineeringAssociation();
        #endregion

        #region Purchasing
        Task<Uri> InitializePOPriceType();
        Task<Uri> InitializePurchasingCommodity();
        Task<Uri> InitializePOPriceEffectiveDateType();
        Task<Uri> InitializeSupplierDevelopmentTeam();
        Task<Uri> InitializeEPOCommodityGroup();
        Task<Uri> InitializePurchasingSupplier();
        Task<Uri> InitializePurchasingMaterial();
        Task<Uri> InitializePurchasingSupplierMaterial();
        Task<Uri> InitializeMaterialHierarchy();
        Task<Uri> InitializeETLPurchasingCommonUtilities();
        Task<Uri> InitializeSupplierMaterialPOPricing();
        Task<Uri> InitializeMaterialOrigin();
        Task<Uri> InitializeSupplierSelection();
        Task<Uri> InitializeMaterialInventory();
        Task<Uri> InitializePurchasingArticleSynchronization();
        Task<Uri> InitializeFirstReceiptDate();
        Task<Uri> InitializeForecastAnnualBySite();
        Task<Uri> InitializeETLH1ToCPDMaterialDataSync();
        Task<Uri> InitializePurchasingArticleJobScheduler();
        Task<Uri> InitializePurchasingArticleJobDetails();
        Task<Uri> InitializeBusinessUnitArticleSynchronization();
        Task<Uri> InitializeCPDToH1SynchronizationScheduler();
        Task<Uri> InitializePurchasingVehicleMaster();
        Task<Uri> InitializePurchasingCustomerMaster();
        Task<Uri> InitializePurchasingFacilityMaster();
        Task<Uri> InitializeSupplierMaterialOriginException();
        Task<Uri> InitializePurchasingCustomerFacilityVehicle();
        Task<Uri> InitializeRFQReason();
        Task<Uri> InitializeCommodityQuantitySettings();
        Task<Uri> InitializeSupplierRFQSettings();
        Task<Uri> InitializeRFQParameterSettings();
        Task<Uri> InitializeRFQEmailSettings();
        Task<Uri> InitializeRFQStatus();
        #endregion

        #region Administration

        #region Security

        Task<Uri> InitializeAccess();
        Task<Uri> InitializeDataFilter();

        #endregion

        #region Maintenance

        Task<Uri> InitializeUXData();

        Task<Uri> InitializeFunctionControlSequenceType();

        #endregion

        #endregion

        #region ETL
        Task<Uri> InitializeHelpdesk();
        #region Emacs
        Task<Uri> InitializeEmacsCustomer();
        Task<Uri> InitializeEmacsCustomerData();
        Task<Uri> InitializeEmacsNpaCustomer();
        Task<Uri> InitializeEmacsNpaSupplier();
        Task<Uri> InitializeEmacsPart();
        Task<Uri> InitializeEmacsSupplier();
        #endregion
        #endregion

        #region Sales

        Task<Uri> InitializeDsi();
        Task<Uri> InitializeDsiAssociation();

        #region Rfq
        Task<Uri> InitializeRFQEnquiry();
        //Task<Uri> InitializeRFQPartSearch();
        #endregion

        #endregion

        Task<string> Encrypt(string encryptingText, bool useHashing, string key);
        Task<string> Decrypt(string decryptingText, bool useHashing, string key);

        #region NPA
        Task<Uri> InitializeSubsidiary();
        Task<Uri> InitializeNPAStatusCode();
        Task<Uri> InitializeProductionPartApprovalProcessLevel();
        Task<Uri> InitializeNewPartsAuthorization();
        Task<Uri> InitializeNPAType();
        Task<Uri> InitializeArchiveNewPartsAuthorization();
        #endregion
        #region NPR
        Task<Uri> InitializeNewPartRequest();
        //Task<Uri> InitializeProjectDetails();
        #endregion
        #region RFQManagement
        //Task<Uri> InitializeRFQReason();
        //Task<Uri> InitializeCommodityQuantitySettings();
        Task<Uri> InitializeNPRBacklog();
        Task<Uri> InitializeRFQ();
        Task<Uri> InitializeFunctionControlSequenceGenerator();
        #endregion
    }
}
