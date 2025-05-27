namespace Master.CQRS.Handler.Vehicle
{
    sealed class QueryHandler : IQueryHandler<GetAllVehiclesQuery, List<VehicleDto>>
    {
        readonly IMastersReadRepository<DbVehicle> _VehicleRepository;

        List<VehicleDto> _Vehicles = new();

        public QueryHandler(IMastersReadRepository<DbVehicle> vehicleRepository)
        {
            _VehicleRepository = vehicleRepository;
        }

        async Task<Result<List<VehicleDto>>> IQueryHandler<GetAllVehiclesQuery, List<VehicleDto>>.Handle(GetAllVehiclesQuery query, CancellationToken cancellationToken)
        {
            _Vehicles.Clear();
            List<DbVehicle> results = await _VehicleRepository.ListAsync(new GetVehicleReadOnlySpec(query.Position, query.TakeAmount), cancellationToken);
            foreach (DbVehicle result in results)
            {
                _Vehicles.Add(result.MapToDto());
            }

            return _Vehicles;
        }
    }
}
