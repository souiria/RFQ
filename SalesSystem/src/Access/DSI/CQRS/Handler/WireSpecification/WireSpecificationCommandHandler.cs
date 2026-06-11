using DSI.CQRS.command;

namespace DSI.CQRS.Handler.WireSpecification
{
    public class WireSpecificationCommandHandler : ICommandHandler<WireSpecificationCommand, List<DbWireSpecification>>
    {
        public IDSIRepository<DbWireSpecification> Repository
        { get; }

        public WireSpecificationCommandHandler(IDSIRepository<DbWireSpecification> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbWireSpecification>>> Handle(WireSpecificationCommand command, CancellationToken cancellationToken)
        {
            List<DbWireSpecification> components = command.WireSpecificationGrpcs
                .Select(x => x.ToEntity()).ToList();

            List<DbWireSpecification> results = new List<DbWireSpecification>();

            IEnumerable<DbWireSpecification> repositoryActionResult;
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

                    Result<List<DbWireSpecification>> failedResult =
                        new Result<List<DbWireSpecification>>(results, false, error);

                    return failedResult;
                }
            }

            Result<List<DbWireSpecification>> result;

            if (success)
            {
                result = new Result<List<DbWireSpecification>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error(
                    "Failure",
                    $"Command type {command.CommandType} failed!",
                    ErrorType.Problem);

                result = new Result<List<DbWireSpecification>>(results, false, error);
            }

            return result;
        }
    }
}