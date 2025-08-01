namespace CDb.CQRS.Handler.Masters.WaterproofType
{
    public class CommandHandler : ICommandHandler<WaterproofTypeCommand>
    {
        public CommandHandler(ICDbRepository<DbWaterproofType> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbWaterproofType> Repository 
        { get; }

        public async Task<Result> Handle(WaterproofTypeCommand command, CancellationToken cancellationToken)
        {
            List<DbWaterproofType> waterproofTypes = command.WaterproofTypeGrpcs.Select(waterproofTypeGrpc => waterproofTypeGrpc.ToEntity()).ToList();
            List<Result<DbWaterproofType>> results = new List<Result<DbWaterproofType>>();
            IEnumerable<DbWaterproofType> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(waterproofTypes, cancellationToken);
                    success = repositoryActionResult.Count() == waterproofTypes.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(waterproofTypes, cancellationToken);
                    success = updateDeleteCount == waterproofTypes.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(waterproofTypes, cancellationToken);    
                    success = updateDeleteCount == waterproofTypes.Count;
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
