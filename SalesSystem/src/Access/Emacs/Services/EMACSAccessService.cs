using Emacs.Data.Model;

namespace Emacs.Services
{
    public class EMACSAccessService : IEMACSAccessService
    {
        #region In Memory Datasets

        #region CombinedParts

        List<CombinedPartsDto> _CombinedParts;

        #endregion

        #region PartCategoryDetail

        List<PartCategoryDetailDto> _PartCatogoryDetail;

        #endregion

        #region PartClassDetail

        List<PartClassDetailDto> _PartClassDetail;

        #endregion

        #region PartGroups

        List<PartGroupsDto> _PartGroups;

        #endregion

        #region PartGroupsConst

        List<PartGroupsConstDto> _PartGroupsConst;

        #endregion

        #region CustomerData

        List<CustomerDataDto> _CustomerData;

        #endregion

        #region ColourCode

        List<ColourCodeDto> _ColourCode;

        #endregion

        #region MaterialGroups

        List<MaterialGroupsDto> _MaterialGroups;

        #endregion

        #region MaterialTypes

        List<MaterialTypesDto> _MaterialTypes;

        #endregion

        #region NPACustomer

        List<NPACustomerDto> _NPACustomer;

        #endregion

        #region NPASupplier

        List<NPASupplierDto> _NPASupplier;

        #endregion

        #region Suppliers

        List<SuppliersDto> _Suppliers;

        #endregion

        #endregion

        #region Fields and Properties

        #region CombinedParts

        IQueryHandler<GetCombinedPartsQuery, List<CombinedPartsDto>>? _CombinedPartsHandler;
        bool _CombinedPartsRefreshInProgress;

        #endregion

        #region PartCatogoryDetail

        IQueryHandler<GetPartCatogoryDetailQuery, List<PartCategoryDetailDto>>? _PartCatogoryDetailHandler;
        bool _PartCatogoryDetailRefreshInProgress;

        #endregion

        #region PartClassDetail

        IQueryHandler<GetPartClassDetailQuery, List<PartClassDetailDto>>? _PartClassDetailHandler;
        bool _PartClassDetailRefreshInProgress;

        #endregion

        #region PartGroups

        IQueryHandler<GetPartGroupsQuery, List<PartGroupsDto>>? _PartGroupsHandler;
        bool _PartGroupsRefreshInProgress;

        #endregion

        #region PartGroupsConst

        IQueryHandler<GetPartGroupsConstQuery, List<PartGroupsConstDto>>? _PartGroupsConstHandler;
        bool _PartGroupsConstRefreshInProgress;

        #endregion

        #region CustomerData

        IQueryHandler<GetCustomerDataQuery, List<CustomerDataDto>>? _CustomerDataHandler;
        bool _CustomerDataRefreshInProgress;

        #endregion

        #region ColourCode

        IQueryHandler<GetColourCodeQuery, List<ColourCodeDto>>? _ColourCodeHandler;
        bool _ColourCodeRefreshInProgress;

        #endregion

        #region MaterialGroups

        IQueryHandler<GetMaterialGroupsQuery, List<MaterialGroupsDto>>? _MaterialGroupsHandler;
        bool _MaterialGroupsRefreshInProgress;

        #endregion

        #region MaterialTypes

        IQueryHandler<GetMaterialTypesQuery, List<MaterialTypesDto>>? _MaterialTypesHandler;
        bool _MaterialTypesRefreshInProgress;

        #endregion

        #region NPACustomer

        IQueryHandler<GetNPACustomerQuery, List<NPACustomerDto>>? _NPACustomerHandler;
        bool _NPACustomerRefreshInProgress;

        #endregion

        #region NPASupplier

        IQueryHandler<GetNPASupplierQuery, List<NPASupplierDto>>? _NPASupplierHandler;
        bool _NPASupplierRefreshInProgress;

        #endregion

        #region Suppliers

        IQueryHandler<GetSuppliersQuery, List<SuppliersDto>>? _SuppliersHandler;
        bool _SuppliersRefreshInProgress;

        #endregion

        readonly IServiceProvider _ServiceProvider;
        #endregion

        #region Constructor
        public EMACSAccessService(IServiceProvider serviceProvider)
        {
            #region CombinedParts

            _CombinedParts = [];
            _CombinedPartsRefreshInProgress = false;

            #endregion

            #region PartCatogoryDetail

            _PartCatogoryDetail = [];
            _PartCatogoryDetailRefreshInProgress = false;

            #endregion

            #region PartClassDetail

            _PartClassDetail = [];
            _PartClassDetailRefreshInProgress = false;

            #endregion

            #region PartGroups

            _PartGroups = [];
            _PartGroupsRefreshInProgress = false;

            #endregion

            #region PartGroupsConst

            _PartGroupsConst = [];
            _PartGroupsConstRefreshInProgress = false;

            #endregion

            #region CustomerData

            _CustomerData = [];
            _CustomerDataRefreshInProgress = false;

            #endregion

            #region ColourCode

            _ColourCode = [];
            _ColourCodeRefreshInProgress = false;

            #endregion

            #region MaterialGroups

            _MaterialGroups = [];
            _MaterialGroupsRefreshInProgress = false;

            #endregion

            #region MaterialTypes

            _MaterialTypes = [];
            _MaterialTypesRefreshInProgress = false;

            #endregion

            #region NPACustomer

            _NPACustomer = [];
            _NPACustomerRefreshInProgress = false;

            #endregion

            #region NPASupplier

            _NPASupplier = [];
            _NPASupplierRefreshInProgress = false;

            #endregion

            #region Suppliers

            _Suppliers = [];
            _SuppliersRefreshInProgress = false;

            #endregion

            _ServiceProvider = serviceProvider;
        }
        #endregion

        #region Handlers

        #region CombinedParts
        public async Task<Result<List<CombinedPartsDto>>> GetAllCombinedParts(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_CombinedParts.Any())
            {
                return _CombinedParts;
            }
            else
            {
                await PopulateCombinedPartsAsync(cancellationToken);
                return _CombinedParts;
            }
        }

        public async Task<Result<int>> GetCombinedPartsDataCount(CancellationToken cancellationToken)
        {
            if (_CombinedParts.Any())
            {
                return _CombinedParts.Count;
            }
            else
            {
                await PopulateCombinedPartsAsync(cancellationToken);
                return _CombinedParts.Count;
            }
        }

        #endregion

        #region PartCategoryDetail

        public async Task<Result<List<PartCategoryDetailDto>>> GetAllPartCategoryDetail(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_PartCatogoryDetail.Any())
            {
                return _PartCatogoryDetail;
            }
            else
            {
                await PopulatePartCategoryDetailAsync(cancellationToken);
                return _PartCatogoryDetail;
            }
        }
        #endregion

        #region PartClassDetail

        public async Task<Result<List<PartClassDetailDto>>> GetAllPartClassDetail(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_PartClassDetail.Any())
            {
                return _PartClassDetail;
            }
            else
            {
                await PopulatePartClassDetailAsync(cancellationToken);
                return _PartClassDetail;
            }
        }
        #endregion

        #region PartGroups

        public async Task<Result<List<PartGroupsDto>>> GetAllPartGroups(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_PartGroups.Any())
            {
                return _PartGroups;
            }
            else
            {
                await PopulatePartGroupsAsync(cancellationToken);
                return _PartGroups;
            }
        }
        #endregion

        #region PartGroupsConst

        public async Task<Result<List<PartGroupsConstDto>>> GetAllPartGroupsConst(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_PartGroupsConst.Any())
            {
                return _PartGroupsConst;
            }
            else
            {
                await PopulatePartGroupsConstAsync(cancellationToken);
                return _PartGroupsConst;
            }
        }
        #endregion

        #region CustomerData
        public async Task<Result<List<CustomerDataDto>>> GetAllCustomerData(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_CustomerData.Any())
            {
                return _CustomerData;
            }
            else
            {
                await PopulateCustomerDataAsync(cancellationToken);
                return _CustomerData;
            }
        }
        #endregion

        #region ColourCode
        public async Task<Result<List<ColourCodeDto>>> GetAllColourCode(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_ColourCode.Any())
            {
                return _ColourCode;
            }
            else
            {
                await PopulateColourCodeAsync(cancellationToken);
                return _ColourCode;
            }
        }
        #endregion

        #region MaterialGroups
        public async Task<Result<List<MaterialGroupsDto>>> GetAllMaterialGroups(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_MaterialGroups.Any())
            {
                return _MaterialGroups;
            }
            else
            {
                await PopulateMaterialGroupsAsync(cancellationToken);
                return _MaterialGroups;
            }
        }
        #endregion

        #region MaterialTypes
        public async Task<Result<List<MaterialTypesDto>>> GetAllMaterialTypes(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_MaterialTypes.Any())
            {
                return _MaterialTypes;
            }
            else
            {
                await PopulateMaterialTypesAsync(cancellationToken);
                return _MaterialTypes;
            }
        }
        #endregion

        #region NPACustomer
        public async Task<Result<List<NPACustomerDto>>> GetAllNPACustomer(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_NPACustomer.Any())
            {
                return _NPACustomer;
            }
            else
            {
                await PopulateNPACustomerAsync(cancellationToken);
                return _NPACustomer;
            }
        }
        #endregion

        #region NPASupplier
        public async Task<Result<List<NPASupplierDto>>> GetAllNPASupplier(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_NPASupplier.Any())
            {
                return _NPASupplier;
            }
            else
            {
                await PopulateNPASupplierAsync(cancellationToken);
                return _NPASupplier;
            }
        }
        #endregion

        #region Suppliers
        public async Task<Result<List<SuppliersDto>>> GetAllSuppliers(CancellationToken cancellationToken)
        {
            await Task.Delay(1, cancellationToken);
            if (_Suppliers.Any())
            {
                return _Suppliers;
            }
            else
            {
                await PopulateSuppliersAsync(cancellationToken);
                return _Suppliers;
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
                    _CombinedPartsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCombinedPartsQuery, List<CombinedPartsDto>>>();
                    _CombinedPartsRefreshInProgress = true;
                    GetCombinedPartsQuery query = new GetCombinedPartsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CombinedPartsDto>> results = await _CombinedPartsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CombinedParts.Clear();
                        _CombinedParts = results.Value;
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
                    _PartCatogoryDetailHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartCatogoryDetailQuery, List<PartCategoryDetailDto>>>();
                    _PartCatogoryDetailRefreshInProgress = true;
                    GetPartCatogoryDetailQuery query = new GetPartCatogoryDetailQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartCategoryDetailDto>> results = await _PartCatogoryDetailHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _PartCatogoryDetail.Clear();
                        _PartCatogoryDetail = results.Value;
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
                    _PartClassDetailHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartClassDetailQuery, List<PartClassDetailDto>>>();
                    _PartClassDetailRefreshInProgress = true;
                    GetPartClassDetailQuery query = new GetPartClassDetailQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartClassDetailDto>> results = await _PartClassDetailHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _PartClassDetail.Clear();
                        _PartClassDetail = results.Value;
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
                    _PartGroupsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartGroupsQuery, List<PartGroupsDto>>>();
                    _PartGroupsRefreshInProgress = true;
                    GetPartGroupsQuery query = new GetPartGroupsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartGroupsDto>> results = await _PartGroupsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _PartGroups.Clear();
                        _PartGroups = results.Value;
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
                    _PartGroupsConstHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetPartGroupsConstQuery, List<PartGroupsConstDto>>>();
                    _PartGroupsConstRefreshInProgress = true;
                    GetPartGroupsConstQuery query = new GetPartGroupsConstQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<PartGroupsConstDto>> results = await _PartGroupsConstHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _PartGroupsConst.Clear();
                        _PartGroupsConst = results.Value;
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
                    _CustomerDataHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetCustomerDataQuery, List<CustomerDataDto>>>();
                    _CustomerDataRefreshInProgress = true;
                    GetCustomerDataQuery query = new GetCustomerDataQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<CustomerDataDto>> results = await _CustomerDataHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _CustomerData.Clear();
                        _CustomerData = results.Value;
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
                    _ColourCodeHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetColourCodeQuery, List<ColourCodeDto>>>();
                    _ColourCodeRefreshInProgress = true;
                    GetColourCodeQuery query = new GetColourCodeQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<ColourCodeDto>> results = await _ColourCodeHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _ColourCode.Clear();
                        _ColourCode = results.Value;
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
                    _MaterialGroupsHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetMaterialGroupsQuery, List<MaterialGroupsDto>>>();
                    _MaterialGroupsRefreshInProgress = true;
                    GetMaterialGroupsQuery query = new GetMaterialGroupsQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MaterialGroupsDto>> results = await _MaterialGroupsHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _MaterialGroups.Clear();
                        _MaterialGroups = results.Value;
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
                    _MaterialTypesHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetMaterialTypesQuery, List<MaterialTypesDto>>>();
                    _MaterialTypesRefreshInProgress = true;
                    GetMaterialTypesQuery query = new GetMaterialTypesQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<MaterialTypesDto>> results = await _MaterialTypesHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _MaterialTypes.Clear();
                        _MaterialTypes = results.Value;
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
                    _NPACustomerHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetNPACustomerQuery, List<NPACustomerDto>>>();
                    _NPACustomerRefreshInProgress = true;
                    GetNPACustomerQuery query = new GetNPACustomerQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<NPACustomerDto>> results = await _NPACustomerHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _NPACustomer.Clear();
                        _NPACustomer = results.Value;
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
                    _NPASupplierHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetNPASupplierQuery, List<NPASupplierDto>>>();
                    _NPASupplierRefreshInProgress = true;
                    GetNPASupplierQuery query = new GetNPASupplierQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<NPASupplierDto>> results = await _NPASupplierHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _NPASupplier.Clear();
                        _NPASupplier = results.Value;
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
                    _SuppliersHandler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetSuppliersQuery, List<SuppliersDto>>>();
                    _SuppliersRefreshInProgress = true;
                    GetSuppliersQuery query = new GetSuppliersQuery();
                    await Task.Delay(1, cancellationToken);
                    Result<List<SuppliersDto>> results = await _SuppliersHandler.Handle(query, cancellationToken);
                    if (results.Value.Count <= 0)
                    {
                    }
                    else
                    {
                        _Suppliers.Clear();
                        _Suppliers = results.Value;
                    }

                    _SuppliersRefreshInProgress = false;
                    return true;
                }
            }

            return false;
        }
        #endregion

        #endregion
    }
}
