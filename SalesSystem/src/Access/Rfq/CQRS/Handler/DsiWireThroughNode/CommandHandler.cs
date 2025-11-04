namespace Rfq.CQRS.Handler.DsiWireThroughNode
{
    public class CommandHandler : ICommandHandler<DsiWireThroughNodeCommand, List<DbDsiWireThroughNode>>
    {
        public IRfqRepository<DbDsiWireThroughNode> Repository 
        { get; }

        public CommandHandler(IRfqRepository<DbDsiWireThroughNode> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiWireThroughNode>>> Handle(DsiWireThroughNodeCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiWireThroughNode> components = command.DsiWireThroughNodeGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiWireThroughNode> results = new List<DbDsiWireThroughNode>();
            results.Clear();
            IEnumerable<DbDsiWireThroughNode> repositoryActionResult;
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
                    Result<List<DbDsiWireThroughNode>> failedResult = new Result<List<DbDsiWireThroughNode>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiWireThroughNode>> result;
            if (success)
            {
                result = new Result<List<DbDsiWireThroughNode>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiWireThroughNode>>(results, false, error);
            }

            return result;
        }
    }
}
