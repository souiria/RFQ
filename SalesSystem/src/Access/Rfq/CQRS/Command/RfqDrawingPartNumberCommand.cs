namespace Rfq.CQRS.Command
{
    public record RfqDrawingPartNumberCommand(CommandType CommandType, ICollection<RfqDrawingPartNumberGrpc> RfqDrawingPartNumbersGrpcs) : ICommand<List<DbRfqDrawingPartNumber>>
    {
    }
}
