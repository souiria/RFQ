namespace NPR.Services
{
    public interface INPRAccessService
    {
        #region H1NPIView
        Task<ListH1NPRViewGrpc> GetAllH1NPRView(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateH1NPRViewAsync(CancellationToken cancellationToken);
        #endregion

        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
    }
}
