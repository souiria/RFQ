namespace Rfq.CQRS.Handler.DsiCentreStrip
{
    public class CommandHandler : ICommandHandler<DsiCentreStripCommand, List<DbDsiCentreStrip>>
    {
        public IRfqRepository<DbDsiCentreStrip> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiCentreStrip> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiCentreStrip>>> Handle(DsiCentreStripCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiCentreStrip> components = command.DsiCentreStripGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiCentreStrip> results = new List<DbDsiCentreStrip>();
            results.Clear();
            IEnumerable<DbDsiCentreStrip> repositoryActionResult;
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
                    Result<List<DbDsiCentreStrip>> failedResult = new Result<List<DbDsiCentreStrip>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiCentreStrip>> result;
            if (success)
            {
                result = new Result<List<DbDsiCentreStrip>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiCentreStrip>>(results, false, error);
            }

            return result;
        }
    }
}
