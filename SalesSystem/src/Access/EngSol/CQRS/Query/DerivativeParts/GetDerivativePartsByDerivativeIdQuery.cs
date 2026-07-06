namespace EngSol.CQRS.Query.DerivativeParts
{
    public class GetDerivativePartsByDerivativeIdQuery : IQuery<List<DerivativePartsGrpc>>
    {
        public int? Id
        { get; set; }
    }
}
