namespace CDb.CQRS.Command.Person
{
    public record PersonCommand(CommandType CommandType, ICollection<PersonGrpc> PersonGrpcs) : ICommand;
}
