namespace CDb.CQRS.Command.Masters.TemperatureRange
{
    public record TemperatureRangeCommand(CommandType CommandType, ICollection<TemperatureRangeGrpc> TemperatureRangeGrpcs) : ICommand;
}
