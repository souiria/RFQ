namespace CDb.CQRS.Command.WaterproofType
{
    public record WaterproofTypeCommand(CommandType CommandType, ICollection<WaterproofTypeGrpc> WaterproofTypeGrpcs) : ICommand;
}
