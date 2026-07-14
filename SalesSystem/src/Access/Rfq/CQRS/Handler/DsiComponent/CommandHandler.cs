namespace Rfq.CQRS.Handler.DsiComponent
{
    public class CommandHandler : ICommandHandler<DsiComponentCommand, List<DbDsiComponent>>
    {
        public IRfqRepository<DbDsiComponent> Repository 
        { get; }

        public CommandHandler(IRfqRepository<DbDsiComponent> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiComponent>>> Handle(DsiComponentCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiComponent> components = command.DsiComponentGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiComponent> results = new List<DbDsiComponent>();
            results.Clear();
            IEnumerable<DbDsiComponent> repositoryActionResult;
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
                    Result<List<DbDsiComponent>> failedResult = new Result<List<DbDsiComponent>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiComponent>> result;
            if (success)
            {
                result = new Result<List<DbDsiComponent>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiComponent>>(results, false, error);
            }

            return result;
        }
    }
}
