namespace Rfq.CQRS.Handler.RfqNprRequest
{
    public class CommandHandler : ICommandHandler<RfqNprRequestCommand, List<DbRfqNprRequestModel>>
    {
        public IRfqRepository<DbRfqNprRequestModel> Repository
        { get; }

        public CommandHandler(IRfqRepository<DbRfqNprRequestModel> repository)
        {
            Repository = repository;
        }

        public async Task<Result<List<DbRfqNprRequestModel>>> Handle(RfqNprRequestCommand command, CancellationToken cancellationToken)
        {
            List<DbRfqNprRequestModel> components = command.RfqNprRequestGrpcs.Select(rfqProjectGrpc => rfqProjectGrpc.ToEntity()).ToList();
            List<DbRfqNprRequestModel> results = new List<DbRfqNprRequestModel>();
            results.Clear();
            IEnumerable<DbRfqNprRequestModel> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

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
