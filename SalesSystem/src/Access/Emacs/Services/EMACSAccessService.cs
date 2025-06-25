namespace Emacs.Services
{
    public class EMACSAccessService : IEMACSAccessService
    {
        #region In Memory Datasets

        #region CombinedParts

        ListCombinedPartsData _ListCombinedParts;

        #endregion

        #region PartCategoryDetail

        ListPartCategoryDetailData _ListPartCatogoryDetail;
        ListPartCategoryDetailData _FilteredListPartCatogoryDetail;

        #endregion

        #region PartClassDetail

        ListPartClassDetailData _ListPartClassDetail;
        ListPartClassDetailData _FilteredListPartClassDetail;

        #endregion

        #region PartGroups

        ListPartGroupsData _ListPartGroups;
        ListPartGroupsData _FilteredListPartGroups;

        #endregion

        #region PartGroupsConst

        ListPartGroupsConstData _ListPartGroupsConst;
        ListPartGroupsConstData _FilteredListPartGroupsConst;

        #endregion

        #region CustomerData

        ListCustomerDataGrpc _ListCustomerData;

        #endregion

        #region ColourCode

        ListColourCodeData _ListColourCode;
        ListColourCodeData _FilteredListColourCode;

        #endregion

        #region MaterialGroups

        ListMaterialGroupsData _ListMaterialGroups;
        ListMaterialGroupsData _FilteredListMaterialGroups;

        #endregion

        #region MaterialTypes

        ListMaterialTypesData _ListMaterialTypes;
        ListMaterialTypesData _FilteredListMaterialTypes;

        #endregion

        #region NPACustomer

        ListNPACustomerData _ListNPACustomer;

        #endregion

        #region NPASupplier

        ListNPASupplierData _ListNPASupplier;

        #endregion

        #region Suppliers

        ListSuppliersData _ListSuppliers;

        #endregion

        #region EmacsRFIView

        ListEmacsRFIViewData _ListEmacsRFIView;

        #endregion

        #region PARTMS

        ListPARTMSData _ListPARTMS;
        ListPARTMSData _FilteredListPARTMS;

        #endregion

        #endregion

        #region Fields and Properties

        #region CombinedParts

        IQueryHandler<GetCombinedPartsQuery, List<CombinedPartsData>>? _CombinedPartsHandler;
        bool _CombinedPartsRefreshInProgress;

        #endregion

        #region PartCatogoryDetail

        IQueryHandler<GetPartCatogoryDetailQuery, List<PartCategoryDetailData>>? _PartCatogoryDetailHandler;
        bool _PartCatogoryDetailRefreshInProgress;

        #endregion

        #region PartClassDetail

        IQueryHandler<GetPartClassDetailQuery, List<PartClassDetailData>>? _PartClassDetailHandler;
        bool _PartClassDetailRefreshInProgress;

        #endregion

        #region PartGroups

        IQueryHandler<GetPartGroupsQuery, List<PartGroupsData>>? _PartGroupsHandler;
        bool _PartGroupsRefreshInProgress;

        #endregion

        #region PartGroupsConst

        IQueryHandler<GetPartGroupsConstQuery, List<PartGroupsConstData>>? _PartGroupsConstHandler;
        bool _PartGroupsConstRefreshInProgress;

        #endregion

        #region CustomerData

        IQueryHandler<GetCustomerDataQuery, List<CustomerDataGrpc>>? _CustomerDataHandler;
        bool _CustomerDataRefreshInProgress;

        #endregion

        #region ColourCode

        IQueryHandler<GetColourCodeQuery, List<ColourCodeData>>? _ColourCodeHandler;
        bool _ColourCodeRefreshInProgress;

        #endregion

        #region MaterialGroups

        IQueryHandler<GetMaterialGroupsQuery, List<MaterialGroupsData>>? _MaterialGroupsHandler;
        bool _MaterialGroupsRefreshInProgress;

        #endregion

        #region MaterialTypes

        IQueryHandler<GetMaterialTypesQuery, List<MaterialTypesData>>? _MaterialTypesHandler;
        bool _MaterialTypesRefreshInProgress;

        #endregion

        #region NPACustomer

        IQueryHandler<GetNPACustomerQuery, List<NPACustomerData>>? _NPACustomerHandler;
        bool _NPACustomerRefreshInProgress;

        #endregion

        #region NPASupplier

        IQueryHandler<GetNPASupplierQuery, List<NPASupplierData>>? _NPASupplierHandler;
        bool _NPASupplierRefreshInProgress;

        #endregion

        #region Suppliers

        IQueryHandler<GetSuppliersQuery, List<SuppliersData>>? _SuppliersHandler;
        bool _SuppliersRefreshInProgress;

        #endregion

        #region EmacsRFIView

        IQueryHandler<GetEmacsRFIViewQuery, List<EmacsRFIViewData>>? _EmacsRFIViewHandler;
        bool _EmacsRFIViewRefreshInProgress;

        #endregion

        #region PARTMS

        IQueryHandler<GetPARTMSQuery, List<PARTMSData>>? _PARTMSHandler;
        bool _PARTMSRefreshInProgress;

        #endregion

        readonly IServiceProvider _ServiceProvider;
        #endregion

        #region Constructor
        public EMACSAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            #region CombinedParts

            _ListCombinedParts = new ListCombinedPartsData();
            _CombinedPartsRefreshInProgress = false;

            #endregion

            #region PartCatogoryDetail

            _ListPartCatogoryDetail = new ListPartCategoryDetailData();
            _FilteredListPartCatogoryDetail = new ListPartCategoryDetailData();
            _PartCatogoryDetailRefreshInProgress = false;

            #endregion

            #region PartClassDetail

            _ListPartClassDetail = new ListPartClassDetailData();
            _FilteredListPartClassDetail = new ListPartClassDetailData();
            _PartClassDetailRefreshInProgress = false;

            #endregion

            #region PartGroups

            _ListPartGroups = new ListPartGroupsData();
            _FilteredListPartGroups = new ListPartGroupsData();
            _PartGroupsRefreshInProgress = false;

            #endregion

            #region PartGroupsConst

            _ListPartGroupsConst = new ListPartGroupsConstData();
            _FilteredListPartGroupsConst = new ListPartGroupsConstData();
            _PartGroupsConstRefreshInProgress = false;

            #endregion

            #region CustomerData

            _ListCustomerData = new ListCustomerDataGrpc();
            _CustomerDataRefreshInProgress = false;

            #endregion

            #region ColourCode

            _ListColourCode = new ListColourCodeData();
            _FilteredListColourCode = new ListColourCodeData();
            _ColourCodeRefreshInProgress = false;

            #endregion

            #region MaterialGroups

            _ListMaterialGroups = new ListMaterialGroupsData();
            _FilteredListMaterialGroups = new ListMaterialGroupsData();
            _MaterialGroupsRefreshInProgress = false;

            #endregion

            #region MaterialTypes

            _ListMaterialTypes = new ListMaterialTypesData();
            _FilteredListMaterialTypes = new ListMaterialTypesData();
            _MaterialTypesRefreshInProgress = false;

            #endregion

            #region NPACustomer

            _ListNPACustomer = new ListNPACustomerData();
            _NPACustomerRefreshInProgress = false;

            #endregion

            #region NPASupplier

            _ListNPASupplier = new ListNPASupplierData();
            _NPASupplierRefreshInProgress = false;

            #endregion

            #region Suppliers

            _ListSuppliers = new ListSuppliersData();
            _SuppliersRefreshInProgress = false;

            #endregion

            #region EmacsRFIView

            _ListEmacsRFIView = new ListEmacsRFIViewData();
            _EmacsRFIViewRefreshInProgress = false;

            #endregion

            #region PARTMS

            //_PARTMSData = [];
            _ListPARTMS = new ListPARTMSData();
            _FilteredListPARTMS = new ListPARTMSData();
            _PARTMSRefreshInProgress = false;

            #endregion

            _ServiceProvider = serviceProvider;

            if (testing)
            {
                PopulateSampleData();
            }
        }
        #endregion

        #region Handlers

        #region CombinedParts
        public async Task<ListCombinedPartsData> GetAllCombinedParts(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListCombinedParts.CombinedPartsData.Any())
            {
                return _ListCombinedParts;
            }
            else
            {
                await PopulateCombinedPartsAsync(cancellationToken);
                return _ListCombinedParts;
            }
        }

        public async Task<Result<int>> GetCombinedPartsDataCount(CancellationToken cancellationToken)
        {
            if (_ListCombinedParts.CombinedPartsData.Any())
            {
                return _ListCombinedParts.CombinedPartsData.Count;
            }
            else
            {
                await PopulateCombinedPartsAsync(cancellationToken);
                return _ListCombinedParts.CombinedPartsData.Count;
            }
        }

        #endregion

        #region PartCategoryDetail

        public async Task<ListPartCategoryDetailData> GetAllPartCategoryDetail(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartCatogoryDetail.PartCategoryDetailData.Any())
            {
                return _ListPartCatogoryDetail;
            }
            else
            {
                await PopulatePartCategoryDetailAsync(cancellationToken);
                return _ListPartCatogoryDetail;
            }
        }

        public async Task<ListPartCategoryDetailData> GetPartCategoryDetailByCategoryCode(string categoryCode , CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartCatogoryDetail.PartCategoryDetailData.Any())
            {
                List<PartCategoryDetailData> filteredList = _ListPartCatogoryDetail.PartCategoryDetailData.Where(x => x.CategoryCode == categoryCode).ToList();
                _FilteredListPartCatogoryDetail.PartCategoryDetailData.AddRange(filteredList);
                return _FilteredListPartCatogoryDetail;
            }
            else
            {
                await PopulatePartCategoryDetailAsync(cancellationToken);
                return _FilteredListPartCatogoryDetail;
            }
        }
        #endregion

        #region PartClassDetail

        public async Task<ListPartClassDetailData> GetAllPartClassDetail(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartClassDetail.PartClassDetailData.Any())
            {
                return _ListPartClassDetail;
            }
            else
            {
                await PopulatePartClassDetailAsync(cancellationToken);
                return _ListPartClassDetail;
            }
        }
        public async Task<ListPartClassDetailData> GetPartClassDetailByClasses(string class1, double class2, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartClassDetail.PartClassDetailData.Any())
            {
                List<PartClassDetailData> filteredList = _ListPartClassDetail.PartClassDetailData.Where(x => x.Class1 == class1 && x.Class2 == class2).ToList();
                _FilteredListPartClassDetail.PartClassDetailData.AddRange(filteredList);
                return _FilteredListPartClassDetail;
            }
            else
            {
                await PopulatePartClassDetailAsync(cancellationToken);
                return _FilteredListPartClassDetail;
            }
        }
        #endregion

        #region PartGroups

        public async Task<ListPartGroupsData> GetAllPartGroups(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartGroups.PartGroupsData.Any())
            {
                return _ListPartGroups;
            }
            else
            {
                await PopulatePartGroupsAsync(cancellationToken);
                return _ListPartGroups;
            }
        }

        public async Task<ListPartGroupsData> GetPartGroupsByPartGroup(string partGroup, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartGroups.PartGroupsData.Any())
            {
                List<PartGroupsData> filteredList = _ListPartGroups.PartGroupsData.Where(x => x.PartGroup == partGroup).ToList();
                _FilteredListPartGroups.PartGroupsData.AddRange(filteredList);
                return _FilteredListPartGroups;
            }
            else
            {
                await PopulatePartGroupsAsync(cancellationToken);
                return _FilteredListPartGroups;
            }
        }
        #endregion

        #region PartGroupsConst

        public async Task<ListPartGroupsConstData> GetAllPartGroupsConst(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartGroupsConst.PartGroupsConstData.Any())
            {
                return _ListPartGroupsConst;
            }
            else
            {
                await PopulatePartGroupsConstAsync(cancellationToken);
                return _ListPartGroupsConst;
            }
        }

        public async Task<ListPartGroupsConstData> GetAllPartGroupsConstByGroup3(string group3 ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartGroupsConst.PartGroupsConstData.Any())
            {
                List<PartGroupsConstData> filteredList = _ListPartGroupsConst.PartGroupsConstData.Where(x => x.Code == group3).ToList();
                _FilteredListPartGroupsConst.PartGroupsConstData.AddRange(filteredList);
                return _FilteredListPartGroupsConst;
            }
            else
            {
                await PopulatePartGroupsConstAsync(cancellationToken);
                return _FilteredListPartGroupsConst;
            }
        }
        #endregion

        #region CustomerData
        public async Task<ListCustomerDataGrpc> GetAllCustomerData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListCustomerData.CustomerDataGrpc.Any())
            {
                return _ListCustomerData;
            }
            else
            {
                await PopulateCustomerDataAsync(cancellationToken);
                return _ListCustomerData;
            }
        }
        #endregion

        #region ColourCode
        public async Task<ListColourCodeData> GetAllColourCode(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListColourCode.ColourCodeData.Any())
            {
                return _ListColourCode;
            }
            else
            {
                await PopulateColourCodeAsync(cancellationToken);
                return _ListColourCode;
            }
        }

        public async Task<ListColourCodeData> GetColourCodeByColorCode(string colorCode, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListColourCode.ColourCodeData.Any())
            {
                List<ColourCodeData> filteredList = _ListColourCode.ColourCodeData.Where(x => x.ClMk == colorCode).ToList();
                _FilteredListColourCode.ColourCodeData.AddRange(filteredList);
                return _FilteredListColourCode;
            }
            else
            {
                await PopulateColourCodeAsync(cancellationToken);
                return _FilteredListColourCode;
            }
        }
        #endregion

        #region MaterialGroups
        public async Task<ListMaterialGroupsData> GetAllMaterialGroups(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListMaterialGroups.MaterialGroupsData.Any())
            {
                return _ListMaterialGroups;
            }
            else
            {
                await PopulateMaterialGroupsAsync(cancellationToken);
                return _ListMaterialGroups;
            }
        }
        public async Task<ListMaterialGroupsData> GetMaterialGroupsByMaterialGroupId(string materialGroupId, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListMaterialGroups.MaterialGroupsData.Any())
            {
                List<MaterialGroupsData> filteredList = _ListMaterialGroups.MaterialGroupsData.Where(x => x.MaterialGroup == materialGroupId).ToList();
                _FilteredListMaterialGroups.MaterialGroupsData.AddRange(filteredList);
                return _FilteredListMaterialGroups;
            }
            else
            {
                await PopulateMaterialGroupsAsync(cancellationToken);
                return _FilteredListMaterialGroups;
            }
        }
        #endregion

        #region MaterialTypes
        public async Task<ListMaterialTypesData> GetAllMaterialTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListMaterialTypes.MaterialTypesData.Any())
            {
                return _ListMaterialTypes;
            }
            else
            {
                await PopulateMaterialTypesAsync(cancellationToken);
                return _ListMaterialTypes;
            }
        }
        public async Task<ListMaterialTypesData> GetMaterialTypesByMaterials(string materialGroup, string materialType ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListMaterialTypes.MaterialTypesData.Any())
            {
                List<MaterialTypesData> filteredList = _ListMaterialTypes.MaterialTypesData.Where(x => x.MaterialGroup == materialGroup && x.MaterialType == materialType).ToList();
                _FilteredListMaterialTypes.MaterialTypesData.AddRange(filteredList);
                return _FilteredListMaterialTypes;
            }
            else
            {
                await PopulateMaterialTypesAsync(cancellationToken);
                return _FilteredListMaterialTypes;
            }
        }
        #endregion

        #region NPACustomer
        public async Task<ListNPACustomerData> GetAllNPACustomer(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListNPACustomer.NPACustomerData.Any())
            {
                return _ListNPACustomer;
            }
            else
            {
                await PopulateNPACustomerAsync(cancellationToken);
                return _ListNPACustomer;
            }
        }
        #endregion

        #region NPASupplier
        public async Task<ListNPASupplierData> GetAllNPASupplier(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListNPASupplier.NPASupplierData.Any())
            {
                return _ListNPASupplier;
            }
            else
            {
                await PopulateNPASupplierAsync(cancellationToken);
                return _ListNPASupplier;
            }
        }
        #endregion

        #region Suppliers
        public async Task<ListSuppliersData> GetAllSuppliers(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListSuppliers.SuppliersData.Any())
            {
                return _ListSuppliers;
            }
            else
            {
                await PopulateSuppliersAsync(cancellationToken);
                return _ListSuppliers;
            }
        }
        #endregion

        #region EmacsRFIView
        public async Task<ListEmacsRFIViewData> GetAllEmacsRFIView(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListEmacsRFIView.EmacsRFIViewData.Any())
            {
                return _ListEmacsRFIView;
            }
            else
            {
                await PopulateEmacsRFIViewAsync(cancellationToken);
                return _ListEmacsRFIView;
            }
        }
        #endregion

        #region PARTMS
        public async Task<ListPARTMSData> GetAllPARTMSData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSData.Any())
            {
                return _ListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _ListPARTMS;
            }
        }

        public async Task<ListPARTMSData> GetPARTMSDataByClass(string class1, double class2, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSData.Any())
            {
                _FilteredListPARTMS.PARTMSData.Clear();
                CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-GB");
                string class2String = class2.ToString(cultureInfo);
                List<PARTMSData> filteredList = _ListPARTMS.PARTMSData.Where(x => x.ClassDetailGroupCode == class1 && x.ClassDetailId == class2String).ToList();
                _FilteredListPARTMS.PARTMSData.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }

        public async Task<ListPARTMSData> GetPARTMSDataByColorCode(string colorCode, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSData.Any())
            {
                _FilteredListPARTMS.PARTMSData.Clear();
                List<PARTMSData> filteredList = _ListPARTMS.PARTMSData.Where(x => x.ColorCode == colorCode).ToList();
                _FilteredListPARTMS.PARTMSData.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }
        public async Task<ListPARTMSData> GetPARTMSDataByMaterial(string materialGroup, string materialType, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSData.Any())
            {
                _FilteredListPARTMS.PARTMSData.Clear();
                List<PARTMSData> filteredList = _ListPARTMS.PARTMSData.Where(x => x.MaterialGroupId == materialGroup && x.MaterialTypeId == materialType).ToList();
                _FilteredListPARTMS.PARTMSData.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }
        public async Task<ListPARTMSData> GetPARTMSDataByMaterialGroup(string materialGroup, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSData.Any())
            {
                _FilteredListPARTMS.PARTMSData.Clear();
                List<PARTMSData> filteredList = _ListPARTMS.PARTMSData.Where(x => x.MaterialGroupId == materialGroup).ToList();
                _FilteredListPARTMS.PARTMSData.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }
        public async Task<ListPARTMSData> GetPARTMSDataByPartGroup(string partGroup, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSData.Any())
            {
                _FilteredListPARTMS.PARTMSData.Clear();
                List<PARTMSData> filteredList = _ListPARTMS.PARTMSData.Where(x => x.ClassDetailGroupCode == partGroup).ToList();
                _FilteredListPARTMS.PARTMSData.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }
        public async Task<ListPARTMSData> GetPARTMSDataByCategoryCode(string catogoryCode, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSData.Any())
            {
                _FilteredListPARTMS.PARTMSData.Clear();
                List<PARTMSData> filteredList = _ListPARTMS.PARTMSData.Where(x => x.CategoryCode == catogoryCode).ToList();
                _FilteredListPARTMS.PARTMSData.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }
        public async Task<ListPARTMSData> GetPARTMSDataByPartGroupsConstCode(string partGroupsConstCode, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSData.Any())
            {
                _FilteredListPARTMS.PARTMSData.Clear();
                List<PARTMSData> filteredList = _ListPARTMS.PARTMSData.Where(x => x.Group3 == partGroupsConstCode).ToList();
                _FilteredListPARTMS.PARTMSData.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }
        #endregion

        #endregion

        #region Data Imports

        #region CombinedParts
        public async Task<bool> PopulateCombinedPartsAsync(CancellationToken cancellationToken)
        {
            if (!_CombinedPartsRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CombinedPartsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCombinedPartsQuery, List<CombinedPartsData>>>();
                    _CombinedPartsRefreshInProgress = true;
                    GetCombinedPartsQuery query = new GetCombinedPartsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CombinedPartsData>> results = await _CombinedPartsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListCombinedParts.CombinedPartsData.Clear();
                        _ListCombinedParts.CombinedPartsData.AddRange(results.Value);
                    }

                    _CombinedPartsRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region PartCategoryDetail

        public async Task<bool> PopulatePartCategoryDetailAsync(CancellationToken cancellationToken)
        {
            if (!_PartCatogoryDetailRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _PartCatogoryDetailHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartCatogoryDetailQuery, List<PartCategoryDetailData>>>();
                    _PartCatogoryDetailRefreshInProgress = true;
                    GetPartCatogoryDetailQuery query = new GetPartCatogoryDetailQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartCategoryDetailData>> results = await _PartCatogoryDetailHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListPartCatogoryDetail.PartCategoryDetailData.Clear();
                        _ListPartCatogoryDetail.PartCategoryDetailData.AddRange(results.Value);
                    }

                    _PartCatogoryDetailRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region PartClassDetail

        public async Task<bool> PopulatePartClassDetailAsync(CancellationToken cancellationToken)
        {
            if (!_PartClassDetailRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _PartClassDetailHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartClassDetailQuery, List<PartClassDetailData>>>();
                    _PartClassDetailRefreshInProgress = true;
                    GetPartClassDetailQuery query = new GetPartClassDetailQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartClassDetailData>> results = await _PartClassDetailHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListPartClassDetail.PartClassDetailData.Clear();
                        _ListPartClassDetail.PartClassDetailData.AddRange(results.Value);
                    }

                    _PartClassDetailRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region PartGroups

        public async Task<bool> PopulatePartGroupsAsync(CancellationToken cancellationToken)
        {
            if (!_PartGroupsRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _PartGroupsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartGroupsQuery, List<PartGroupsData>>>();
                    _PartGroupsRefreshInProgress = true;
                    GetPartGroupsQuery query = new GetPartGroupsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartGroupsData>> results = await _PartGroupsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListPartGroups.PartGroupsData.Clear();
                        _ListPartGroups.PartGroupsData.AddRange(results.Value);
                    }

                    _PartGroupsRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region PartGroupsConst

        public async Task<bool> PopulatePartGroupsConstAsync(CancellationToken cancellationToken)
        {
            if (!_PartGroupsConstRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _PartGroupsConstHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartGroupsConstQuery, List<PartGroupsConstData>>>();
                    _PartGroupsConstRefreshInProgress = true;
                    GetPartGroupsConstQuery query = new GetPartGroupsConstQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartGroupsConstData>> results = await _PartGroupsConstHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListPartGroupsConst.PartGroupsConstData.Clear();
                        _ListPartGroupsConst.PartGroupsConstData.AddRange(results.Value);
                    }

                    _PartGroupsConstRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region CustomerData

        public async Task<bool> PopulateCustomerDataAsync(CancellationToken cancellationToken)
        {
            if (!_CustomerDataRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _CustomerDataHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCustomerDataQuery, List<CustomerDataGrpc>>>();
                    _CustomerDataRefreshInProgress = true;
                    GetCustomerDataQuery query = new GetCustomerDataQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerDataGrpc>> results = await _CustomerDataHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListCustomerData.CustomerDataGrpc.Clear();
                        _ListCustomerData.CustomerDataGrpc.AddRange(results.Value);
                    }

                    _CustomerDataRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region ColourCode

        public async Task<bool> PopulateColourCodeAsync(CancellationToken cancellationToken)
        {
            if (!_ColourCodeRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _ColourCodeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetColourCodeQuery, List<ColourCodeData>>>();
                    _ColourCodeRefreshInProgress = true;
                    GetColourCodeQuery query = new GetColourCodeQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ColourCodeData>> results = await _ColourCodeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListColourCode.ColourCodeData.Clear();
                        _ListColourCode.ColourCodeData.AddRange(results.Value);
                    }

                    _ColourCodeRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region MaterialGroups

        public async Task<bool> PopulateMaterialGroupsAsync(CancellationToken cancellationToken)
        {
            if (!_MaterialGroupsRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _MaterialGroupsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetMaterialGroupsQuery, List<MaterialGroupsData>>>();
                    _MaterialGroupsRefreshInProgress = true;
                    GetMaterialGroupsQuery query = new GetMaterialGroupsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MaterialGroupsData>> results = await _MaterialGroupsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListMaterialGroups.MaterialGroupsData.Clear();
                        _ListMaterialGroups.MaterialGroupsData.AddRange(results.Value);
                    }

                    _MaterialGroupsRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region MaterialTypes

        public async Task<bool> PopulateMaterialTypesAsync(CancellationToken cancellationToken)
        {
            if (!_MaterialTypesRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _MaterialTypesHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetMaterialTypesQuery, List<MaterialTypesData>>>();
                    _MaterialTypesRefreshInProgress = true;
                    GetMaterialTypesQuery query = new GetMaterialTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MaterialTypesData>> results = await _MaterialTypesHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListMaterialTypes.MaterialTypesData.Clear();
                        _ListMaterialTypes.MaterialTypesData.AddRange(results.Value);
                    }

                    _MaterialTypesRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region NPACustomer

        public async Task<bool> PopulateNPACustomerAsync(CancellationToken cancellationToken)
        {
            if (!_NPACustomerRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _NPACustomerHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetNPACustomerQuery, List<NPACustomerData>>>();
                    _NPACustomerRefreshInProgress = true;
                    GetNPACustomerQuery query = new GetNPACustomerQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<NPACustomerData>> results = await _NPACustomerHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListNPACustomer.NPACustomerData.Clear();
                        _ListNPACustomer.NPACustomerData.AddRange(results.Value);
                    }

                    _NPACustomerRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region NPASupplier

        public async Task<bool> PopulateNPASupplierAsync(CancellationToken cancellationToken)
        {
            if (!_NPASupplierRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _NPASupplierHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetNPASupplierQuery, List<NPASupplierData>>>();
                    _NPASupplierRefreshInProgress = true;
                    GetNPASupplierQuery query = new GetNPASupplierQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<NPASupplierData>> results = await _NPASupplierHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListNPASupplier.NPASupplierData.Clear();
                        _ListNPASupplier.NPASupplierData.AddRange(results.Value);
                    }

                    _NPASupplierRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region Suppliers

        public async Task<bool> PopulateSuppliersAsync(CancellationToken cancellationToken)
        {
            if (!_SuppliersRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _SuppliersHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetSuppliersQuery, List<SuppliersData>>>();
                    _SuppliersRefreshInProgress = true;
                    GetSuppliersQuery query = new GetSuppliersQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<SuppliersData>> results = await _SuppliersHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListSuppliers.SuppliersData.Clear();
                        _ListSuppliers.SuppliersData.AddRange(results.Value);
                    }

                    _SuppliersRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region EmacsRFIView

        public async Task<bool> PopulateEmacsRFIViewAsync(CancellationToken cancellationToken)
        {
            if (!_EmacsRFIViewRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _EmacsRFIViewHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetEmacsRFIViewQuery, List<EmacsRFIViewData>>>();
                    _EmacsRFIViewRefreshInProgress = true;
                    GetEmacsRFIViewQuery query = new GetEmacsRFIViewQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<EmacsRFIViewData>> results = await _EmacsRFIViewHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListEmacsRFIView.EmacsRFIViewData.Clear();
                        _ListEmacsRFIView.EmacsRFIViewData.AddRange(results.Value);
                    }

                    _EmacsRFIViewRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region PARTMS

        public async Task<bool> PopulatePARTMSAsync(CancellationToken cancellationToken)
        {
            if (!_PARTMSRefreshInProgress)
            {
                using (IServiceScope scope = _ServiceProvider.CreateScope())
                {
                    _PARTMSHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPARTMSQuery, List<PARTMSData>>>();
                    _PARTMSRefreshInProgress = true;
                    GetPARTMSQuery query = new GetPARTMSQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PARTMSData>> results = await _PARTMSHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListPARTMS.PARTMSData.Clear();
                        _ListPARTMS.PARTMSData.AddRange(results.Value);
                    }

                    _PARTMSRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #endregion

        void PopulateSampleData()
        {
            _ListCombinedParts = SampleEmacsDataService.PopulateCombinedParts();
            _ListPartCatogoryDetail = SampleEmacsDataService.PopulatePartCategoryDetail();
            _ListPartClassDetail = SampleEmacsDataService.PopulatePartClassDetail();
            _ListPartGroups = SampleEmacsDataService.PopulatePartGroups();
            _ListPartGroupsConst = SampleEmacsDataService.PopulatePartGroupsConst();
            _ListCustomerData = SampleEmacsDataService.PopulateCustomerDataGrps();
            _ListColourCode = SampleEmacsDataService.PopulateColourCode();
            _ListMaterialGroups = SampleEmacsDataService.PopulateMaterialGroups();
            _ListMaterialTypes = SampleEmacsDataService.PopulateMaterialTypes();
            _ListNPACustomer = SampleEmacsDataService.PopulateNPACustomer();
            _ListNPASupplier = SampleEmacsDataService.PopulateNPASupplier();
            _ListSuppliers = SampleEmacsDataService.PopulateSuppliers();
            _ListPARTMS = SampleEmacsDataService.PopulatePARTMS();
        }
    }
}
