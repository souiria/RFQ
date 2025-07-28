namespace CDb.CQRS.Handler.CrimpingProcessType
{
    public class CommandHandler : ICommandHandler<CrimpingProcessTypeCommand>
    {
        public CommandHandler(ICDbRepository<DbCrimpingProcessType> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbCrimpingProcessType> Repository 
        { get; }

        public async Task<Result> Handle(CrimpingProcessTypeCommand command, CancellationToken cancellationToken)
        {
            List<DbCrimpingProcessType> crimpingProcessTypes = command.CrimpingProcessTypeGrpcs.Select(crimpingProcessTypeGrpc => crimpingProcessTypeGrpc.ToEntity()).ToList();
            List<Result<DbCrimpingProcessType>> results = new List<Result<DbCrimpingProcessType>>();
            IEnumerable<DbCrimpingProcessType> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(crimpingProcessTypes, cancellationToken);
                    success = repositoryActionResult.Count() == crimpingProcessTypes.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(crimpingProcessTypes, cancellationToken);
                    success = updateDeleteCount == crimpingProcessTypes.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(crimpingProcessTypes, cancellationToken);    
                    success = updateDeleteCount == crimpingProcessTypes.Count;
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
