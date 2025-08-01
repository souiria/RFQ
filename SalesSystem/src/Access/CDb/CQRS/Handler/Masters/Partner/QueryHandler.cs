namespace CDb.CQRS.Handler.Masters.Partner
{
    sealed class QueryHandler : IQueryHandler<GetPartnersQuery, List<PartnerGrpc>>
    {
        readonly ICDbRepository<DbPartner> _Repository;
        List<PartnerGrpc> _Partners;

        public QueryHandler(ICDbRepository<DbPartner> repository)
        {
            _Repository = repository;
            _Partners = [];
        }

        async Task<Result<List<PartnerGrpc>>> IQueryHandler<GetPartnersQuery, List<PartnerGrpc>>.Handle(GetPartnersQuery query, CancellationToken cancellationToken)
        {
            _Partners.Clear();
            GetPartnersSpecification spec = new GetPartnersSpecification(query.Position, query.TakeAmount);
            List<DbPartner> results = await _Repository.ListAsync(spec, cancellationToken);
            foreach (DbPartner result in results)
            {
                PartnerGrpc partnerGrpc = result.FromEntity();
                _Partners.Add(partnerGrpc);
            }

            return _Partners;
        }
    }
}
