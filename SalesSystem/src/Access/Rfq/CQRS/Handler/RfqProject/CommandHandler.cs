namespace Rfq.CQRS.Handler.RfqProject
{
    public class CommandHandler : ICommandHandler<RfqProjectCommand, List<DbRfqProject>>
    {
        public IRfqRepository<DbRfqProject> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbRfqProject> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbRfqProject>>> Handle(RfqProjectCommand command, CancellationToken cancellationToken)
        {
            List<DbRfqProject> components = command.RfqProjectGrpcs.Select(rfqProjectGrpc => rfqProjectGrpc.ToEntity()).ToList();

            List<DbRfqProject> results = new List<DbRfqProject>();
            IEnumerable<DbRfqProject> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;
            switch(command.CommandType)
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
                        Result<List<DbRfqProject>> failedResult = new Result<List<DbRfqProject>>(results, false, error);
                    return failedResult;
                    }
            }

            if (success)
            {
                Result<List<DbRfqProject>> result = new Result<List<DbRfqProject>>(results, true, Error.None);
                return result;
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                Result<List<DbRfqProject>> result = new Result<List<DbRfqProject>>(results, false, error);
                return result;
            }
        }
    }
}
