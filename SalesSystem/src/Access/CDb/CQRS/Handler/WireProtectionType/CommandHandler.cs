namespace CDb.CQRS.Handler.WireProtectionType
{
    public class CommandHandler : ICommandHandler<WireProtectionTypeCommand>
    {
        public CommandHandler(ICDbRepository<DbWireProtectionType> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbWireProtectionType> Repository 
        { get; }

        public async Task<Result> Handle(WireProtectionTypeCommand command, CancellationToken cancellationToken)
        {
            List<DbWireProtectionType> wireProtectionTypes = command.WireProtectionTypeGrpcs.Select(wireProtectionTypeGrpc => wireProtectionTypeGrpc.ToEntity()).ToList();
            List<Result<DbWireProtectionType>> results = new List<Result<DbWireProtectionType>>();
            IEnumerable<DbWireProtectionType> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(wireProtectionTypes, cancellationToken);
                    success = repositoryActionResult.Count() == wireProtectionTypes.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(wireProtectionTypes, cancellationToken);
                    success = updateDeleteCount == wireProtectionTypes.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(wireProtectionTypes, cancellationToken);    
                    success = updateDeleteCount == wireProtectionTypes.Count;
                break;
                default:
                    {
                        Error e = new Error("InvalidCommand", "The command type is not supported.", ErrorType.Failure);
                        Result f = Result.Failure(e);
                        return f;
                    }
            }

            // not needed, the repository methods already save changes - which is why we don't need to call SaveChangesAsync here
            // otoh, how is one implemention the UnitOfWork pattern? 
            // int saved = await Repository.SaveChangesAsync(cancellationToken);

            Result r;
            if (success)
            {
                r = Result.Success();
            }
            else
            {
                Error w = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                r = Result.Failure(w);
            }

            return r;   
        }
    }
}
