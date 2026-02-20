namespace Rfq.CQRS.Command
{
    public record RfqNprRequestCommand(CommandType CommandType, ICollection<RfqNprRequestGrpc> RfqNprRequestGrpcs) : ICommand<List<DbRfqNprRequestModel>>
    {
    }
}
