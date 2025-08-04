namespace CDb.CQRS.Handler.Masters.TypeCode
{
    public class CommandHandler : ICommandHandler<TypeCodeCommand>
    {
        public CommandHandler(ICDbRepository<DbTypeCode> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbTypeCode> Repository 
        { get; }

        public async Task<Result> Handle(TypeCodeCommand command, CancellationToken cancellationToken)
        {
            List<DbTypeCode> typeCodes = command.TypeCodeGrpcs.Select(typeCodeGrpc => typeCodeGrpc.ToEntity()).ToList();
            List<Result<DbTypeCode>> results = new List<Result<DbTypeCode>>();
            IEnumerable<DbTypeCode> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(typeCodes, cancellationToken);
                    success = repositoryActionResult.Count() == typeCodes.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(typeCodes, cancellationToken);
                    success = updateDeleteCount == typeCodes.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(typeCodes, cancellationToken);    
                    success = updateDeleteCount == typeCodes.Count;
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
