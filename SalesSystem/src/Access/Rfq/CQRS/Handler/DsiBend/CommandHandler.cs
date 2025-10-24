namespace Rfq.CQRS.Handler.DsiBend
{
    public class CommandHandler : ICommandHandler<DsiBendCommand, List<DbDsiBend>>
    {
        public IRfqRepository<DbDsiBend> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiBend> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiBend>>> Handle(DsiBendCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiBend> components = command.DsiBendGrpcs.Select(dsiBendGrpcs => dsiBendGrpcs.ToEntity()).ToList();
            List<DbDsiBend> results = new List<DbDsiBend>();
            results.Clear();
            IEnumerable<DbDsiBend> repositoryActionResult;
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
                    Result<List<DbDsiBend>> failedResult = new Result<List<DbDsiBend>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiBend>> result;
            if (success)
            {
                result = new Result<List<DbDsiBend>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiBend>>(results, false, error);
            }

            return result;
        }
    }
}
