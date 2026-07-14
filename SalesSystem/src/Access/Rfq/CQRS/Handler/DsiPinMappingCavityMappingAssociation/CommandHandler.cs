namespace Rfq.CQRS.Handler.DsiPinMappingCavityMappingAssociation
{
    public class CommandHandler : ICommandHandler<DsiPinMappingCavityMappingAssociationCommand, List<DbDsiPinMappingCavityMappingAssociation>>
    {
        public IRfqRepository<DbDsiPinMappingCavityMappingAssociation> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbDsiPinMappingCavityMappingAssociation> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbDsiPinMappingCavityMappingAssociation>>> Handle(DsiPinMappingCavityMappingAssociationCommand command, CancellationToken cancellationToken)
        {
            List<DbDsiPinMappingCavityMappingAssociation> components = command.DsiPinMappingCavityMappingAssociationGrpcs.Select(x => x.ToEntity()).ToList();
            List<DbDsiPinMappingCavityMappingAssociation> results = new List<DbDsiPinMappingCavityMappingAssociation>();
            results.Clear();
            IEnumerable<DbDsiPinMappingCavityMappingAssociation> repositoryActionResult;
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
                    Result<List<DbDsiPinMappingCavityMappingAssociation>> failedResult = new Result<List<DbDsiPinMappingCavityMappingAssociation>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbDsiPinMappingCavityMappingAssociation>> result;
            if (success)
            {
                result = new Result<List<DbDsiPinMappingCavityMappingAssociation>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbDsiPinMappingCavityMappingAssociation>>(results, false, error);
            }

            return result;
        }
    }
}