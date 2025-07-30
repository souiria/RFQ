namespace CDb.CQRS.Command.Partner
{
    public record PartnerCommand(CommandType CommandType, ICollection<PartnerGrpc> PartnerGrpcs) : ICommand;
}
