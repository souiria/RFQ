namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        //TODO: Needs separating into regions

        public static readonly ServiceEndpointRoutes SupplierAssociation = new ServiceEndpointRoutes("SupplierAssociation");
        public static readonly ServiceEndpointRoutes SupplierMaterialAssociation = new ServiceEndpointRoutes("SupplierMaterialAssociation");
        public static readonly ServiceEndpointRoutes UnitOfMeasureAssociation = new ServiceEndpointRoutes("UnitOfMeasureAssociation");
        public static readonly ServiceEndpointRoutes TariffCodeCountryAssociation = new ServiceEndpointRoutes("TariffCodeCountryAssociation");
        public static readonly ServiceEndpointRoutes MaterialAssociation = new ServiceEndpointRoutes("MaterialAssociation");
        public static readonly ServiceEndpointRoutes CountryRegionsAssociation = new ServiceEndpointRoutes("CountryRegionsAssociation");
        public static readonly ServiceEndpointRoutes SourceApplicationArticleAssociation = new ServiceEndpointRoutes("SourceApplicationArticleAssociation");
        public static readonly ServiceEndpointRoutes ProcurementUnitBusinessUnitAssociation = new ServiceEndpointRoutes("ProcurementUnitBusinessUnitAssociation");
        public static readonly ServiceEndpointRoutes BusinessUnitGIStoreAssociation = new ServiceEndpointRoutes("BusinessUnitGIStoreAssociation");
        public static readonly ServiceEndpointRoutes CurrencyExchangeRateAssociation = new ServiceEndpointRoutes("CurrencyExchangeRate");
        public static readonly ServiceEndpointRoutes MaterialAssociationGridListByFilter = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/MaterialAssociation_GetGridListByFilter");
        public static readonly ServiceEndpointRoutes MaterialAssociationDataForCombo = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/MaterialAssociation_GetMaterialAssociationDataForCombo");
        //public static readonly ServiceEndpointRoutes SupplierMaterialAssociationGridListByFilter = new ServiceEndpointRoutes("SupplierMaterialAssociation/GetGridListByFilter");
        public static readonly ServiceEndpointRoutes SupplierMaterialAssociationGridListByFilter = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/SupplierMaterialAssociation_GetGridDataByFilter");
        public static readonly ServiceEndpointRoutes UOMAssociationCombo = new ServiceEndpointRoutes("UnitOfMeasureAssociation/GetUOMAssociationFiltered");
        //public static readonly ServiceEndpointRoutes SupplierAssociationDataForCombo = new ServiceEndpointRoutes("SupplierMaterialAssociation/GetSupplierDataForCombo");
        public static readonly ServiceEndpointRoutes SupplierAssociationDataForCombo = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/SupplierMaterialAssociation_GetSupplierDataForCombo");
        public static readonly ServiceEndpointRoutes SupplierAssociationGetGridRefreshData = new ServiceEndpointRoutes("SupplierAssociation/GetGridRefreshData");
        public static readonly ServiceEndpointRoutes MaterialAssociationGridFilterWithBaseMaterial = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/MaterialAssociation_GetGridListByFilterWithBaseMaterial");
        public static readonly ServiceEndpointRoutes MaterialAssociationDataForComboWithBaseMaterial = new ServiceEndpointRoutes("ETLPurchasingSupplierMaterial/MaterialAssociation_GetMaterialAssociationDataWithBaseMaterial");
        public static readonly ServiceEndpointRoutes PurchasingOrgProcUnitAssociation = new ServiceEndpointRoutes("PurchasingOrganisationProcurementAssociation");
        public static readonly ServiceEndpointRoutes SupplierAssociationGridListByFilter = new ServiceEndpointRoutes("SupplierAssociation/GetGridListByFilter");
        public static readonly ServiceEndpointRoutes ReasonH1FunctionAssociation = new ServiceEndpointRoutes("ReasonH1FunctionAssociation");
        public static readonly ServiceEndpointRoutes ProjectEngineeringAssociation = new ServiceEndpointRoutes("ProjectEngineeringAssociation");
        public static readonly ServiceEndpointRoutes CustomerUserAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/api/SF.GlobalMastersAssociationCore.AssociationMasters/CustomerUserAssociation");
        public static readonly ServiceEndpointRoutes CustomerBusinessUserAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/api/SF.GlobalMastersAssociationCore.AssociationMasters/CustomerBusinessUserAssociation");
        public static readonly ServiceEndpointRoutes UserCustomerGroupFlatData = new ServiceEndpointRoutes("GlobalMastersAssociation/api/SF.GlobalMastersAssociationCore.AssociationMasters/CustomerBusinessUserAssociation/UserCustomerGroup");
        public static readonly ServiceEndpointRoutes CustomerBusinessGroupFlatData = new ServiceEndpointRoutes("GlobalMastersAssociation/api/SF.GlobalMastersAssociationCore.AssociationMasters/CustomerBusinessUserAssociation/CustomerBusinessGroup");
        // public static readonly ServiceEndpointRoutes CurrencyExchangeRateConversionAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/api/SF.GlobalMastersAssociationCore.AssociationMasters/CurrencyExchangeRateConversionAssociation"); //used in currency Screen...StatefullService commented by Prakhar
        public static readonly ServiceEndpointRoutes CurrencyExchangeRateConversionAssociationH1ToDHSSync = new ServiceEndpointRoutes("GlobalMastersAssociation/CurrencyExchangeRateConversionAssociation/H1ToDHSSync");

        public static readonly ServiceEndpointRoutes SiteUserAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/api/SF.GlobalMastersAssociationCore.AssociationMasters/SiteUserAssociation");
        public static readonly ServiceEndpointRoutes UserBusinessUnitFlatData = new ServiceEndpointRoutes("GlobalMastersAssociation/api/SF.GlobalMastersAssociationCore.AssociationMasters/SiteUserAssociation/UserBusinessUnit");
        public static readonly ServiceEndpointRoutes BusinessUnitUserFlatData = new ServiceEndpointRoutes("GlobalMastersAssociation/api/SF.GlobalMastersAssociationCore.AssociationMasters/SiteUserAssociation/BusinessUnitUser");

        public static readonly ServiceEndpointRoutes CurrencyAndForeignExchangeSyncLog = new ServiceEndpointRoutes("GlobalMastersAssociation/CurrencyExchangeRateConversionAssociation/CurrencyAndForeignExchangeSyncLog");
        public static readonly ServiceEndpointRoutes ProductFamilyCustomerAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/ProductFamilyCustomerAssociation");
        public static readonly ServiceEndpointRoutes GetProductFamilyCustomerAssociationByProcedure = new ServiceEndpointRoutes("GlobalMastersAssociation/ProductFamilyCustomerAssociation/ProductFamilyCustomerAssociationByProcedure");
        public static readonly ServiceEndpointRoutes BusinessUnitWeekDay = new ServiceEndpointRoutes("GlobalMastersAssociation/ProductFamilyCustomerAssociation/BusinessUnitWeekDay");
        public static readonly ServiceEndpointRoutes UploadProductFamilyCustomerAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/ProductFamilyCustomerAssociation/UploadProductFamilyCustomerAssociation");
        // public static readonly ServiceEndpointRoutes CustomerDeliveryPointAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/api/SF.GlobalMastersAssociationCore.AssociationMasters/CustomerDeliveryPointAssociation");  //Commented By Prakhar
        public static readonly ServiceEndpointRoutes GetCustomerNameWithProjectGuid = new ServiceEndpointRoutes("GlobalMastersAssociation/ProjectEngineeringAssociation/CustomerNameWithProjectGuid");
        public static readonly ServiceEndpointRoutes GetCurrencyExchangeRateConversionAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/CurrencyExchangeRateConversionAssociation/GetCurrencyExchangeRateConversionAssociation");  //Added By Prakhar
        public static readonly ServiceEndpointRoutes GetCountryData = new ServiceEndpointRoutes("GlobalMastersAssociation/CurrencyExchangeRateConversionAssociation/GetCountryData"); //Added By Prakhar
        public static readonly ServiceEndpointRoutes ProcessOperationCurrencyExchangeRateConversionAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/CurrencyExchangeRateConversionAssociation/ProcessOperationCurrencyExchangeRateConversionAssociation"); //Added By Prakhar
        public static readonly ServiceEndpointRoutes GetCurrencyData = new ServiceEndpointRoutes("GlobalMastersAssociation/CurrencyExchangeRateConversionAssociation/GetCurrencyData"); //Added By Prakhar
        public static readonly ServiceEndpointRoutes GetAllCurrencyExchangeRateConversionAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/CurrencyExchangeRateConversionAssociation/GetAllCurrencyExchangeRateConversionAssociation"); //Added By Prakhar
        public static readonly ServiceEndpointRoutes GetAllCustomerDeliveryPointAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/CustomerDeliveryPointAssociation/GetAllCustomerDeliveryPointAssociation");  //Added By Prakhar
        public static readonly ServiceEndpointRoutes CustomerDeliveryPointAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/CustomerDeliveryPointAssociation/ProcessOperationCustomerDeliveryPointAssociation");  //Added By Prakhar
        public static readonly ServiceEndpointRoutes GetProcurementUnitBusinessUnitAssociation = new ServiceEndpointRoutes("GlobalMastersAssociation/CurrencyExchangeRateConversionAssociation/GetProcurementUnitBusinessUnitAssociation"); //Added By Prakhar
        public static readonly ServiceEndpointRoutes GetCustomerProductAndVehicle = new ServiceEndpointRoutes("GlobalMastersAssociation/ProductFamilyCustomerAssociation/GetCustomerProductAndVehicle"); //Added By Prakhar


    }
}
