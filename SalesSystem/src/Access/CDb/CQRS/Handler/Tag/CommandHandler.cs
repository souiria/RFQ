namespace CDb.CQRS.Handler.Tag
{
    public class CommandHandler : ICommandHandler<TagCommand>
    {
        public CommandHandler(ICDbRepository<DbTag> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbTag> Repository 
        { get; }

        public async Task<Result> Handle(TagCommand command, CancellationToken cancellationToken)
        {
            List<DbTag> tags = command.TagGrpcs.Select(compositeTagGrpc => compositeTagGrpc.ToEntity()).ToList();
            List<Result<DbTag>> results = new List<Result<DbTag>>();
            IEnumerable<DbTag> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(tags, cancellationToken);
                    success = repositoryActionResult.Count() == tags.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(tags, cancellationToken);
                    success = updateDeleteCount == tags.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(tags, cancellationToken);    
                    success = updateDeleteCount == tags.Count;
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
            int savedEntitiesCount = await Repository.SaveChangesAsync(cancellationToken);

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
