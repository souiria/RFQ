namespace DSI.CQRS.command
{
    public record ComponentCommand(CommandType CommandType, ICollection<ComponentGrpc> ComponentGrpcs)
        : ICommand<List<DbComponent>>;

}
