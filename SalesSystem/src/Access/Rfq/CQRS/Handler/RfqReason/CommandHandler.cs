namespace Rfq.CQRS.Handler.RfqReason
{
    public class CommandHandler : ICommandHandler<RfqReasonCommand, List<DbRfqReason>>
    {
        public IRfqRepository<DbRfqReason> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbRfqReason> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbRfqReason>>> Handle(RfqReasonCommand command, CancellationToken cancellationToken)
        {
            List<DbRfqReason> components = command.RfqReasonGrpcs.Select(rfqReasonGrpc => rfqReasonGrpc.ToEntity()).ToList();
            List<DbRfqReason> results = new List<DbRfqReason>();
            IEnumerable<DbRfqReason> repositoryActionResult;
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
                    Result<List<DbRfqReason>> failedResult = new Result<List<DbRfqReason>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbRfqReason>> result;
            if (success)
            {
                result = new Result<List<DbRfqReason>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbRfqReason>>(results, false, error);
            }

            return result;
        }
    }
}
