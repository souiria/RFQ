using Master.CQRS.Query.Currency;
using Master.CQRS.Query.Customer;
using Master.CQRS.Specification.Customer;
using Master.Extensions;

namespace Master.CQRS.Handler.Customer
{
    public class QueryHandler : IRequestHandler<GetAllCustomerBusinessUnitsQuery, List<CustomerBusinessHierarchyDto>>,
        IRequestHandler<GetAllCustomerLocationsQuery, List<CustomerHierarchyDto>>
    {
        readonly IMastersReadRepository<DbCustomerBusinessHierarchy> _CustomerBusinessHierarchyRepository;
        readonly IMastersReadRepository<DbCustomerHierarchy> _CustomerHierarchyRepository;
        readonly IMastersReadRepository<DbCustomerProjectAssociation> _CustomerProjectAssociationRepository;

        List<CustomerBusinessHierarchyDto> _Customers = new();
        List<CustomerHierarchyDto> _CustomerLocations = new();
        List<CustomerProjectAssociationDto> _CustomerProjectAssociations = new();

        public QueryHandler(IMastersReadRepository<DbCustomerBusinessHierarchy> customerBusinessHierarchyRepository,
            IMastersReadRepository<DbCustomerHierarchy> customerHierarchyRepository,
            IMastersReadRepository<DbCustomerProjectAssociation> customerProjectAssociationRepository)
        {
            _CustomerBusinessHierarchyRepository = customerBusinessHierarchyRepository;
            _CustomerHierarchyRepository = customerHierarchyRepository;
            _CustomerProjectAssociationRepository = customerProjectAssociationRepository;
        }

        public async Task<List<CustomerBusinessHierarchyDto>> Handle(GetAllCustomerBusinessUnitsQuery request, CancellationToken cancellationToken)
        {
            _Customers.Clear();
            List<DbCustomerBusinessHierarchy> results = await _CustomerBusinessHierarchyRepository.ListAsync(new GetCustomerBusinessUnitsReadOnlySpec(request.Position, request.TakeAmount), cancellationToken);
            foreach (DbCustomerBusinessHierarchy result in results)
            {
                _Customers.Add(result.MapToCustomerBusinessHierarchyDto());
            }

            return _Customers;
        }

        public async Task<List<CustomerHierarchyDto>> Handle(GetAllCustomerLocationsQuery request, CancellationToken cancellationToken)
        {
            _CustomerLocations.Clear();
            List<DbCustomerHierarchy> results = await _CustomerHierarchyRepository.ListAsync(new GetCustomerLocationsReadOnlySpec(request.Position, request.TakeAmount), cancellationToken);
            foreach (DbCustomerHierarchy result in results)
            {
                _CustomerLocations.Add(result.MapToCustomerHierarchyDto());
            }

            return _CustomerLocations;
        }

        public async Task<List<CustomerProjectAssociationDto>> Handle(GetAllCustomerProjectAssociationsQuery request, CancellationToken cancellationToken)
        {
            _CustomerProjectAssociations.Clear();
            List<DbCustomerProjectAssociation> results = await _CustomerProjectAssociationRepository.ListAsync(new GetCustomerProjectAssociationReadOnlySpec(request.Position, request.TakeAmount), cancellationToken);
            foreach (DbCustomerProjectAssociation result in results)
            {
                _CustomerProjectAssociations.Add(result.MapToCustomerProjectAssociationDto());
            }

            return _CustomerProjectAssociations;
        }
    }
}
