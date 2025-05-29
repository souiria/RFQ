namespace Master.CQRS.Handler.Vehicle
{
    sealed class QueryHandler : IQueryHandler<GetAllVehiclesQuery, List<VehicleDto>>
    {
        readonly IMastersReadRepository<DbVehicle> _VehicleRepository;

        List<VehicleDto> _Vehicles;

        public QueryHandler(IMastersReadRepository<DbVehicle> vehicleRepository)
        {
            _VehicleRepository = vehicleRepository;
            _Vehicles = [];
        }

        async Task<Result<List<VehicleDto>>> IQueryHandler<GetAllVehiclesQuery, List<VehicleDto>>.Handle(GetAllVehiclesQuery query, CancellationToken cancellationToken)
        {
            _Vehicles.Clear();
            GetVehicleReadOnlySpec spec = new GetVehicleReadOnlySpec(query.Position, query.TakeAmount);
            List<DbVehicle> results = await _VehicleRepository.ListAsync(spec, cancellationToken);
            foreach (DbVehicle result in results)
            {
                VehicleDto mapping = result.MapToDto();
                _Vehicles.Add(mapping);
            }

            return _Vehicles;
        }
    }
}
