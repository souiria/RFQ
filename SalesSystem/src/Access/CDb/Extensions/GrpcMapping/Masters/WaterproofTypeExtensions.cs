namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class WaterproofTypeExtensions
    {
        public static WaterproofTypeGrpc FromEntity(this DbWaterproofType entity)
        {

            WaterproofTypeGrpc grpc = new WaterproofTypeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Code = entity.Code;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbWaterproofType ToEntity(this WaterproofTypeGrpc grpc)
        {
            DbWaterproofType entity = new DbWaterproofType();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Code = grpc.Code;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
