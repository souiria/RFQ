namespace DSI.CQRS.Command
{
    public record BranchInsulationCommand(
        CommandType CommandType,
        ICollection<BranchInsulationGrpc> BranchInsulationGrpcs)
        : ICommand<List<DbBranchInsulation>>;
}
