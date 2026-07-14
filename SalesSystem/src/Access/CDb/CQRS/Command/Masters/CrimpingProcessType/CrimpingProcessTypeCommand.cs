namespace CDb.CQRS.Command.Masters.CrimpingProcessType
{
    public record CrimpingProcessTypeCommand(CommandType CommandType, ICollection<CrimpingProcessTypeGrpc> CrimpingProcessTypeGrpcs) : ICommand;
}
