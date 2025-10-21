namespace Rfq.CQRS.Handler.DsiCompositeDetailCircuitOptionAssociation
{
    public class CommandHandler : ICommandHandler<DsiCompositeDetailCircuitOptionAssociationCommand, List<DbDsiCompositeDetailCircuitOptionAssociation>>
    {
        public IRfqRepository<DbDsiCompositeDetailCircuitOptionAssociation> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiCompositeDetailCircuitOptionAssociation> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiCompositeDetailCircuitOptionAssociation>>> Handle(DsiCompositeDetailCircuitOptionAssociationCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiCompositeDetailCircuitOptionAssociation> components = command.DsiCompositeDetailCircuitOptionAssociationGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiCompositeDetailCircuitOptionAssociation> results = new List<DbDsiCompositeDetailCircuitOptionAssociation>();
            results.Clear();
            IEnumerable<DbDsiCompositeDetailCircuitOptionAssociation> repositoryActionResult;
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
                    Result<List<DbDsiCompositeDetailCircuitOptionAssociation>> failedResult = new Result<List<DbDsiCompositeDetailCircuitOptionAssociation>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiCompositeDetailCircuitOptionAssociation>> result;
            if (success)
            {
                result = new Result<List<DbDsiCompositeDetailCircuitOptionAssociation>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiCompositeDetailCircuitOptionAssociation>>(results, false, error);
            }

            return result;
        }
    }
}
