namespace Rfq.CQRS.Handler.DsiBranchInsulation
{
    public class CommandHandler : ICommandHandler<DsiBranchInsulationCommand, List<DbDsiBranchInsulation>>
    {
        public IRfqRepository<DbDsiBranchInsulation> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiBranchInsulation> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiBranchInsulation>>> Handle(DsiBranchInsulationCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiBranchInsulation> components = command.DsiBranchInsulationGrpcs.Select(dsiBranchInsulationGrpcs => dsiBranchInsulationGrpcs.ToEntity()).ToList();
            List<DbDsiBranchInsulation> results = new List<DbDsiBranchInsulation>();
            results.Clear();
            IEnumerable<DbDsiBranchInsulation> repositoryActionResult;
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
                        Result<List<DbDsiBranchInsulation>> failedResult = new Result<List<DbDsiBranchInsulation>>(results, false, error);
                        return failedResult;
                    }
            }

            Result<List<DbDsiBranchInsulation>> result;
            if (success)
            {
                result = new Result<List<DbDsiBranchInsulation>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiBranchInsulation>>(results, false, error);
            }

            return result;
        }
    }
}
