namespace CDb.CQRS.Command.CrimpingProcessType
{
    public record CrimpingProcessTypeCommand(CommandType CommandType, ICollection<CrimpingProcessTypeGrpc> CrimpingProcessTypeGrpcs) : ICommand;
}
