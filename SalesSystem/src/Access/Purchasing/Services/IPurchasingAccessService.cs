namespace Purchasing.Services
{
    public interface IPurchasingAccessService
    {
        #region H1CPD

        Task<ListH1CPDGrpc> GetAllH1CPD(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);

        Task<bool> PopulateH1CPD(CancellationToken cancellationToken);

        #endregion

        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
    }
}
