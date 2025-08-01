namespace CDb.CQRS.Handler.Masters.MaterialType
{
    public class CommandHandler : ICommandHandler<MaterialTypeCommand>
    {
        public CommandHandler(ICDbRepository<DbMaterialType> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbMaterialType> Repository 
        { get; }

        public async Task<Result> Handle(MaterialTypeCommand command, CancellationToken cancellationToken)
        {
            List<DbMaterialType> materialTypes = command.MaterialTypeGrpcs.Select(materialTypeGrpc => materialTypeGrpc.ToEntity()).ToList();
            List<Result<DbMaterialType>> results = new List<Result<DbMaterialType>>();
            IEnumerable<DbMaterialType> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(materialTypes, cancellationToken);
                    success = repositoryActionResult.Count() == materialTypes.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(materialTypes, cancellationToken);
                    success = updateDeleteCount == materialTypes.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(materialTypes, cancellationToken);    
                    success = updateDeleteCount == materialTypes.Count;
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
