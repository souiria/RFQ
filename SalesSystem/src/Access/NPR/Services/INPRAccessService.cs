using System.Collections.ObjectModel;

namespace NPR.Services
{
    public interface INPRAccessService
    {
        #region H1NPIView
        Task<ListH1NPRViewGrpc> GetAllH1NPRView(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListRFQStatusGrpc> GetAllRFQStatus(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateH1NPRViewAsync(CancellationToken cancellationToken);
        Task<bool> PopulateRFQStatusAsync(CancellationToken cancellationToken);
        #endregion

        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
        Task<List<RfqNprRequestSetModel>> LoadNprRequestSetsFromBackendAsync(CancellationToken cancellationToken);
        Task SaveNprRequestSetsToBackendAsync(ReadOnlyCollection<RfqNprRequestSetModel> sets, CancellationToken cancellationToken);
        Task<List<RfqNprRequestModel>> LoadDuplicatedNprRequestsAsync(CancellationToken cancellationToken, bool includeEmptyKeys = false, bool removeFormatting = true);
        Task<List<RfqNprRequestSetModel>> LoadNprSetsWithoutDuplicatesAndSaveRemovedAsync(CancellationToken cancellationToken, bool includeEmptyKeys = false, bool removeFormatting = true, string? duplicatesOutputPath = null);
    }
}
