namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class CrimpingProcessTypeExtensions
    {
        public static CrimpingProcessTypeGrpc FromEntity(this DbCrimpingProcessType entity)
        {

            CrimpingProcessTypeGrpc grpc = new CrimpingProcessTypeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Code = entity.Code;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbCrimpingProcessType ToEntity(this CrimpingProcessTypeGrpc grpc)
        {
            DbCrimpingProcessType entity = new DbCrimpingProcessType();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Code = grpc.Code;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
