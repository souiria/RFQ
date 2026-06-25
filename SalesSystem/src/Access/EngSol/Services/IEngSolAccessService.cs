namespace EngSol.Services
{
    public interface IEngSolAccessService
    {
        #region DerivativeWires
        Task<ListDerivativeWiresGrpc> GetAllDerivativeWires(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);

        Task<bool> PopulateIDerivativeWiresAsync(CancellationToken cancellationToken);
        #endregion
    }
}
