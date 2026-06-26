namespace EngSol.CQRS.Query.DerivativeWires
{
    public class GetDerivativeWireByIdQuery : IQuery<List<DerivativeWiresGrpc>>
    {
        public int? Id
        { get; set; }
    }
}
