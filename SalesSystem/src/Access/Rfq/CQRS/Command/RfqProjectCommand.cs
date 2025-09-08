namespace Rfq.CQRS.Command
{
    public record RfqProjectCommand(CommandType CommandType, ICollection<RfqProjectGrpc> RfqProjectGrpcs) : ICommand<List<DbRfqProject>>
    {
    }
}
