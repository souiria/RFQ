namespace Emacs.Services
{
    public class EMACSAccessService : IEMACSAccessService
    {
        #region In Memory Datasets

        #region CombinedParts

        ListCombinedPartsGrpc _ListCombinedParts;

        #endregion

        #region PartCategoryDetail

        ListPartCategoryDetailGrpc _ListPartCatogoryDetail;
        ListPartCategoryDetailGrpc _FilteredListPartCatogoryDetail;

        #endregion

        #region PartClassDetail

        ListPartClassDetailGrpc _ListPartClassDetail;
        ListPartClassDetailGrpc _FilteredListPartClassDetail;

        #endregion

        #region PartGroups

        ListPartGroupsGrpc _ListPartGroups;
        ListPartGroupsGrpc _FilteredListPartGroups;

        #endregion

        #region PartGroupsConst

        ListPartGroupsConstGrpc _ListPartGroupsConst;
        ListPartGroupsConstGrpc _FilteredListPartGroupsConst;

        #endregion

        #region CustomerData

        ListCustomerDataGrpc _ListCustomerData;

        #endregion

        #region ColourCode

        ListColourCodeGrpc _ListColourCode;
        ListColourCodeGrpc _FilteredListColourCode;

        #endregion

        #region MaterialGroups

        ListMaterialGroupsGrpc _ListMaterialGroups;
        ListMaterialGroupsGrpc _FilteredListMaterialGroups;

        #endregion

        #region MaterialTypes

        ListMaterialTypesGrpc _ListMaterialTypes;
        ListMaterialTypesGrpc _FilteredListMaterialTypes;

        #endregion

        #region NPACustomer

        ListNPACustomerGrpc _ListNPACustomer;

        #endregion

        #region NPASupplier

        ListNPASupplierGrpc _ListNPASupplier;

        #endregion

        #region Suppliers

        ListSuppliersGrpc _ListSuppliers;

        #endregion

        #region EmacsRFIView

        ListEmacsRFIViewGrpc _ListEmacsRFIView;

        #endregion

        #region PARTMS

        ListPARTMSGrpc _ListPARTMS;
        ListPARTMSGrpc _FilteredListPARTMS;

        #endregion

        #endregion

        #region Fields and Properties

        #region CombinedParts

        IQueryHandler<GetCombinedPartsQuery, List<CombinedPartsGrpc>>? _CombinedPartsHandler;
        bool _CombinedPartsRefreshInProgress;

        #endregion

        #region PartCatogoryDetail

        IQueryHandler<GetPartCatogoryDetailQuery, List<PartCategoryDetailGrpc>>? _PartCatogoryDetailHandler;
        bool _PartCatogoryDetailRefreshInProgress;

        #endregion

        #region PartClassDetail

        IQueryHandler<GetPartClassDetailQuery, List<PartClassDetailGrpc>>? _PartClassDetailHandler;
        bool _PartClassDetailRefreshInProgress;

        #endregion

        #region PartGroups

        IQueryHandler<GetPartGroupsQuery, List<PartGroupsGrpc>>? _PartGroupsHandler;
        bool _PartGroupsRefreshInProgress;

        #endregion

        #region PartGroupsConst

        IQueryHandler<GetPartGroupsConstQuery, List<PartGroupsConstGrpc>>? _PartGroupsConstHandler;
        bool _PartGroupsConstRefreshInProgress;

        #endregion

        #region CustomerData

        IQueryHandler<GetCustomerDataGrpcQuery, List<CustomerDataGrpc>>? _CustomerDataHandler;
        bool _CustomerDataRefreshInProgress;

        #endregion

        #region ColourCode

        IQueryHandler<GetColourCodeQuery, List<ColourCodeGrpc>>? _ColourCodeHandler;
        bool _ColourCodeRefreshInProgress;

        #endregion

        #region MaterialGroups

        IQueryHandler<GetMaterialGroupsQuery, List<MaterialGroupsGrpc>>? _MaterialGroupsHandler;
        bool _MaterialGroupsRefreshInProgress;

        #endregion

        #region MaterialTypes

        IQueryHandler<GetMaterialTypesQuery, List<MaterialTypesGrpc>>? _MaterialTypesHandler;
        bool _MaterialTypesRefreshInProgress;

        #endregion

        #region NPACustomer

        IQueryHandler<GetNPACustomerQuery, List<NPACustomerGrpc>>? _NPACustomerHandler;
        bool _NPACustomerRefreshInProgress;

        #endregion

        #region NPASupplier

        IQueryHandler<GetNPASupplierQuery, List<NPASupplierGrpc>>? _NPASupplierHandler;
        bool _NPASupplierRefreshInProgress;

        #endregion

        #region Suppliers

        IQueryHandler<GetSuppliersQuery, List<SuppliersGrpc>>? _SuppliersHandler;
        bool _SuppliersRefreshInProgress;

        #endregion

        #region EmacsRFIView

        IQueryHandler<GetEmacsRFIViewQuery, List<EmacsRFIViewGrpc>>? _EmacsRFIViewHandler;
        bool _EmacsRFIViewRefreshInProgress;

        #endregion

        #region PARTMS

        IQueryHandler<GetPARTMSQuery, List<PARTMSGrpc>>? _PARTMSHandler;
        bool _PARTMSRefreshInProgress;

        #endregion

        readonly IServiceProvider _ServiceProvider;
        #endregion

        #region Constructor
        public EMACSAccessService(IServiceProvider serviceProvider, bool testing = false)
        {
            #region CombinedParts

            _ListCombinedParts = new ListCombinedPartsGrpc();
            _CombinedPartsRefreshInProgress = false;

            #endregion

            #region PartCatogoryDetail

            _ListPartCatogoryDetail = new ListPartCategoryDetailGrpc();
            _FilteredListPartCatogoryDetail = new ListPartCategoryDetailGrpc();
            _PartCatogoryDetailRefreshInProgress = false;

            #endregion

            #region PartClassDetail

            _ListPartClassDetail = new ListPartClassDetailGrpc();
            _FilteredListPartClassDetail = new ListPartClassDetailGrpc();
            _PartClassDetailRefreshInProgress = false;

            #endregion

            #region PartGroups

            _ListPartGroups = new ListPartGroupsGrpc();
            _FilteredListPartGroups = new ListPartGroupsGrpc();
            _PartGroupsRefreshInProgress = false;

            #endregion

            #region PartGroupsConst

            _ListPartGroupsConst = new ListPartGroupsConstGrpc();
            _FilteredListPartGroupsConst = new ListPartGroupsConstGrpc();
            _PartGroupsConstRefreshInProgress = false;

            #endregion

            #region CustomerData

            _ListCustomerData = new ListCustomerDataGrpc();
            _CustomerDataRefreshInProgress = false;

            #endregion

            #region ColourCode

            _ListColourCode = new ListColourCodeGrpc();
            _FilteredListColourCode = new ListColourCodeGrpc();
            _ColourCodeRefreshInProgress = false;

            #endregion

            #region MaterialGroups

            _ListMaterialGroups = new ListMaterialGroupsGrpc();
            _FilteredListMaterialGroups = new ListMaterialGroupsGrpc();
            _MaterialGroupsRefreshInProgress = false;

            #endregion

            #region MaterialTypes

            _ListMaterialTypes = new ListMaterialTypesGrpc();
            _FilteredListMaterialTypes = new ListMaterialTypesGrpc();
            _MaterialTypesRefreshInProgress = false;

            #endregion

            #region NPACustomer

            _ListNPACustomer = new ListNPACustomerGrpc();
            _NPACustomerRefreshInProgress = false;

            #endregion

            #region NPASupplier

            _ListNPASupplier = new ListNPASupplierGrpc();
            _NPASupplierRefreshInProgress = false;

            #endregion

            #region Suppliers

            _ListSuppliers = new ListSuppliersGrpc();
            _SuppliersRefreshInProgress = false;

            #endregion

            #region EmacsRFIView

            _ListEmacsRFIView = new ListEmacsRFIViewGrpc();
            _EmacsRFIViewRefreshInProgress = false;

            #endregion

            #region PARTMS

            //_PARTMSGrpc = [];
            _ListPARTMS = new ListPARTMSGrpc();
            _FilteredListPARTMS = new ListPARTMSGrpc();
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
        public async Task<ListCombinedPartsGrpc> GetAllCombinedParts(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListCombinedParts.CombinedPartsGrpc.Any())
            {
                return _ListCombinedParts;
            }
            else
            {
                await PopulateCombinedPartsAsync(cancellationToken);
                return _ListCombinedParts;
            }
        }

        public async Task<Result<int>> GetCombinedPartsGrpcCount(CancellationToken cancellationToken)
        {
            if (_ListCombinedParts.CombinedPartsGrpc.Any())
            {
                return _ListCombinedParts.CombinedPartsGrpc.Count;
            }
            else
            {
                await PopulateCombinedPartsAsync(cancellationToken);
                return _ListCombinedParts.CombinedPartsGrpc.Count;
            }
        }

        #endregion

        #region PartCategoryDetail

        public async Task<ListPartCategoryDetailGrpc> GetAllPartCategoryDetail(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartCatogoryDetail.PartCategoryDetailGrpc.Any())
            {
                return _ListPartCatogoryDetail;
            }
            else
            {
                await PopulatePartCategoryDetailAsync(cancellationToken);
                return _ListPartCatogoryDetail;
            }
        }

        public async Task<ListPartCategoryDetailGrpc> GetPartCategoryDetailByCategoryCode(string categoryCode , CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartCatogoryDetail.PartCategoryDetailGrpc.Any())
            {
                List<PartCategoryDetailGrpc> filteredList = _ListPartCatogoryDetail.PartCategoryDetailGrpc.Where(x => x.CategoryCode == categoryCode).ToList();
                _FilteredListPartCatogoryDetail.PartCategoryDetailGrpc.AddRange(filteredList);
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

        public async Task<ListPartClassDetailGrpc> GetAllPartClassDetail(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartClassDetail.PartClassDetailGrpc.Any())
            {
                return _ListPartClassDetail;
            }
            else
            {
                await PopulatePartClassDetailAsync(cancellationToken);
                return _ListPartClassDetail;
            }
        }
        public async Task<ListPartClassDetailGrpc> GetPartClassDetailByClasses(string class1, double class2, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartClassDetail.PartClassDetailGrpc.Any())
            {
                List<PartClassDetailGrpc> filteredList = _ListPartClassDetail.PartClassDetailGrpc.Where(x => x.Class1 == class1 && x.Class2 == class2).ToList();
                _FilteredListPartClassDetail.PartClassDetailGrpc.AddRange(filteredList);
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

        public async Task<ListPartGroupsGrpc> GetAllPartGroups(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartGroups.PartGroupsGrpc.Any())
            {
                return _ListPartGroups;
            }
            else
            {
                await PopulatePartGroupsAsync(cancellationToken);
                return _ListPartGroups;
            }
        }

        public async Task<ListPartGroupsGrpc> GetPartGroupsByPartGroup(string partGroup, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartGroups.PartGroupsGrpc.Any())
            {
                List<PartGroupsGrpc> filteredList = _ListPartGroups.PartGroupsGrpc.Where(x => x.PartGroup == partGroup).ToList();
                _FilteredListPartGroups.PartGroupsGrpc.AddRange(filteredList);
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

        public async Task<ListPartGroupsConstGrpc> GetAllPartGroupsConst(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartGroupsConst.PartGroupsConstGrpc.Any())
            {
                return _ListPartGroupsConst;
            }
            else
            {
                await PopulatePartGroupsConstAsync(cancellationToken);
                return _ListPartGroupsConst;
            }
        }

        public async Task<ListPartGroupsConstGrpc> GetAllPartGroupsConstByGroup3(string group3 ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPartGroupsConst.PartGroupsConstGrpc.Any())
            {
                List<PartGroupsConstGrpc> filteredList = _ListPartGroupsConst.PartGroupsConstGrpc.Where(x => x.Code == group3).ToList();
                _FilteredListPartGroupsConst.PartGroupsConstGrpc.AddRange(filteredList);
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
        public async Task<ListColourCodeGrpc> GetAllColourCode(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListColourCode.ColourCodeGrpc.Any())
            {
                return _ListColourCode;
            }
            else
            {
                await PopulateColourCodeAsync(cancellationToken);
                return _ListColourCode;
            }
        }

        public async Task<ListColourCodeGrpc> GetColourCodeByColorCode(string colorCode, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListColourCode.ColourCodeGrpc.Any())
            {
                List<ColourCodeGrpc> filteredList = _ListColourCode.ColourCodeGrpc.Where(x => x.ClMk == colorCode).ToList();
                _FilteredListColourCode.ColourCodeGrpc.AddRange(filteredList);
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
        public async Task<ListMaterialGroupsGrpc> GetAllMaterialGroups(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListMaterialGroups.MaterialGroupsGrpc.Any())
            {
                return _ListMaterialGroups;
            }
            else
            {
                await PopulateMaterialGroupsAsync(cancellationToken);
                return _ListMaterialGroups;
            }
        }
        public async Task<ListMaterialGroupsGrpc> GetMaterialGroupsByMaterialGroupId(string materialGroupId, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListMaterialGroups.MaterialGroupsGrpc.Any())
            {
                List<MaterialGroupsGrpc> filteredList = _ListMaterialGroups.MaterialGroupsGrpc.Where(x => x.MaterialGroup == materialGroupId).ToList();
                _FilteredListMaterialGroups.MaterialGroupsGrpc.AddRange(filteredList);
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
        public async Task<ListMaterialTypesGrpc> GetAllMaterialTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListMaterialTypes.MaterialTypesGrpc.Any())
            {
                return _ListMaterialTypes;
            }
            else
            {
                await PopulateMaterialTypesAsync(cancellationToken);
                return _ListMaterialTypes;
            }
        }
        public async Task<ListMaterialTypesGrpc> GetMaterialTypesByMaterials(string materialGroup, string materialType ,CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListMaterialTypes.MaterialTypesGrpc.Any())
            {
                List<MaterialTypesGrpc> filteredList = _ListMaterialTypes.MaterialTypesGrpc.Where(x => x.MaterialGroup == materialGroup && x.MaterialType == materialType).ToList();
                _FilteredListMaterialTypes.MaterialTypesGrpc.AddRange(filteredList);
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
        public async Task<ListNPACustomerGrpc> GetAllNPACustomer(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListNPACustomer.NPACustomerGrpc.Any())
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
        public async Task<ListNPASupplierGrpc> GetAllNPASupplier(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListNPASupplier.NPASupplierGrpc.Any())
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
        public async Task<ListSuppliersGrpc> GetAllSuppliers(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListSuppliers.SuppliersGrpc.Any())
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
        public async Task<ListEmacsRFIViewGrpc> GetAllEmacsRFIView(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListEmacsRFIView.EmacsRFIViewGrpc.Any())
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
        public async Task<ListPARTMSGrpc> GetAllPARTMSGrpc(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSGrpc.Any())
            {
                return _ListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _ListPARTMS;
            }
        }

        public async Task<ListPARTMSGrpc> GetPARTMSGrpcByClass(string class1, double class2, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSGrpc.Any())
            {
                _FilteredListPARTMS.PARTMSGrpc.Clear();
                CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-GB");
                string class2String = class2.ToString(cultureInfo);
                List<PARTMSGrpc> filteredList = _ListPARTMS.PARTMSGrpc.Where(x => x.ClassDetailGroupCode == class1 && x.ClassDetailId == class2String).ToList();
                _FilteredListPARTMS.PARTMSGrpc.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }

        public async Task<ListPARTMSGrpc> GetPARTMSGrpcByColorCode(string colorCode, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSGrpc.Any())
            {
                _FilteredListPARTMS.PARTMSGrpc.Clear();
                List<PARTMSGrpc> filteredList = _ListPARTMS.PARTMSGrpc.Where(x => x.ColorCode == colorCode).ToList();
                _FilteredListPARTMS.PARTMSGrpc.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }
        public async Task<ListPARTMSGrpc> GetPARTMSGrpcByMaterial(string materialGroup, string materialType, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSGrpc.Any())
            {
                _FilteredListPARTMS.PARTMSGrpc.Clear();
                List<PARTMSGrpc> filteredList = _ListPARTMS.PARTMSGrpc.Where(x => x.MaterialGroupId == materialGroup && x.MaterialTypeId == materialType).ToList();
                _FilteredListPARTMS.PARTMSGrpc.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }
        public async Task<ListPARTMSGrpc> GetPARTMSGrpcByMaterialGroup(string materialGroup, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSGrpc.Any())
            {
                _FilteredListPARTMS.PARTMSGrpc.Clear();
                List<PARTMSGrpc> filteredList = _ListPARTMS.PARTMSGrpc.Where(x => x.MaterialGroupId == materialGroup).ToList();
                _FilteredListPARTMS.PARTMSGrpc.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }
        public async Task<ListPARTMSGrpc> GetPARTMSGrpcByPartGroup(string partGroup, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSGrpc.Any())
            {
                _FilteredListPARTMS.PARTMSGrpc.Clear();
                List<PARTMSGrpc> filteredList = _ListPARTMS.PARTMSGrpc.Where(x => x.ClassDetailGroupCode == partGroup).ToList();
                _FilteredListPARTMS.PARTMSGrpc.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }
        public async Task<ListPARTMSGrpc> GetPARTMSGrpcByCategoryCode(string catogoryCode, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSGrpc.Any())
            {
                _FilteredListPARTMS.PARTMSGrpc.Clear();
                List<PARTMSGrpc> filteredList = _ListPARTMS.PARTMSGrpc.Where(x => x.CategoryCode == catogoryCode).ToList();
                _FilteredListPARTMS.PARTMSGrpc.AddRange(filteredList);
                return _FilteredListPARTMS;
            }
            else
            {
                await PopulatePARTMSAsync(cancellationToken);
                return _FilteredListPARTMS;
            }
        }
        public async Task<ListPARTMSGrpc> GetPARTMSGrpcByPartGroupsConstCode(string partGroupsConstCode, CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ListPARTMS.PARTMSGrpc.Any())
            {
                _FilteredListPARTMS.PARTMSGrpc.Clear();
                List<PARTMSGrpc> filteredList = _ListPARTMS.PARTMSGrpc.Where(x => x.Group3 == partGroupsConstCode).ToList();
                _FilteredListPARTMS.PARTMSGrpc.AddRange(filteredList);
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
                    _CombinedPartsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCombinedPartsQuery, List<CombinedPartsGrpc>>>();
                    _CombinedPartsRefreshInProgress = true;
                    GetCombinedPartsQuery query = new GetCombinedPartsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CombinedPartsGrpc>> results = await _CombinedPartsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListCombinedParts.CombinedPartsGrpc.Clear();
                        _ListCombinedParts.CombinedPartsGrpc.AddRange(results.Value);
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
                    _PartCatogoryDetailHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartCatogoryDetailQuery, List<PartCategoryDetailGrpc>>>();
                    _PartCatogoryDetailRefreshInProgress = true;
                    GetPartCatogoryDetailQuery query = new GetPartCatogoryDetailQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartCategoryDetailGrpc>> results = await _PartCatogoryDetailHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListPartCatogoryDetail.PartCategoryDetailGrpc.Clear();
                        _ListPartCatogoryDetail.PartCategoryDetailGrpc.AddRange(results.Value);
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
                    _PartClassDetailHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartClassDetailQuery, List<PartClassDetailGrpc>>>();
                    _PartClassDetailRefreshInProgress = true;
                    GetPartClassDetailQuery query = new GetPartClassDetailQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartClassDetailGrpc>> results = await _PartClassDetailHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListPartClassDetail.PartClassDetailGrpc.Clear();
                        _ListPartClassDetail.PartClassDetailGrpc.AddRange(results.Value);
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
                    _PartGroupsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartGroupsQuery, List<PartGroupsGrpc>>>();
                    _PartGroupsRefreshInProgress = true;
                    GetPartGroupsQuery query = new GetPartGroupsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartGroupsGrpc>> results = await _PartGroupsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListPartGroups.PartGroupsGrpc.Clear();
                        _ListPartGroups.PartGroupsGrpc.AddRange(results.Value);
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
                    _PartGroupsConstHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartGroupsConstQuery, List<PartGroupsConstGrpc>>>();
                    _PartGroupsConstRefreshInProgress = true;
                    GetPartGroupsConstQuery query = new GetPartGroupsConstQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartGroupsConstGrpc>> results = await _PartGroupsConstHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListPartGroupsConst.PartGroupsConstGrpc.Clear();
                        _ListPartGroupsConst.PartGroupsConstGrpc.AddRange(results.Value);
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
                    _CustomerDataHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCustomerDataGrpcQuery, List<CustomerDataGrpc>>>();
                    _CustomerDataRefreshInProgress = true;
                    GetCustomerDataGrpcQuery query = new GetCustomerDataGrpcQuery();
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
                    _ColourCodeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetColourCodeQuery, List<ColourCodeGrpc>>>();
                    _ColourCodeRefreshInProgress = true;
                    GetColourCodeQuery query = new GetColourCodeQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ColourCodeGrpc>> results = await _ColourCodeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListColourCode.ColourCodeGrpc.Clear();
                        _ListColourCode.ColourCodeGrpc.AddRange(results.Value);
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
                    _MaterialGroupsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetMaterialGroupsQuery, List<MaterialGroupsGrpc>>>();
                    _MaterialGroupsRefreshInProgress = true;
                    GetMaterialGroupsQuery query = new GetMaterialGroupsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MaterialGroupsGrpc>> results = await _MaterialGroupsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListMaterialGroups.MaterialGroupsGrpc.Clear();
                        _ListMaterialGroups.MaterialGroupsGrpc.AddRange(results.Value);
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
                    _MaterialTypesHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetMaterialTypesQuery, List<MaterialTypesGrpc>>>();
                    _MaterialTypesRefreshInProgress = true;
                    GetMaterialTypesQuery query = new GetMaterialTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MaterialTypesGrpc>> results = await _MaterialTypesHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListMaterialTypes.MaterialTypesGrpc.Clear();
                        _ListMaterialTypes.MaterialTypesGrpc.AddRange(results.Value);
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
                    _NPACustomerHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetNPACustomerQuery, List<NPACustomerGrpc>>>();
                    _NPACustomerRefreshInProgress = true;
                    GetNPACustomerQuery query = new GetNPACustomerQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<NPACustomerGrpc>> results = await _NPACustomerHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListNPACustomer.NPACustomerGrpc.Clear();
                        _ListNPACustomer.NPACustomerGrpc.AddRange(results.Value);
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
                    _NPASupplierHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetNPASupplierQuery, List<NPASupplierGrpc>>>();
                    _NPASupplierRefreshInProgress = true;
                    GetNPASupplierQuery query = new GetNPASupplierQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<NPASupplierGrpc>> results = await _NPASupplierHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListNPASupplier.NPASupplierGrpc.Clear();
                        _ListNPASupplier.NPASupplierGrpc.AddRange(results.Value);
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
                    _SuppliersHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetSuppliersQuery, List<SuppliersGrpc>>>();
                    _SuppliersRefreshInProgress = true;
                    GetSuppliersQuery query = new GetSuppliersQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<SuppliersGrpc>> results = await _SuppliersHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListSuppliers.SuppliersGrpc.Clear();
                        _ListSuppliers.SuppliersGrpc.AddRange(results.Value);
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
                    _EmacsRFIViewHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetEmacsRFIViewQuery, List<EmacsRFIViewGrpc>>>();
                    _EmacsRFIViewRefreshInProgress = true;
                    GetEmacsRFIViewQuery query = new GetEmacsRFIViewQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<EmacsRFIViewGrpc>> results = await _EmacsRFIViewHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListEmacsRFIView.EmacsRFIViewGrpc.Clear();
                        _ListEmacsRFIView.EmacsRFIViewGrpc.AddRange(results.Value);
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
                    _PARTMSHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPARTMSQuery, List<PARTMSGrpc>>>();
                    _PARTMSRefreshInProgress = true;
                    GetPARTMSQuery query = new GetPARTMSQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PARTMSGrpc>> results = await _PARTMSHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ListPARTMS.PARTMSGrpc.Clear();
                        _ListPARTMS.PARTMSGrpc.AddRange(results.Value);
                    }

                    _PARTMSRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #endregion

        public async Task<IEnumerable<T>> Filter<T>(Func<T, bool> func, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return typeof(T).Name switch
                {
                    "CombinedPartsGrpc" => _ListCombinedParts.CombinedPartsGrpc.Cast<T>().Where(func).ToList(),
                    "PartCategoryDetailGrpc" => _ListPartCatogoryDetail.PartCategoryDetailGrpc.Cast<T>().Where(func).ToList(),
                    "PartClassDetailGrpc" => _ListPartClassDetail.PartClassDetailGrpc.Cast<T>().Where(func).ToList(),
                    "PartGroupsGrpc" => _ListPartGroups.PartGroupsGrpc.Cast<T>().Where(func).ToList(),
                    "PartGroupsConstGrpc" => _ListPartGroupsConst.PartGroupsConstGrpc.Cast<T>().Where(func).ToList(),
                    "CustomerDataGrpc" => _ListCustomerData.CustomerDataGrpc.Cast<T>().Where(func).ToList(),
                    "ColourCodeGrpc" => _ListColourCode.ColourCodeGrpc.Cast<T>().Where(func).ToList(),
                    "MaterialGroupsGrpc" => _ListMaterialGroups.MaterialGroupsGrpc.Cast<T>().Where(func).ToList(),
                    "MaterialTypesGrpc" => _ListMaterialTypes.MaterialTypesGrpc.Cast<T>().Where(func).ToList(),
                    "NPACustomerGrpc" => _ListNPACustomer.NPACustomerGrpc.Cast<T>().Where(func).ToList(),
                    "NPASupplierGrpc" => _ListNPASupplier.NPASupplierGrpc.Cast<T>().Where(func).ToList(),
                    "SuppliersGrpc" => _ListSuppliers.SuppliersGrpc.Cast<T>().Where(func).ToList(),
                    "EmacsRFIViewGrpc" => _ListEmacsRFIView.EmacsRFIViewGrpc.Cast<T>().Where(func).ToList(),
                    "PARTMSGrpc" => _ListPARTMS.PARTMSGrpc.Cast<T>().Where(func).ToList(),
                    _ => throw new NotSupportedException($"Filtering not supported for type {typeof(T).Name}")
                };
            }, cancellationToken);
        }

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
