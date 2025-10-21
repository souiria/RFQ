namespace Rfq.CQRS.Handler.DsiManualBomQuantity
{
    public class CommandHandler : ICommandHandler<DsiManualBomQuantityCommand, List<DbDsiManualBomQuantity>>
    {
        public IRfqRepository<DbDsiManualBomQuantity> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiManualBomQuantity> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiManualBomQuantity>>> Handle(DsiManualBomQuantityCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiManualBomQuantity> components = command.DsiManualBomQuantityGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiManualBomQuantity> results = new List<DbDsiManualBomQuantity>();
            results.Clear();
            IEnumerable<DbDsiManualBomQuantity> repositoryActionResult;
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
                    Result<List<DbDsiManualBomQuantity>> failedResult = new Result<List<DbDsiManualBomQuantity>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiManualBomQuantity>> result;
            if (success)
            {
                result = new Result<List<DbDsiManualBomQuantity>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiManualBomQuantity>>(results, false, error);
            }

            return result;
        }
    }
}

