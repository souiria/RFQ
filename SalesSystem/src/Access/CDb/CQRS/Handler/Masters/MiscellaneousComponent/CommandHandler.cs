namespace CDb.CQRS.Handler.Masters.MiscellaneousComponent
{
    public class CommandHandler : ICommandHandler<MiscellaneousComponentTypeCommand>
    {
        public CommandHandler(ICDbRepository<DbMiscellaneousComponentType> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbMiscellaneousComponentType> Repository 
        { get; }

        public async Task<Result> Handle(MiscellaneousComponentTypeCommand command, CancellationToken cancellationToken)
        {
            List<DbMiscellaneousComponentType> miscellaneousComponentTypes = command.MiscellaneousComponentTypeGrpcs.Select(miscellaneousComponentTypeGrpc => miscellaneousComponentTypeGrpc.ToEntity()).ToList();
            List<Result<DbMiscellaneousComponentType>> results = new List<Result<DbMiscellaneousComponentType>>();
            IEnumerable<DbMiscellaneousComponentType> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(miscellaneousComponentTypes, cancellationToken);
                    success = repositoryActionResult.Count() == miscellaneousComponentTypes.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(miscellaneousComponentTypes, cancellationToken);
                    success = updateDeleteCount == miscellaneousComponentTypes.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(miscellaneousComponentTypes, cancellationToken);    
                    success = updateDeleteCount == miscellaneousComponentTypes.Count;
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
