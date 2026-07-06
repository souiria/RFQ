namespace EngSol.CQRS.Query.DerivativeWires
{
    public class GetDerivativeWireByDerivativeIdQuery : IQuery<List<DerivativeWiresGrpc>>
    {
        public int? Id
        { get; set; }
    }
}
