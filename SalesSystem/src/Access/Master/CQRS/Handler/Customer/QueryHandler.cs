namespace Master.CQRS.Handler.Customer
{
    sealed class QueryHandler : IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerBusinessHierarchyDto>>,
        IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerHierarchyDto>>,
        IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationDto>>,
        IQueryHandler<GetAllCustomerSalesEntitiesQuery, List<CustomerSalesEntityDto>>,
        IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationDto>>
    {
        readonly IMastersReadRepository<DbCustomerBusinessHierarchy> _CustomerBusinessHierarchyRepository;
        readonly IMastersReadRepository<DbCustomerHierarchy> _CustomerHierarchyRepository;
        readonly IMastersReadRepository<DbCustomerProjectAssociation> _CustomerProjectAssociationRepository;
        readonly IMastersReadRepository<DbCustomerSalesEntity> _CustomerSalesEntityRepository;
        readonly IMastersReadRepository<DbCustomerBusinessUserAssociation> _CustomerBusinessUserAssociationRepository;

        List<CustomerBusinessHierarchyDto> _Customers;
        List<CustomerHierarchyDto> _CustomerLocations;
        List<CustomerProjectAssociationDto> _CustomerProjectAssociations;
        List<CustomerSalesEntityDto> _CustomerSalesEntities;
        List<CustomerBusinessUserAssociationDto> _CustomerBusinessUserAssociations;

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

        async Task<Result<List<CustomerBusinessHierarchyDto>>> IQueryHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerBusinessHierarchyDto>>.Handle(GetAllCustomerBusinessUnitsQuery query, CancellationToken cancellationToken)
        {
            _Customers.Clear();
            GetCustomerBusinessUnitsReadOnlySpec spec = new GetCustomerBusinessUnitsReadOnlySpec(query.Position, query.TakeAmount);
            List<DbCustomerBusinessHierarchy> results = await _CustomerBusinessHierarchyRepository.ListAsync(spec, cancellationToken);
            foreach (DbCustomerBusinessHierarchy result in results)
            {
                CustomerBusinessHierarchyDto mapping = result.MapToCustomerBusinessHierarchyDto();
                _Customers.Add(mapping);
            }

            return _Customers;
        }

        async Task<Result<List<CustomerHierarchyDto>>> IQueryHandler<GetAllCustomerLocationsQuery, List<CustomerHierarchyDto>>.Handle(GetAllCustomerLocationsQuery query, CancellationToken cancellationToken)
        {
            _CustomerLocations.Clear();
            List<DbCustomerHierarchy> results = await _CustomerHierarchyRepository.ListAsync(new GetCustomerLocationsReadOnlySpec(query.Position, query.TakeAmount), cancellationToken);
            foreach (DbCustomerHierarchy result in results)
            {
                _CustomerLocations.Add(result.MapToCustomerHierarchyDto());
            }

            return _CustomerLocations;
        }

        async Task<Result<List<CustomerProjectAssociationDto>>> IQueryHandler<GetAllCustomerProjectAssociationsQuery, List<CustomerProjectAssociationDto>>.Handle(GetAllCustomerProjectAssociationsQuery query, CancellationToken cancellationToken)
        {
            _CustomerProjectAssociations.Clear();
            List<DbCustomerProjectAssociation> results = await _CustomerProjectAssociationRepository.ListAsync(new GetCustomerProjectAssociationReadOnlySpec(query.Position, query.TakeAmount), cancellationToken);
            foreach (DbCustomerProjectAssociation result in results)
            {
                _CustomerProjectAssociations.Add(result.MapToCustomerProjectAssociationDto());
            }

            return _CustomerProjectAssociations;
        }

        async Task<Result<List<CustomerSalesEntityDto>>> IQueryHandler<GetAllCustomerSalesEntitiesQuery, List<CustomerSalesEntityDto>>.Handle(GetAllCustomerSalesEntitiesQuery query, CancellationToken cancellationToken)
        {
            _CustomerSalesEntities.Clear();
            List<DbCustomerSalesEntity> results = await _CustomerSalesEntityRepository.ListAsync(new GetCustomerSalesEntitiesReadOnlySpec(query.Position, query.TakeAmount), cancellationToken);
            foreach (DbCustomerSalesEntity result in results)
            {
                _CustomerSalesEntities.Add(result.MapToCustomerSalesEntityDto());
            }

            return _CustomerSalesEntities;
        }

        async Task<Result<List<CustomerBusinessUserAssociationDto>>> IQueryHandler<GetCustomerBusinessUserAssociationsQuery, List<CustomerBusinessUserAssociationDto>>.Handle(GetCustomerBusinessUserAssociationsQuery query, CancellationToken cancellationToken)
        {
            _CustomerBusinessUserAssociations.Clear();
            List<DbCustomerBusinessUserAssociation> results = await _CustomerBusinessUserAssociationRepository.ListAsync(new GetCustomerBusinessUserAssociationReadOnlySpec(query.Position, query.TakeAmount, query.UserGuid), cancellationToken);
            foreach (DbCustomerBusinessUserAssociation result in results)
            {
                _CustomerBusinessUserAssociations.Add(result.MapToCustomerBusinessUserAssociationDto());
            }

            return _CustomerBusinessUserAssociations;
        }
    }
}
