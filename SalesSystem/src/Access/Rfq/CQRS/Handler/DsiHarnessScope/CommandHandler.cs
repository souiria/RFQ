namespace Rfq.CQRS.Handler.DsiHarnessScope
{
    public class CommandHandler : ICommandHandler<DsiHarnessScopeCommand, List<DbDsiHarnessScope>>
    {
        public IRfqRepository<DbDsiHarnessScope> Repository 
        { get; }

        public CommandHandler(IRfqRepository<DbDsiHarnessScope> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiHarnessScope>>> Handle(DsiHarnessScopeCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiHarnessScope> components = command.DsiHarnessScopeGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiHarnessScope> results = new List<DbDsiHarnessScope>();
            results.Clear();
            IEnumerable<DbDsiHarnessScope> repositoryActionResult;
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
                    Result<List<DbDsiHarnessScope>> failedResult = new Result<List<DbDsiHarnessScope>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiHarnessScope>> result;
            if (success)
            {
                result = new Result<List<DbDsiHarnessScope>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiHarnessScope>>(results, false, error);
            }

            return result;
        }
    }
}

