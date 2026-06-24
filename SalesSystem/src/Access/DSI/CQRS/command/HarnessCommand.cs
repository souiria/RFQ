namespace DSI.CQRS.Command
{
    public record HarnessCommand(CommandType CommandType, ICollection<HarnessGrpc> HarnessGrpcs)
        : ICommand<List<DbHarness>>;
}
