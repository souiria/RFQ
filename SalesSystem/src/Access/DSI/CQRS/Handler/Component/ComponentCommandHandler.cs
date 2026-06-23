namespace DSI.CQRS.Handler.Component
{
    public class ComponentCommandHandler : ICommandHandler<ComponentCommand, List<DbComponent>>
    {
        public IDSIRepository<DbComponent> Repository
        { get; }

        public ComponentCommandHandler(IDSIRepository<DbComponent> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbComponent>>> Handle(ComponentCommand command, CancellationToken cancellationToken)
        {

            List<DbComponent> components = command.ComponentGrpcs
                .Select(x => x.ToEntity()).ToList();

            List<DbComponent> results = new List<DbComponent>();

            IEnumerable<DbComponent> repositoryActionResult;
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

                    Result<List<DbComponent>> failedResult =
                        new Result<List<DbComponent>>(results, false, error);

                    return failedResult;
                }
            }

            Result<List<DbComponent>> result;

            if (success)
            {
                result = new Result<List<DbComponent>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error(
                    "Failure",
                    $"Command type {command.CommandType} failed!",
                    ErrorType.Problem);

                result = new Result<List<DbComponent>>(results, false, error);
            }

            return result;
        }
    }
}