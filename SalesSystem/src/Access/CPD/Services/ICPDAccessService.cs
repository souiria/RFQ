namespace CPD.Services
{
    public interface ICPDAccessService
    {
        #region MatSuppMst
        Task<ListMatSuppMstGrpc> GetAllMatSuppMstView(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateMatSuppMstView(CancellationToken cancellationToken);
        #endregion

        #region HarnessCostingCalculationData
        Task<ListHarnessCostingCalculationDataGrpc> GetHarnessCostingCalculationDataView(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateHarnessCostingCalculationDataView(CancellationToken cancellationToken);
        #endregion

        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
    }
}
