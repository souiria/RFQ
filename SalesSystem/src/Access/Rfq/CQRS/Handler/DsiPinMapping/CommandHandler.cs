namespace Rfq.CQRS.Handler.DsiPinMapping
{
    public class CommandHandler : ICommandHandler<DsiPinMappingCommand, List<DbDsiPinMapping>>
    {
        public IRfqRepository<DbDsiPinMapping> Repository 
        { get; }

        public CommandHandler(IRfqRepository<DbDsiPinMapping> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiPinMapping>>> Handle(DsiPinMappingCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiPinMapping> components = command.DsiPinMappingGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiPinMapping> results = new List<DbDsiPinMapping>();
            results.Clear();
            IEnumerable<DbDsiPinMapping> repositoryActionResult;
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
                    Result<List<DbDsiPinMapping>> failedResult = new Result<List<DbDsiPinMapping>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiPinMapping>> result;
            if (success)
            {
                result = new Result<List<DbDsiPinMapping>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiPinMapping>>(results, false, error);
            }

            return result;
        }
    }
}