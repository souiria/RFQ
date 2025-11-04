namespace Rfq.CQRS.Handler.DsiModuleChildDetail
{
    public class CommandHandler : ICommandHandler<DsiModuleChildDetailCommand, List<DbDsiModuleChildDetail>>
    {
        public IRfqRepository<DbDsiModuleChildDetail> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiModuleChildDetail> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiModuleChildDetail>>> Handle(DsiModuleChildDetailCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiModuleChildDetail> components = command.DsiModuleChildDetailGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiModuleChildDetail> results = new List<DbDsiModuleChildDetail>();
            results.Clear();
            IEnumerable<DbDsiModuleChildDetail> repositoryActionResult;
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
                    Result<List<DbDsiModuleChildDetail>> failedResult = new Result<List<DbDsiModuleChildDetail>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiModuleChildDetail>> result;
            if (success)
            {
                result = new Result<List<DbDsiModuleChildDetail>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiModuleChildDetail>>(results, false, error);
            }

            return result;
        }
    }
}
