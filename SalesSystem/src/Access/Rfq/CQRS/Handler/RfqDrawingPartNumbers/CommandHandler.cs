namespace Rfq.CQRS.Handler.RfqDrawingPartNumbers
{
    public class CommandHandler : ICommandHandler<RfqDrawingPartNumberCommand, List<DbRfqDrawingPartNumber>>
    {
        readonly ILogger<CommandHandler> _Logger;

        public IRfqRepository<DbRfqDrawingPartNumber> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbRfqDrawingPartNumber> repository, ILogger<CommandHandler> logger)
        {
            Repository = repository;
            _Logger = logger;
        }

        public async Task<Result<List<DbRfqDrawingPartNumber>>> Handle(RfqDrawingPartNumberCommand command, CancellationToken cancellationToken)
        {
            List<DbRfqDrawingPartNumber> components = command.RfqDrawingPartNumbersGrpcs.Select(rfqDrawingPartNumberGrpc => rfqDrawingPartNumberGrpc.ToEntity()).ToList();
            List<DbRfqDrawingPartNumber> results = new List<DbRfqDrawingPartNumber>();
            results.Clear();
            IEnumerable<DbRfqDrawingPartNumber> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            Result<List<DbRfqDrawingPartNumber>> result;
#pragma warning disable CA1031 // Do not catch general exception types
            try
            {
                switch (command.CommandType)
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
            }
            catch (OperationCanceledException)
            {
                // Re-throw cancellation - this is expected behavior
                _Logger.GenericLogInformation($"Operation cancelled for command {command.CommandType}");
                throw;
            }
            catch (Exception ex)
            {
                _Logger.GenericLogError($"Error occurred while processing command {command.CommandType} for {command.RfqDrawingPartNumbersGrpcs.Count} RfqDrawingPartNumbersGrpcs: {ex.Message}", ex);

                Error error = new Error("Exception", $"Command type {command.CommandType} threw exception: {ex.Message}", ErrorType.Problem);
                result = new Result<List<DbRfqDrawingPartNumber>>(results, false, error);
                return result;
            }
#pragma warning restore CA1031 // Do not catch general exception types

            
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
