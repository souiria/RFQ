namespace DSI.CQRS.Handler.CompositeDetail
{
    public class CompositeDetailCommandHandler : ICommandHandler<CompositeDetailCommand, List<DbCompositeDetail>>
    {
        public IDSIRepository<DbCompositeDetail> Repository
        { get; }

        public CompositeDetailCommandHandler(IDSIRepository<DbCompositeDetail> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbCompositeDetail>>> Handle(CompositeDetailCommand command, CancellationToken cancellationToken)
        {
            List<DbCompositeDetail> components = command.CompositeDetailGrpcs
                .Select(x => x.ToEntity()).ToList();

            List<DbCompositeDetail> results = new List<DbCompositeDetail>();

            IEnumerable<DbCompositeDetail> repositoryActionResult;
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

                    Result<List<DbCompositeDetail>> failedResult =
                        new Result<List<DbCompositeDetail>>(results, false, error);

                    return failedResult;
                }
            }

            Result<List<DbCompositeDetail>> result;

            if (success)
            {
                result = new Result<List<DbCompositeDetail>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error(
                    "Failure",
                    $"Command type {command.CommandType} failed!",
                    ErrorType.Problem);

                result = new Result<List<DbCompositeDetail>>(results, false, error);
            }

            return result;
        }
    }
}