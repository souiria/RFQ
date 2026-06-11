namespace DSI.CQRS.command
{
    public record BranchInsulationCommand(
        CommandType CommandType,
        ICollection<BranchInsulationGrpc> BranchInsulationGrpcs)
        : ICommand<List<DbBranchInsulation>>;
}
