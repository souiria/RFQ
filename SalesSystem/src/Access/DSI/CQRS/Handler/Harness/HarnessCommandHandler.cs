using DSI.CQRS.command;

namespace DSI.CQRS.Handler.Harness
{
    public class HarnessCommandHandler : ICommandHandler<HarnessCommand, List<DbHarness>>
    {
        public IDSIRepository<DbHarness> Repository
        { get; }

        public HarnessCommandHandler(IDSIRepository<DbHarness> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbHarness>>> Handle(HarnessCommand command, CancellationToken cancellationToken)
        {
            List<DbHarness> entities = command.HarnessGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbHarness> results = new();

            IEnumerable<DbHarness> repoResult;
            int count = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                repoResult = await Repository.AddRangeAsync(entities, cancellationToken);
                success = repoResult.Count() == entities.Count;
                results = repoResult.ToList();
                break;

                case CommandType.Update:
                count = await Repository.UpdateRangeAsync(entities, cancellationToken);
                success = count == entities.Count;
                break;

                case CommandType.Delete:
                count = await Repository.DeleteRangeAsync(entities, cancellationToken);
                success = count == entities.Count;
                break;
                default:
                {
                    Error error = new Error("InvalidCommand", "The command type is not supported.", ErrorType.Failure);
                    Result<List<DbHarness>> failedResult = new Result<List<DbHarness>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbHarness>> result;
            if (success)
            {
                result = new Result<List<DbHarness>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbHarness>>(results, false, error);
            }

            return result;
        }
    }
}