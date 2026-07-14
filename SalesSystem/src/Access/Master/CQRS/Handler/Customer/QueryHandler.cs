namespace Master.CQRS.Handler.Customer
{
    sealed class QueryHandler : IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerGrpc>>,
        IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerLocationGrpc>>,
        IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationGrpc>>,
        IQueryHandler<GetAllCustomerSalesEntitiesQuery, List<CustomerSalesEntityGrpc>>,
        IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationGrpc>>
    {
        readonly IMastersReadRepository<DbCustomerBusinessHierarchy> _CustomerBusinessHierarchyRepository;
        readonly IMastersReadRepository<DbCustomerHierarchy> _CustomerHierarchyRepository;
        readonly IMastersReadRepository<DbCustomerProjectAssociation> _CustomerProjectAssociationRepository;
        readonly IMastersReadRepository<DbCustomerSalesEntity> _CustomerSalesEntityRepository;
        readonly IMastersReadRepository<DbCustomerBusinessUserAssociation> _CustomerBusinessUserAssociationRepository;

        List<CustomerGrpc> _Customers;
        List<CustomerLocationGrpc> _CustomerLocations;
        List<CustomerProjectAssociationGrpc> _CustomerProjectAssociations;
        List<CustomerSalesEntityGrpc> _CustomerSalesEntities;
        List<CustomerBusinessUserAssociationGrpc> _CustomerBusinessUserAssociations;

        public QueryHandler(IMastersReadRepository<DbCustomerBusinessHierarchy> customerBusinessHierarchyRepository,
            IMastersReadRepository<DbCustomerHierarchy> customerHierarchyRepository,
            IMastersReadRepository<DbCustomerProjectAssociation> customerProjectAssociationRepository,
            IMastersReadRepository<DbCustomerSalesEntity> customerSalesEntityRepository,
            IMastersReadRepository<DbCustomerBusinessUserAssociation> customerBusinessUserAssociationRepository)
        {
            _CustomerBusinessHierarchyRepository = customerBusinessHierarchyRepository;
            _CustomerHierarchyRepository = customerHierarchyRepository;
            _CustomerProjectAssociationRepository = customerProjectAssociationRepository;
            _CustomerSalesEntityRepository = customerSalesEntityRepository;
            _CustomerBusinessUserAssociationRepository = customerBusinessUserAssociationRepository;

            _Customers = [];
            _CustomerLocations = [];
            _CustomerProjectAssociations = [];
            _CustomerSalesEntities = [];
            _CustomerBusinessUserAssociations = [];
        }

        async Task<Result<List<CustomerGrpc>>> IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerGrpc>>.Handle(GetAllCustomerBusinessUnitsQuery query, CancellationToken cancellationToken)
        {
            _Customers.Clear();
            GetCustomerBusinessUnitsReadOnlySpec spec = new GetCustomerBusinessUnitsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerBusinessHierarchy> results = await _CustomerBusinessHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerBusinessHierarchy result in results)
            {
                CustomerGrpc mapping = result.MapToCustomerGrpc();
                _Customers.Add(mapping);
            }

            return _Customers;
        }

        async Task<Result<List<CustomerLocationGrpc>>> IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerLocationGrpc>>.Handle(GetAllCustomerLocationsQuery query, CancellationToken cancellationToken)
        {
            _CustomerLocations.Clear();
            GetCustomerLocationsReadOnlySpec spec = new GetCustomerLocationsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerHierarchy> results = await _CustomerHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerHierarchy result in results)
            {
                CustomerLocationGrpc mapping = result.MapToLocationGrpc();
                _CustomerLocations.Add(mapping);
            }

            return _CustomerLocations;
        }

        async Task<Result<List<CustomerProjectAssociationGrpc>>> IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationGrpc>>.Handle(GetAllCustomerProjectAssociationsQuery query, CancellationToken cancellationToken)
        {
            _CustomerProjectAssociations.Clear();
            GetCustomerProjectAssociationReadOnlySpec spec = new GetCustomerProjectAssociationReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerProjectAssociation> results = await _CustomerProjectAssociationRepository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerProjectAssociation result in results)
            {
                CustomerProjectAssociationGrpc mapping = result.MapToCustomerProjectAssociationGrpc();
                _CustomerProjectAssociations.Add(mapping);
            }

            return _CustomerProjectAssociations;
        }

        async Task<Result<List<CustomerSalesEntityGrpc>>> IQueryHandler<GetAllCustomerSalesEntitiesQuery, List<CustomerSalesEntityGrpc>>.Handle(GetAllCustomerSalesEntitiesQuery query, CancellationToken cancellationToken)
        {
            _CustomerSalesEntities.Clear();
            GetCustomerSalesEntitiesReadOnlySpec spec = new GetCustomerSalesEntitiesReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerSalesEntity> results = await _CustomerSalesEntityRepository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerSalesEntity result in results)
            {
                CustomerSalesEntityGrpc mapping = result.MapToCustomerSalesEntityGrpc();
                _CustomerSalesEntities.Add(mapping);
            }

            return _CustomerSalesEntities;
        }

        async Task<Result<List<CustomerBusinessUserAssociationGrpc>>> IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationGrpc>>.Handle(GetCustomerBusinessUserAssociationsQuery query, CancellationToken cancellationToken)
        {
            _CustomerBusinessUserAssociations.Clear();
            GetCustomerBusinessUserAssociationReadOnlySpec spec = new GetCustomerBusinessUserAssociationReadOnlySpec(query.Position, query.TakeAmount, query.UserGuid);
            List<DbCustomerBusinessUserAssociation> results = await _CustomerBusinessUserAssociationRepository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerBusinessUserAssociation result in results)
            {
                CustomerBusinessUserAssociationGrpc mapping = result.MapToCustomerBusinessUserAssociationGrpc();
                _CustomerBusinessUserAssociations.Add(mapping);
            }

            return _CustomerBusinessUserAssociations;
        }
    }
}
