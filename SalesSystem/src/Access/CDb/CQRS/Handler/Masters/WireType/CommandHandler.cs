namespace CDb.CQRS.Handler.Masters.WireType
{
    public class CommandHandler : ICommandHandler<WireTypeCommand>
    {
        public CommandHandler(ICDbRepository<DbWireType> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbWireType> Repository 
        { get; }

        public async Task<Result> Handle(WireTypeCommand command, CancellationToken cancellationToken)
        {
            List<DbWireType> wireTypes = command.WireTypeGrpcs.Select(wireTypeGrpc => wireTypeGrpc.ToEntity()).ToList();
            List<Result<DbWireType>> results = new List<Result<DbWireType>>();
            IEnumerable<DbWireType> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(wireTypes, cancellationToken);
                    success = repositoryActionResult.Count() == wireTypes.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(wireTypes, cancellationToken);
                    success = updateDeleteCount == wireTypes.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(wireTypes, cancellationToken);
                    success = updateDeleteCount == wireTypes.Count;
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
