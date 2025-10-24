namespace Rfq.CQRS.Handler.DsiUnitOfMeasure
{
    public class CommandHandler : ICommandHandler<DsiUnitOfMeasureCommand, List<DbDsiUnitOfMeasure>>
    {
        public IRfqRepository<DbDsiUnitOfMeasure> Repository 
        { get; }

        public CommandHandler(IRfqRepository<DbDsiUnitOfMeasure> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiUnitOfMeasure>>> Handle(DsiUnitOfMeasureCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiUnitOfMeasure> components = command.DsiUnitOfMeasureGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiUnitOfMeasure> results = new List<DbDsiUnitOfMeasure>();
            results.Clear();
            IEnumerable<DbDsiUnitOfMeasure> repositoryActionResult;
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
                    Result<List<DbDsiUnitOfMeasure>> failedResult = new Result<List<DbDsiUnitOfMeasure>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiUnitOfMeasure>> result;
            if (success)
            {
                result = new Result<List<DbDsiUnitOfMeasure>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiUnitOfMeasure>>(results, false, error);
            }

            return result;
        }
    }
}
