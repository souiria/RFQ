namespace DSI.CQRS.command
{
    public record HarnessCommand(CommandType CommandType, ICollection<HarnessGrpc> HarnessGrpcs)
        : ICommand<List<DbHarness>>;
}
