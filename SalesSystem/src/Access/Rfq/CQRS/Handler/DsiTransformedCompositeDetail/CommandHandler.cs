namespace Rfq.CQRS.Handler.DsiTransformedCompositeDetail
{
    public class CommandHandler : ICommandHandler<DsiTransformedCompositeDetailCommand, List<DbDsiTransformedCompositeDetail>>
    {
        public IRfqRepository<DbDsiTransformedCompositeDetail> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiTransformedCompositeDetail> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiTransformedCompositeDetail>>> Handle(DsiTransformedCompositeDetailCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiTransformedCompositeDetail> components = command.DsiTransformedCompositeDetailGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiTransformedCompositeDetail> results = new List<DbDsiTransformedCompositeDetail>();
            results.Clear();
            IEnumerable<DbDsiTransformedCompositeDetail> repositoryActionResult;
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
                    Result<List<DbDsiTransformedCompositeDetail>> failedResult = new Result<List<DbDsiTransformedCompositeDetail>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiTransformedCompositeDetail>> result;
            if (success)
            {
                result = new Result<List<DbDsiTransformedCompositeDetail>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiTransformedCompositeDetail>>(results, false, error);
            }

            return result;
        }
    }
}
