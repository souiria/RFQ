using System;
using System.Threading.Tasks;
using Common.SF.Contracts.Interfaces.Core;

namespace Common.SF.Tests.MockServices
{
    internal class MockUtilities : IUtilities
    {
        public Task<Uri> InitializeEmail()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeNotifications() => Task.FromResult(new Uri("fabric:/Core.Framework/SF.Core.Notifications"));

        public Task<Uri> InitializeLogging() => Task.FromResult(new Uri("fabric:/Core.Framework/SF.Core.Logging"));

        public Task<Uri> InitializeServiceConfiguration() =>
            Task.FromResult(new Uri("fabric:/Core.Framework/SF.Core.ServiceConfiguration"));

        public Task<Uri> InitializeSecurity()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeUser()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeH1ConfigurationSetting()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeH1ServiceConfigurationSetting()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSupplierType()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSupplierGroup()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSite()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSiteType()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeCountrySecurityFilter()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeMaterial()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSupplier()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeMaterialType()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeUnitOfMeasure()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeCommodity()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeCountry()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeContact()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeContactType()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeCurrency()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePaymentTerms()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeIncoterms()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeTariffCode()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSourceApplication()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeBusinessUnit()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeBusinessUnitType()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeCountryRegions()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeVehicle()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeFacility()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeApplicationArticle()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeProcurementUnit()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeGIStore()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeExchangeRate()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeOriginStatus()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeReason()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeReasonH1FunctionAssociation()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSupplierMaterialAssociation()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSupplierAssociation()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeMaterialAssociation()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeValidationsGlobalMastersAssociation()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSourceApplicationArticleAssociation()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeUnitOfMeasureAssociation()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeCountryRegionsAssociation()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeProcurementUnitBusinessUnitAssociation()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeCurrencyExchangeRate()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePOPriceType()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingCommodity()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePOPriceEffectiveDateType()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSupplierDevelopmentTeam()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeEPOCommodityGroup()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingSupplier()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingMaterial()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingSupplierMaterial()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeETLPurchasingCommonUtilities()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSupplierMaterialPOPricing()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeMaterialOrigin()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSupplierSelection()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeMaterialInventory()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingArticleSynchronization()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeFirstReceiptDate()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeForecastAnnualBySite()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeETLH1ToCPDMaterialDataSync()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingArticleJobScheduler()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingArticleJobDetails()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeBusinessUnitArticleSynchronization()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeCPDToH1SynchronizationScheduler()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingVehicle()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingFacility()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingCustomerGroup()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingFacilityGroup()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeAccess()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeDataFilter() =>
            Task.FromResult(new Uri("fabric:/Administration.Security/SF.Security.DataFilter"));

        public Task<Uri> InitializeUXData()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeHelpdesk()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeEmacsCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeEmacsCustomerData()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeEmacsNpaCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeEmacsNpaSupplier()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeEmacsPart()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeEmacsSupplier()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeDsi()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeDsiAssociation()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeRFQEnquiry()
        {
            throw new NotImplementedException();
        }

        public Task<string> Encrypt(string encryptingText, bool useHashing, string key)
        {
            throw new NotImplementedException();
        }

        public Task<string> Decrypt(string decryptingText, bool useHashing, string key)
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSubsidiary()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeNPAStatusCode()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeProductionPartApprovalProcessLevel()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeNewPartsAuthorization()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeNPAType()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeArchiveNewPartsAuthorization()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSupplierMaterialOriginException()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingCustomerFacilityVehicle()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingVehicleMaster()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingCustomerMaster()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializePurchasingFacilityMaster()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeNewPartRequest()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeRFQReason()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeCommodityQuantitySettings()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSupplierApprovalStatus()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeProjectEngineeringAssociation()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeSupplierRFQSettings()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeRFQParameterSettings()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeRFQEmailSettings()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeRFQStatus()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeFunctionControlSequenceType()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeProjectDetails()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeNPRBacklog()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeRFQ()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeFunctionControlSequenceGenerator()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeMaterialHierarchy()
        {
            throw new NotImplementedException();
        }

        public Task<Uri> InitializeCustomerBusinessHierarchy()
        {
            throw new NotImplementedException();
        }
    }
}
