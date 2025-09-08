namespace Rfq.CQRS.Handler.RfqNotes
{
    public class CommandHandler : ICommandHandler<RfqNotesCommand, List<DbRfqNotes>>
    {
        public IRfqRepository<DbRfqNotes> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbRfqNotes> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbRfqNotes>>> Handle(RfqNotesCommand command, CancellationToken cancellationToken)
        {
            List<DbRfqNotes> components = command.RfqNotesGrpcs.Select(rfqNotesGrpc => rfqNotesGrpc.ToEntity()).ToList();
            List<DbRfqNotes> results = new List<DbRfqNotes>();
            IEnumerable<DbRfqNotes> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                repositoryActionResult = await Repository.AddRangeAsync(components, cancellationToken);
                success = repositoryActionResult.Count() == components.Count;
                results = repositoryActionResult.ToList();
                break;
                case CommandType.Update:
                updateDeleteCount = await Repository.UpdateRangeAsync(components, cancellationToken);
                success = updateDeleteCount == components.Count;
                break;
                case CommandType.Delete:
                updateDeleteCount = await Repository.DeleteRangeAsync(components, cancellationToken);
                success = updateDeleteCount == components.Count;
                break;
                default:
                {
                    Error error = new Error("InvalidCommand", "The command type is not supported.", ErrorType.Failure);
                    Result<List<DbRfqNotes>> failedResult = new Result<List<DbRfqNotes>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbRfqNotes>> result;
            if (success)
            {
                result = new Result<List<DbRfqNotes>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbRfqNotes>>(results, false, error);
            }

            return result;
        }
    }
}
