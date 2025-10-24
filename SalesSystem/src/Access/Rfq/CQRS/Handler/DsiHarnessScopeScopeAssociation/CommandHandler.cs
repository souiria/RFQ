namespace Rfq.CQRS.Handler.DsiHarnessScopeScopeAssociation
{
    public class CommandHandler : ICommandHandler<DsiHarnessScopeScopeAssociationCommand, List<DbDsiHarnessScopeScopeAssociation>>
    {
        public IRfqRepository<DbDsiHarnessScopeScopeAssociation> Repository 
        { get; }

        public CommandHandler(IRfqRepository<DbDsiHarnessScopeScopeAssociation> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiHarnessScopeScopeAssociation>>> Handle(DsiHarnessScopeScopeAssociationCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiHarnessScopeScopeAssociation> components = command.DsiHarnessScopeScopeAssociationGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiHarnessScopeScopeAssociation> results = new List<DbDsiHarnessScopeScopeAssociation>();
            results.Clear();
            IEnumerable<DbDsiHarnessScopeScopeAssociation> repositoryActionResult;
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
                    Result<List<DbDsiHarnessScopeScopeAssociation>> failedResult = new Result<List<DbDsiHarnessScopeScopeAssociation>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiHarnessScopeScopeAssociation>> result;
            if (success)
            {
                result = new Result<List<DbDsiHarnessScopeScopeAssociation>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiHarnessScopeScopeAssociation>>(results, false, error);
            }

            return result;
        }
    }
}
