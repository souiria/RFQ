namespace CDb.CQRS.Command.Masters.WaterproofType
{
    public record WaterproofTypeCommand(CommandType CommandType, ICollection<WaterproofTypeGrpc> WaterproofTypeGrpcs) : ICommand;
}
