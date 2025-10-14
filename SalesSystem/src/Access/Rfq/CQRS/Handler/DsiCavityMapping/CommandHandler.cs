
namespace Rfq.CQRS.Handler.DsiCavityMapping
{
    public class CommandHandler : ICommandHandler<DsiCavityMappingCommand, List<DbDsiCavityMapping>>
    {
        public IRfqRepository<DbDsiCavityMapping> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiCavityMapping> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiCavityMapping>>> Handle(DsiCavityMappingCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiCavityMapping> components = command.DsiCavityMappingGrpcs.Select(dsiCavityMapping => dsiCavityMapping.ToEntity()).ToList();
            List<DbDsiCavityMapping> results = new List<DbDsiCavityMapping>();
            results.Clear();
            IEnumerable<DbDsiCavityMapping> repositoryActionResult;
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
                    Result<List<DbDsiCavityMapping>> failedResult = new Result<List<DbDsiCavityMapping>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiCavityMapping>> result;
            if (success)
            {
                result = new Result<List<DbDsiCavityMapping>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiCavityMapping>>(results, false, error);
            }

            return result;
        }
    }
}
