namespace Rfq.CQRS.Handler.DsiModuleCompatibility
{
    public class CommandHandler : ICommandHandler<DsiModuleCompatibilityCommand, List<DbDsiModuleCompatibility>>
    {
        public IRfqRepository<DbDsiModuleCompatibility> Repository 
        { get; }

        public CommandHandler(IRfqRepository<DbDsiModuleCompatibility> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiModuleCompatibility>>> Handle(DsiModuleCompatibilityCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiModuleCompatibility> components = command.DsiModuleCompatibilityGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiModuleCompatibility> results = new List<DbDsiModuleCompatibility>();
            results.Clear();
            IEnumerable<DbDsiModuleCompatibility> repositoryActionResult;
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
                default:
                {
                    Error error = new Error("InvalidCommand", "The command type is not supported.", ErrorType.Failure);
                    Result<List<DbDsiModuleCompatibility>> failedResult = new Result<List<DbDsiModuleCompatibility>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiModuleCompatibility>> result;
            if (success)
            {
                result = new Result<List<DbDsiModuleCompatibility>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiModuleCompatibility>>(results, false, error);
            }

            return result;
        }
    }
}

