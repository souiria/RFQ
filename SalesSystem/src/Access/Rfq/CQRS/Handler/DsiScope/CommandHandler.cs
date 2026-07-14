namespace Rfq.CQRS.Handler.DsiScope
{
    public class CommandHandler : ICommandHandler<DsiScopeCommand, List<DbDsiScope>>
    {
        public IRfqRepository<DbDsiScope> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiScope> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiScope>>> Handle(DsiScopeCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiScope> components = command.DsiScopeGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiScope> results = new List<DbDsiScope>();
            results.Clear();
            IEnumerable<DbDsiScope> repositoryActionResult;
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
                    Result<List<DbDsiScope>> failedResult = new Result<List<DbDsiScope>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiScope>> result;
            if (success)
            {
                result = new Result<List<DbDsiScope>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiScope>>(results, false, error);
            }

            return result;
        }
    }
}