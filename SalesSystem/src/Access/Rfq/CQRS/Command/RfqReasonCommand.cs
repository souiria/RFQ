namespace Rfq.CQRS.Command
{
    public record RfqReasonCommand(CommandType CommandType, ICollection<RfqReasonGrpc> RfqReasonGrpcs) : ICommand<List<DbRfqReason>>
    {
    }
}
