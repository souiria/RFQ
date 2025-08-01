namespace CDb.CQRS.Command.Masters.Person
{
    public record PersonCommand(CommandType CommandType, ICollection<PersonGrpc> PersonGrpcs) : ICommand;
}
