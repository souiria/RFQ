namespace CPD.Services
{
    public interface ICPDAccessService
    {
        #region MatSuppMst
        Task<ListMatSuppMstGrpc> GetAllMatSuppMstView(CancellationToken cancellationToken);
        Task<bool> PopulateMatSuppMstView(CancellationToken cancellationToken);
        #endregion

        #region HarnessCostingCalculationData
        Task<ListHarnessCostingCalculationDataGrpc> GetHarnessCostingCalculationDataView(CancellationToken cancellationToken);
        Task<bool> PopulateHarnessCostingCalculationDataView(CancellationToken cancellationToken);
        #endregion
    }
}
