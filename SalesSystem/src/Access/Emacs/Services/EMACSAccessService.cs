
namespace Emacs.Services
{
    public class EMACSAccessService : IEMACSAccessService
    {
        #region In Memory Datasets

        #region CombinedParts

        List<CombinedPartsDto> _CombinedParts;

        #endregion

        #endregion

        #region Fields and Properties

        #region CombinedParts

        IQueryHandler<GetCombinedPartsQuery, List<CombinedPartsDto>>? _CombinedPartsHandler;
        bool _CombinedPartsRefreshInProgress;

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

        #endregion
    }
}
