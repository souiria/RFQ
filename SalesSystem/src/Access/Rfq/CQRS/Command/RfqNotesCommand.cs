namespace Rfq.CQRS.Command
{
    public record RfqNotesCommand(CommandType CommandType, ICollection<RfqNotesGrpc> RfqNotesGrpcs) : ICommand<List<DbRfqNotes>>
    {
    }
}
