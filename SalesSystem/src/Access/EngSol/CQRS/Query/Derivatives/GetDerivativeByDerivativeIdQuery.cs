namespace EngSol.CQRS.Query.Derivatives
{
    public class GetDerivativeByDerivativeIdQuery : IQuery<DerivativeGrpc>
    {
        public int Id
        { get; set; }
    }
}
