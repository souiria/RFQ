using CDb.CQRS.Command.Masters.TerminalFamily;

namespace CDb.CQRS.Handler.Masters.TerminalFamily
{
    public class CommandHandler : ICommandHandler<TerminalFamilyCommand>
    {
        public CommandHandler(ICDbRepository<DbTerminalFamily> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbTerminalFamily> Repository 
        { get; }

        public async Task<Result> Handle(TerminalFamilyCommand command, CancellationToken cancellationToken)
        {
            List<DbTerminalFamily> terminalFamilys = command.TerminalFamilyGrpcs.Select(terminalFamilyGrpc => terminalFamilyGrpc.ToEntity()).ToList();
            List<Result<DbTerminalFamily>> results = new List<Result<DbTerminalFamily>>();
            IEnumerable<DbTerminalFamily> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(terminalFamilys, cancellationToken);
                    success = repositoryActionResult.Count() == terminalFamilys.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(terminalFamilys, cancellationToken);
                    success = updateDeleteCount == terminalFamilys.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(terminalFamilys, cancellationToken);    
                    success = updateDeleteCount == terminalFamilys.Count;
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
