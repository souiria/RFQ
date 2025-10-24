namespace Rfq.CQRS.Handler.DsiMulticoreSpecification
{
    public class CommandHandler : ICommandHandler<DsiMulticoreSpecificationCommand, List<DbDsiMulticoreSpecification>>
    {
        public IRfqRepository<DbDsiMulticoreSpecification> Repository 
        { get; }

        public CommandHandler(IRfqRepository<DbDsiMulticoreSpecification> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiMulticoreSpecification>>> Handle(DsiMulticoreSpecificationCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiMulticoreSpecification> components = command.DsiMulticoreSpecificationGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiMulticoreSpecification> results = new List<DbDsiMulticoreSpecification>();
            results.Clear();
            IEnumerable<DbDsiMulticoreSpecification> repositoryActionResult;
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
                    Result<List<DbDsiMulticoreSpecification>> failedResult = new Result<List<DbDsiMulticoreSpecification>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiMulticoreSpecification>> result;
            if (success)
            {
                result = new Result<List<DbDsiMulticoreSpecification>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiMulticoreSpecification>>(results, false, error);
            }

            return result;
        }
    }
}
