namespace EngSol.CQRS.Query.Derivatives
{
    public class GetDerivativesQuery : IQuery<List<DerivativeGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
