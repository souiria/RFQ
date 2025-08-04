namespace CDb.CQRS.Handler.Component
{
    public class CommandHandler : ICommandHandler<ComponentCommand>
    {
        public CommandHandler(ICDbRepository<DbComponent> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbComponent> Repository 
        { get; }

        public async Task<Result> Handle(ComponentCommand command, CancellationToken cancellationToken)
        {
            List<DbComponent> components = command.CompositeComponentGrpcs.Select(compositeComponentGrpc => compositeComponentGrpc.ToEntity()).ToList();
            List<Result<DbComponent>> results = new List<Result<DbComponent>>();
            IEnumerable<DbComponent> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(components, cancellationToken);
                    success = repositoryActionResult.Count() == components.Count;
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
