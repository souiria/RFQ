namespace CDb.CQRS.Command.Masters.Partner
{
    public record PartnerCommand(CommandType CommandType, ICollection<PartnerGrpc> PartnerGrpcs) : ICommand;
}
