namespace Master.CQRS.Handler.Customer
{
    sealed class QueryHandler : IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerData>>,
        IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerLocationData>>,
        IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationData>>,
        IQueryHandler<GetAllCustomerSalesEntitiesQuery, List<CustomerSalesEntityData>>,
        IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationData>>
    {
        readonly IMastersReadRepository<DbCustomerBusinessHierarchy> _CustomerBusinessHierarchyRepository;
        readonly IMastersReadRepository<DbCustomerHierarchy> _CustomerHierarchyRepository;
        readonly IMastersReadRepository<DbCustomerProjectAssociation> _CustomerProjectAssociationRepository;
        readonly IMastersReadRepository<DbCustomerSalesEntity> _CustomerSalesEntityRepository;
        readonly IMastersReadRepository<DbCustomerBusinessUserAssociation> _CustomerBusinessUserAssociationRepository;

        List<CustomerData> _Customers;
        List<CustomerLocationData> _CustomerLocations;
        List<CustomerProjectAssociationData> _CustomerProjectAssociations;
        List<CustomerSalesEntityData> _CustomerSalesEntities;
        List<CustomerBusinessUserAssociationData> _CustomerBusinessUserAssociations;

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

        async Task<Result<List<CustomerData>>> IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerData>>.Handle(GetAllCustomerBusinessUnitsQuery query, CancellationToken cancellationToken)
        {
            _Customers.Clear();
            GetCustomerBusinessUnitsReadOnlySpec spec = new GetCustomerBusinessUnitsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerBusinessHierarchy> results = await _CustomerBusinessHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerBusinessHierarchy result in results)
            {
                CustomerData mapping = result.MapToCustomerData();
                _Customers.Add(mapping);
            }

            return _Customers;
        }

        async Task<Result<List<CustomerLocationData>>> IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerLocationData>>.Handle(GetAllCustomerLocationsQuery query, CancellationToken cancellationToken)
        {
            _CustomerLocations.Clear();
            GetCustomerLocationsReadOnlySpec spec = new GetCustomerLocationsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerHierarchy> results = await _CustomerHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerHierarchy result in results)
            {
                CustomerLocationData mapping = result.MapToLocationData();
                _CustomerLocations.Add(mapping);
            }

            return _CustomerLocations;
        }

        async Task<Result<List<CustomerProjectAssociationData>>> IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationData>>.Handle(GetAllCustomerProjectAssociationsQuery query, CancellationToken cancellationToken)
        {
            _CustomerProjectAssociations.Clear();
            GetCustomerProjectAssociationReadOnlySpec spec = new GetCustomerProjectAssociationReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerProjectAssociation> results = await _CustomerProjectAssociationRepository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerProjectAssociation result in results)
            {
                CustomerProjectAssociationData mapping = result.MapToCustomerProjectAssociationDto();
                _CustomerProjectAssociations.Add(mapping);
            }

            return _CustomerProjectAssociations;
        }

        async Task<Result<List<CustomerSalesEntityData>>> IQueryHandler<GetAllCustomerSalesEntitiesQuery, List<CustomerSalesEntityData>>.Handle(GetAllCustomerSalesEntitiesQuery query, CancellationToken cancellationToken)
        {
            _CustomerSalesEntities.Clear();
            GetCustomerSalesEntitiesReadOnlySpec spec = new GetCustomerSalesEntitiesReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerSalesEntity> results = await _CustomerSalesEntityRepository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerSalesEntity result in results)
            {
                CustomerSalesEntityData mapping = result.MapToCustomerSalesEntityDto();
                _CustomerSalesEntities.Add(mapping);
            }

            return _CustomerSalesEntities;
        }

        async Task<Result<List<CustomerBusinessUserAssociationData>>> IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationData>>.Handle(GetCustomerBusinessUserAssociationsQuery query, CancellationToken cancellationToken)
        {
            _CustomerBusinessUserAssociations.Clear();
            GetCustomerBusinessUserAssociationReadOnlySpec spec = new GetCustomerBusinessUserAssociationReadOnlySpec(query.Position, query.TakeAmount, query.UserGuid);
            List<DbCustomerBusinessUserAssociation> results = await _CustomerBusinessUserAssociationRepository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerBusinessUserAssociation result in results)
            {
                CustomerBusinessUserAssociationData mapping = result.MapToCustomerBusinessUserAssociationDto();
                _CustomerBusinessUserAssociations.Add(mapping);
            }

            return _CustomerBusinessUserAssociations;
        }
    }
}
