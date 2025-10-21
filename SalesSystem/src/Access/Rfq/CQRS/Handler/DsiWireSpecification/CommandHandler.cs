namespace Rfq.CQRS.Handler.DsiWireSpecification
{
    public class CommandHandler : ICommandHandler<DsiWireSpecificationCommand, List<DbDsiWireSpecification>>
    {
        public IRfqRepository<DbDsiWireSpecification> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiWireSpecification> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiWireSpecification>>> Handle(DsiWireSpecificationCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiWireSpecification> components = command.DsiWireSpecificationGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiWireSpecification> results = new List<DbDsiWireSpecification>();
            results.Clear();
            IEnumerable<DbDsiWireSpecification> repositoryActionResult;
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
                    Result<List<DbDsiWireSpecification>> failedResult = new Result<List<DbDsiWireSpecification>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiWireSpecification>> result;
            if (success)
            {
                result = new Result<List<DbDsiWireSpecification>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiWireSpecification>>(results, false, error);
            }

            return result;
        }
    }
}