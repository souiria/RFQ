namespace CDb.CQRS.Command.TemperatureRange
{
    public record TemperatureRangeCommand(CommandType CommandType, ICollection<TemperatureRangeGrpc> TemperatureRangeGrpcs) : ICommand;
}
