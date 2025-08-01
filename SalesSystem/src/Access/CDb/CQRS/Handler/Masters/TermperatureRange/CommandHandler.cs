namespace CDb.CQRS.Handler.Masters.TermperatureRange
{
    public class CommandHandler : ICommandHandler<TemperatureRangeCommand>
    {
        public CommandHandler(ICDbRepository<DbTemperatureRange> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbTemperatureRange> Repository 
        { get; }

        public async Task<Result> Handle(TemperatureRangeCommand command, CancellationToken cancellationToken)
        {
            List<DbTemperatureRange> temperatureRanges = command.TemperatureRangeGrpcs.Select(temperatureRangeGrpc => temperatureRangeGrpc.ToEntity()).ToList();
            List<Result<DbTemperatureRange>> results = new List<Result<DbTemperatureRange>>();
            IEnumerable<DbTemperatureRange> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(temperatureRanges, cancellationToken);
                    success = repositoryActionResult.Count() == temperatureRanges.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(temperatureRanges, cancellationToken);
                    success = updateDeleteCount == temperatureRanges.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(temperatureRanges, cancellationToken);    
                    success = updateDeleteCount == temperatureRanges.Count;
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
