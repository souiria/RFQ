namespace DSI.CQRS.Handler.BranchInsulation
{
    public class BranchInsulationCommandHandler : ICommandHandler<BranchInsulationCommand, List<DbBranchInsulation>>
    {
        public IDSIRepository<DbBranchInsulation> Repository
        { get; }

        public BranchInsulationCommandHandler(IDSIRepository<DbBranchInsulation> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbBranchInsulation>>> Handle(BranchInsulationCommand command, CancellationToken cancellationToken)
        {
            List<DbBranchInsulation> components = command.BranchInsulationGrpcs
                .Select(x => x.ToEntity()).ToList();

            List<DbBranchInsulation> results = new List<DbBranchInsulation>();

            IEnumerable<DbBranchInsulation> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                {
                    repositoryActionResult = await Repository.AddRangeAsync(components, cancellationToken);
                    success = repositoryActionResult.Count() == components.Count;
                    results = repositoryActionResult.ToList();
                    break;
                }

                case CommandType.Update:
                {
                    updateDeleteCount = await Repository.UpdateRangeAsync(components, cancellationToken);
                    success = updateDeleteCount == components.Count;
                    break;
                }

                case CommandType.Delete:
                {
                    updateDeleteCount = await Repository.DeleteRangeAsync(components, cancellationToken);
                    success = updateDeleteCount == components.Count;
                    break;
                }

                default:
                {
                    Error error = new Error(
                        "InvalidCommand",
                        "The command type is not supported.",
                        ErrorType.Failure);

                    Result<List<DbBranchInsulation>> failedResult =
                        new Result<List<DbBranchInsulation>>(results, false, error);

                    return failedResult;
                }
            }

            Result<List<DbBranchInsulation>> result;

            if (success)
            {
                result = new Result<List<DbBranchInsulation>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error(
                    "Failure",
                    $"Command type {command.CommandType} failed!",
                    ErrorType.Problem);

                result = new Result<List<DbBranchInsulation>>(results, false, error);
            }

            return result;
        }
    }
}
