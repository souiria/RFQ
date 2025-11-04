namespace Rfq.CQRS.Handler.DsiSupplier
{
    public class CommandHandler : ICommandHandler<DsiSupplierCommand, List<DbDsiSupplier>>
    {
        public IRfqRepository<DbDsiSupplier> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiSupplier> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiSupplier>>> Handle(DsiSupplierCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiSupplier> components = command.DsiSupplierGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiSupplier> results = new List<DbDsiSupplier>();
            results.Clear();
            IEnumerable<DbDsiSupplier> repositoryActionResult;
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
                    Result<List<DbDsiSupplier>> failedResult = new Result<List<DbDsiSupplier>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiSupplier>> result;
            if (success)
            {
                result = new Result<List<DbDsiSupplier>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiSupplier>>(results, false, error);
            }

            return result;
        }
    }
}
