namespace CPD.Services
{
    public interface ICPDAccessService
    {
        #region MATSUPPMST
        Task<ListMatSuppMstGrpc> GetAllMatSuppMstView(CancellationToken cancellationToken);
        Task<bool> PopulateMatSuppMstView(CancellationToken cancellationToken);
        #endregion
    }
}
