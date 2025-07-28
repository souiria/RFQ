namespace CDb.CQRS.Handler.ClipType
{
    public class CommandHandler : ICommandHandler<ClipTypeCommand>
    {
        public CommandHandler(ICDbRepository<DbClipType> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbClipType> Repository 
        { get; }

        public async Task<Result> Handle(ClipTypeCommand command, CancellationToken cancellationToken)
        {
            List<DbClipType> clipTypes = command.ClipTypeGrpcs.Select(clipTypeGrpc => clipTypeGrpc.ToEntity()).ToList();
            List<Result<DbClipType>> results = new List<Result<DbClipType>>();
            IEnumerable<DbClipType> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(clipTypes, cancellationToken);
                    success = repositoryActionResult.Count() == clipTypes.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(clipTypes, cancellationToken);
                    success = updateDeleteCount == clipTypes.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(clipTypes, cancellationToken);    
                    success = updateDeleteCount == clipTypes.Count;
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
