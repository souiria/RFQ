namespace Rfq.CQRS.Handler.RfqDrawingPartNumbers
{
    public class CommandHandler : ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>>
    {
        public IRfqRepository<DbRfqDrawingPartNumber> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbRfqDrawingPartNumber> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbRfqDrawingPartNumber>>> Handle(RfqDrawingPartNumberCommand command, CancellationToken cancellationToken)
        {
            List<DbRfqDrawingPartNumber> components = command.RfqDrawingPartNumbersGrpcs.Select(rfqDrawingPartNumberGrpc => rfqDrawingPartNumberGrpc.ToEntity()).ToList();
            List<DbRfqDrawingPartNumber> results = new List<DbRfqDrawingPartNumber>();
            results.Clear();
            IEnumerable<DbRfqDrawingPartNumber> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch(command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(components, cancellationToken);
                    success = repositoryActionResult.Count() == components.Count;
                    results = repositoryActionResult.ToList();
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
                        Error error = new Error("InvalidCommand", "The command type is not supported.", ErrorType.Failure);
                        Result<List<DbRfqDrawingPartNumber>> failedResult = new Result<List<DbRfqDrawingPartNumber>>(results, false, error);
                        return failedResult;
                    }
            }

            Result<List<DbRfqDrawingPartNumber>> result;
            if (success)
            {
                result = new Result<List<DbRfqDrawingPartNumber>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbRfqDrawingPartNumber>>(results, false, error);
            }

            return result;
        }
    }
}
