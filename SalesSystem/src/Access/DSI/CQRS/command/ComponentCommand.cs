namespace DSI.CQRS.Command
{
    public record ComponentCommand(CommandType CommandType, ICollection<ComponentGrpc> ComponentGrpcs)
        : ICommand<List<DbComponent>>;

}
