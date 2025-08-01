using CDb.CQRS.Command.Masters.FuseType;

namespace CDb.CQRS.Handler.Masters.FuseType
{
    public class CommandHandler : ICommandHandler<FuseTypeCommand>
    {
        public CommandHandler(ICDbRepository<DbFuseType> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbFuseType> Repository 
        { get; }

        public async Task<Result> Handle(FuseTypeCommand command, CancellationToken cancellationToken)
        {
            List<DbFuseType> fuseTypes = command.FuseTypeGrpcs.Select(fuseTypeGrpc => fuseTypeGrpc.ToEntity()).ToList();
            List<Result<DbFuseType>> results = new List<Result<DbFuseType>>();
            IEnumerable<DbFuseType> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(fuseTypes, cancellationToken);
                    success = repositoryActionResult.Count() == fuseTypes.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(fuseTypes, cancellationToken);
                    success = updateDeleteCount == fuseTypes.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(fuseTypes, cancellationToken);    
                    success = updateDeleteCount == fuseTypes.Count;
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
