/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name           :   ServiceEndpointRoutesPurchasing.cs
Function            :   Maintaining all endpoints to reach the service for Purchasing master module
Created By          :   MIND Team
Created on          :   02-Jan-2019
Revision History    :   Ajay: 25-Aug-2019
                        [ ]: SupplierPanel endpoint routes added
                    :   [25-Sep-2019] : Pawan Kumar
                        [ ]: Added route for Issue username
                    :   [14-Oct-2019] : Srashti Gupta
                         Added route for Material Hierarchy
                    :   [19-Nov-2019] : Srashti Gupta
                        [ ]:Added route for POPriceValidations/ValidateSupplierMaterialPOPricingHierarchyUploadData/?H1=true
                    :   [12-Dec-2019] : Srashti Gupta
                        [ ]:Remove route for POPriceValidations/ValidateSupplierMaterialPOPricingHierarchyUploadData/?H1=true
                    :   [30-March-2020] : Srashti Gupta
                        []: Added route for CoreMaterialHierarchy Service.
                    :   [28-April-2020] : Srashti Gupta
                        []: Remove route for ETLSupplierMaterialPOPricingGetGridDataWithFilter.
                    :   [28-April-2020] : Srashti Gupta
                        []: Remove unused EndPoints.
                    :   [07-May-2020] Dharmendra
                        [] :change  SupplierMaterialOriginExceptionPropagation and FCDataSyncFacilityVehicleCustomer endpoint from CPDToH1SynchronizationScheduler to ETLPurchasingArticleSynchronization
                    :   [14-May-2020] : Dharmendra 
                    :   [ ] : Change endpoint FCDataSyncFacilityVehicleCustomer to FCDataSyncVehicleFacilityCustomer
                    :   [22-May-2020] : Dharmendra 
                    :   [ ] : Comment ETLSupplierMaterialPOPricing endpoint.
                    :   [02-Sep-2020] : Dharmendra 
                    :   [ ] : Un Comment PurchasingFacilityMaster,PurchasingCustomerMaster and PurchasingVehicleMaster endpoint.
                    :   [09-Sep-2021] : Shivam Kalia
                    :   [ ] : Added an endpoint GetMaterialShortageReportDHSData
                    :   [23-Mar-2022] : Shivam Kalia
                    :   [ ] : Added an endpoint SupplierSelectionHierarchyShowStateless
                    :   [24-Mar-2022] : Sejal Srivastava
                    :   [ ] : Added an endpoint SupplierMaterialMaintenanceHierarchyShowStateless
                    :   [24-Mar-2022] : Shivam Kalia
                    :   [ ] : Added an endpoint GetPurchasingSupplierMaterialCombination
                    :   [25-Mar-2022] : Shivam Kalia
                    :   [ ] : Added an endpoint ProcessSupplierSelectionHierarchy,H1SupplierSelectionHierarchyUploadValidateAndSave,ProcessOperationPurchasingSupplierMaterialHierarchy
                    :   [28-Mar-2022] : Sejal Srivastava
                    :   [] : Added an endpoint H1PurchasingSupplierMaterialHierarchyUploadValidateAndSave
                    :   [01-Apr-2022] : Sejal Srivastava
                    :   [] : Added an endpoint CheckWithMaterialNumber  
                    :   [01-Apr-2022] : Shivam Kalia
                    :   Shifted endpoint CheckWithMaterialNumber to ServiceEndpointRoutesGlobalMasters.cs and added an endpoint for GetAllMaterialForSupplierSelectionHierarchy
                    :   [05-Apr-2022] : Ranjay
                    :   [ ] : Added an endpoint GetSupplierMaterialHierarchyByFilterStateless
                    :   [03-Jun-2022] : Shivam Kalia
                    :   [] : Added endpoint ShowPOPriceListIncSupplierMaterialDetailsNewFormat
                    :   [16-Jun-2022] : Dharmendra
                    :   [] : Added endpoint SupplierSelectionHierarchyShowStatelessSearchfilter
                    :   [30-Sep-2022] : Dharmendra
                    :   [] : Added endpoint ToolTypeData,GetToolTypeDataByToolType
                    :   [30-Sep-2022] : Virendra
                    :   [] : Added endpoint ToolConditionData and GetToolConditionData
                    :   [13-Oct-2022] : Dharmendra 
                    :   [] : Added endpoint SupplierToolMaintenanceData and SupplierToolMaintenance,H1SupplierToolMaintenanceUploadValidateAndSave
                    :   [07-Nov-2022] : Virendra 
                    :   [] : Added endpoint SupplierToolMaintenanceLogByProcedure
                    :   [10-Nov-2022] : Virendra 
                    :   [] : Added endpoint TransferData_PurchasingSupplierMaterial_TO_SupplierToolMaintenance
                    :   [23-Nov-2022] : Ranjay 
                    :   [] : Added endpoint GetAllMaterialInSupplierToolMaintenance
                    :   [05-Dec-2022] : Virendra  
                    :   [] : Added two endpoint 1. ProcessOperationGenerateOTP 2. ValidateOTP
                    :   [13-Dec-2022] : Virendra  
                    :   [] : Added endpoint GetAllAuditID
                    :   [20-Jan-2023] : Vishwadeep Singh 
                    :   [] : Added endpoint GetNPRBackLogByFilter
                    :   [08-Feb-2023] : Ranjay 
                    :   [] : Added new endpoint GetSupplierRFQPortalSettingsFilterData (HD 00368968)
                    :   [01-Mar-2023] : Ranjay              
                    :   [] : [HD Call Number : 00368968] Change endpoint name CheckUserInSupplierRFQPortalSettings
                    :   [11-Apr-2023] : Prakhar Singh 
                    :   [] : Added endpoint GetAllSupplierPartNumber
                    :   [21-Apr-2023] : Vishwadeep Singh 
                    :   [HD-00376675] : Added endpoint GetNPRBackLogFilteredData
                    :   [27-Jun-2023] : Vishwadeep Singh 
                    :   [HD-00367280] : Added new endpoint GetNPRByMultipleId
                    :   [06-Jul-2023] : Ranjay 
                    :   [] : Added new endpoint CheckNPRDataBySupplierGroupGuid
                    :   [12-Jul-2023] : Ranjay 
                    :   [HD-00385117] : Added new endpoint CheckNprByRequestIdAndSupplier
                    :   [21-Jul-2023] : Prakhar 
                    :   [HD-00383937] : Added new endpoint GetInvoiceQueryReason and ProcessOperationInvoiceQueryReason
                    :   [24-Jul-2023] : Virendra 
                    :   [HD-00383937] : Added new endpoint
                    :   [26-Jul-2023] : Virendra 
                    :   [HD-00383937] : Added new endpoint SyncInvoiceH1ToDHS
                    :   [27-Jul-2023] : Virendra 
                    :   [HD-00383937] : Added new endpoint H1_ShowOrderValueByInvoiceNumber
                    :   [07-Aug-2023] : Virendra 
                    :   [HD-00383937] : Added new endpoint InvoiceManagementUpload
*                   :   [23-Aug-2023] : Dharmendra
*                   :   HD Call Number 00387437 : Migrate 5.2.4 Supplier Material Origin Exception from a stateful service to stateless
*                   :   [24-Aug-2023] : Vishwadeep Singh
*                   :   [HD-00387438] : Added three new endpoint GetPurchaseSupplierMaterialPoPricingByFilter,SupplierMaterialMaintenanceHierarchyShowStatelessNew,SupplierMaterialPOPricingHierarchyStatelessNew
*                   
****************************************************************************************************/
using Common.Core.Infrastructure.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        #region Generic Call For EF
        //public static string SiteSupplier => "SiteSupplier";
        //public static string SiteMaterialSupplier => "SiteMaterialSupplier";

        public static readonly ServiceEndpointRoutes SiteSupplier = new ServiceEndpointRoutes("SiteSupplier");
        public static readonly ServiceEndpointRoutes SiteMaterialSupplier = new ServiceEndpointRoutes("SiteMaterialSupplier");
        public static readonly ServiceEndpointRoutes ForecastAnnualBySite = new ServiceEndpointRoutes("ForecastAnnualBySite");
        public static readonly ServiceEndpointRoutes PurchasingCommodity = new ServiceEndpointRoutes("PurchasingCommodity");
        public static readonly ServiceEndpointRoutes PurchasingMaterial = new ServiceEndpointRoutes("PurchasingMaterial");
        public static readonly ServiceEndpointRoutes PurchasingSupplierMaterial = new ServiceEndpointRoutes("PurchasingSupplierMaterial");
        public static readonly ServiceEndpointRoutes MaterialHierarchy = new ServiceEndpointRoutes("MaterialHierarchy");
        public static readonly ServiceEndpointRoutes PurchasingSupplier = new ServiceEndpointRoutes("PurchasingSupplier");
        public static readonly ServiceEndpointRoutes SupplierMaterialPOPricing = new ServiceEndpointRoutes("SupplierMaterialPOPricing");
        public static readonly ServiceEndpointRoutes POPriceType = new ServiceEndpointRoutes("POPriceType");
        public static readonly ServiceEndpointRoutes SupplierDevelopmentTeam = new ServiceEndpointRoutes("SupplierDevelopmentTeam");
        public static readonly ServiceEndpointRoutes EPOCommodityGroup = new ServiceEndpointRoutes("EPOCommodityGroup");
        public static readonly ServiceEndpointRoutes POPriceEffectiveDateType = new ServiceEndpointRoutes("POPriceEffectiveDateType");
        public static readonly ServiceEndpointRoutes MaterialOrigin = new ServiceEndpointRoutes("MaterialOrigin");
        public static readonly ServiceEndpointRoutes SupplierSelection = new ServiceEndpointRoutes("SupplierSelection");
        public static readonly ServiceEndpointRoutes ValidateSupplierMaterialPOPricingUploadData = new ServiceEndpointRoutes("POPriceValidations/ValidateSupplierMaterialPOPricingUploadData");
        public static readonly ServiceEndpointRoutes ValidateSupplierMaterialPOPricingUploadDataWithH1 = new ServiceEndpointRoutes("POPriceValidations/ValidateSupplierMaterialPOPricingUploadData/?H1=true");

        public static readonly ServiceEndpointRoutes ValidateSupplierMaterialPOPricingUploadDataWithCPD = new ServiceEndpointRoutes("POPriceValidations/ValidateSupplierMaterialPOPricingUploadData/?H1=false");
        public static readonly ServiceEndpointRoutes ValidateSupplierMaterialPORatioData = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/ValidateSupplierMaterialPORatioData");
        public static readonly ServiceEndpointRoutes FirstReceiptDate = new ServiceEndpointRoutes("FirstReceiptDate");
        public static readonly ServiceEndpointRoutes MaterialInventory = new ServiceEndpointRoutes("MaterialInventory");
        public static readonly ServiceEndpointRoutes SupplierCapacityPlanning = new ServiceEndpointRoutes("SupplierCapacityPlanning");
        public static readonly ServiceEndpointRoutes PurchasingArticleSynchronization = new ServiceEndpointRoutes("PurchasingArticleSynchronization");
        public static readonly ServiceEndpointRoutes PurchasingArticleJobDetails = new ServiceEndpointRoutes("PurchasingArticleJobDetails");
        public static readonly ServiceEndpointRoutes PurchasingArticleJobScheduler = new ServiceEndpointRoutes("PurchasingArticleJobScheduler");
        public static readonly ServiceEndpointRoutes BusinessUnitArticleSynchronization = new ServiceEndpointRoutes("BusinessUnitArticleSynchronization");
        public static readonly ServiceEndpointRoutes CPDMaterialSynchronization = new ServiceEndpointRoutes("CPDToH1SynchronizationScheduler/MaterialDataSync");
        public static readonly ServiceEndpointRoutes CPDMaterialSiteSynchronization = new ServiceEndpointRoutes("CPDToH1SynchronizationScheduler/MaterialSiteDataSync");
        public static readonly ServiceEndpointRoutes ForecastDataSynchronization = new ServiceEndpointRoutes("CPDToH1SynchronizationScheduler/FCDataSync");
        public static readonly ServiceEndpointRoutes SupplierInactivePropagation = new ServiceEndpointRoutes("CPDToH1SPurchasingArticleSynchronizationynchronizationScheduler/SupplierInactivePropagation");
        public static readonly ServiceEndpointRoutes SupplierMaterialInactivePropagation = new ServiceEndpointRoutes("CPDToH1SynchronizationScheduler/SupplierMaterialInactivePropagation");
        public static readonly ServiceEndpointRoutes PurchasingSupplierMaterialInactivePropagation = new ServiceEndpointRoutes("CPDToH1SynchronizationScheduler/PurchasingSupplierMaterialInactivePropagation");

        public static readonly ServiceEndpointRoutes ETLFirstReceiptDateGetGridDataWithFilter = new ServiceEndpointRoutes("CPDReports/GetGridDataFirstReceipt");
        public static readonly ServiceEndpointRoutes PurchasingCustomer = new ServiceEndpointRoutes("PurchasingCustomer");
        public static readonly ServiceEndpointRoutes PurchasingVehicle = new ServiceEndpointRoutes("PurchasingVehicle");
        public static readonly ServiceEndpointRoutes PurchasingFacility = new ServiceEndpointRoutes("PurchasingFacility");
        public static readonly ServiceEndpointRoutes PurchasingCustomerGroup = new ServiceEndpointRoutes("PurchasingCustomerGroup");
        public static readonly ServiceEndpointRoutes PurchasingFacilityGroup = new ServiceEndpointRoutes("PurchasingFacilityGroup");
        //    public static readonly ServiceEndpointRoutes ETLFirstReceiptDateGetGridDataWithFilterReport = new ServiceEndpointRoutes("CPDReports/GetGridDataWithFilterFirstReceiptDate");
        //public static readonly ServiceEndpointRoutes SupplierMaterialOriginException = new ServiceEndpointRoutes("SupplierMaterialOriginException");
        //Commented by Dharmendra on 07-May-2020
        // public static readonly ServiceEndpointRoutes SupplierMaterialOriginExceptionPropagation = new ServiceEndpointRoutes("CPDToH1SynchronizationScheduler/SupplierMaterialOriginExceptionPropagation");
        // public static readonly ServiceEndpointRoutes SupplierMaterialOriginExceptionPropagation = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/SupplierMaterialOriginExceptionPropagation");
        public static readonly ServiceEndpointRoutes FCDataSyncFacilityVehicleCustomer = new ServiceEndpointRoutes("ETLPurchasingArticleSynchronization/FCDataSyncVehicleFacilityCustomer");
        public static readonly ServiceEndpointRoutes PurchasingFacilityMaster = new ServiceEndpointRoutes("PurchasingFacilityMaster");
        public static readonly ServiceEndpointRoutes PurchasingCustomerMaster = new ServiceEndpointRoutes("PurchasingCustomerMaster");
        public static readonly ServiceEndpointRoutes PurchasingVehicleMaster = new ServiceEndpointRoutes("PurchasingVehicleMaster");
        public static readonly ServiceEndpointRoutes SupplierEmailSettings = new ServiceEndpointRoutes("SupplierEmailSettings");

        public static readonly ServiceEndpointRoutes CoreMaterialHierarchy = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CoreMaterialHierarchy);
        public static readonly ServiceEndpointRoutes CoreMaterialHierarchyPartitions = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CoreMaterialHierarchyPartitions);

        #endregion Generic Call For EF

        #region ETL Purchasing Data
        #region ETLPurchasingMaterial

        public static readonly ServiceEndpointRoutes ETLPurchasingMaterialGetGridList = new ServiceEndpointRoutes("ETLPurchasingMaterial/GetGridList");
        public static readonly ServiceEndpointRoutes ETLPurchasingMaterial = new ServiceEndpointRoutes("ETLPurchasingMaterial");
        public static readonly ServiceEndpointRoutes ETLMaterialInventory = new ServiceEndpointRoutes("ETLMaterialInventory");
        //  public static readonly ServiceEndpointRoutes ETLMaterialInventoryGetGridListReport = new ServiceEndpointRoutes("CPDReports/GetGridDataMaterialInventory"); 
        public static readonly ServiceEndpointRoutes ETLPurchasingArticleSynchronization = new ServiceEndpointRoutes("ETLPurchasingArticleSynchronization");
        public static readonly ServiceEndpointRoutes ETLPurchasingArticleSynchronizationGetGridList = new ServiceEndpointRoutes("ETLPurchasingArticleSynchronization/GetGridList");
        public static readonly ServiceEndpointRoutes ETLPurchasingArticleSynchronizationSyncArticles = new ServiceEndpointRoutes("ETLPurchasingArticleSynchronization/SyncArticles");
        public static readonly ServiceEndpointRoutes ETLMaterialNoXReferenceGetGridList = new ServiceEndpointRoutes("ETLMaterialNoXReference/GetGridList");
        public static readonly ServiceEndpointRoutes ETLMaterialNoXReferenceGetGridListReport = new ServiceEndpointRoutes("CPDReports/GetGridDataMaterialNoXReference");
        public static readonly ServiceEndpointRoutes ETLPurchasingMaterialGridListByFilter = new ServiceEndpointRoutes("ETLPurchasingMaterial/GetGridListByFilter");
        #endregion

        public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilities = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities");
        public static readonly ServiceEndpointRoutes RestoreServiceDatBusinessApplicationaFromDB = new ServiceEndpointRoutes("RestoreServiceDataFromDB");


        #region ETLPurchasingSupplier
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplier = new ServiceEndpointRoutes("ETLPurchasingSupplier/GetGridList");
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplierFilter = new ServiceEndpointRoutes("ETLPurchasingSupplier/GetGridListByFilter");
        public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetSupplierList = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetSupplierList");
        public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetBusinessUnit = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetBusinessUnitList");

        //public static readonly ServiceEndpointRoutes ETLSupplierSelection = new ServiceEndpointRoutes("ETLSupplierSelection/GetGridList");
        // public static readonly ServiceEndpointRoutes ETLMaterialOriginReport = new ServiceEndpointRoutes("CPDReports/GetGridDataMaterialOrigin"); 
        public static readonly ServiceEndpointRoutes ETLSupplierMaterialPOPricingGetGridList = new ServiceEndpointRoutes("ETLSupplierMaterialPOPricing/GetGridList");

        public static readonly ServiceEndpointRoutes ETLSupplierCapacityPlanningGetGridList = new ServiceEndpointRoutes("ETLSupplierCapacityPlanning/GetGridList");
        public static readonly ServiceEndpointRoutes ETLSupplierCapacityPlanningGetGridListReport = new ServiceEndpointRoutes("CPDReports/GetGridDataSupplierCapacityPlanning");
        //   public static readonly ServiceEndpointRoutes ETLFirstReceiptDateGetGridListReport = new ServiceEndpointRoutes("CPDReports/GetGridDataFirstReceiptDate");
        public static readonly ServiceEndpointRoutes ETLConsolidatedMRPErrorList = new ServiceEndpointRoutes("ETLConsolidatedMRPErrorList/GetGridList");
        public static readonly ServiceEndpointRoutes ETLConsolidatedMRPErrorListReport = new ServiceEndpointRoutes("CPDReports/GetGridDataConsolidatedMRPErrorList");
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplierMaterialGridList = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/GetGridDataListOldWay");
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplierMaterialGridListByFilter = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/GetGridListByFilter");
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplierMaterialGetMaterial = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/GetMaterialList");
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplierMaterialGetActiveMaterial = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/GetActiveMaterialList");
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplierMaterialGetActiveMaterialForNewItem = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/GetActiveMaterialForNewItemList");
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplierMaterialGetSupplier = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/GetActiveSupplierList");
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplierMaterialGetActiveSupplier = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/GetActiveSupplierList");
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplierMaterialGetCountryRegionOriginList = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/GetCountryRegionOriginList");
        public static readonly ServiceEndpointRoutes ETLSupplierSelectionGridList = new ServiceEndpointRoutes("ETLSupplierSelection/GetGridList");
        public static readonly ServiceEndpointRoutes ETLSupplierSelectionGetMaterial = new ServiceEndpointRoutes("ETLSupplierSelection/GetMaterialList");
        public static readonly ServiceEndpointRoutes ETLSupplierSelectionGetSupplier = new ServiceEndpointRoutes("ETLSupplierSelection/GetSupplierList");
        public static readonly ServiceEndpointRoutes ETLSupplierSelectionGetBusinessUnit = new ServiceEndpointRoutes("ETLSupplierSelection/GetBusinessUnitList");
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplierMaterialForCombo = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/GetPurchasingSupplierMaterialForCombo");
        public static readonly ServiceEndpointRoutes ETLSupplierSelectionMaterialForCombo = new ServiceEndpointRoutes("ETLSupplierSelection/GetMaterialHeaderCombo");
        public static readonly ServiceEndpointRoutes ETLSupplierSelectionMaterialWithPORatioComplete = new ServiceEndpointRoutes("ETLSupplierSelection/GetMaterialWithPORatioComplete");
        public static readonly ServiceEndpointRoutes ETLSupplierSelectionSupplierForCombo = new ServiceEndpointRoutes("ETLSupplierSelection/GetSupplierHeaderCombo");
        public static readonly ServiceEndpointRoutes ETLSupplierSelectionGridListByFilter = new ServiceEndpointRoutes("ETLSupplierSelection/GetGridListByFilter");
        public static readonly ServiceEndpointRoutes ETLPurchasingSupplierMaterialGetHeaderSupplierCombo = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/GetHeaderSupplierCombo");

        public static readonly ServiceEndpointRoutes ETLSupplierMaterialPOPricingGetGridListForReport = new ServiceEndpointRoutes("ETLSupplierMaterialPOPricing/GetGridListForReport");
        public static readonly ServiceEndpointRoutes ETLMaterialInventoryGetGridListByFilter = new ServiceEndpointRoutes("CPDReports/GetGridDataMaterialInventory");
        //    public static readonly ServiceEndpointRoutes ETLMaterialInventoryGetGridListByFilterReport = new ServiceEndpointRoutes("CPDReports/GetGridDataByFilterMaterialInventory");
        public static readonly ServiceEndpointRoutes ETLMaterialOriginGridModelGetGridListByFilter = new ServiceEndpointRoutes("ETLMaterialOrigin/GetGridListByFilter");
        //  public static readonly ServiceEndpointRoutes ETLMaterialOriginGridModelGetGridListByFilterReport = new ServiceEndpointRoutes("CPDReports/GetGridDataByFilterMaterialOrigin"); 
        public static readonly ServiceEndpointRoutes ETLSupplierMaterialPOPricingGetPOPriceListIncSupplierMaterialDetails = new ServiceEndpointRoutes("ETLSupplierMaterialPOPricing/GetPOPriceListIncSupplierMaterial");

        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetMaterialList = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetMaterialList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetCommodityList = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetCommodityList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetMaterialTypeList = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetMaterialTypeList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetUnitOfMeasureList = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetUnitOfMeasureList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetCurrency = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetCurrencyList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetIncoterms = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetIncotermsList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetEPOCommodityGroup= new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetEPOCommodityGroupList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetContact = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetContactList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetPOPriceEffective = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetPOPriceEffectiveList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetPOPriceTypeList = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetPOPriceTypeList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetSupplierAssociation = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetSupplierAssociationList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetSDE = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetSupplierDevelopmentTeamList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetSupplierType = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetSupplierTypeList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetSupplierGroup = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetSupplierGroupList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetSuppMatAssociation = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetSupplierMaterialAssociationList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetSupplierCountryAssociation = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetSupplierSupplierCountryAssociationList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetMaterialAssociation = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetMaterialAssociationList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetTariffCountryAssociation = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetTariffCountryAssociationList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetSupplierMatAssociation = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetSupplierMatAssociationList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetAllSupplierMaterialAssociationList = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetAllSupplierMaterialAssociationList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetActiveSupplierMatAssociationList = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetActiveSupplierMatAssociationList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetHeaderSupplierList = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetHeaderSupplierList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetHeaderMaterialList = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetHeaderMaterialList");
        //public static readonly ServiceEndpointRoutes ETLPurchasingCommonUtilitiesGetSupplierMaterialAssociationDataList = new ServiceEndpointRoutes("ETLPurchasingCommonUtilities/GetSupplierMaterialAssociationDataList");
        //public static readonly ServiceEndpointRoutes ETLFirstReceiptDateGetGridList = new ServiceEndpointRoutes("ETLFirstReceiptDate/GetGridList");
        //public static readonly ServiceEndpointRoutes ETLMaterialInventoryGetGridList = new ServiceEndpointRoutes("ETLMaterialInventory/GetGridList");
        // public static readonly ServiceEndpointRoutes ETLMaterialOrigin = new ServiceEndpointRoutes("ETLMaterialOrigin/GetGridList");
        // public static readonly ServiceEndpointRoutes ETLSupplierMaterialPOPricingGetGridDataWithFilter = new ServiceEndpointRoutes("ETLSupplierMaterialPOPricing/GetGridDataWithFilter");


        public static readonly ServiceEndpointRoutes ETLMaterialChangeLog = new ServiceEndpointRoutes("CPDReports/GetGridDataMaterialChangeLog");
        public static readonly ServiceEndpointRoutes ETLSupplierMaterialChangeLog = new ServiceEndpointRoutes("CPDReports/GetGridDataSupplierMaterialChangeLog");
        public static readonly ServiceEndpointRoutes ETLMaterialSiteChangeLog = new ServiceEndpointRoutes("CPDReports/GetGridDataMaterialSiteChangeLog");
        #endregion

        #endregion
        #region RFQ Management
        public static readonly ServiceEndpointRoutes RFQReason = new ServiceEndpointRoutes("RFQReason");
        public static readonly ServiceEndpointRoutes RFQStatus = new ServiceEndpointRoutes("RFQStatus");
        public static readonly ServiceEndpointRoutes RFQSamplesSettings = new ServiceEndpointRoutes("RFQSamplesSettings");
        public static readonly ServiceEndpointRoutes SupplierRFQFieldSettings = new ServiceEndpointRoutes("SupplierRFQFieldSettings");
        public static readonly ServiceEndpointRoutes SupplierRFQPortalSettingsstateless = new ServiceEndpointRoutes("NPRWebService/SupplierRFQPortalSettings");
        // public static readonly ServiceEndpointRoutes SupplierRFQPortalSettings = new ServiceEndpointRoutes("SupplierRFQPortalSettings");
        public static readonly ServiceEndpointRoutes RFQEmailSettings = new ServiceEndpointRoutes("RFQEmailSettings");
        public static readonly ServiceEndpointRoutes SupplierRFQPortalSettingsGeneratePassword = new ServiceEndpointRoutes("NPRWebService/SupplierRFQPortalSettings/GenerateRandomPassword");
        public static readonly ServiceEndpointRoutes SupplierRFQPortalSettingsReSetPassword = new ServiceEndpointRoutes("NPRWebService/SupplierRFQPortalSettings/ResetPassword");
        public static readonly ServiceEndpointRoutes SupplierRFQPortalSettingsUpdatePassword = new ServiceEndpointRoutes("NPRWebService/SupplierRFQPortalSettings/UpdatePassword");
        public static readonly ServiceEndpointRoutes RFQParameterSettings = new ServiceEndpointRoutes("RFQParameterSettings");
        public static readonly ServiceEndpointRoutes SupplierPanel = new ServiceEndpointRoutes("SupplierPanel");
        public static readonly ServiceEndpointRoutes SupplierRFQPortalSettingsIssueUsername = new ServiceEndpointRoutes("NPRWebService/SupplierRFQPortalSettings/IssueUsername");
        //Ajay: 25-Aug-2019: SupplierPanel route added

        public static readonly ServiceEndpointRoutes MaterialDataSynchronizationModel = new ServiceEndpointRoutes("NPAToH1DataSynchronization/MaterialDataSync");
        public static readonly ServiceEndpointRoutes CheckUserInSupplierRFQPortalSettings = new ServiceEndpointRoutes("NPRWebService/SupplierRFQPortalSettings/CheckUserInSupplierRFQPortalSettings"); // Modified By Ranjay 01-Mar-2023
        #endregion

        #region Material Shortage Report
        public static readonly ServiceEndpointRoutes GetMaterialShortageReportDHSData = new ServiceEndpointRoutes("CPDReports/GetMaterialShortageReportDHSData");
        #endregion

        #region Statefull to Stateless Services
        public static readonly ServiceEndpointRoutes SupplierSelectionHierarchyShowStateless = new ServiceEndpointRoutes("NPRWebService/SupplierSelectionHierarchy/GetSpecificFieldsAsyncByFilter");
        public static readonly ServiceEndpointRoutes SupplierMaterialMaintenanceHierarchyShowStateless = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/GetSpecificFieldsAsyncByFilter");
        public static readonly ServiceEndpointRoutes GetPurchasingSupplierMaterialCombination = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/GetPurchasingSupplierMaterialCombination");
        public static readonly ServiceEndpointRoutes ProcessSupplierSelectionHierarchy = new ServiceEndpointRoutes("NPRWebService/SupplierSelectionHierarchy");
        public static readonly ServiceEndpointRoutes H1SupplierSelectionHierarchyUploadValidateAndSave = new ServiceEndpointRoutes("NPRWebService/SupplierSelectionHierarchy/H1SupplierSelectionHierarchyUploadValidateAndSave");
        public static readonly ServiceEndpointRoutes ProcessOperationPurchasingSupplierMaterialHierarchy = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy");
        public static readonly ServiceEndpointRoutes H1PurchasingSupplierMaterialHierarchyUploadValidateAndSave = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/H1PurchasingSupplierMaterialHierarchyUploadValidateAndSave");
        public static readonly ServiceEndpointRoutes GetAllMaterialForSupplierSelectionHierarchy = new ServiceEndpointRoutes("NPRWebService/SupplierSelectionHierarchy/GetAllMaterialForSupplierSelectionHierarchy");
        public static readonly ServiceEndpointRoutes PurchasingSupplierMaterialHierarchyExportAll = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/ExportAll");

        public static readonly ServiceEndpointRoutes SupplierMaterialPOPricingHierarchyStateless = new ServiceEndpointRoutes("NPRWebService/SupplierMaterialPOPricingHierarchy/GetSpecificFieldsAsyncByFilter");
        public static readonly ServiceEndpointRoutes ProcessOperationSupplierMaterialPOPricingHierarchy = new ServiceEndpointRoutes("NPRWebService/SupplierMaterialPOPricingHierarchy");
        public static readonly ServiceEndpointRoutes SupplierMaterialPOPricingHierarchyUploadValidateAndSave = new ServiceEndpointRoutes("NPRWebService/SupplierMaterialPOPricingHierarchy/SupplierMaterialPOPricingHierarchyUploadValidateAndSave");
        public static readonly ServiceEndpointRoutes GetSupplierMaterialHierarchyByFilterStateless = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/GetSupplierMaterialMaintenanceHierarchyByFilter");
        public static readonly ServiceEndpointRoutes GetPurchasingSupplierMaterialCombinationForOriginException = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/GetPurchasingSupplierMaterialCombinationForOriginException");

        public static readonly ServiceEndpointRoutes SupplierSelectionHierarchyShowStatelessWithFilterFields = new ServiceEndpointRoutes("NPRWebService/SupplierSelectionHierarchy/GetSupplierSelectionHierarchyWithFilteredFields");
        // public static readonly ServiceEndpointRoutes SupplierMaterialMaintenanceHierarchyShowStatelessWithFilterFields = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/SupplierMaterialMaintenanceHierarchyShowStatelessWithFilterFields");
        //public static readonly ServiceEndpointRoutes ShowMaterialGridDataForOriginException = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/ShowMaterialGridDataForOriginException");
        public static readonly ServiceEndpointRoutes GetPurchasingSupplierMaterialCombinationforMaterialMaintenance = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/GetPurchasingSupplierMaterialCombinationForOriginException");
        public static readonly ServiceEndpointRoutes ShowPOPriceListIncSupplierMaterialDetailsNewFormat = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/ShowPOPriceListIncSupplierMaterialDetailsNewFormat");
        public static readonly ServiceEndpointRoutes SupplierSelectionHierarchyShowStatelessSearchfilter = new ServiceEndpointRoutes("NPRWebService/SupplierSelectionHierarchy/ShowSupplierSelectionHierarchyFilterData");

        public static readonly ServiceEndpointRoutes NPRTransactionLogByProcedure = new ServiceEndpointRoutes("NPRWebService/NPRTransactionLogByProcedure");
        public static readonly ServiceEndpointRoutes ToolTypeData = new ServiceEndpointRoutes("NPRWebService/ToolType");
        public static readonly ServiceEndpointRoutes GetToolTypeDataByToolType = new ServiceEndpointRoutes("NPRWebService/ToolType/GetToolType");
        public static readonly ServiceEndpointRoutes ToolConditionData = new ServiceEndpointRoutes("NPRWebService/ToolCondition");
        public static readonly ServiceEndpointRoutes GetToolConditionData = new ServiceEndpointRoutes("NPRWebService/ToolCondition/GetToolCondition");
        public static readonly ServiceEndpointRoutes SupplierToolMaintenanceData = new ServiceEndpointRoutes("NPRWebService/SupplierToolMaintenance/GetAllFilteredData");
        public static readonly ServiceEndpointRoutes SupplierToolMaintenance = new ServiceEndpointRoutes("NPRWebService/SupplierToolMaintenance");
        public static readonly ServiceEndpointRoutes GetMaterialBySupplier = new ServiceEndpointRoutes("NPRWebService/SupplierToolMaintenance/GetMaterialBySupplierId");
        public static readonly ServiceEndpointRoutes H1SupplierToolMaintenanceUploadValidateAndSave = new ServiceEndpointRoutes("NPRWebService/SupplierToolMaintenance/H1SupplierToolMaintenanceUploadValidateAndSave");
        public static readonly ServiceEndpointRoutes GetAllMaterialInSupplierToolMaintenance = new ServiceEndpointRoutes("NPRWebService/SupplierToolMaintenance/GetAllMaterialInSupplierToolMaintenance");
        public static readonly ServiceEndpointRoutes GetAllSupplierPartNumber = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/GetAllSupplierPartNumber");
        #endregion

        #region ToolMaster
        public static readonly ServiceEndpointRoutes ToolOwner = new ServiceEndpointRoutes("NPRWebService/ToolOwner");
        public static readonly ServiceEndpointRoutes GetToolOwnerFilterById = new ServiceEndpointRoutes("NPRWebService/ToolOwner/GetToolOwnerFilterById");
        #endregion

        #region EOL
        public static readonly ServiceEndpointRoutes AuditConfiguration = new ServiceEndpointRoutes("NPRWebService/AuditConfiguration");
        public static readonly ServiceEndpointRoutes GetSupplierGroups_Id_Name = new ServiceEndpointRoutes("NPRWebService/AuditConfiguration/GetSupplierGroups_Id_Name");
        #endregion
        public static readonly ServiceEndpointRoutes SupplierToolMaintenanceLogByProcedure = new ServiceEndpointRoutes("NPRWebService/SupplierToolMaintenance/SupplierToolMaintenanceLogByProcedure");
        public static readonly ServiceEndpointRoutes TransferData_PurchasingSupplierMaterial_TO_SupplierToolMaintenance = new ServiceEndpointRoutes("NPRWebService/SupplierToolMaintenance/TransferData_PurchasingSupplierMaterial_TO_SupplierToolMaintenance");
        public static readonly ServiceEndpointRoutes ProcessOperationGenerateOTP = new ServiceEndpointRoutes("NPRWebService/GenerateAndValidateOTP/ProcessOperationGenerateOTP");
        public static readonly ServiceEndpointRoutes ValidateOTP = new ServiceEndpointRoutes("NPRWebService/GenerateAndValidateOTP/ValidateOTP");
        public static readonly ServiceEndpointRoutes GetAllAuditID = new ServiceEndpointRoutes("NPRWebService/SupplierToolMaintenance/GetAllAuditID");

        public static readonly ServiceEndpointRoutes GetNPRBackLogByFilter = new ServiceEndpointRoutes("NPRWebService/NPRBacklog/GetNPRBackLogByFilter");
        public static readonly ServiceEndpointRoutes GetNPRBackLogFilteredData = new ServiceEndpointRoutes("NPRWebService/NPRBacklog/GetNPRBackLogFilteredData");
        public static readonly ServiceEndpointRoutes GetNPRByMultipleId = new ServiceEndpointRoutes("NPRWebService/NewPartRequest/GetNPRByMultipleId");
        public static readonly ServiceEndpointRoutes CheckNPRDataBySupplierGroupGuid = new ServiceEndpointRoutes("NPRWebService/NewPartRequest/CheckNPRDataBySupplierGroupGuid");
        public static readonly ServiceEndpointRoutes CheckNprByRequestIdAndSupplier = new ServiceEndpointRoutes("NPRWebService/NewPartRequest/CheckNprByRequestIdAndSupplier");
        public static readonly ServiceEndpointRoutes GetInvoiceQueryReason = new ServiceEndpointRoutes("NPRWebService/InvoiceQueryReason/GetInvoiceQueryReason");
        public static readonly ServiceEndpointRoutes ProcessOperationInvoiceQueryReason = new ServiceEndpointRoutes("NPRWebService/InvoiceQueryReason/ProcessOperationInvoiceQueryReason");
        public static readonly ServiceEndpointRoutes AssociateMaterialfromPSMBySupplier = new ServiceEndpointRoutes("NPRWebService/SupplierMaterialOriginException/AssociatePSMMaterialBySupplier");
        public static readonly ServiceEndpointRoutes GetAllPSMBySupplierGuid = new ServiceEndpointRoutes("NPRWebService/SupplierMaterialOriginException/GetAllPSMBySupplierGuid");
        public static readonly ServiceEndpointRoutes BindSupplierMaterialOriginExceptionDataInGrid = new ServiceEndpointRoutes("NPRWebService/SupplierMaterialOriginException/BindSupplierMaterialOriginExceptionDataInGrid");
        public static readonly ServiceEndpointRoutes GetSupplierMaterialOriginExceptionDataWithFilter = new ServiceEndpointRoutes("NPRWebService/SupplierMaterialOriginException/GetSupplierMaterialOriginExceptionDataWithFilter");
        public static readonly ServiceEndpointRoutes ProcessOperationSupplierMaterialOriginException = new ServiceEndpointRoutes("NPRWebService/SupplierMaterialOriginException");
        public static readonly ServiceEndpointRoutes BindSupplierMaterialOriginExceptionMaterialGridCombo = new ServiceEndpointRoutes("NPRWebService/SupplierMaterialOriginException/H1GetAssociatePSMForBindGridComboBySupplier");
        public static readonly ServiceEndpointRoutes UploadSupplierMaterialOriginExceptionMaterialData = new ServiceEndpointRoutes("NPRWebService/SupplierMaterialOriginException/Upload");
        #region Endpoint for Business Unit Association Invoice
        public static readonly ServiceEndpointRoutes Show_BusinessUnitAssociationInvoice = new ServiceEndpointRoutes("NPRWebService/BusinessUnitAssociationInvoice/Show_BusinessUnitAssociationInvoice");
        public static readonly ServiceEndpointRoutes ProcessBusinessUnitAssociationInvoice = new ServiceEndpointRoutes("NPRWebService/BusinessUnitAssociationInvoice/ProcessBusinessUnitAssociationInvoice");
        public static readonly ServiceEndpointRoutes GetALLBussinessUnitStateless = new ServiceEndpointRoutes("NPRWebService/BusinessUnitAssociationInvoice/GetALLBussinessUnitStateless");
        #endregion
        #region Endpoint for Invoice Management
        public static readonly ServiceEndpointRoutes Get_PartNumberAndInvoiceNumber = new ServiceEndpointRoutes("NPRWebService/InvoiceManagement/Get_PartNumberAndInvoiceNumber");
        public static readonly ServiceEndpointRoutes H1_Show_InvoiceManagement = new ServiceEndpointRoutes("NPRWebService/InvoiceManagement/H1_Show_InvoiceManagement");
        public static readonly ServiceEndpointRoutes GetDataBasedOnModelType = new ServiceEndpointRoutes("NPRWebService/InvoiceManagement/GetDataBasedOnModelType");
        public static readonly ServiceEndpointRoutes ProcessInvoiceManagement = new ServiceEndpointRoutes("NPRWebService/InvoiceManagement/ProcessInvoiceManagement");
        public static readonly ServiceEndpointRoutes SyncInvoiceH1ToDHS = new ServiceEndpointRoutes("NPRWebService/InvoiceManagement/SyncInvoiceH1ToDHS");
        public static readonly ServiceEndpointRoutes H1_ShowOrderValueByInvoiceNumber = new ServiceEndpointRoutes("NPRWebService/InvoiceManagement/H1_ShowOrderValueByInvoiceNumber");
        public static readonly ServiceEndpointRoutes InvoiceManagementUpload = new ServiceEndpointRoutes("NPRWebService/InvoiceManagement/InvoiceManagementUpload");
        #endregion

        public static readonly ServiceEndpointRoutes GetPurchaseSupplierMaterialPoPricingByFilter = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/GetSupplierMaterialPoPricingByFilter");//vishwadeep
        public static readonly ServiceEndpointRoutes SupplierMaterialMaintenanceHierarchyShowStatelessNew = new ServiceEndpointRoutes("NPRWebService/PurchasingSupplierMaterialHierarchy/GetSpecificFieldsAsyncByFilterNew");//vishwadeep
        public static readonly ServiceEndpointRoutes SupplierMaterialPOPricingHierarchyStatelessNew = new ServiceEndpointRoutes("NPRWebService/SupplierMaterialPOPricingHierarchy/GetSpecificFieldsAsyncByFilterNew");//vishwadeep
  

    }
}
