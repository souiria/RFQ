namespace CDb.CQRS.Handler.Masters.TerminalFamily
{
    sealed class QueryHandler : IQueryHandler<GetTerminalFamilysQuery, List<TerminalFamilyGrpc>>
    {
        readonly ICDbRepository<DbTerminalFamily> _Repository;
        List<TerminalFamilyGrpc> _TerminalFamilys;

        public QueryHandler(ICDbRepository<DbTerminalFamily> repository)
        {
            _Repository = repository;
            _TerminalFamilys = [];
        }

        async Task<Result<List<TerminalFamilyGrpc>>> IQueryHandler<GetTerminalFamilysQuery, List<TerminalFamilyGrpc>>.Handle(GetTerminalFamilysQuery query, CancellationToken cancellationToken)
        {
            _TerminalFamilys.Clear();
            GetTerminalFamilysSpecification spec = new GetTerminalFamilysSpecification(query.Position, query.TakeAmount);
            List<DbTerminalFamily> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbTerminalFamily result in results)
            {
                TerminalFamilyGrpc terminalFamilyGrpc = result.FromEntity();
                _TerminalFamilys.Add(terminalFamilyGrpc);
            }

            return _TerminalFamilys;
        }
    }
}
