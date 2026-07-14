namespace Master.CQRS.Handler.Vehicle
{
    sealed class QueryHandler : IQueryHandler<GetAllVehiclesQuery, List<VehicleGrpc>>
    {
        readonly IMastersReadRepository<DbVehicle> _VehicleRepository;

        List<VehicleGrpc> _Vehicles;

        public QueryHandler(IMastersReadRepository<DbVehicle> vehicleRepository)
        {
            _VehicleRepository = vehicleRepository;
            _Vehicles = [];
        }

        async Task<Result<List<VehicleGrpc>>> IQueryHandler<GetAllVehiclesQuery, List<VehicleGrpc>>.Handle(GetAllVehiclesQuery query, CancellationToken cancellationToken)
        {
            _Vehicles.Clear();
            GetVehicleReadOnlySpec spec = new GetVehicleReadOnlySpec(query.Position, query.TakeAmount);
            List<DbVehicle> results = await _VehicleRepository.ListAsync(spec, cancellationToken);
            foreach (DbVehicle result in results)
            {
                VehicleGrpc mapping = result.MapToVehicleGrpc();
                _Vehicles.Add(mapping);
            }

            return _Vehicles;
        }
    }
}
