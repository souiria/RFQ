namespace Rfq.CQRS.Handler.DsiCompositeDetail
{
    public class CommandHandler : ICommandHandler<DsiCompositeDetailCommand, List<DbDsiCompositeDetail>>
    {
        public IRfqRepository<DbDsiCompositeDetail> Repository 
        { get; }

        public CommandHandler(IRfqRepository<DbDsiCompositeDetail> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiCompositeDetail>>> Handle(DsiCompositeDetailCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiCompositeDetail> components = command.DsiCompositeDetailGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiCompositeDetail> results = new List<DbDsiCompositeDetail>();
            results.Clear();
            IEnumerable<DbDsiCompositeDetail> repositoryActionResult;
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
                    Result<List<DbDsiCompositeDetail>> failedResult = new Result<List<DbDsiCompositeDetail>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiCompositeDetail>> result;
            if (success)
            {
                result = new Result<List<DbDsiCompositeDetail>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiCompositeDetail>>(results, false, error);
            }

            return result;
        }
    }
}
