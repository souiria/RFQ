using CDb.CQRS.Query.Masters.Person;
using CDb.CQRS.Specification.Masters.Person;

namespace CDb.CQRS.Handler.Masters.Person
{
    sealed class QueryHandler : IQueryHandler<GetPersonsQuery, List<PersonGrpc>>
    {
        readonly ICDbRepository<DbPerson> _Repository;
        List<PersonGrpc> _Persons;

        public QueryHandler(ICDbRepository<DbPerson> repository)
        {
            _Repository = repository;
            _Persons = [];
        }

        async Task<Result<List<PersonGrpc>>> IQueryHandler<GetPersonsQuery, List<PersonGrpc>>.Handle(GetPersonsQuery query, CancellationToken cancellationToken)
        {
            _Persons.Clear();
            GetPersonsSpecification spec = new GetPersonsSpecification(query.Position, query.TakeAmount);
            List<DbPerson> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPerson result in results)
            {
                PersonGrpc personGrpc = result.FromEntity();
                _Persons.Add(personGrpc);
            }

            return _Persons;
        }
    }
}
