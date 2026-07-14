namespace Rfq.CQRS.Command
{
    public record RfqDrawingPartNumberCommand(CommandType CommandType, ICollection<RfqDrawingPartNumbersGrpc> RfqDrawingPartNumbersGrpcs) : ICommand<List<DbRfqDrawingPartNumber>>
    {
    }
}
