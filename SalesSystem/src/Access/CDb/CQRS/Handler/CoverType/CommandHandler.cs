namespace CDb.CQRS.Handler.CoverType
{
    public class CommandHandler : ICommandHandler<CoverTypeCommand>
    {
        public CommandHandler(ICDbRepository<DbCoverType> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbCoverType> Repository 
        { get; }

        public async Task<Result> Handle(CoverTypeCommand command, CancellationToken cancellationToken)
        {
            List<DbCoverType> coverTypes = command.CoverTypeGrpcs.Select(coverTypeGrpc => coverTypeGrpc.ToEntity()).ToList();
            List<Result<DbCoverType>> results = new List<Result<DbCoverType>>();
            IEnumerable<DbCoverType> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(coverTypes, cancellationToken);
                    success = repositoryActionResult.Count() == coverTypes.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(coverTypes, cancellationToken);
                    success = updateDeleteCount == coverTypes.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(coverTypes, cancellationToken);    
                    success = updateDeleteCount == coverTypes.Count;
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
