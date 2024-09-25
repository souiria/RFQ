/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ServiceEndpointRoutesSupplyPlanning.cs
Function           :   ServiceEndpointRoutes SupplyPlanning
Created By         :   Srashti Gupta
Created on         :   28-Jan-2020
Revision History   :   [29-Jan-2020]:Srashti Gupta
*                  :   Added the endpoint for CustomerEDISetupFlattenData
*                  :   [11-Feb-2020]:Srashti Gupta
*                  :   Added the endpoint for EDISetup Multiple Dictionaries..
*                  :   [12-Feb-2020]:Srashti Gupta
*                  :   Change the endpoint routes for EDISetup Multiple Dictionaries.
*                  :   [17-Apr-2020]:Shivam Dhingra
*                  :   Changed the endpoint routes for WMSInventoryMaster and EDIMessageHeaderMaster.
*                  :   [04-June-2020]:Srashti Gupta
*                  :   Changed the endpoint routes for SupplyChainSettingsPartWiseHierarchy.
*                  :   [05-June-2020]:Srashti Gupta
*                  :   Changed the endpoint routes for SupplyPlanningDataSyncConfigurationSetup.
*                  :   [11-June-2020]:Srashti Gupta
*                  :   Changed the endpoint routes for SupplyPlanningDataSyncCalendar.
*                  :   [10-Sep-2020]:Dharmendra
*                  :   Add new endpoint routes  for WMSInventorySnapShotMaster.
*                  :   [01-oCT-2020]:Srashti Gupta
*                  :   Add new endpoint routes  for WMSInventoryCalendarSync.
*                  :   [06-Oct-2020]: Shivam Dhingra
*                  :   Add new endpoint routes  for CustomerDemandCalculation and GenerateCustomerDemandCalculation.
*                  :   [16-Oct-2020]: Shivam Dhingra
*                  :   Add new endpoint route  for HarnessType
*                  :   [20-Oct-2020]: Shivam Dhingra
*                  :   Add new endpoint route for DRPCalculationParameters
*                  :   [20-Oct-2020]: Shivam Dhingra
*                  :   Add new endpoint route for SiteFinancialCalendar
*                  :   [21-Oct-2020]: Shivam Dhingra
*                  :   Renamed endpoint SiteFinancialCalendar to SiteProductionCalendar and added LogisticsFinancialCalendar
*                  :   [28-Oct-2020]: Shivam Dhingra
*                  :   Add new endpoint route for CustomerCalendar
*                  :   [28-Oct-2020]: Srashti Gupta
*                  :   Add new endpoint route for WMSStockPositionCumulate  
*                  :   [09-Nov-2020]: Shivam Dhingra
*                  :   Add new endpoint route for CustomerBacklogOrder
*                  :   [10-Nov-2020]: Srashti Gupta
*                  :   Add new endpoint route for PPSCustomerASNCodeXref
*                  :   [11-Nov-2020]: Srashti Gupta
*                  :   Add new endpoint route for WIPMaintenance
*                  :   [18-Nov-2020]: Shivam Dhingra
*                  :   Add new endpoint route for SiteFacilityCalendar
*                  :   [23-Nov-2020]: Srashti Gupta
*                  :   Add new endpoint route for DRPCalculationSettingsMatrix
*                  :   [25-Nov-2020]: Srashti Gupta
*                  :   Add new endpoint route for WarehouseSiteCalendar
*                  :   [27-May-2021]: Shivam Dhingra
*                  :   Add new endpoint route for DRPGenerationReportData
*                  :   [15-June-2021]: Shivam Kalia
*                  :   Add new endpoint route for DaysOfDemandSettingsFilteredData
*                  :   [17-June-2021]: Shivam Kalia
*                  :   Add new endpoint route for DaysOfDemandSettingsUpdateData
*                  :   [05-July-2021]: Shivam Kalia
*                  :   Add new endpoint route for ABCAnalysisFilteredData and ABCAnalysisUpdateData
*                  :   [06-July-2021]: Shivam Kalia
*                  :   Add new endpoint route for ReGenerateABCAnalysisSync                  
*                  :   [13-Jul-2021]: Shivam Dhingra
*                  :   Add new endpoint route for OrderStatus
*                  :   [27-Jul-2021]: Shivam Kalia
*                  :   Add new endpoint route for CustomerProductNumberParameters
*                  :   [29-Jul-2021]: Shivam Kalia
*                  :   Add new endpoint route for RefreshCustomerProductNumber
*                  :   [05-Aug-2021]: Shahab Ashraf
*                  :   Add new endpoint route for EDIMessageMissingCustomerPart
*                  :   [11-Aug-2021]: Sejal Srivastava
*                  :   Add new endpoint route for GetSupplyChainDesignFilteredData and ProcessOperationSupplyChainDesignData                   
*                  :   [18-Aug-2021]: Shivam Dhingra
*                  :   Add new endpoint route for SupplyChainMapping
*                  :   [26-Aug-2021]: Ashish
*                  :   Add New endpoint route for PartABCCategory
*                  :   [27-Aug-2021]: Shivam Kalia
*                  :   Add new endpoint route for CustomerProductNumberParametersKeys
*                  :   [27-Sep-2020]: Shahab Ashraf
*                  :   Add new endpoint routes  for CustomerDemandCalculation and CheckMissingProductCustomerDemand.
*                  :   [27-Oct-2021]: Shivam Kalia
*                  :   Add new endpoint route for GetDataSyncCalendarByDataSyncConfigurationSetupGuid   
*                  :   [20-Jan-2022] : Shivam Dhingra
                   :   [] : Added endpoint route for SupplyChainMappingMissingCustomerProductNumber
*                  :   [25-Apr-2022] : Ranjay
                   :   [] : Added endpoint route for ManualDemandDocumentDesign
*                  :   [25-Apr-2022] : Anmol jain
                   :   [] : Added endpoint route for ManualDemandDocumentDataEntry
*                  :   [20-Apr-2022]: Sejal Srivastava
*                  :   Added new endpoint route for ManualDemandDocumentStatusReviewData and ManualDemandDocumentStatusReviewUpdateData
*                  :   [27-Apr-2022] : Ranjay
                   :   [] : Added endpoint route for OrderBookMissingTransferPriceData\
*                  :   [2-May-2022] : Anmol jain
                   :   [] : Added endpoint route for DemandCalculationMethod
*                  :   [2-May-2022] : Sejal Srivastava
*                  :   [] : Added endpoint route for GetDemandCalculationMethodSelectionFilteredData and DemandCalculationMethodSelectionSaveData
*                  :   [30-May-2022] : Ranjay
*                  :   [] : Added endpoint route for ManualDemandDocumentDataEntryUpload endpoint
*                  :   [06-jun-2022]: Anmol Jain
*                  :   [] : Added endpoint route CustomerDemandCalculationFilterData
*                  :   [25-July-2022]: Sejal Srivastava
*                  :   Added endpoint route for DRPGenerationReportData_old
*                  :   [28-July-2022]: Sejal Srivastava
*                  :   Added endpoint route for GetSupplyChainExceptionListData, SupplyChainExceptionListSaveData, SupplyChainExceptionListUploadData
*                  :   [28-July-2022]: Sejal Srivastava
*                  :   Added endpoint route for GetAllUnloadingPoint, GetFilteredCustomerPartNumber
*                  :   [04-Aug-2022] : Sejal Srivastava
*                  :   [] Added new endpoint GetCustomerPartNumberBySupplyChainFromProductNumber
*                  :   [04-Aug-2022] : Ranjay
*                  :   [] Added new endpoint GetGroupNameData,GetProcessNameData,GetSupplyPlanningMailDistributionSettingData,SupplyPlanningMailDistributionSettingData
*                  :   [08-Aug-2022] : Sejal Srivastava
*                  :   [] Added new endpoint route for GetABCAnalysisMethod, GetTargetInventoryMethod
*                  :   [09-Aug-2022] : Virendra
*                  :   [] Added new endpoint DRPGenerationPrecheckReport   
*                  :   [08-Sept-2022] : Virendra
*                  :   [] Added new endpoint SupplyChainMappingDataUpload   
*                  :   [12-Sep-2022] : Ranjay
*                  :   [] Added new endpoint GetCustomerBusinessGroup, HD Call No HD00354389
*                  :   [14-Sept-2022] : Sejal Srivastava
*                  :   [] Added new endpoint GetEDIMessageDetailMappingData
*                  :   [23-Sep-2022] : Ranjay
*                  :   [] Added new endpoint GetAllCustomerDeliveryPoint
*                  :   [07-Oct-2022] : Virendra
*                  :   [] Added new endpoint AllLocationTypeByProcedure              
*                  :   [06-Oct-2022] : Sejal Srivastava
*                  :   [] : Renamed FinishedGoodsStatusData to GetFinishedGoodsStatusUXData
*                  :   [] Added new endpoint GetFinishedGoodsFGStockReport, GetChildGridAllData, GetFinishedGoodsFGStockTransitDetailsReport, GetFinishedGoodsFGStockOrderStatusReport
*                  :   [21-Oct-2022] : Vishwadeep Singh
*                  :   [] Added new endpoint EDIMessageDateFormat
*                  :   [03-Nov-2022] : Ranjay
*                  :   [] Added new endpoint GetDRPOrderCancelationData
*                  :   [03-Nov-2022] : Vishwadeep Singh
*                  :   [] Added new endpoint ProcessOperationDRPOrderCancelationData
*                  :   [05-Dec-2022] : Prakhar Singh
*                  :   [] Added new endpoint EDIMessageExportFromDB
*                  :   [05-Dec-2022] : Ranjay
*                  :   [] Added new endpoint GetCustomerIdentificationSettingsData, ProcessCustomerIdentificationSettingsData, GetUnloadingPointByFilterData
*                  :   [12-Dec-2022] : Ranjay
*                  :   [] Added new endpoint GetCustomerDemandParameterSettingsData, ProcessCustomerDemandParameterSettingsData
*                  :   [18-Jan-2023] : Ranjay
*                  :   [] Added new endpoint GetCustomerCalendarData, ProcessCustomerCalendarData
*                  :   [17-Jan-2023] : Vishwadeep Singh
*                  :   [24-Jan-2023] : Prakhar Singh
*                  :   [] Added new endpoint CustomerDemandCalculationSettingMatrixStateless
*                  :   [25-Jan-2023] : Mayur Pawar
*                  :   [] Added new endpoint DefaultLogisticsFinancialCalendarStateLess
*                  :   [25-Jan-2023] : Ranjay
*                  :   [] Added new endpoint GenerateCustomerCalendarData, ReplicateCustomerCalendarData
*                  :   [15-Feb-2023] : Prakhar
*                  :   [] Added new endpoint GetSupplierCalendarData,ProcessSupplierCalendarData [HDCall 00370357]
*                  :   [21-Feb-2023] : Prakhar
*                  :   [] Added new endpoint DefaultSupplierCalendarStateLess [HDCall 00370357]
*                  :   [28-Feb-2023] : Prakhar
*                  :   [] Added new endpoint GetCustomerProductNumberXREFController
*                  :   [28-Feb-2023] : Prakhar
*                  :   [] Added new endpoint ProcessCustomerProductNumberXREFController
*                  :   [28-Feb-2023] : Prakhar
*                  :   [] Added new endpoint GetUnloadingPointByCustomerGuid
*                  :   [07-Mar-2023] : Ranjay
*                  :   [] Added new endpoint UploadCustomerProductNumberXREF
*                  :   [24-March-2023] : Virendra
*                  :   [] Added new endpoint GetUnloadingPointByCustomerGuidAndCustomerDeliveryPoint
*                  :   [24-March-2023] : Virendra
*                  :   [] Added new endpoint ProcessOperationCustomerDemandCalculationProgramMaintenance
*                  :   [24-March-2023] : Virendra
*                  :   [] Added new endpoint GetCustomerDemandCalculationProgramMaintenance
*                  :   [27-March-2023] : Virendra
*                  :   [] Added new endpoint GetAllCustomerDemandFunction                
*                  :   [27-March-2023] : Virendra
*                  :   [] Added new endpoint GetCustomerDemandParameterByDemandFunction  
*                  :   [28-March-2023] : Virendra
*                  :   [] Added new endpoint ProcessOperationDemandFunctionData  
*                  :   [28-March-2023] : Virendra
*                  :   [] Added new endpoint ProcessOperationCustomerDemandFunctionParameter  
*                  :   [22-March-2023] : Ranjay
*                  :   [] Added new endpoint GetCustomerDemandFunctionAndParameter  
*                  :   [05-May-2023] : Virendra
*                  :   [] Added new endpoint SaveCustomerDemandFunctionAndFunctionParameter 
*                  :   [23-May-2023] : Vishwadeep Singh
*                  :   [HD-00374786] Added new endpoint GetCustomerPartNumber
*                  :   [10-Aug-2023] : Prakhar Singh
*                  :   [HD-00374786] Added new endpoint DRPGenerationReportData_temp
*                  :   [24-Aug-2023] : Prakhar
                   :   [ ] : Added endpoints for GetSupplierCalendarCustomerHierarchyDropDownData and GetSupplierCalendarCustomerBusinessHierarchyDropDownData
*                  :   [18-Sep-2023] : Ranjay
*                  :   [HD-00365855] Added new endpoint GetCustomerNameBasedOnSupplyChain,GetProjectNameBasedOnSupplyChain,GetDcLocationBasedOnSupplyChain,GetMFSiteBasedOnSupplyChain
*                  :   [19-Sep-2023] : Piyush Anand
*                  :   [HD-00365855] Added new endpoint  GetDRPManualOrderGenerationLogData
*                  :   [21-Sep-2023] : Prakhar
*                  :   Added new endpoint GetDRPManualOrderDocumentId,GetDRPManualOrderGenerationDataEntry,ProcessOperationDRPManualOrderGenerationDataEntry,GetDRPManualOrderPartNo,DRPManualOrderGenerationDataEntryUpload and GetDefaultDRPManualOrderDocumentId.   
*                  :   [27-Sep-2023] : Sachin
*                  :   [HD-00381398]  Added new endpoint GetWarehouseCodeData,GetExternalWMSLocationTypeAssociationDataByWhCode and ProcessOperationExternalWMSLocationData
*                  :   [27-Nov-2023] : Virendra
*                  :   [HD-0397031]  Added new endpoint Show_CustomerDemandInterChangeability and ProcessCustomerDemandInterChangeability
*                  :   [18-Dec-2023] : Prakhar
*                  :   [HD-00401275]  Added new endpoint GetCustomerProductNumberParameterFilteredData and ProcessOperationCustomerProductNumberParameterData
*                  :   [18-Dec-2023] : Prakhar
*                  :   []  Added new endpoint GetDRPManualOrderSupplyChainId
*                  :   [15-Jan-2024] : Piyush Anand
*                  :   [HD-00401275] Commented Old stateful endpoint ApplicationReference,BuyerDetails,ConsigneeDetails,ConsignorDetails,EDIMessageType,DataSyncConfigurationSetup,InvoiceeDetails,
                       PackagingType,SchedulingCondition,SchedulingFrequency,UnloadingPoint,UNBSender,EDIMessageMatrix 
                       for statefull to stateless changes and Added new endpoints
                       GetApplicationReferenceData,ProcessApplicationReferenceData,GetBuyerDetailsData,ProcessBuyerDetailsData,GetConsigneeDetailsData,
                       ProcessConsigneeDetailsData,GetConsignorDetailsData,ProcessConsignorDetailsData,GetEDIMessageTypeData,ProcessEDIMessageTypeData,
                       GetDataSyncConfigurationSetupData,ProcessDataSyncConfigurationSetupData,GetSupplyPlanningParameterSettings,GetInvoiceeDetailsData,
                       ProcessInvoiceeDetailsData,GetPackagingTypeData,ProcessPackagingTypeData,GetSchedulingConditionData,ProcessSchedulingConditionData,
                       GetSchedulingFrequencyData,ProcessSchedulingFrequencyData,GetUNBSenderData,GetEDIMessageMatrixData,GetUnloadingPointData and ProcessUnloadingPointData
 *                 :   [18-Jan-2024] : Sachin
*                  :   [HD-00394058] Added new endpoints GetSingleUserMaintanencedata,ProcessOperationSingleUserMaintanencedata,GetScreenName,LockScreenDuringDRPOperation
*                  :   [12-Feb-2024] : Sachin
*                  :   [HD-00393919] Added new endpoints GetUnlockSingleUserDataAdmin,ProcessOperationUnlockSingleUserdataAdmin,ProcessOperationSinleUserAccessCloseAll,ProcessOperationSinleUserAccessCloseScreenWise and GetSetSinleUserAccess
*                  :   [02-Apr-2024] : Piyush Anand
*                  :   [HD-00409165] : Added new endpoints GetVehicleName,GetFamilyName,GetCarSetMaintenanceData and ProcessCarSetMaintenanceData
****************************************************************************************************/

namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        //public static readonly ServiceEndpointRoutes ApplicationReference = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/ApplicationReference");  commented by Piyush Anand on 05-Dec-2023
        //public static readonly ServiceEndpointRoutes BuyerDetails = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/BuyerDetails");   commented by Piyush Anand on 07-Dec-2023
        //public static readonly ServiceEndpointRoutes ConsigneeDetails = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/ConsigneeDetails");   commented by Piyush Anand on 08-Dec-2023
        //public static readonly ServiceEndpointRoutes ConsignorDetails = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/ConsignorDetails");   commented by Piyush Anand on 08-Dec-2023
        public static readonly ServiceEndpointRoutes CustomerAccountDetails = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/CustomerAccountDetails");
        //public static readonly ServiceEndpointRoutes EDIMessageType = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/EDIMessageType");     commented by Piyush Anand on 12-Dec-2023
        //public static readonly ServiceEndpointRoutes InvoiceeDetails = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/InvoiceeDetails");      commented by Piyush Anand on 14-Dec-2023
        //public static readonly ServiceEndpointRoutes PackagingType = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/PackagingType");      commented by Piyush Anand on 14-Dec-2023
        //public static readonly ServiceEndpointRoutes SchedulingCondition = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/SchedulingCondition");      commented by Piyush Anand on 15-Dec-2023
        //public static readonly ServiceEndpointRoutes SchedulingFrequency = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/SchedulingFrequency");      commented by Piyush Anand on 15-Dec-2023
        public static readonly ServiceEndpointRoutes SellerDetails = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/SellerDetails");
        public static readonly ServiceEndpointRoutes TransportRoute = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/TransportRoute");
        //public static readonly ServiceEndpointRoutes UnloadingPoint = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/UnloadingPoint");     commented by Piyush Anand on 18-Dec-2023
        public static readonly ServiceEndpointRoutes Workstation = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/Workstation");
        //public static readonly ServiceEndpointRoutes EDIMessageMatrix = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/EDIMessageMatrix");    commented by Piyush Anand on 15-Jan-2024
        public static readonly ServiceEndpointRoutes EDITypeMaster = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/EDITypeMaster");
        public static readonly ServiceEndpointRoutes EDIFileTypeMaster = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/EDIFileTypeMaster");
        public static readonly ServiceEndpointRoutes CustomerEDITemplateMaster = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/CustomerEDITemplateMaster");
        public static readonly ServiceEndpointRoutes CustomerEDISetupMaster = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.CustomerEDISetup/CustomerEDISetupMaster");
        public static readonly ServiceEndpointRoutes DistributionCenter = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/DistributionCenter");
        public static readonly ServiceEndpointRoutes DistributionCenterType = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/DistributionCenterType");
        public static readonly ServiceEndpointRoutes SupplyPlanningEmailNotificationSettings = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/SupplyPlanningEmailNotificationSettings");
        public static readonly ServiceEndpointRoutes SupplyPlanningParameterSettings = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/SupplyPlanningParameterSettings");
        public static readonly ServiceEndpointRoutes EDIMessageHeaderMaster = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/EDIMessageHeaderMaster");
        public static readonly ServiceEndpointRoutes EDIMessageExportFromDB = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/EDIMessageHeaderMaster/EDIMessageExportFromDB"); //prakhar
        public static readonly ServiceEndpointRoutes WMSInventoryMaster = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.WMSDataSynchronizationETL/WMSInventoryMaster");
        public static readonly ServiceEndpointRoutes H1CustomerHierarchyPPSCustomerMatrix = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/H1CustomerHierarchyPPSCustomerMatrix");
        public static readonly ServiceEndpointRoutes PPSCustomerCarModelFacility = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/PPSCustomerCarModelFacility");
        //public static readonly ServiceEndpointRoutes UNBSender = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/UNBSender");       commented by Piyush Anand on 18-Dec-2023
        public static readonly ServiceEndpointRoutes SupplyChainMappingSection = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/SupplyChainMappingSection");
        public static readonly ServiceEndpointRoutes SupplyChainFieldSettings = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/SupplyChainFieldSettings");
        //public static readonly ServiceEndpointRoutes CustomerIdentificationSettings = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/CustomerIdentificationSettings");
        // public static readonly ServiceEndpointRoutes SupplyChainSettingsPartWiseMapping = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/EDIMessageHeaderMaster/SupplyChainSettingsPartWiseMapping");
        public static readonly ServiceEndpointRoutes SupplyChainSettingsPartWise = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainSettingsPartWise");
        public static readonly ServiceEndpointRoutes SupplyChainSettingsPartWiseHierarchy = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/SupplyChainSettingsPartWiseHierarchy");
        public static readonly ServiceEndpointRoutes SupplyChainMappingDetaiHierarchy = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/SupplyChainSettingsPartWiseHierarchy/SupplyChainMappingSectionDetailHierarchy");
        public static readonly ServiceEndpointRoutes WMSLocationReportingSection = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/WMSLocationReportingSection");
        public static readonly ServiceEndpointRoutes WMSLocationMapping = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/WMSLocationMapping");
        //public static readonly ServiceEndpointRoutes SupplyPlanningDataSyncConfigurationSetup = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/DataSyncConfigurationSetup");      commented by Piyush Anand on 12-Dec-2023
        public static readonly ServiceEndpointRoutes SupplyPlanningDataSyncCalendar = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyPlanningDataSyncCalendar");
        public static readonly ServiceEndpointRoutes H1SupplyPlanningDataSyncLog = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/H1SupplyPlanningDataSyncLog");
        public static readonly ServiceEndpointRoutes H1SupplyPlanningDataSyncLogGetByFilter = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/H1SupplyPlanningDataSyncLog/GetByFilter");
        public static readonly ServiceEndpointRoutes SupplyPlanningDataSyncCalendarGenerateData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyPlanningDataSyncCalendar/GenerateCalendarData");
        public static readonly ServiceEndpointRoutes SupplyPlanningDataSyncCalendarGetByFilter = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyPlanningDataSyncCalendar/GetByFilter");
        public static readonly ServiceEndpointRoutes H1SupplyPlanningDataSyncLogArchive = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/H1SupplyPlanningDataSyncLogArchive");
        public static readonly ServiceEndpointRoutes H1SupplyPlanningDataSyncLogArchiveGetByFilter = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/H1SupplyPlanningDataSyncLogArchive/GetByFilter");
        public static readonly ServiceEndpointRoutes EDIMessageHeaderMasterReProcessingData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/EDIMessageHeaderMaster/ReProcessingData");
        public static readonly ServiceEndpointRoutes WMSInventorySnapShotMaster = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.WMSDataSynchronizationETL/WMSInventoryMaster/WMSInventorySnapShot");
        public static readonly ServiceEndpointRoutes CustomerDemandCalculationParameters = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/CustomerDemandCalculationParameters");
        public static readonly ServiceEndpointRoutes MonthlyDemandSplitLogic = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/MonthlyDemandSplitLogic");
        public static readonly ServiceEndpointRoutes WeeklyDemandSplitLogic = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/WeeklyDemandSplitLogic");
        public static readonly ServiceEndpointRoutes CustomerDemandCalculationSettingsMatrix = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/CustomerDemandCalculationSettingsMatrix");
        public static readonly ServiceEndpointRoutes WMSInventoryCalendarSync = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.WMSDataSynchronizationETL/WMSInventoryMaster/SyncCalendartoWMS");
        public static readonly ServiceEndpointRoutes CustomerDemandCalculation = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculation");
        public static readonly ServiceEndpointRoutes GenerateCustomerDemandCalculation = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculation/GenerateCustomerDemand");
        public static readonly ServiceEndpointRoutes CustomerDemandCalculationFilterData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculation/ViewCustomerDemand");
        public static readonly ServiceEndpointRoutes HarnessType = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/HarnessType");
        public static readonly ServiceEndpointRoutes DRPCalculationParameters = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/DRPCalculationParameters");
        public static readonly ServiceEndpointRoutes SiteProductionCalendar = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/SiteProductionCalendar");
        public static readonly ServiceEndpointRoutes LogisticsFinancialCalendar = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/LogisticsFinancialCalendar");
        public static readonly ServiceEndpointRoutes CustomerCalendar = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/CustomerCalendar");
        public static readonly ServiceEndpointRoutes WMSInventorySnapShotByPartNumber = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.WMSDataSynchronizationETL/WMSInventoryMaster/GetAllWMSInventorySnapShotByPartNumber");
        public static readonly ServiceEndpointRoutes WMSStockPositionCumulate = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.WMSDataSynchronizationETL/WMSInventoryMaster/OpeningStockPositionCumulate");
        public static readonly ServiceEndpointRoutes CustomerBacklogOrder = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/CustomerBacklogOrder");
        public static readonly ServiceEndpointRoutes PPSCustomerASNCodeXref = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/PPSCustomerASNCodeXref");
        public static readonly ServiceEndpointRoutes WIPMaintenance = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/WIPMaintenance");
        public static readonly ServiceEndpointRoutes SiteFacilityCalendar = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/SiteFacilityCalendar");
        public static readonly ServiceEndpointRoutes DRPCalculationSettingsMatrix = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/DRPCalculationSettingsMatrix");
        public static readonly ServiceEndpointRoutes WarehouseSiteCalendar = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/WarehouseSiteCalendar");
        public static readonly ServiceEndpointRoutes DRPGenerationBySupplyChainMatrix = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationBySupplyChainMatrix");
        public static readonly ServiceEndpointRoutes DRPGenerationBySupplyChainMatrixFilteredData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationBySupplyChainMatrix/GetDRPGenerationBySupplyChainMatrixFilteredData");
        public static readonly ServiceEndpointRoutes DRPCalculationStageOne = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationBySupplyChainMatrix/DRPCalculationStageOne");
        public static readonly ServiceEndpointRoutes IssueDRPOrder = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationBySupplyChainMatrix/IssueDRPOrder");
        public static readonly ServiceEndpointRoutes GenerateWMSOrderFile = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationBySupplyChainMatrix/GenerateWMSOrderFile");
        public static readonly ServiceEndpointRoutes IssueForecastOrder = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationBySupplyChainMatrix/IssueForecastOrder");
        public static readonly ServiceEndpointRoutes WMSInventorySnapShotByProcedure = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.WMSDataSynchronizationETL/WMSInventoryMaster/WMSInventorySnapShotByProcedure");
        public static readonly ServiceEndpointRoutes DRPGenerationReportData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.WMSDataSynchronizationETL/WMSInventoryMaster/DRPGenerationReportData");
        public static readonly ServiceEndpointRoutes DRPGenerationReportData_old = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.WMSDataSynchronizationETL/WMSInventoryMaster/DRPGenerationReportData_old");
        public static readonly ServiceEndpointRoutes WMSOpeningStockByProcedure = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.WMSDataSynchronizationETL/WMSInventoryMaster/WMSOpeningStockByProcedure");
        public static readonly ServiceEndpointRoutes DRPGenerationReportIssueOrder = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/DRPGenerationReportIssueOrder");
        public static readonly ServiceEndpointRoutes OrderStatus = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/OrderStatus");
        public static readonly ServiceEndpointRoutes DaysOfDemandSettingsFilteredData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/DaysOfDemandSettings/GetDaysOfDemandSettingsFilteredData");
        public static readonly ServiceEndpointRoutes DaysOfDemandSettingsUpdateData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/DaysOfDemandSettings/UpdateDaysOfDemandSettingsData");
        public static readonly ServiceEndpointRoutes ABCAnalysisFilteredData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/ABCAnalysis/GetABCAnalysisFilteredData");
        public static readonly ServiceEndpointRoutes ABCAnalysisUpdateData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/ABCAnalysis/UpdateABCAnalysisData");
        public static readonly ServiceEndpointRoutes ReGenerateABCAnalysisSync = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/ABCAnalysis/ReGenerateABCAnalysisSync");
       // public static readonly ServiceEndpointRoutes CustomerProductNumberParameters = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDISetupMaster/CustomerProductNumberParameters"); //Commented By Prakhar
        public static readonly ServiceEndpointRoutes RefreshCustomerProductNumber = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/CustomerProductNumberParameters/RefreshCustomerProductNumber");
        public static readonly ServiceEndpointRoutes GetSupplyChainDesignFilteredData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainDesign/GetSupplyChainDesignFilteredData");
        public static readonly ServiceEndpointRoutes SupplyChainMappingFilteredData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainMapping/SupplyChainMappingFilteredData");
        public static readonly ServiceEndpointRoutes SupplyChainMapping = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainMapping");
        public static readonly ServiceEndpointRoutes ProcessOperationSupplyChainDesignData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainDesign/ProcessOperationSupplyChainDesignData");
        public static readonly ServiceEndpointRoutes PartABCCategoryAnalysis = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/PartABCCategoryAnalysis/GetPartABCCategoryAnalysis");
        public static readonly ServiceEndpointRoutes ReGeneratePartCategoryABCAnalysisSync = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/PartABCCategoryAnalysis/ReGeneratePartCategoryABCAnalysisSync");
        public static readonly ServiceEndpointRoutes CustomerProductNumberParametersKeys = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/CustomerProductNumberParameters/GetCustomerProductNumberParametersKeys");
        public static readonly ServiceEndpointRoutes EDIMessageMissingCustomerPart = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/EDIMessageHeaderMaster/GetEDIMessageMissingCustomerPart");
        public static readonly ServiceEndpointRoutes CheckMissingProductCustomerDemand = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculation/CheckMissingProductCustomerDemand");
        public static readonly ServiceEndpointRoutes OrderBookStatus = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/OrderBookStatus");
        public static readonly ServiceEndpointRoutes GetDataSyncCalendarByDataSyncConfigurationSetupGuid = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyPlanningDataSyncCalendar/GetDataSyncCalendarByDataSyncConfigurationSetupGuid");
        public static readonly ServiceEndpointRoutes SyncSupplyPlanningDataSyncConfigurationSetup = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/SyncSupplyPlanningDataSyncConfigurationSetup");
        public static readonly ServiceEndpointRoutes SyncSupplyPlanningDataSyncConfigurationSetupToWMS = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/SyncSupplyPlanningDataSyncConfigurationSetupToWMS");
        public static readonly ServiceEndpointRoutes SupplyChainMappingMissingCustomerProductNumber = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/SupplyChainMappingMissingCustomerProductNumber");
        public static readonly ServiceEndpointRoutes ManualDemandDocumentDataEntry = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ManualDemandDocumentDataEntry");
        public static readonly ServiceEndpointRoutes ManualDemandDocumentDataEntryUpload = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ManualDemandDocumentDataEntry/ManualDemandDocumentDataEntryUpload");
        public static readonly ServiceEndpointRoutes ManualDemandDocumentDataEntryFilterData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ManualDemandDocumentDataEntry/GetManualDemandDocumentDataEntryData");
        public static readonly ServiceEndpointRoutes GetDocumentEDICollection = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ManualDemandDocumentDataEntry/GetDocumentEDICollection");
        public static readonly ServiceEndpointRoutes ProcessRequestManualDemandDocumentDataEntry = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ManualDemandDocumentDataEntry/ProcessRequest");
        public static readonly ServiceEndpointRoutes GetPartNumberByProcedure = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ManualDemandDocumentDataEntry/GetPartNumberByProcedure");
        public static readonly ServiceEndpointRoutes ManualDemandDocumentDesignFilteredData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ManualDemandDocumentDesign/ManualDemandDocumentDesignFilteredData");
        public static readonly ServiceEndpointRoutes ManualDemandDocumentDesignData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ManualDemandDocumentDesign/ProcessOperationManualDemandDocumentDesignData");
        public static readonly ServiceEndpointRoutes ManualDemandDocumentStatusReviewData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ManualDemandDocumentStatusReview/GetManualDemandDocumentStatusReviewData");
        public static readonly ServiceEndpointRoutes ManualDemandDocumentStatusReviewUpdateData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ManualDemandDocumentStatusReview/ManualDemandDocumentStatusReviewUpdateData");
        public static readonly ServiceEndpointRoutes OrderBookMissingTransferPriceData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/OrderBookStatus/OrderBookMissingTransferPriceData");
        public static readonly ServiceEndpointRoutes DemandCalculationMethod = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DemandCalculationMethod");
        public static readonly ServiceEndpointRoutes GetDemandCalculationMethodSelectionFilteredData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DemandCalculationMethodSelection/GetDemandCalculationMethodSelection");
        public static readonly ServiceEndpointRoutes DemandCalculationMethodSelectionSaveData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DemandCalculationMethodSelection/DemandCalculationMethodSelectionSaveData");
        public static readonly ServiceEndpointRoutes GetSupplyChainExceptionListData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainExceptionList/GetSupplyChainExceptionListData");
        public static readonly ServiceEndpointRoutes SupplyChainExceptionListSaveData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainExceptionList/SupplyChainExceptionListSaveData");
        public static readonly ServiceEndpointRoutes SupplyChainExceptionListUploadData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainExceptionList/SupplyChainExceptionListUpload");
        public static readonly ServiceEndpointRoutes GetAllUnloadingPoint = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainExceptionList/GetUnloadingPoint");
        public static readonly ServiceEndpointRoutes GetFilteredCustomerPartNumber = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainExceptionList/GetFilteredCustomerPartNumber");
        public static readonly ServiceEndpointRoutes GetCustomerPartNumberBySupplyChainFromProductNumber = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainMapping/GetCustomerPartNumberBySupplyChain");
        public static readonly ServiceEndpointRoutes GetGroupNameData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyPlanningMailDistributionSetting/GetGroupNameData");
        public static readonly ServiceEndpointRoutes GetProcessNameData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyPlanningMailDistributionSetting/GetProcessNameData");
        public static readonly ServiceEndpointRoutes GetSupplyPlanningMailDistributionSettingData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyPlanningMailDistributionSetting/GetSupplyPlanningMailDistributionSettingData");
        public static readonly ServiceEndpointRoutes SupplyPlanningMailDistributionSettingData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyPlanningMailDistributionSetting/ProcessSupplyPlanningMailDistributionSettingData");
        public static readonly ServiceEndpointRoutes GetABCAnalysisMethod = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainDesign/GetABCAnalysisMethod");
        public static readonly ServiceEndpointRoutes GetTargetInventoryMethod = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainDesign/GetTargetInventoryMethod");
        public static readonly ServiceEndpointRoutes DRPGenerationPrecheckReport = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/DRPGenerationPrecheckReport");
        public static readonly ServiceEndpointRoutes SupplyChainMappingDataUpload = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainMapping/SupplyChainMappingDataUpload"); // [08-Sept-2022] : Virendra
        public static readonly ServiceEndpointRoutes GetCustomerBusinessGroup = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPGenerationModule/GetCustomerBusinessGroup");
        public static readonly ServiceEndpointRoutes GetEDIMessageDetailMappingData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/EDIMessageHeaderMaster/GetEDIMessageDetailMappingData");
        public static readonly ServiceEndpointRoutes GetAllCustomerDeliveryPoint = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/FinishedGoodsStatus/GetAllCustomerDeliveryPoint");
        public static readonly ServiceEndpointRoutes GetFinishedGoodsStatusUXData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/FinishedGoodsStatus/GetFinishedGoodsStatusUXData");
        public static readonly ServiceEndpointRoutes AllLocationTypeByProcedure = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.WMSDataSynchronizationETL/WMSInventoryMaster/AllLocationTypeByProcedure");
        public static readonly ServiceEndpointRoutes GetFinishedGoodsFGStockReport = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/FinishedGoodsStatus/GetFinishedGoodsFGStockReport");
        public static readonly ServiceEndpointRoutes GetChildGridAllData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/FinishedGoodsStatus/GetChildGridData");
        public static readonly ServiceEndpointRoutes GetFinishedGoodsFGStockTransitDetailsReport = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/FinishedGoodsStatus/GetFinishedGoodsFGStockTransitDetailsReport");
        public static readonly ServiceEndpointRoutes GetFinishedGoodsFGStockOrderStatusReport = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/FinishedGoodsStatus/GetFinishedGoodsFGStockOrderStatusReport");
        public static readonly ServiceEndpointRoutes EDIMessageDateFormat = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/EDIMessageHeaderMaster/GetDateFormat");       
        public static readonly ServiceEndpointRoutes GetDRPOrderCancelationData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPOrderCancelation/GetDRPOrderCancelationData");
        public static readonly ServiceEndpointRoutes ProcessOperationDRPOrderCancelationData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPOrderCancelation");
        public static readonly ServiceEndpointRoutes GetCustomerIdentificationSettingsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerIdentificationSettings/GetCustomerIdentificationSettingsData");
        public static readonly ServiceEndpointRoutes ProcessCustomerIdentificationSettingsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerIdentificationSettings");
        public static readonly ServiceEndpointRoutes GetUnloadingPointByFilterData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerIdentificationSettings/GetUnloadingPointByFilterData");
        //public static readonly ServiceEndpointRoutes GetCustomerDemandParameterSettingsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandParameterSettings/GetCustomerDemandParameterSettingsData");//Commented by vishwadeep Singh as suggested by Shahab Ashraf on [23-Mar-2023]
        //public static readonly ServiceEndpointRoutes ProcessCustomerDemandParameterSettingsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandParameterSettings");//Commented by vishwadeep Singh as suggested by Shahab Ashraf on [23-Mar-2023]

        public static readonly ServiceEndpointRoutes GetCustomerCalendarData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerCalendar/GetCustomerCalendarData");
        public static readonly ServiceEndpointRoutes ProcessCustomerCalendarData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerCalendar/ProcessOperationCustomerCalendarData");
        public static readonly ServiceEndpointRoutes GenerateCustomerCalendarData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerCalendar/GenerateCustomerCalendarData");
        public static readonly ServiceEndpointRoutes ReplicateCustomerCalendarData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerCalendar/ReplicateCustomerCalendarData");

        public static readonly ServiceEndpointRoutes LogisticsFinancialCalendarStateLess = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/LogisticsFinancialCalendar");
        public static readonly ServiceEndpointRoutes CustomerDemandCalculationSettingMatrixStateless = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculationSettingMatrix/GetCustomerDemandCalculationSettingMatrix");
        public static readonly ServiceEndpointRoutes DefaultLogisticsFinancialCalendarStateLess = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/LogisticsFinancialCalendar/GetDefaultLogisticsCalendarData"); //mayur
        public static readonly ServiceEndpointRoutes GetSupplierCalendarData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplierCalender/GetSupplierCalenderFilteredData"); //Prakhar
        public static readonly ServiceEndpointRoutes ProcessSupplierCalendarData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplierCalender/ProcessOperationSupplierCalender"); //Prakhar
        public static readonly ServiceEndpointRoutes DefaultSupplierCalendarStateLess = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplierCalender/GetDefaultSupplierCalendarData"); //prakhar
        public static readonly ServiceEndpointRoutes GetCustomerProductNumberXREF = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerProductNumberXREF/GetCustomerProductNumberXREFFilteredData"); //prakhar
        public static readonly ServiceEndpointRoutes ProcessCustomerProductNumberXREF = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerProductNumberXREF/ProcessOperationCustomerProductNumberXREF"); //prakhar
        public static readonly ServiceEndpointRoutes GetUnloadingPointByCustomerGuid = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerProductNumberXREF/GetUnloadingPointByCustomerGuid"); //prakhar
        public static readonly ServiceEndpointRoutes UploadCustomerProductNumberXREF = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerProductNumberXREF/UploadCustomerProductNumberXREF");
       
        public static readonly ServiceEndpointRoutes GetUnloadingPointByCustomerGuidAndCustomerDeliveryPoint = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculationProgramMaintenance/GetUnloadingPointByCustomerGuidAndCustomerDeliveryPoint"); //Virendra
        public static readonly ServiceEndpointRoutes ProcessOperationCustomerDemandCalculationProgramMaintenance = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculationProgramMaintenance/ProcessOperationCustomerDemandCalculationProgramMaintenance"); //Virendra
        public static readonly ServiceEndpointRoutes GetCustomerDemandCalculationProgramMaintenance = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculationProgramMaintenance/GetCustomerDemandCalculationProgramMaintenance"); //Virendra
        public static readonly ServiceEndpointRoutes GetAllCustomerDemandFunction = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculationProgramMaintenance/GetAllCustomerDemandFunction"); //Virendra
        public static readonly ServiceEndpointRoutes GetCustomerDemandParameterByDemandFunction = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculationProgramMaintenance/GetCustomerDemandParameterByDemandFunction"); //Virendra
       // public static readonly ServiceEndpointRoutes ProcessOperationDemandFunctionData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculationProgramMaintenance/ProcessOperationDemandFunctionData"); // Commented by Virendra
        public static readonly ServiceEndpointRoutes ProcessOperationCustomerDemandFunctionParameter = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculationProgramMaintenance/ProcessOperationCustomerDemandFunctionParameter"); //Virendra
        public static readonly ServiceEndpointRoutes GetCustomerDemandFunctionAndParameter = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandFunctionAndParameters/GetCustomerDemandFunctionAndParameter");
        public static readonly ServiceEndpointRoutes SaveCustomerDemandFunctionAndFunctionParameter = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandCalculationProgramMaintenance/SaveCustomerDemandFunctionAndFunctionParameter"); //Virendra

        public static readonly ServiceEndpointRoutes GetCustomerPartNumber = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplyChainMapping/GetCustomerPartNumber");//Vishwadeep Singh
        public static readonly ServiceEndpointRoutes DRPGenerationReportData_temp = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.WMSDataSynchronizationETL/WMSInventoryMaster/DRPGenerationReportData_temp"); //prakhar
        public static readonly ServiceEndpointRoutes GetSupplierCalendarCustomerHierarchyDropDownData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplierCalender/GetSupplierCalendarCustomerHierarchyDropDownData");//prakhar
        public static readonly ServiceEndpointRoutes GetSupplierCalendarCustomerBusinessHierarchyDropDownData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SupplierCalender/GetSupplierCalendarCustomerBusinessHierarchyDropDownData");//prakhar

        public static readonly ServiceEndpointRoutes GetCustomerNameBasedOnSupplyChain = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGeneration/GetCustomerNameBasedOnSupplyChain");//Ranjay
        public static readonly ServiceEndpointRoutes GetProjectNameBasedOnSupplyChain = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGeneration/GetProjectNameBasedOnSupplyChain");//Ranjay
        public static readonly ServiceEndpointRoutes GetDcLocationBasedOnSupplyChain = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGeneration/GetDcLocationBasedOnSupplyChain");//Ranjay
        public static readonly ServiceEndpointRoutes GetMFSiteBasedOnSupplyChain = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGeneration/GetMFSiteBasedOnSupplyChain");//Ranjay
        public static readonly ServiceEndpointRoutes GetDRPManualOrderGenerationReviewData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGenerationReview/GetDRPManualOrderGenerationReviewData");//Ranjay
        public static readonly ServiceEndpointRoutes ProcessDRPManualOrderGenerationReviewData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGenerationReview/ProcessDRPManualOrderGenerationReview");//Ranjay
        public static readonly ServiceEndpointRoutes GetDRPManualOrderGenerationLogData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGenerationLog/GetDRPManualOrderGenerationLogData");//Piyush
        public static readonly ServiceEndpointRoutes GetDRPManualOrderDocumentId = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGenerationDataEntryController/GetDRPManualOrderDocumentId");//Prakhar
        public static readonly ServiceEndpointRoutes GetDRPManualOrderGenerationDataEntry = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGenerationDataEntryController/GetDRPManualOrderGenerationDataEntry");//Prakhar
        public static readonly ServiceEndpointRoutes ProcessOperationDRPManualOrderGenerationDataEntry = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGenerationDataEntryController/ProcessOperationDRPManualOrderGenerationDataEntry");//Prakhar
        public static readonly ServiceEndpointRoutes GetDRPManualOrderPartNo = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGenerationDataEntryController/GetDRPManualOrderPartNo");//Prakhar
        public static readonly ServiceEndpointRoutes DRPManualOrderGenerationDataEntryUpload = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGenerationDataEntryController/DRPManualOrderGenerationDataEntryUpload");//Prakhar
        public static readonly ServiceEndpointRoutes GetDefaultDRPManualOrderDocumentId = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGenerationDataEntryController/GetDefaultDRPManualOrderDocumentId");//Prakhar  
        public static readonly ServiceEndpointRoutes DRPManualOrderDataEntrySendForApproval = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGenerationDataEntryController/DRPManualOrderDataEntrySendForApproval");//Prakhar
        public static readonly ServiceEndpointRoutes GetWarehouseCodeData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ExternalWMSLocationTypeAssociation/GetWarehouseCodeData");//Sachin
        public static readonly ServiceEndpointRoutes GetExternalWMSLocationTypeAssociationDataByWhCode = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ExternalWMSLocationTypeAssociation/GetExternalWMSLocationTypeAssociationDataByWhCode");//Sachin
        public static readonly ServiceEndpointRoutes ProcessOperationExternalWMSLocationData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ExternalWMSLocationTypeAssociation/ProcessOperationExternalWMSLocationTypeAssociationData");//Sachin
        #region Added Endpoint for Customer Demand InterChangeability Screen
        public static readonly ServiceEndpointRoutes Show_CustomerDemandInterChangeability = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandInterChangeability/Show_CustomerDemandInterChangeability"); //Virendra
        public static readonly ServiceEndpointRoutes ProcessCustomerDemandInterChangeability = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerDemandInterChangeability/ProcessCustomerDemandInterChangeability"); //Virendra
        public static readonly ServiceEndpointRoutes GetDRPManualOrderSupplyChainId = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DRPManualOrderGenerationDataEntryController/GetDRPManualOrderSupplyChainId");//Prakhar
        #endregion
        public static readonly ServiceEndpointRoutes GetCustomerProductNumberParameterFilteredData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerProductNumberParameter/GetCustomerProductNumberParameterFilteredData");//Prakhar
        public static readonly ServiceEndpointRoutes ProcessOperationCustomerProductNumberParameterData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CustomerProductNumberParameter/ProcessOperationCustomerProductNumberParameterData");//Prakhar
        public static readonly ServiceEndpointRoutes GetApplicationReferenceData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ApplicationReference/GetApplicationReferenceData");  //added by piyush on 05-Dec-2023
        public static readonly ServiceEndpointRoutes ProcessApplicationReferenceData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ApplicationReference/ProcessApplicationReferenceData");   //added by piyush on 05-Dec-2023
        public static readonly ServiceEndpointRoutes GetBuyerDetailsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/BuyerDetails/GetBuyerDetailsData");  //added by piyush on 07-Dec-2023
        public static readonly ServiceEndpointRoutes ProcessBuyerDetailsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/BuyerDetails/ProcessBuyerDetailsData");   //added by piyush on 07-Dec-2023
        public static readonly ServiceEndpointRoutes GetConsigneeDetailsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ConsigneeDetails/GetConsigneeDetailsData");  //added by piyush on 08-Dec-2023
        public static readonly ServiceEndpointRoutes ProcessConsigneeDetailsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ConsigneeDetails/ProcessConsigneeDetailsData");   //added by piyush on 08-Dec-2023
        public static readonly ServiceEndpointRoutes GetConsignorDetailsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ConsignorDetails/GetConsignorDetailsData");  //added by piyush on 08-Dec-2023
        public static readonly ServiceEndpointRoutes ProcessConsignorDetailsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/ConsignorDetails/ProcessConsignorDetailsData");   //added by piyush on 08-Dec-2023
        public static readonly ServiceEndpointRoutes GetEDIMessageTypeData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/EDIMessageType/GetEDIMessageTypeData");  //added by piyush on 12-Dec-2023
        public static readonly ServiceEndpointRoutes ProcessEDIMessageTypeData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/EDIMessageType/ProcessEDIMessageTypeData");   //added by piyush on 12-Dec-2023
        public static readonly ServiceEndpointRoutes GetDataSyncConfigurationSetupData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DataSyncConfigurationSetup/GetDataSyncConfigurationSetupData");  //added by piyush on 12-Dec-2023
        public static readonly ServiceEndpointRoutes ProcessDataSyncConfigurationSetupData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DataSyncConfigurationSetup/ProcessDataSyncConfigurationSetupData");   //added by piyush on 12-Dec-2023
        public static readonly ServiceEndpointRoutes GetSupplyPlanningParameterSettings = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/DataSyncConfigurationSetup/GetSupplyPlanningParameterSettings");   //added by piyush on 12-Dec-2023
        public static readonly ServiceEndpointRoutes GetInvoiceeDetailsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/InvoiceeDetails/GetInvoiceeDetailsData");   //added by piyush on 14-Dec-2023
        public static readonly ServiceEndpointRoutes ProcessInvoiceeDetailsData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/InvoiceeDetails/ProcessInvoiceeDetailsData");   //added by piyush on 14-Dec-2023
        public static readonly ServiceEndpointRoutes GetPackagingTypeData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/PackagingType/GetPackagingTypeData");   //added by piyush on 14-Dec-2023
        public static readonly ServiceEndpointRoutes ProcessPackagingTypeData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/PackagingType/ProcessPackagingTypeData");   //added by piyush on 14-Dec-2023
        public static readonly ServiceEndpointRoutes GetSchedulingConditionData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SchedulingCondition/GetSchedulingConditionData");   //added by piyush on 15-Dec-2023
        public static readonly ServiceEndpointRoutes ProcessSchedulingConditionData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SchedulingCondition/ProcessSchedulingConditionData");   //added by piyush on 15-Dec-2023
        public static readonly ServiceEndpointRoutes GetSchedulingFrequencyData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SchedulingFrequency/GetSchedulingFrequencyData");   //added by piyush on 15-Dec-2023
        public static readonly ServiceEndpointRoutes ProcessSchedulingFrequencyData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SchedulingFrequency/ProcessSchedulingFrequencyData");   //added by piyush on 15-Dec-2023
        public static readonly ServiceEndpointRoutes GetUnloadingPointData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/UnloadingPoint/GetUnloadingPointData");   //added by piyush on 18-Dec-2023
        public static readonly ServiceEndpointRoutes ProcessUnloadingPointData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/UnloadingPoint/ProcessUnloadingPointData");   //added by piyush on 18-Dec-2023
        public static readonly ServiceEndpointRoutes GetUNBSenderData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/UNBSender/GetUNBSenderData");   //added by piyush on 18-Dec-2023
        public static readonly ServiceEndpointRoutes GetEDIMessageMatrixData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/EDIMessageMatrix/GetEDIMessageMatrixData");   //added by piyush on 15-Jan-2024
        public static readonly ServiceEndpointRoutes GetSingleUserMaintanencedata = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SingleUserMaintanence/GetSingleUserMaintanencedata");//Sachin
        public static readonly ServiceEndpointRoutes ProcessOperationSingleUserMaintanencedata = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SingleUserMaintanence/ProcessOperationSingleUserMaintanencedata");//Sachin
        public static readonly ServiceEndpointRoutes GetScreenName = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SingleUserMaintanence/GetScreenName");//Sachin
        public static readonly ServiceEndpointRoutes LockScreenDuringDRPOperation = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/SingleUserMaintanence/LockScreenDuringDRPOperation");//Sachin
        public static readonly ServiceEndpointRoutes GetUnlockSingleUserDataAdmin = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/UnlockSingleUser/GetUnlockSingleUserDataAdmin");//Sachin
        public static readonly ServiceEndpointRoutes ProcessOperationUnlockSingleUserdataAdmin = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/UnlockSingleUser/ProcessOperationUnlockSingleUserdataAdmin");//Sachin
        public static readonly ServiceEndpointRoutes ProcessOperationSinleUserAccessCloseAll = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/UnlockSingleUser/ProcessOperationSinleUserAccessCloseAll");//Piyush Anand
        public static readonly ServiceEndpointRoutes ProcessOperationSinleUserAccessCloseScreenWise = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/UnlockSingleUser/ProcessOperationSinleUserAccessCloseScreenWise");//Piyush Anand
        public static readonly ServiceEndpointRoutes GetSetSinleUserAccess = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/UnlockSingleUser/GetSetSinleUserAccess");//Piyush Anand
        public static readonly ServiceEndpointRoutes GetVehicleName = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CarSetMaintenance/GetVehicleName");//Piyush Anand
        public static readonly ServiceEndpointRoutes GetFamilyName = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CarSetMaintenance/GetFamilyName");//Piyush Anand
        public static readonly ServiceEndpointRoutes GetCarSetMaintenanceData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CarSetMaintenance/GetCarSetMaintenanceData");//Piyush Anand
        public static readonly ServiceEndpointRoutes ProcessCarSetMaintenanceData = new ServiceEndpointRoutes("SupplyPlanning/api/SF.SupplyPlanning.EDIProcessETL/CarSetMaintenance/ProcessCarSetMaintenanceData");//Piyush Anand

    }
}
