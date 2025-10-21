namespace Rfq.CQRS.Handler.DsiTransformedModuleChildDetail
{
    public class CommandHandler : ICommandHandler<DsiTransformedModuleChildDetailCommand, List<DbDsiTransformedModuleChildDetail>>
    {
        public IRfqRepository<DbDsiTransformedModuleChildDetail> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiTransformedModuleChildDetail> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiTransformedModuleChildDetail>>> Handle(DsiTransformedModuleChildDetailCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiTransformedModuleChildDetail> components = command.DsiTransformedModuleChildDetailGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiTransformedModuleChildDetail> results = new List<DbDsiTransformedModuleChildDetail>();
            results.Clear();
            IEnumerable<DbDsiTransformedModuleChildDetail> repositoryActionResult;
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
                    Result<List<DbDsiTransformedModuleChildDetail>> failedResult = new Result<List<DbDsiTransformedModuleChildDetail>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiTransformedModuleChildDetail>> result;
            if (success)
            {
                result = new Result<List<DbDsiTransformedModuleChildDetail>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiTransformedModuleChildDetail>>(results, false, error);
            }

            return result;
        }
    }
}
