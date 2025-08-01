namespace CDb.CQRS.Handler.Masters.Person
{
    public class CommandHandler : ICommandHandler<PersonCommand>
    {
        public CommandHandler(ICDbRepository<DbPerson> repository)
        {
            Repository = repository;
        }

        public ICDbRepository<DbPerson> Repository 
        { get; }

        public async Task<Result> Handle(PersonCommand command, CancellationToken cancellationToken)
        {
            List<DbPerson> partners = command.PersonGrpcs.Select(partnerGrpc => partnerGrpc.ToEntity()).ToList();
            List<Result<DbPerson>> results = new List<Result<DbPerson>>();
            IEnumerable<DbPerson> repositoryActionResult;
            int updateDeleteCount = 0;
            bool success = false;

            switch (command.CommandType)
            {
                case CommandType.Create:
                    repositoryActionResult = await Repository.AddRangeAsync(partners, cancellationToken);
                    success = repositoryActionResult.Count() == partners.Count;
                break;
                case CommandType.Update:
                    updateDeleteCount = await Repository.UpdateRangeAsync(partners, cancellationToken);
                    success = updateDeleteCount == partners.Count;
                break;
                case CommandType.Delete:
                    updateDeleteCount = await Repository.DeleteRangeAsync(partners, cancellationToken);    
                    success = updateDeleteCount == partners.Count;
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
