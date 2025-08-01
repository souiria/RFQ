using CDb.CQRS.Command.Masters.FileType;

namespace CDb.CQRS.Handler.Masters.FileType
{
    public class CommandHandler : ICommandHandler<FileTypeCommand>
    {
        public CommandHandler(ICDbRepository<DbFileType> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbFileType> Repository 
        { get; }

        public async Task<Result> Handle(FileTypeCommand command, CancellationToken cancellationToken)
        {
            List<DbFileType> fileTypes = command.FileTypeGrpcs.Select(fileTypeGrpc => fileTypeGrpc.ToEntity()).ToList();
            List<Result<DbFileType>> results = new List<Result<DbFileType>>();
            IEnumerable<DbFileType> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(fileTypes, cancellationToken);
                    success = repositoryActionResult.Count() == fileTypes.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(fileTypes, cancellationToken);
                    success = updateDeleteCount == fileTypes.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(fileTypes, cancellationToken);    
                    success = updateDeleteCount == fileTypes.Count;
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
