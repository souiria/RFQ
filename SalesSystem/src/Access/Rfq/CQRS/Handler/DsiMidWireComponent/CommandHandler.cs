namespace Rfq.CQRS.Handler.DsiMidWireComponent
{
    public class CommandHandler : ICommandHandler<DsiMidWireComponentCommand, List<DbDsiMidWireComponent>>
    {
        public IRfqRepository<DbDsiMidWireComponent> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiMidWireComponent> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiMidWireComponent>>> Handle(DsiMidWireComponentCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiMidWireComponent> components = command.DsiMidWireComponentGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiMidWireComponent> results = new List<DbDsiMidWireComponent>();
            results.Clear();
            IEnumerable<DbDsiMidWireComponent> repositoryActionResult;
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
                    Result<List<DbDsiMidWireComponent>> failedResult = new Result<List<DbDsiMidWireComponent>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiMidWireComponent>> result;
            if (success)
            {
                result = new Result<List<DbDsiMidWireComponent>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiMidWireComponent>>(results, false, error);
            }

            return result;
        }
    }
}
