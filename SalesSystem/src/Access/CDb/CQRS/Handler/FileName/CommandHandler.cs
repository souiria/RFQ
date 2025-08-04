namespace CDb.CQRS.Handler.FileName
{
    public class CommandHandler : ICommandHandler<FileNameCommand>
    {
        public CommandHandler(ICDbRepository<DbFileName> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbFileName> Repository 
        { get; }

        public async Task<Result> Handle(FileNameCommand command, CancellationToken cancellationToken)
        {
            List<DbFileName> fileNames = command.FileNameGrpcs.Select(compositeFileNameGrpc => compositeFileNameGrpc.ToEntity()).ToList();
            List<Result<DbFileName>> results = new List<Result<DbFileName>>();
            IEnumerable<DbFileName> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(fileNames, cancellationToken);
                    success = repositoryActionResult.Count() == fileNames.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(fileNames, cancellationToken);
                    success = updateDeleteCount == fileNames.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(fileNames, cancellationToken);    
                    success = updateDeleteCount == fileNames.Count;
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
