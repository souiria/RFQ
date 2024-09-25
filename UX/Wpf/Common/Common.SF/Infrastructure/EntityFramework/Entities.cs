using Common.Core.Contracts.Models.Administration.Maintenance;
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.Core.Logging;
using Common.Core.Contracts.Models.Core.Notifications;
using Common.Core.Contracts.Models.Core.Security;
using Common.Core.Contracts.Models.Core.Settings;
using Common.Core.Contracts.Models.ETL.CPD;
using Common.Core.Contracts.Models.ETL.EMACS;
using Common.Core.Contracts.Models.ETL.Helpdesk;
using Common.Core.Contracts.Models.ETL.NPA;
using Common.Core.Contracts.Models.GlobalMasters;
using Common.Core.Contracts.Models.GlobalMastersAssociation;
using Common.Core.Contracts.Models.Procurement;
using Common.Core.Contracts.Models.Purchasing;
using Common.Core.Contracts.Models.Sales.AlternativePart;
using Common.Core.Contracts.Models.Sales.CAE;
using Common.Core.Contracts.Models.Sales.Dsi;
using Common.Core.Contracts.Models.Sales.DsiAssociation;
using Common.Core.Contracts.Models.Yokoten;
using Common.SF.Infrastructure.EntityFramework.Conventions;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Common.SF.Infrastructure.EntityFramework
{
    public class Entities : DbContext
    {
        public Entities() : base(DefaultConnectionStringHelper.DefaultConnectionString)
        {
            Database.SetInitializer<Entities>(null);
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300;
        }

        public Entities(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<Entities>(null);
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 300;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(c => c.IsUnicode(false));
            modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());

            #region Core
            modelBuilder.Entity<ErrorLogModel>().ToTable("ApplicationErrorLog", "dbo");
            modelBuilder.Entity<UXLanguageModel>().ToTable("UXLanguage", "dbo");
            modelBuilder.Entity<UXResourceLabelModel>().ToTable("UXResourceLabel", "dbo");
            //modelBuilder.Entity<UXRegionsModel>().ToTable("UXRegions", "dbo");
            //modelBuilder.Entity<SiteSecurityFilterModel>().ToTable("SiteSecurityFilter", "dbo");
            modelBuilder.Entity<H1ViewMasterModel>().ToTable("H1ViewMaster", "dbo");
            modelBuilder.Entity<H1ModuleMasterModel>().ToTable("H1ModuleMaster", "dbo");
            modelBuilder.Entity<H1ModuleH1ViewAssociationModel>().ToTable("H1ModuleH1ViewAssociation", "dbo");
            modelBuilder.Entity<H1FunctionMasterModel>().ToTable("H1FunctionMaster", "dbo");
            modelBuilder.Entity<H1FunctionH1ModuleAssociationModel>().ToTable("H1FunctionH1ModuleAssociation", "dbo");
            modelBuilder.Entity<HelpdeskApproval>().ToTable("Approvals", "dbo");
            modelBuilder.Entity<HelpdeskUserPreferences>().ToTable("userpreferences", "dbo");
            modelBuilder.Entity<HelpdeskCallLog>().ToTable("CallLog", "dbo");
            modelBuilder.Entity<AuditTrailModel>().ToTable("AuditTrail", "dbo");
            modelBuilder.Entity<NPRStageChangeLogModel>().ToTable("NPRStageChangeLog", "dbo");

            #endregion

            #region Global Masters
            modelBuilder.Entity<BusinessUnitModel>().ToTable("BusinessUnit", "dbo");
            modelBuilder.Entity<BusinessUnitTypeModel>().ToTable("BusinessUnitType", "dbo");
            modelBuilder.Entity<ContactModel>().ToTable("Contact", "dbo");
            modelBuilder.Entity<CustomerModel>().ToTable("Customer", "dbo");
            modelBuilder.Entity<ProjectModel>().ToTable("Project", "dbo");
            modelBuilder.Entity<SourceApplicationModel>().ToTable("SourceApplication", "dbo");
            modelBuilder.Entity<CountryModel>().ToTable("Country", "dbo");
            modelBuilder.Entity<CurrencyModel>().ToTable("Currency", "dbo");
            modelBuilder.Entity<UnitOfMeasureModel>().ToTable("UnitOfMeasure", "dbo");
            modelBuilder.Entity<ExchangeRateModel>().ToTable("ExchangeRate", "dbo");
            modelBuilder.Entity<IndexedMaterialModel>().ToTable("IndexedMaterial", "dbo");
            modelBuilder.Entity<TariffCodeModel>().ToTable("TariffCode", "dbo");
            modelBuilder.Entity<WireModel>().ToTable("Wire", "dbo");
            modelBuilder.Entity<PartModel>().ToTable("Part", "dbo");
            modelBuilder.Entity<MaterialTypeModel>().ToTable("MaterialType", "dbo");
            modelBuilder.Entity<MaterialModel>().ToTable("Material", "dbo");//.HasRequired(t => t.MaterialType).WithRequiredDependent() ;
            modelBuilder.Entity<CompositeModel>().ToTable("Composite", "dbo");
            modelBuilder.Entity<DerivativeModel>().ToTable("Derivative", "dbo");
            modelBuilder.Entity<VehicleModel>().ToTable("Vehicle", "dbo");
            modelBuilder.Entity<IncotermsModel>().ToTable("Incoterms", "dbo");
            modelBuilder.Entity<FacilityModel>().ToTable("Facility", "dbo");
            //Ajay: 19-Nov-2017
            //TODO: Integrate [Global Supplier] Service
            modelBuilder.Entity<SupplierModel>().ToTable("Supplier", "dbo");
            modelBuilder.Entity<MaterialSupplierModel>().ToTable("MaterialSupplier", "dbo");
            modelBuilder.Entity<SupplierGroupModel>().ToTable("SupplierGroup", "dbo");
            modelBuilder.Entity<SupplierTypeModel>().ToTable("SupplierType", "dbo");
            modelBuilder.Entity<SiteModel>().ToTable("Site", "dbo");
            modelBuilder.Entity<SiteTypeModel>().ToTable("SiteType", "dbo");
            modelBuilder.Entity<AgressoSupplierModel>().ToTable("AgressoSupplier", "dbo");
            modelBuilder.Entity<MaterialCostGroupModel>().ToTable("MaterialCostGroup", "dbo");
            modelBuilder.Entity<PaymentTermsModel>().ToTable("PayTerms", "dbo");
            //Added by Pawan [12-Dec-2017]
            modelBuilder.Entity<CommodityModel>().ToTable("Commodity", "dbo");
            modelBuilder.Entity<ForecastTypeModel>().ToTable("ForecastType", "dbo");
            modelBuilder.Entity<PackFormModel>().ToTable("PackForm", "dbo");
            modelBuilder.Entity<RatingConcernModel>().ToTable("RatingConcern", "dbo");
            modelBuilder.Entity<LogisticsConcernRaisedStatusModel>().ToTable("LogisticsConcernRaisedStatus", "dbo");
            modelBuilder.Entity<LogisticsConcernReasonModel>().ToTable("LogisticsConcernReason", "dbo");
            modelBuilder.Entity<H1ConfigurationSettingModel>().ToTable("H1ConfigurationSetting", "dbo");
            modelBuilder.Entity<H1ConfigurationKeyModel>().ToTable("H1ConfigurationKey", "dbo");
            modelBuilder.Entity<TransportationModeModel>().ToTable("TransportationMode", "dbo");
            modelBuilder.Entity<ApplicationArticleModel>().ToTable("ApplicationArticle", "dbo");
            modelBuilder.Entity<GIStoreModel>().ToTable("GIStore", "dbo");
            modelBuilder.Entity<ProcurementUnitModel>().ToTable("ProcurementUnit", "dbo");
            modelBuilder.Entity<ContactTypeModel>().ToTable("ContactType", "dbo");
            modelBuilder.Entity<OriginStatusModel>().ToTable("OriginStatus", "dbo");
            modelBuilder.Entity<CountryRegionsModel>().ToTable("CountryRegions", "dbo");
            modelBuilder.Entity<PurchasingOrganisationModel>().ToTable("PurchasingOrganisation", "dbo");
            #endregion

            #region Procurement
            modelBuilder.Entity<ProcurementProcessCounterSettingModel>().ToTable("ProcurementProcessCounterSetting", "dbo");
            modelBuilder.Entity<ProcurementProcessCounterDetailModel>().ToTable("ProcurementProcessCounterDetail", "dbo");
            modelBuilder.Entity<ProcurementProcessPrefixSettingModel>().ToTable("ProcurementProcessPrefixSetting", "dbo");
            #endregion

            #region Global Masters Association
            modelBuilder.Entity<SupplierAssociationModel>().ToTable("SupplierAssociation", "dbo");
            modelBuilder.Entity<MaterialAssociationModel>().ToTable("MaterialAssociation", "dbo");

            modelBuilder.Entity<SupplierMaterialAssociationModel>().ToTable("SupplierMaterialAssociation", "dbo");
            modelBuilder.Entity<UnitOfMeasureAssociationModel>().ToTable("UnitOfMeasureAssociation", "dbo");
            modelBuilder.Entity<CountryRegionsAssociationModel>().ToTable("CountryRegionsAssociation", "dbo");
            modelBuilder.Entity<SourceApplicationArticleAssociationModel>().ToTable("SourceApplicationArticleAssociation", "dbo");
            modelBuilder.Entity<ProcurementUnitBusinessUnitAssociationModel>().ToTable("ProcurementUnitBusinessUnitAssociation", "dbo");
            modelBuilder.Entity<BusinessUnitGIStoreAssociationModel>().ToTable("BusinessUnitGIStoreAssociation", "dbo");
            modelBuilder.Entity<CurrencyExchangeRateAssociationModel>().ToTable("CurrencyExchangeRateAssociation", "dbo");
            modelBuilder.Entity<PurchasingOrganisationProcurementAssociationModel>().ToTable("PurchasingOrganisationProcurementAssociation", "dbo");
            #endregion

            #region Purchasing
            modelBuilder.Entity<PurchasingCommodityModel>().ToTable("PurchasingCommodity", "dbo");
            modelBuilder.Entity<PurchasingMaterialModel>().ToTable("PurchasingMaterial", "dbo");
            modelBuilder.Entity<PurchasingSupplierModel>().ToTable("PurchasingSupplier", "dbo");
            modelBuilder.Entity<PurchasingSupplierMaterialModel>().ToTable("PurchasingSupplierMaterial", "dbo");
            modelBuilder.Entity<SupplierMaterialPOPricingModel>().ToTable("SupplierMaterialPOPricing", "dbo");
            modelBuilder.Entity<POPriceTypeModel>().ToTable("POPriceType", "dbo");
            modelBuilder.Entity<SupplierDevelopmentTeamModel>().ToTable("SupplierDevelopmentTeam", "dbo");
            modelBuilder.Entity<EPOCommodityGroupModel>().ToTable("EPOCommodityGroup", "dbo");
            modelBuilder.Entity<POPriceEffectiveDateTypeModel>().ToTable("POPriceEffectiveDateType", "dbo");
            modelBuilder.Entity<MaterialOriginModel>().ToTable("MaterialOrigin", "dbo");
            modelBuilder.Entity<SupplierSelectionModel>().ToTable("SupplierSelection", "dbo");
            modelBuilder.Entity<MaterialInventoryModel>().ToTable("MaterialInventory", "dbo");
            modelBuilder.Entity<ForecastAnnualBySiteModel>().ToTable("ForecastAnnualBySite", "dbo");
            modelBuilder.Entity<FirstReceiptDateModel>().ToTable("FirstReceiptDate", "dbo");
            modelBuilder.Entity<PurchasingArticleSynchronizationModel>().ToTable("PurchasingArticleSynchronization", "dbo");
            modelBuilder.Entity<CPDForecastAnnualBySiteModel>().ToTable("fc_annual_mst", "dbo");
            modelBuilder.Entity<CPDForecastAnnualBySiteModel>().HasKey((it) => new { it.Section_c, it.supplier_c, it.material_no, it.Month_Year_ID, it.customer_nm, it.vehicle_nm, it.facility_nm });
            modelBuilder.Entity<CPDMaterialInventoryModel>().ToTable("invt_mst", "dbo");
            modelBuilder.Entity<CPDMaterialInventoryModel>().HasKey((it) => new { it.section_c, it.material_no });
            modelBuilder.Entity<CPDFirstReceiptModel>().ToTable("first_Receipt", "dbo");
            modelBuilder.Entity<CPDFirstReceiptModel>().HasKey((it) => new { it.section_c, it.supplier_c, it.material_no });
            modelBuilder.Entity<CPDToH1MaterialModel>().ToTable("material_mst", "dbo");
            modelBuilder.Entity<CPDToH1MaterialModel>().HasKey((it) => new { it.material_no });
            modelBuilder.Entity<CPDToH1MaterialSiteModel>().ToTable("matsite_mst", "dbo");
            modelBuilder.Entity<CPDToH1MaterialSiteModel>().HasKey((it) => new { it.material_no, it.section_c, it.supplier_c });
            modelBuilder.Entity<PurchasingArticleJobSchedulerModel>().ToTable("PurchasingArticleJobScheduler", "dbo");
            modelBuilder.Entity<PurchasingArticleJobDetailsModel>().ToTable("PurchasingArticleJobDetails", "dbo");
            modelBuilder.Entity<BusinessUnitArticleSynchronizationModel>().ToTable("BusinessUnitArticleSynchronization", "dbo");
            #endregion

            #region SystemAdmin
            //modelBuilder.Entity<UserListModel>().ToTable("UserList", "dbo");
            //modelBuilder.Entity<ServiceDataFilterModel>().ToTable("ServiceDataFilter", "dbo");
            modelBuilder.Entity<H1ServiceConfigurationSettingModel>().ToTable("H1ServiceConfigurationSetting", "dbo");
            //modelBuilder.Entity<AdGroupLanguageKey>().ToTable("ApplicationMenu", "dbo");
            #endregion

            #region ETL
            #region EMACS
            modelBuilder.Entity<BUBANMModel>().ToTable("BUBANM", "dbo");
            modelBuilder.Entity<EMACSDataNoConvModel>().ToTable("EMACSDataNoConv", "dbo");
            modelBuilder.Entity<EMACSSupplierNoXrefModel>().ToTable("EmacsSupplierNoXref", "dbo");
            modelBuilder.Entity<PARTMSModel>().ToTable("PARTMS", "dbo");
            modelBuilder.Entity<CustomerDataModel>().ToTable("CustomerData", "dbo");
            #endregion
            #region CPD
            modelBuilder.Entity<InterfaceWHCPDMastersMaterialOriginModel>().ToTable("Interface_WH_CPD_Masters_Material_Origin", "dbo");
            modelBuilder.Entity<InterfaceWHCPDMastersMaterialSupplierModel>().ToTable("Interface_WH_CPD_Masters_Material_Supplier", "dbo");
            #endregion
            #region NPA
            modelBuilder.Entity<InterfaceWHNPAMaterialPriceModel>().ToTable("Interface_WH_NPA_Material_Price", "dbo");
            modelBuilder.Entity<NPACustomerModel>().ToTable("NPACustomer", "dbo");
            modelBuilder.Entity<NPASupplierModel>().ToTable("NPASupplier", "dbo");
            modelBuilder.Entity<VWMassNPAFromRFQModel>().ToTable("VW_MassNPA_from_RFQ", "dbo");
            #endregion
            #endregion

            #region Sales
            #region Dsi
            modelBuilder.Entity<BendModel>().ToTable("Bend", "dbo");
            modelBuilder.Entity<BranchConfigurationModel>().ToTable("BranchConfiguration", "dbo");
            modelBuilder.Entity<BranchInsulationModel>().ToTable("BranchInsulation", "dbo");
            modelBuilder.Entity<BranchInsulationThroughNodeModel>().ToTable("BranchInsulationThroughNode", "dbo");
            modelBuilder.Entity<CavityMappingModel>().ToTable("CavityMapping", "dbo");
            modelBuilder.Entity<CentreStripModel>().ToTable("CentreStrip", "dbo");
            modelBuilder.Entity<CircuitOptionModel>().ToTable("CircuitOption", "dbo");
            modelBuilder.Entity<ComponentModel>().ToTable("Component", "dbo");
            modelBuilder.Entity<CompositeDetailModel>().ToTable("CompositeDetail", "dbo");
            modelBuilder.Entity<CompositeOptionModel>().ToTable("CompositeOption", "dbo");
            modelBuilder.Entity<HarnessModel>().ToTable("Harness", "dbo");
            modelBuilder.Entity<HarnessScopeModel>().ToTable("HarnessScope", "dbo");
            modelBuilder.Entity<ManualBomQuantityModel>().ToTable("ManualBomQuantity", "dbo");
            modelBuilder.Entity<MidWireComponentModel>().ToTable("MidWireComponent", "dbo");
            modelBuilder.Entity<ModuleChildDetailModel>().ToTable("ModuleChildDetail", "dbo");
            modelBuilder.Entity<ModuleCompatibilityModel>().ToTable("ModuleCompatibility", "dbo");
            modelBuilder.Entity<MulticoreSpecificationModel>().ToTable("MulticoreSpecification", "dbo");
            modelBuilder.Entity<PinMappingModel>().ToTable("PinMapping", "dbo");
            modelBuilder.Entity<ScopeModel>().ToTable("Scope", "dbo");
            modelBuilder.Entity<WireMulticoreMarkerModel>().ToTable("WireMulticoreMarker", "dbo");
            modelBuilder.Entity<WireSpecificationModel>().ToTable("WireSpecification", "dbo");
            modelBuilder.Entity<WireThroughNodeModel>().ToTable("WireThroughNode", "dbo");
            #endregion
            #region DsiAssociation
            modelBuilder.Entity<BranchConfigurationBendAssociationModel>().ToTable("BranchConfigurationBendAssociation", "dbo");
            modelBuilder.Entity<CompositeDetailCircuitOptionAssociationModel>().ToTable("CompositeDetailCircuitOptionAssociation", "dbo");
            modelBuilder.Entity<HarnessScopeScopeAssociationModel>().ToTable("HarnessScopeScopeAssociation", "dbo");
            modelBuilder.Entity<PinMappingCavityMappingAssociationModel>().ToTable("PinMappingCavityMappingAssociation", "dbo");
            #endregion
            #region AlternativeParts
            modelBuilder.Entity<PartGroupConstModel>().ToTable("PartGroupsConst", "dbo");
            modelBuilder.Entity<PartCategoryDetailModel>().ToTable("PartCategoryDetail", "dbo");
            modelBuilder.Entity<PartClassDetailModel>().ToTable("PartClassDetail", "dbo");
            modelBuilder.Entity<PartColourCode>().ToTable("ColourCode", "dbo");
            modelBuilder.Entity<MaterialGroups>().ToTable("MaterialGroups", "dbo");
            modelBuilder.Entity<MaterialTypes>().ToTable("MaterialTypes", "dbo");
            #region CAE for VAVE
            modelBuilder.Entity<JH1_0_CommonData>().ToTable("JH1_0_CommonData", "data");
            modelBuilder.Entity<JH1_06_SplicePositions>().ToTable("JH1_6_SplicePositions", "data");
            modelBuilder.Entity<JH1_07_SpliceAttachments>().ToTable("JH1_7_SpliceAttachments", "data");
            modelBuilder.Entity<JH1_08_Terminals>().ToTable("JH1_8_Terminals", "data");
            modelBuilder.Entity<JH1_09_TerminalAttachments>().ToTable("JH1_9_TerminalAttachments", "data");
            modelBuilder.Entity<JH1_10_LeadParts>().ToTable("JH1_10_LeadParts", "data");
            modelBuilder.Entity<JH1_11_BranchParts>().ToTable("JH1_11_BranchParts", "data");
            modelBuilder.Entity<JH1_12_BranchAttachments>().ToTable("JH1_12_BranchAttachments", "data");
            modelBuilder.Entity<JH1_13_Connectors>().ToTable("JH1_13_Connectors", "data");
            modelBuilder.Entity<JH1_14_ConnectorAttachments>().ToTable("JH1_14_ConnectorAttachments", "data");
            modelBuilder.Entity<JH1_15_NodeParts>().ToTable("JH1_15_NodeParts", "data");
            modelBuilder.Entity<JH1_16_NodeAttachments>().ToTable("JH1_16_NodeAttachments", "data");
            modelBuilder.Entity<JH1_17_OptionTaping>().ToTable("JH1_17_OptionTaping", "data");
            modelBuilder.Entity<JH1_18_HarnessAttachment>().ToTable("JH1_18_HarnessAttachment", "data");
            #endregion
            #endregion
            #endregion
        }

        #region Core
        public virtual DbSet<H1ViewMasterModel> H1ViewMasterItems { get; set; }
        public virtual DbSet<H1ModuleMasterModel> H1ModuleMasterItems { get; set; }
        public virtual DbSet<H1ModuleH1ViewAssociationModel> H1ModuleH1ViewAssociationItems { get; set; }
        public virtual DbSet<H1FunctionMasterModel> H1FunctionMasterItems { get; set; }
        public virtual DbSet<H1FunctionH1ModuleAssociationModel> H1FunctionH1ModuleAssociationItems { get; set; }
        public virtual DbSet<ErrorLogModel> ErrorLogItems { get; set; }
        public virtual DbSet<UXLanguageModel> UXLanguageItems { get; set; }
        //public virtual DbSet<UXRegionsModel> UXRegionsItems { get; set; }
        public virtual DbSet<UXResourceLabelModel> UXResourceLabelItems { get; set; }
        public virtual DbSet<HelpdeskApproval> HelpdeskApprovals { get; set; }
        public virtual DbSet<HelpdeskUserPreferences> HelpdeskUserPreferences { get; set; }
        public virtual DbSet<AuditTrailModel> AuditTrailItems { get; set; }
        #endregion

        #region Global Masters
        public virtual DbSet<CountryModel> CountryItems { get; set; }
        public virtual DbSet<BusinessUnitModel> BusinessUnitItems { get; set; }
        public virtual DbSet<BusinessUnitTypeModel> BusinessUnitTypeItems { get; set; }
        public virtual DbSet<ContactModel> ContactItems { get; set; }
        public virtual DbSet<CustomerModel> CustomerItems { get; set; }
        public virtual DbSet<ProjectModel> ProjectItems { get; set; }
        public virtual DbSet<SourceApplicationModel> SourceApplicationItems { get; set; }
        public virtual DbSet<CurrencyModel> CurrencyItems { get; set; }
        public virtual DbSet<UnitOfMeasureModel> UnitOfMeasureItems { get; set; }
        public virtual DbSet<ExchangeRateModel> ExchangeRateItems { get; set; }
        public virtual DbSet<IndexedMaterialModel> IndexedMaterialItems { get; set; }
        public virtual DbSet<TariffCodeModel> TariffCodeItems { get; set; }
        public virtual DbSet<WireModel> WireItems { get; set; }
        public virtual DbSet<PartModel> PartItems { get; set; }
        public virtual DbSet<MaterialTypeModel> MaterialTypeItems { get; set; }
        public virtual DbSet<CompositeModel> CompositeItems { get; set; }
        public virtual DbSet<DerivativeModel> DerivativeItems { get; set; }
        public virtual DbSet<MaterialModel> MaterialItems { get; set; }
        public virtual DbSet<VehicleModel> VehicleItems { get; set; }
        public virtual DbSet<IncotermsModel> IncotermsItems { get; set; }
        public virtual DbSet<FacilityModel> FacilityItems { get; set; }
        public virtual DbSet<Notification> NotificationItems { get; set; }
        public virtual DbSet<SupplierModel> SupplierItems { get; set; }
        public virtual DbSet<MaterialSupplierModel> MaterialSupplierItems { get; set; }
        public virtual DbSet<SupplierGroupModel> SupplierGroupItems { get; set; }
        public virtual DbSet<SupplierTypeModel> SupplierTypeItems { get; set; }
        public virtual DbSet<SiteTypeModel> SiteTypeItems { get; set; }
        public virtual DbSet<SiteModel> SiteItems { get; set; }
        public virtual DbSet<AgressoSupplierModel> AgressoSupplierItems { get; set; }
        public virtual DbSet<MaterialCostGroupModel> MaterialCostGroupItems { get; set; }
        public virtual DbSet<PaymentTermsModel> PaymentTermsItems { get; set; }
        //Added by Pawan [12-Dec-2017]
        public virtual DbSet<CommodityModel> CommodityItems { get; set; }
        public virtual DbSet<ForecastTypeModel> ForecastTypeItems { get; set; }
        public virtual DbSet<PackFormModel> PackFormItems { get; set; }
        //public virtual DbSet<POPriceEffectiveModel> POPriceEffectiveItems { get; set; }
        public virtual DbSet<RatingConcernModel> RatingConcernItems { get; set; }
        //public virtual DbSet<SiteSecurityFilterModel> SiteSecurityFilterItems { get; set; }
        public virtual DbSet<LogisticsConcernRaisedStatusModel> LogisticsConcernRaisedStatusItems { get; set; }
        public virtual DbSet<LogisticsConcernReasonModel> LogisticsConcernReasonItems { get; set; }
        public virtual DbSet<H1ConfigurationSettingModel> H1ConfigurationSettingItems { get; set; }
        public virtual DbSet<H1ConfigurationKeyModel> H1ConfigurationKeyItems { get; set; }
        public virtual DbSet<TransportationModeModel> TransportationModeItems { get; set; }
        public virtual DbSet<ApplicationArticleModel> ApplicationArticleItems { get; set; }
        public virtual DbSet<GIStoreModel> GIStoreItems { get; set; }
        public virtual DbSet<ProcurementUnitModel> ProcurementUnitItems { get; set; }
        public virtual DbSet<ContactTypeModel> ContactTypeItems { get; set; }
        public virtual DbSet<OriginStatusModel> OriginStatusItems { get; set; }
        public virtual DbSet<PurchasingOrganisationModel> PurchasingOrganisationItems { get; set; }
        #endregion

        #region Global Masters Association
        public virtual DbSet<SupplierAssociationModel> SupplierAssociationItems { get; set; }
        public virtual DbSet<SupplierMaterialAssociationModel> SupplierMaterialAssociationItems { get; set; }
        public virtual DbSet<UnitOfMeasureAssociationModel> UnitOfMeasureAssociationItems { get; set; }
        public virtual DbSet<MaterialAssociationModel> MaterialAssociationItems { get; set; }
        public virtual DbSet<CountryRegionsAssociationModel> CountryRegionsAssociationItems { get; set; }
        public virtual DbSet<SourceApplicationArticleAssociationModel> SourceApplicationArticleAssociationItems { get; set; }
        public virtual DbSet<ProcurementUnitBusinessUnitAssociationModel> ProcurementUnitBusinessUnitAssociationItems { get; set; }
        public virtual DbSet<BusinessUnitGIStoreAssociationModel> BusinessUnitGIStoreAssociationItems { get; set; }
        public virtual DbSet<CurrencyExchangeRateAssociationModel> CurrencyExchangeRateAssociationItems { get; set; }
        #endregion

        #region Procurement
        public virtual DbSet<ProcurementProcessCounterSettingModel> ProcurementProcessCounterSettingItems { get; set; }
        public virtual DbSet<ProcurementProcessCounterDetailModel> ProcurementProcessCounterDetailItems { get; set; }
        public virtual DbSet<ProcurementProcessPrefixSettingModel> ProcurementProcessPrefixSettingItems { get; set; }
        #endregion

        #region Purchasing
        public virtual DbSet<PurchasingCommodityModel> PurchasingCommodityItems { get; set; }
        public virtual DbSet<PurchasingMaterialModel> PurchasingMaterialItems { get; set; }
        public virtual DbSet<PurchasingSupplierModel> PurchasingSupplierItems { get; set; }
        public virtual DbSet<PurchasingSupplierMaterialModel> PurchasingSupplierMaterialItems { get; set; }
        public virtual DbSet<SupplierMaterialPOPricingModel> SupplierMaterialPOPricingItems { get; set; }
        public virtual DbSet<POPriceTypeModel> POPriceTypeItems { get; set; }
        public virtual DbSet<SupplierDevelopmentTeamModel> SupplierDevelopmentTeamItems { get; set; }
        public virtual DbSet<EPOCommodityGroupModel> EPOCommodityGroupItems { get; set; }
        public virtual DbSet<POPriceEffectiveDateTypeModel> POPriceEffectiveDateTypeItems { get; set; }
        public virtual DbSet<MaterialOriginModel> MaterialOriginItems { get; set; }
        public virtual DbSet<SupplierSelectionModel> SupplierSelectionItems { get; set; }
        public virtual DbSet<MaterialInventoryModel> MaterialInventoryItems { get; set; }
        public virtual DbSet<ForecastAnnualBySiteModel> ForecastAnnualBySiteItems { get; set; }
        public virtual DbSet<FirstReceiptDateModel> FirstReceiptDateItems { get; set; }
        public virtual DbSet<PurchasingArticleSynchronizationModel> PurchasingArticleSynchronizationItems { get; set; }
        public virtual DbSet<CPDForecastAnnualBySiteModel> CPDForecastAnnualBySiteItems { get; set; }
        public virtual DbSet<CPDMaterialInventoryModel> CPDMaterialInventoryItems { get; set; }
        public virtual DbSet<CPDFirstReceiptModel> CPDFirstReceiptItems { get; set; }
        public virtual DbSet<CPDToH1MaterialModel> CPDToH1MaterialItems { get; set; }
        public virtual DbSet<CPDToH1MaterialSiteModel> CPDToH1MaterialSiteItems { get; set; }

        public virtual DbSet<PurchasingArticleJobSchedulerModel> PurchasingArticleJobSchedulerItems { get; set; }
        public virtual DbSet<PurchasingArticleJobDetailsModel> PurchasingArticleJobDetailsItems { get; set; }
        public virtual DbSet<BusinessUnitArticleSynchronizationModel> BusinessUnitArticleSynchronizationItems { get; set; }
        #endregion

        #region SystemAdmin
        //public virtual DbSet<UserListModel> H1SecurityUserListModelItems { get; set; }
        //public virtual DbSet<ServiceDataFilterModel> ServiceDataFilterModelItems { get; set; }
        public virtual DbSet<H1ServiceConfigurationSettingModel> H1ServiceConfigurationSettingItems { get; set; }
        #endregion

        #region ETL
        #region EMACS
        public virtual DbSet<BUBANMModel> BUBANM { get; set; }
        public virtual DbSet<EMACSDataNoConvModel> EMACSDataNoConv { get; set; }
        public virtual DbSet<EMACSSupplierNoXrefModel> EMACSSupplierNoXref { get; set; }
        public virtual DbSet<PARTMSModel> PARTMS { get; set; }
        public virtual DbSet<CustomerDataModel> CustomerData { get; set; }
        #endregion
        #region CPD
        public virtual DbSet<InterfaceWHCPDMastersMaterialOriginModel> InterfaceWHCPDMastersMaterialOrigin { get; set; }
        public virtual DbSet<InterfaceWHCPDMastersMaterialSupplierModel> InterfaceWHCPDMastersMaterialSupplier { get; set; }
        #endregion
        #region NPA
        public virtual DbSet<InterfaceWHNPAMaterialPriceModel> InterfaceWHNPAMaterialPrice { get; set; }
        public virtual DbSet<NPACustomerModel> NPACustomer { get; set; }
        public virtual DbSet<NPASupplierModel> NPASupplier { get; set; }
        public virtual DbSet<VWMassNPAFromRFQModel> VWMassNPAFromRFQ { get; set; }
        #endregion
        #endregion

        #region Sales
        #region Enquiry
        #endregion
        #region Dsi
        public virtual DbSet<BendModel> Bend { get; set; }
        public virtual DbSet<BranchConfigurationModel> BranchConfiguration { get; set; }
        public virtual DbSet<BranchInsulationModel> BranchInsulation { get; set; }
        public virtual DbSet<BranchInsulationThroughNodeModel> BranchInsulationThroughNode { get; set; }
        public virtual DbSet<CavityMappingModel> CavityMapping { get; set; }
        public virtual DbSet<CentreStripModel> CentreStrip { get; set; }
        public virtual DbSet<CircuitOptionModel> CircuitOption { get; set; }
        public virtual DbSet<ComponentModel> Component { get; set; }
        public virtual DbSet<CompositeDetailModel> CompositeDetail { get; set; }
        public virtual DbSet<CompositeOptionModel> CompositeOption { get; set; }
        public virtual DbSet<HarnessModel> Harness { get; set; }
        public virtual DbSet<HarnessScopeModel> HarnessScope { get; set; }
        public virtual DbSet<ManualBomQuantityModel> ManualBomQuantity { get; set; }
        public virtual DbSet<MidWireComponentModel> MidWireComponent { get; set; }
        public virtual DbSet<ModuleChildDetailModel> ModuleChildDetail { get; set; }
        public virtual DbSet<ModuleCompatibilityModel> ModuleCompatibility { get; set; }
        public virtual DbSet<MulticoreSpecificationModel> MulticoreSpecification { get; set; }
        public virtual DbSet<PinMappingModel> PinMapping { get; set; }
        public virtual DbSet<ScopeModel> Scope { get; set; }
        public virtual DbSet<WireMulticoreMarkerModel> WireMulticoreMarker { get; set; }
        public virtual DbSet<WireSpecificationModel> WireSpecification { get; set; }
        public virtual DbSet<WireThroughNodeModel> WireThroughNode { get; set; }
        #endregion
        #region DsiAssociation
        public virtual DbSet<BranchConfigurationBendAssociationModel> BranchConfigurationBendAssociation { get; set; }
        public virtual DbSet<CompositeDetailCircuitOptionAssociationModel> CompositeDetailCircuitOptionAssociation { get; set; }
        public virtual DbSet<HarnessScopeScopeAssociationModel> HarnessScopeScopeAssociation { get; set; }
        public virtual DbSet<PinMappingCavityMappingAssociationModel> PinMappingCavityMappingAssociation { get; set; }
        #endregion
        #region AlternativeParts
        public virtual DbSet<MaterialGroups> MaterialGroups { get; set; }
        public virtual DbSet<MaterialTypes> MaterialTypes { get; set; }
        public virtual DbSet<PartCategoryDetailModel> PartCategoryDetail { get; set; }
        public virtual DbSet<PartClassDetailModel> PartClassDetail { get; set; }
        public virtual DbSet<PartGroupConstModel> PartGroupConst { get; set; }
        public virtual DbSet<PartColourCode> PartColourCode { get; set; }
        public virtual DbSet<JH1_0_CommonData> JH1_0_CommonData { get; set; }
        public virtual DbSet<JH1_06_SplicePositions> JH1_06_SplicePositions { get; set; }
        public virtual DbSet<JH1_07_SpliceAttachments> JH1_07_SpliceAttachments { get; set; }
        public virtual DbSet<JH1_08_Terminals> JH1_08_Terminals { get; set; }
        public virtual DbSet<JH1_09_TerminalAttachments> JH1_09_TerminalAttachments { get; set; }
        public virtual DbSet<JH1_10_LeadParts> JH1_10_LeadParts { get; set; }
        public virtual DbSet<JH1_11_BranchParts> JH1_11_BranchParts { get; set; }
        public virtual DbSet<JH1_12_BranchAttachments> JH1_12_BranchAttachments { get; set; }
        public virtual DbSet<JH1_13_Connectors> JH1_13_Connectors { get; set; }
        public virtual DbSet<JH1_14_ConnectorAttachments> JH1_14_ConnectorAttachments { get; set; }
        public virtual DbSet<JH1_15_NodeParts> JH1_15_NodeParts { get; set; }
        public virtual DbSet<JH1_16_NodeAttachments> JH1_16_NodeAttachments { get; set; }
        public virtual DbSet<JH1_17_OptionTaping> JH1_17_OptionTaping { get; set; }
        public virtual DbSet<JH1_18_HarnessAttachment> JH1_18_HarnessAttachment { get; set; }

        #endregion
        #endregion

        private ObjectContext _ObjectContext
        {
            get { return (this as IObjectContextAdapter).ObjectContext; }
        }


        public IEnumerable<EntitySetBase> GetEntitySet()
        {
            ObjectContext octx = _ObjectContext;
            var es = octx.MetadataWorkspace
                            .GetItemCollection(DataSpace.SSpace)
                            .GetItems<EntityContainer>()
                            .SelectMany(c => c.BaseEntitySets);
            return es;
        }
    }
}

