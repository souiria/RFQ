namespace Rfq.CQRS.Handler.RfqNprRequest
{
    public class CommandHandler : ICommandHandler<RfqNprRequestCommand, List<DbRfqNprRequestModel>>
    {
        readonly ILogger<CommandHandler> _Logger;

        public IRfqRepository<DbRfqNprRequestModel> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbRfqNprRequestModel> repository,
                              ILogger<CommandHandler> logger)
        {
            Repository = repository;
            _Logger = logger;
        }

        public async Task<Result<List<DbRfqNprRequestModel>>> Handle(RfqNprRequestCommand command, CancellationToken cancellationToken)
        {
            // List<DbRfqNprRequestModel> dbRfqNprRequests = command.RfqNprRequestGrpcs.Select(x => x.ToEntity()).ToList();

            _Logger.GenericLogInformation($"III CQRS Handler RfqNprRequestCommand command type {command.CommandType}");

            List<DbRfqNprRequestModel> dbRfqNprRequests = new();
            foreach (RfqNprRequestGrpc rfqNprRequest in command.RfqNprRequestGrpcs)
            {
                DbRfqNprRequestModel dbRfqNprRequest = rfqNprRequest.ToEntity();
                dbRfqNprRequests.Add(dbRfqNprRequest);
            }

            List<DbRfqNprRequestModel> results = new List<DbRfqNprRequestModel>();
            results.Clear();
            IEnumerable<DbRfqNprRequestModel> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(dbRfqNprRequests, cancellationToken);
                    success = repositoryActionResult.Count() == dbRfqNprRequests.Count;
                    results = repositoryActionResult.ToList();
                    break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(dbRfqNprRequests, cancellationToken);
                    success = updateDeleteCount == dbRfqNprRequests.Count;
                    break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(dbRfqNprRequests, cancellationToken);
                    success = updateDeleteCount == dbRfqNprRequests.Count;
                    break;
                default:
                {
                    Error error = new Error("InvalidCommand", "The command type is not supported.", ErrorType.Failure);
                    Result<List<DbRfqNprRequestModel>> failedResult = new Result<List<DbRfqNprRequestModel>>(results, false, error);
                    return failedResult;
                }
            }

            Result<List<DbRfqNprRequestModel>> result;
            if (success)
            {
                result = new Result<List<DbRfqNprRequestModel>>(results, true, Error.None);
            }
            else
            {
                Error error = new Error("Failure", $"Command type {command.CommandType} failed!", ErrorType.Problem);
                result = new Result<List<DbRfqNprRequestModel>>(results, false, error);
            }

            return result;
        }
    }
}
