
namespace Rfq.CQRS.Handler.DsiBranchInsulationThroughNode
{
    public class CommandHandler : ICommandHandler<DsiBranchInsulationThroughNodeCommand, List<DbDsiBranchInsulationThroughNode>>
    {
        public IRfqRepository<DbDsiBranchInsulationThroughNode> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiBranchInsulationThroughNode> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiBranchInsulationThroughNode>>> Handle(DsiBranchInsulationThroughNodeCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiBranchInsulationThroughNode> components = command.DsiBranchInsulationThroughNodeGrpcs.Select(dsiBranchInsulationThroughNodeGrpcs => dsiBranchInsulationThroughNodeGrpcs.ToEntity()).ToList();
            List<DbDsiBranchInsulationThroughNode> results = new List<DbDsiBranchInsulationThroughNode>();
            results.Clear();
            IEnumerable<DbDsiBranchInsulationThroughNode> repositoryActionResult;
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
                    Result<List<DbDsiBranchInsulationThroughNode>> failedResult = new Result<List<DbDsiBranchInsulationThroughNode>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiBranchInsulationThroughNode>> result;
            if (success)
            {
                result = new Result<List<DbDsiBranchInsulationThroughNode>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiBranchInsulationThroughNode>>(results, false, error);
            }

            return result;
        }
    }
}
