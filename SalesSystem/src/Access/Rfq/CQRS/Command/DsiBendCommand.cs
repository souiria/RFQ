namespace Rfq.CQRS.Command
{
    public record DsiBendCommand(CommandType CommandType, ICollection<DsiBendGrpc> DsiBendGrpcs) : ICommand<List<DbDsiBend>>
    {
    }
}
