namespace CDb.CQRS.Handler.Masters.TerminalSize
{
    sealed class QueryHandler : IQueryHandler<GetTerminalSizesQuery, List<TerminalSizeGrpc>>
    {
        readonly ICDbRepository<DbTerminalSize> _Repository;
        List<TerminalSizeGrpc> _TerminalSizes;

        public QueryHandler(ICDbRepository<DbTerminalSize> repository)
        {
            _Repository = repository;
            _TerminalSizes = [];
        }

        async Task<Result<List<TerminalSizeGrpc>>> IQueryHandler<GetTerminalSizesQuery, List<TerminalSizeGrpc>>.Handle(GetTerminalSizesQuery query, CancellationToken cancellationToken)
        {
            _TerminalSizes.Clear();
            GetTerminalSizesSpecification spec = new GetTerminalSizesSpecification(query.Position, query.TakeAmount);
            List<DbTerminalSize> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbTerminalSize result in results)
            {
                TerminalSizeGrpc terminalSizeGrpc = result.FromEntity();
                _TerminalSizes.Add(terminalSizeGrpc);
            }

            return _TerminalSizes;
        }
    }
}
