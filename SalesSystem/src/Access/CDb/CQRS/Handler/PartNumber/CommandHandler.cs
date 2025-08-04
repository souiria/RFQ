namespace CDb.CQRS.Handler.PartNumber
{
    public class CommandHandler : ICommandHandler<PartNumberCommand>
    {
        public CommandHandler(ICDbRepository<DbPartNumber> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbPartNumber> Repository 
        { get; }

        public async Task<Result> Handle(PartNumberCommand command, CancellationToken cancellationToken)
        {
            List<DbPartNumber> partNumbers = command.PartNumberGrpcs.Select(compositePartNumberGrpc => compositePartNumberGrpc.ToEntity()).ToList();
            List<Result<DbPartNumber>> results = new List<Result<DbPartNumber>>();
            IEnumerable<DbPartNumber> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(partNumbers, cancellationToken);
                    success = repositoryActionResult.Count() == partNumbers.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(partNumbers, cancellationToken);
                    success = updateDeleteCount == partNumbers.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(partNumbers, cancellationToken);    
                    success = updateDeleteCount == partNumbers.Count;
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
