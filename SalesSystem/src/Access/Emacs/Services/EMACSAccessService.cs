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

        #region PartGroupsDetail

        IQueryHandler<GetPartGroupsQuery, List<PartGroupsDto>>? _PartGroupsHandler;
        bool _PartGroupsRefreshInProgress;

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

            #region PartGroups

            _PartGroups = [];
            _PartGroupsRefreshInProgress = false;

            #endregion

            #region PartClassDetail

            _PartClassDetail = [];
            _PartClassDetailRefreshInProgress = false;

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

        #region PartGroupDetail

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

        #endregion
    }
}
