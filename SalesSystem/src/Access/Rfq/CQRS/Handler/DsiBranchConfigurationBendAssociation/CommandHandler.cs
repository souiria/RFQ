
namespace Rfq.CQRS.Handler.DsiBranchConfigurationBendAssociation
{
    public class CommandHandler : ICommandHandler<DsiBranchConfigurationBendAssociationCommand, List<DbDsiBranchConfigurationBendAssociation>>
    {
        public IRfqRepository<DbDsiBranchConfigurationBendAssociation> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiBranchConfigurationBendAssociation> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiBranchConfigurationBendAssociation>>> Handle(DsiBranchConfigurationBendAssociationCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiBranchConfigurationBendAssociation> components = command.DsiBranchConfigurationBendAssociationGrpcs.Select(dsiBranchConfigurationBendAssociationGrpcs => dsiBranchConfigurationBendAssociationGrpcs.ToEntity()).ToList();
            List<DbDsiBranchConfigurationBendAssociation> results = new List<DbDsiBranchConfigurationBendAssociation>();
            results.Clear();
            IEnumerable<DbDsiBranchConfigurationBendAssociation> repositoryActionResult;
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
                    Result<List<DbDsiBranchConfigurationBendAssociation>> failedResult = new Result<List<DbDsiBranchConfigurationBendAssociation>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiBranchConfigurationBendAssociation>> result;
            if (success)
            {
                result = new Result<List<DbDsiBranchConfigurationBendAssociation>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiBranchConfigurationBendAssociation>>(results, false, error);
            }

            return result;
        }
    }
}
