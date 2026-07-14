namespace Master.CQRS.Handler.ProjectEngineeringAssociation
{
    sealed class QueryHandler : IQueryHandler<GetProjectEngineeringAssociationsQuery, List<ProjectEngineeringAssociationGrpc>>
    {
        readonly IMastersReadRepository<DbProjectEngineeringAssociation> _Repository;
        List<ProjectEngineeringAssociationGrpc> _ProjectEngineeringAssociations;

        public QueryHandler(IMastersReadRepository<DbProjectEngineeringAssociation> repository)
        {
            _Repository = repository;
            _ProjectEngineeringAssociations = [];
        }

        async Task<Result<List<ProjectEngineeringAssociationGrpc>>>
            IQueryHandler<GetProjectEngineeringAssociationsQuery, List<ProjectEngineeringAssociationGrpc>>
            .Handle(GetProjectEngineeringAssociationsQuery query, CancellationToken cancellationToken)
        {
            _ProjectEngineeringAssociations.Clear();

            GetProjectEngineeringAssociationsReadOnlySpec spec =
                new GetProjectEngineeringAssociationsReadOnlySpec(query.Position, query.TakeAmount);

            List<DbProjectEngineeringAssociation> results =
                await _Repository.ListAsync(spec, cancellationToken);

            foreach (DbProjectEngineeringAssociation result in results)
            {
                ProjectEngineeringAssociationGrpc item =
                    result.MapToProjectEngineeringAssociationGrpc();

                _ProjectEngineeringAssociations.Add(item);
            }

            return _ProjectEngineeringAssociations;
        }
    }
}
