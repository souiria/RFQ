/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name           :   ServiceEndpointRoutesPurchasing.cs
Function            :   Maintaining all endpoints to reach the service for Purchasing master module
Created By          :   MIND Team
Created on          :   02-Jan-2019
Revision History    :   [02-Sep-2020] : Dharmendra 
                    :   [ ] :  Comment endpoints for CorePurchasingCustomerMaster, CorePurchasingVehicleMaster, CorePurchasingFacilityMaster
                    :   [30-Oct-2020] : Srashti Gupta
                    :   [ ] :  Added endpoints for CoreCustomerProductList
                    :   [22-Mar-2022] : Ranjay
                    :   [ ] :  Added endpoints for GetMaterialNumberList
                    :   [29-Mar-2022] : Shivam Kalia
                    :   [ ] :  Added endpoints for GetMaterialHierarchyByIds
                    :   [29-Mar-2022] : Ranjay
                    :   [ ] :  Added endpoints for TariffCodeStateLess,GetTariffCodeNameStateLess,CheckTariffCodeCrossReferenceStateLess
                    :   [01-Apr-2022] : Shivam Kalia
                    :   [ ] :  Added endpoint for CheckWithMaterialNumber and GetAllAvailableMaterialBySupplierForPSM
                    :   [24-Jun-2022] : Prakhar Singh
                    :   [ ] :  Added endpoint for GetCustomerVehicleProduct and GetCustomerBuisnessGroupNameVehicleProduct
                    :   [15-Jul-2022] : Shivam Dhingra
                    :   [ ] :  Added endpoint GetAllBusinessUnitWithLegacyFields
                    :   [14-Jul-2022] : PrakharSingh
                    :   [ ] :  Added endpoint GetProjectHierarchy_Id_ProjectName
                    :   [14-Jul-2022] : PrakharSingh
                    :   [ ] :  Added endpoint GetCustomerHierarchy_Id_CustomerName_CustomerCode
                    :   [14-Jul-2022] : PrakharSingh
                    :   [ ] :  Added endpoint GetCustomerProjectAssociation
                    :   [14-Jul-2022] : PrakharSingh
                    :   [ ] :  Added endpoint ProcessOperationCustomerProjectAssociation
                    :   [22-Jul-2022] : Virendra
                    :   [ ] :  Added endpoint GetAllCustomerProjectAssociate
                    :   [31-Jan-2023] : Prakhar Singh
                    :   [ ] : Added endpoint GetAllVehicle
                    :   [15-Feb-2023] : Mayur
                    :   [ ] : Added endpoint GetAllBuisnessUnitFiltered
                    :   [15-Feb-2022] : Ranjay
                    :   [ ] : [HD Call Number - 00370357] Added endpoints for GetCustomerBusinessHierarchyDropDownData, GetCustomerHierarchyDropDownData
                    :   [20-Feb-2023] vishwadeep Singh
*                   :   [ ] HD:00375862 : Added 5 new endpoint PlatformHierarchy,ProgramHierarchy,ProjectHierarchy,MilestoneHierarchy and GetAllHierarchyDataBasedOnModelType
*                   :   [27-Feb-2023] : Ranjay
*                   :   [HD-00375862] : Added new endpoint GetAllCustomerBusinessHierarchy,GetAllCustomerHierarchy,GetAllCustomerSalesEntityHierarchy,GetAllCountry,ProcessCustomerBusinessHierarchy,CheckCustomerBusinessGroupCode
                    :   [21-Mar-2023] : Prakhar
                    :   [ ] : [HD Call Number - 00370582] Added endpoints for ProcessOperationVehicle 


****************************************************************************************************/

using Common.Core.Infrastructure.Endpoints;

namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        //TODO: Needs separating into regions

       // public static readonly ServiceEndpointRoutes Composite = new ServiceEndpointRoutes("Composite");
        public static readonly ServiceEndpointRoutes Country = new ServiceEndpointRoutes("Country");
        public static readonly ServiceEndpointRoutes Currency = new ServiceEndpointRoutes("Currency");
        //public static readonly ServiceEndpointRoutes Derivative = new ServiceEndpointRoutes("Derivative");
        //public static readonly ServiceEndpointRoutes ExchangeRate = new ServiceEndpointRoutes("ExchangeRate");
        //public static readonly ServiceEndpointRoutes Facility = new ServiceEndpointRoutes("Facility");
        public static readonly ServiceEndpointRoutes Incoterms = new ServiceEndpointRoutes("Incoterms");
       // public static readonly ServiceEndpointRoutes IndexedMaterial = new ServiceEndpointRoutes("IndexedMaterial");
        public static readonly ServiceEndpointRoutes Material = new ServiceEndpointRoutes("Material");
        public static readonly ServiceEndpointRoutes MaterialType = new ServiceEndpointRoutes("MaterialType");
       // public static readonly ServiceEndpointRoutes Part = new ServiceEndpointRoutes("Part");
        public static readonly ServiceEndpointRoutes Site = new ServiceEndpointRoutes("Site");
        public static readonly ServiceEndpointRoutes SiteType = new ServiceEndpointRoutes("SiteType");
        public static readonly ServiceEndpointRoutes Supplier = new ServiceEndpointRoutes("Supplier");
        public static readonly ServiceEndpointRoutes TariffCode = new ServiceEndpointRoutes("TariffCode");
        public static readonly ServiceEndpointRoutes UnitOfMeasure = new ServiceEndpointRoutes("UnitOfMeasure");
       // public static readonly ServiceEndpointRoutes Vehicle = new ServiceEndpointRoutes("Vehicle");
       // public static readonly ServiceEndpointRoutes Wire = new ServiceEndpointRoutes("Wire");
        public static readonly ServiceEndpointRoutes MaterialSupplier = new ServiceEndpointRoutes("MaterialSupplier");
        public static readonly ServiceEndpointRoutes SupplierType = new ServiceEndpointRoutes("SupplierType");
        public static readonly ServiceEndpointRoutes SupplierGroup = new ServiceEndpointRoutes("SupplierGroup");
        public static readonly ServiceEndpointRoutes ErrorLog = new ServiceEndpointRoutes("ErrorLog");
        public static readonly ServiceEndpointRoutes MaterialCostGroup = new ServiceEndpointRoutes("MaterialCostGroup");
        public static readonly ServiceEndpointRoutes PaymentTerms = new ServiceEndpointRoutes("PaymentTerms");
        public static readonly ServiceEndpointRoutes AgressoSupplier = new ServiceEndpointRoutes("AgressoSupplier");
        public static readonly ServiceEndpointRoutes ForecastType = new ServiceEndpointRoutes("ForecastType");
        public static readonly ServiceEndpointRoutes RatingConcern = new ServiceEndpointRoutes("RatingConcern");
        public static readonly ServiceEndpointRoutes PackForm = new ServiceEndpointRoutes("PackForm");
        public static readonly ServiceEndpointRoutes Commodity = new ServiceEndpointRoutes("Commodity");
        //public static readonly ServiceEndpointRoutes Customer = new ServiceEndpointRoutes("Customer");
        //public static readonly ServiceEndpointRoutes Project = new ServiceEndpointRoutes("Project");
        public static readonly ServiceEndpointRoutes LogisticsConcernReason = new ServiceEndpointRoutes("LogisticsConcernReason");
        public static readonly ServiceEndpointRoutes LogisticsConcernRaisedStatus = new ServiceEndpointRoutes("LogisticsConcernRaisedStatus");
        public static readonly ServiceEndpointRoutes TransportationMode = new ServiceEndpointRoutes("TransportationMode");
        public static readonly ServiceEndpointRoutes BusinessUnitType = new ServiceEndpointRoutes("BusinessUnitType");
        public static readonly ServiceEndpointRoutes BusinessUnit = new ServiceEndpointRoutes("BusinessUnit");
        public static readonly ServiceEndpointRoutes Contact = new ServiceEndpointRoutes("Contact");
        public static readonly ServiceEndpointRoutes SourceApplication = new ServiceEndpointRoutes("SourceApplication");
        public static readonly ServiceEndpointRoutes CountryRegions = new ServiceEndpointRoutes("CountryRegions");
        public static readonly ServiceEndpointRoutes ApplicationArticle = new ServiceEndpointRoutes("ApplicationArticle");
        public static readonly ServiceEndpointRoutes ProcurementUnit = new ServiceEndpointRoutes("ProcurementUnit");
        public static readonly ServiceEndpointRoutes GIStore = new ServiceEndpointRoutes("GIStore");
        public static readonly ServiceEndpointRoutes ContactType = new ServiceEndpointRoutes("ContactType");
        public static readonly ServiceEndpointRoutes OriginStatus = new ServiceEndpointRoutes("OriginStatus");
        public static readonly ServiceEndpointRoutes MaterialGetBaseMaterials = new ServiceEndpointRoutes("Material/GetBaseMaterials");
        public static readonly ServiceEndpointRoutes PurchasingOrganisation = new ServiceEndpointRoutes("PurchasingOrganisation");
        public static readonly ServiceEndpointRoutes Reason = new ServiceEndpointRoutes("Reason");
        public static readonly ServiceEndpointRoutes SupplierApprovalStatus = new ServiceEndpointRoutes("SupplierApprovalStatus");
        public static readonly ServiceEndpointRoutes WireType = new ServiceEndpointRoutes("WireType");
        public static readonly ServiceEndpointRoutes WireSize = new ServiceEndpointRoutes("WireSize");
        public static readonly ServiceEndpointRoutes FlexType = new ServiceEndpointRoutes("FlexType");
        public static readonly ServiceEndpointRoutes WireColour = new ServiceEndpointRoutes("WireColour");
        //public static readonly ServiceEndpointRoutes CustomerBusinessHierarchy = new ServiceEndpointRoutes("CustomerBusinessHierarchy");

        public static readonly ServiceEndpointRoutes CoreDefectType = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CoreDefectType);
        public static readonly ServiceEndpointRoutes CoreLiabilityType = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CoreLiabilityType);
        public static readonly ServiceEndpointRoutes CoreHarnessFamilyGroup = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CoreHarnessFamilyGroup);
        public static readonly ServiceEndpointRoutes CoreGetCustomerProductList = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CoreGetCustomerProductList);
        public static readonly ServiceEndpointRoutes CoreCustomerProductList = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CoreCustomerProductList);
        public static readonly ServiceEndpointRoutes Customer = new ServiceEndpointRoutes("Customer");
        public static readonly ServiceEndpointRoutes Project = new ServiceEndpointRoutes("Project");
        public static readonly ServiceEndpointRoutes MaterialHierarchyStateless = new ServiceEndpointRoutes("GlobalMasters/MaterialHierarchy/GetSpecificFieldsAsyncByFilter");
        public static readonly ServiceEndpointRoutes ProcessMaterialHierarchy = new ServiceEndpointRoutes("GlobalMasters/MaterialHierarchy");
        public static readonly ServiceEndpointRoutes MaterialHierarchyCheckForCrossReference = new ServiceEndpointRoutes("GlobalMasters/MaterialHierarchy/CheckForCrossReference");
        
        //public static readonly ServiceEndpointRoutes CorePurchasingCustomerMaster = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CorePurchasingCustomerMaster);
        //public static readonly ServiceEndpointRoutes CorePurchasingFacilityMaster = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CorePurchasingFacilityMaster);
        //public static readonly ServiceEndpointRoutes CorePurchasingVehicleMaster = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CorePurchasingVehicleMaster);

        //public static readonly ServiceEndpointRoutes CorePurchasingCustomerPartitions = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CorePurchasingCustomerPartitions);
        //public static readonly ServiceEndpointRoutes CorePurchasingFacilityMasterPartitions = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CorePurchasingFacilityMasterPartitions);
        //public static readonly ServiceEndpointRoutes CorePurchasingVehicleMasterPartitions = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.CorePurchasingVehicleMasterPartitions);

        public static readonly ServiceEndpointRoutes GetMaterialNumberList = new ServiceEndpointRoutes("GlobalMasters/MaterialHierarchy/GetMaterial");
        public static readonly ServiceEndpointRoutes GetMaterialHierarchyByIds = new ServiceEndpointRoutes("GlobalMasters/MaterialHierarchy/GetByIds");
        public static readonly ServiceEndpointRoutes TariffCodeStateLess = new ServiceEndpointRoutes("GlobalMasters/TariffCode");
        public static readonly ServiceEndpointRoutes GetTariffCodeNameStateLess = new ServiceEndpointRoutes("GlobalMasters/TariffCode/GetTariffCodeName");
        public static readonly ServiceEndpointRoutes CheckTariffCodeCrossReferenceStateLess = new ServiceEndpointRoutes("GlobalMasters/TariffCode/CheckTariffCodeCrossReference");
        public static readonly ServiceEndpointRoutes CheckWithMaterialNumber = new ServiceEndpointRoutes("GlobalMasters/MaterialHierarchy/CheckWithMaterialNumber");
        public static readonly ServiceEndpointRoutes GetAllAvailableMaterialBySupplierForPSM = new ServiceEndpointRoutes("GlobalMasters/MaterialHierarchy/GetAllAvailableMaterialBySupplierForPSM");
        public static readonly ServiceEndpointRoutes GetAllAvailableMaterialBySupplierForPSMBySupplierCode = new ServiceEndpointRoutes("GlobalMasters/MaterialHierarchy/GetAllAvailableMaterialBySupplierForPSMBySupplierCode");
        public static readonly ServiceEndpointRoutes GetAllAvailableMaterialBySupplierForPSMBySupplierCodeAndMaterialNumber = new ServiceEndpointRoutes("GlobalMasters/MaterialHierarchy/GetAllAvailableMaterialBySupplierForPSMBySupplierCodeAndMaterialNumber");
       // public static readonly ServiceEndpointRoutes GetCustomerVehicleProduct = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.GetCustomerVehicleProduct);
        //public static readonly ServiceEndpointRoutes GetCustomerBuisnessGroupNameVehicleProduct = new ServiceEndpointRoutes(NetCoreServiceEndpointRoutes.GetCustomerBuisnessGroupNameVehicleProduct);
        public static readonly ServiceEndpointRoutes GetAllBusinessUnitWithLegacyFields = new ServiceEndpointRoutes("BusinessUnit/GetAllBusinessUnitWithLegacyFields");
        public static readonly ServiceEndpointRoutes DropDownProjectHierarchy_Id_ProjectName = new ServiceEndpointRoutes("GlobalMasters/CustomerProjectAssociation/GetProjectHierarchy_Id_ProjectName");
        //public static readonly ServiceEndpointRoutes DropDownCustomerHierarchy_Id_CustomerName_CustomerCode = new ServiceEndpointRoutes("GlobalMasters/CustomerProjectAssociation/GetCustomerHierarchy_Id_CustomerName_CustomerCode");
        public static readonly ServiceEndpointRoutes GetCustomerProjectAssociation = new ServiceEndpointRoutes("GlobalMasters/CustomerProjectAssociation/GetCustomerProjectAssociation");
        public static readonly ServiceEndpointRoutes ProcessOperationCustomerProjectAssociation = new ServiceEndpointRoutes("GlobalMasters/CustomerProjectAssociation/ProcessOperationCustomerProjectAssociation");
        public static readonly ServiceEndpointRoutes GetAllCustomerProjectAssociate = new ServiceEndpointRoutes("GlobalMasters/CustomerProjectAssociation/GetAllCustomerProjectAssociate");
        public static readonly ServiceEndpointRoutes GetAllVehicle = new ServiceEndpointRoutes("GlobalMasters/Vehicle/GetAllVehicle"); //prakhar Stateless
        public static readonly ServiceEndpointRoutes GetAllBuisnessUnitFiltered = new ServiceEndpointRoutes("GlobalMasters/BusinessUnit/GetAllBuisnessUnitFiltered"); //mayur
        public static readonly ServiceEndpointRoutes GetCustomerBusinessHierarchyDropDownData = new ServiceEndpointRoutes("GlobalMasters/CustomerBusinessHierarchy/GetCustomerBusinessHierarchyDropDownData");
        public static readonly ServiceEndpointRoutes GetCustomerHierarchyDropDownData = new ServiceEndpointRoutes("GlobalMasters/CustomerHierarchy/GetCustomerHierarchyDropDownData");
        public static readonly ServiceEndpointRoutes PlatformHierarchy = new ServiceEndpointRoutes("GlobalMasters/PlatformHierarchy");
        public static readonly ServiceEndpointRoutes ProgramHierarchy = new ServiceEndpointRoutes("GlobalMasters/ProgramHierarchy");
        public static readonly ServiceEndpointRoutes ProjectHierarchy = new ServiceEndpointRoutes("GlobalMasters/ProjectHierarchy");
        public static readonly ServiceEndpointRoutes MilestoneHierarchy = new ServiceEndpointRoutes("GlobalMasters/MilestoneHierarchy");
        public static readonly ServiceEndpointRoutes GetAllHierarchyDataBasedOnModelType = new ServiceEndpointRoutes("GlobalMasters/ProjectHierarchy/GetAllHierarchyDataBasedOnModelType");
        public static readonly ServiceEndpointRoutes GetAllCustomerBusinessHierarchy = new ServiceEndpointRoutes("GlobalMasters/CustomerBusinessHierarchy/GetAllCustomerBusinessHierarchy");
        public static readonly ServiceEndpointRoutes GetAllCustomerHierarchy = new ServiceEndpointRoutes("GlobalMasters/CustomerHierarchy/GetAllCustomerHierarchy");
        public static readonly ServiceEndpointRoutes GetAllCustomerSalesEntityHierarchy = new ServiceEndpointRoutes("GlobalMasters/CustomerSalesEntityHierarchy/GetAllCustomerSalesEntityHierarchy");
        public static readonly ServiceEndpointRoutes GetAllCountry = new ServiceEndpointRoutes("GlobalMasters/CustomerBusinessHierarchy/GetAllCountry");
        public static readonly ServiceEndpointRoutes ProcessCustomerBusinessHierarchy = new ServiceEndpointRoutes("GlobalMasters/CustomerBusinessHierarchy/ProcessCustomerBusinessHierarchy");
        public static readonly ServiceEndpointRoutes CheckCustomerBusinessGroupCode = new ServiceEndpointRoutes("GlobalMasters/CustomerBusinessHierarchy/CheckCustomerBusinessGroupCode");
        public static readonly ServiceEndpointRoutes ProcessOperationVehicle = new ServiceEndpointRoutes("GlobalMasters/Vehicle/ProcessOperationVehicle"); //prakhar Stateless
    }

}



