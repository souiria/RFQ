namespace EngSol.Services
{
    public interface IEngSolAccessService
    {
        #region DerivativeWires
        Task<List<DerivativeWiresGrpc>> GetDerivativeWiresByDerivativeId(int derivativeId, CancellationToken cancellationToken);
        #endregion

        #region DerivativeParts
        Task<List<DerivativePartsGrpc>> GetDerivativePartsByDerivativeId(int derivativeId, CancellationToken cancellationToken);

        #endregion

        #region Derivatives
        Task<ListDerivatives> GetAllDerivatives(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<DerivativeGrpc> GetDerivativeByDerivativeId(int derivativeId, CancellationToken cancellationToken);
        Task<bool> PopulateDerivativesAsync(CancellationToken cancellationToken);
        #endregion

        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
    }
}
