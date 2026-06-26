namespace EngSol.Services
{
    public interface IEngSolAccessService
    {
        #region DerivativeWires
        Task<ListDerivativeWiresGrpc> GetAllDerivativeWires(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<DerivativeWiresGrpc> GetDerivativeWireById(int derivativeId, CancellationToken cancellationToken);

        Task<bool> PopulateDerivativeWiresAsync(CancellationToken cancellationToken);
        #endregion
    }
}
