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

            switch (command.CommandType)
            {
                case CommandType.Create:
                    await Repository.AddRangeAsync(clipTypes, cancellationToken);
                    break;
                case CommandType.Update:
                    await Repository.UpdateRangeAsync(clipTypes, cancellationToken);
                    break;
                case CommandType.Delete:
                    await Repository.DeleteRangeAsync(clipTypes, cancellationToken);    
                    break;
                default:
                    {
                        Error e = new Error("InvalidCommand", "The command type is not supported.", ErrorType.Failure);
                        Result f = Result.Failure(e);
                        return f;
                    }
            }   
            
            int saved = await Repository.SaveChangesAsync(cancellationToken);

            Result r;
            if (saved <= 0)
            {
                Error e = new Error("Failure", "Failed to create clip types.", ErrorType.Failure);
                r = Result.Failure(e);
            }
            else
            {
                if(clipTypes.Count == saved)
                {
                    r = Result.Success();
                }
                else
                {
                    Error w = new Error("Problem", $"Failed to create all clip types, commited {saved} vs. requested {clipTypes.Count}", ErrorType.Problem);
                    r = Result.Failure(w);
                }
            }

            return r;   
        }
    }
}
