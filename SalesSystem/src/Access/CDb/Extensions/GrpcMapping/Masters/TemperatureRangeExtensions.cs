namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class TemperatureRangeExtensions
    {
        public static TemperatureRangeGrpc FromEntity(this DbTemperatureRange entity)
        {

            TemperatureRangeGrpc grpc = new TemperatureRangeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.TemperatureRange = entity.TemperatureRange;
            grpc.TemperatureHigh = entity.TemperatureHigh;
            grpc.TemperatureLow = entity.TemperatureLow;
            grpc.IsCustom = entity.IsCustom;
            return grpc;
        }
        public static DbTemperatureRange ToEntity(this TemperatureRangeGrpc grpc)
        {
            DbTemperatureRange entity = new DbTemperatureRange();
            entity.Id = Guid.Parse(grpc.Id);
            entity.TemperatureRange = grpc.TemperatureRange;
            entity.TemperatureHigh = grpc.TemperatureHigh ?? 0;
            entity.TemperatureLow = grpc.TemperatureLow?? 0;
            entity.IsCustom = grpc.IsCustom ?? false;
            return entity;
        }
    }
}
