namespace Rfq.CQRS.Handler.DsiWireMulticoreMarker
{
    public class CommandHandler : ICommandHandler<DsiWireMulticoreMarkerCommand, List<DbDsiWireMulticoreMarker>>
    {
        public IRfqRepository<DbDsiWireMulticoreMarker> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiWireMulticoreMarker> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiWireMulticoreMarker>>> Handle(DsiWireMulticoreMarkerCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiWireMulticoreMarker> components = command.DsiWireMulticoreMarkerGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiWireMulticoreMarker> results = new List<DbDsiWireMulticoreMarker>();
            results.Clear();
            IEnumerable<DbDsiWireMulticoreMarker> repositoryActionResult;
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
                    Result<List<DbDsiWireMulticoreMarker>> failedResult = new Result<List<DbDsiWireMulticoreMarker>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiWireMulticoreMarker>> result;
            if (success)
            {
                result = new Result<List<DbDsiWireMulticoreMarker>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiWireMulticoreMarker>>(results, false, error);
            }

            return result;
        }
    }
}
