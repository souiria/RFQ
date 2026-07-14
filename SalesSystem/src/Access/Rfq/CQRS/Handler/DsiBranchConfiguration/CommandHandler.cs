
namespace Rfq.CQRS.Handler.DsiBranchConfiguration
{
    public class CommandHandler : ICommandHandler<DsiBranchConfigurationCommand, List<DbDsiBranchConfiguration>>
    {
        public IRfqRepository<DbDsiBranchConfiguration> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiBranchConfiguration> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiBranchConfiguration>>> Handle(DsiBranchConfigurationCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiBranchConfiguration> components = command.DsiBranchConfigurationGrpc.Select(dsiBranchConfigurationGrpcs => dsiBranchConfigurationGrpcs.ToEntity()).ToList();
            List<DbDsiBranchConfiguration> results = new List<DbDsiBranchConfiguration>();
            results.Clear();
            IEnumerable<DbDsiBranchConfiguration> repositoryActionResult;
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
                    Result<List<DbDsiBranchConfiguration>> failedResult = new Result<List<DbDsiBranchConfiguration>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiBranchConfiguration>> result;
            if (success)
            {
                result = new Result<List<DbDsiBranchConfiguration>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiBranchConfiguration>>(results, false, error);
            }

            return result;
        }
    }
}
