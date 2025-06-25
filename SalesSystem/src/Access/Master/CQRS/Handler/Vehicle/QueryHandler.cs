namespace Master.CQRS.Handler.Vehicle
{
    sealed class QueryHandler : IQueryHandler<GetAllVehiclesQuery, List<VehicleData>>
    {
        readonly IMastersReadRepository<DbVehicle> _VehicleRepository;

        List<VehicleData> _Vehicles;

        public QueryHandler(IMastersReadRepository<DbVehicle> vehicleRepository)
        {
            _VehicleRepository = vehicleRepository;
            _Vehicles = [];
        }

        async Task<Result<List<VehicleData>>> IQueryHandler<GetAllVehiclesQuery, List<VehicleData>>.Handle(GetAllVehiclesQuery query, CancellationToken cancellationToken)
        {
            _Vehicles.Clear();
            GetVehicleReadOnlySpec spec = new GetVehicleReadOnlySpec(query.Position, query.TakeAmount);
            List<DbVehicle> results = await _VehicleRepository.ListAsync(spec, cancellationToken);
            foreach (DbVehicle result in results)
            {
                VehicleData mapping = result.MapToVehicleData();
                _Vehicles.Add(mapping);
            }

            return _Vehicles;
        }
    }
}
