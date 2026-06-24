using Emacs;

namespace EngSol.CQRS.Query.DerivativeWires
{
    public class GetDerivativeWiresQuery : IQuery<List<DerivativeWiresGrpc>>
    {
        public int? Position
        { get; set; }
        public int? TakeAmount
        { get; set; }
    }
}
