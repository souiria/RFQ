namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class MaterialTypeExtensions
    {
        public static MaterialTypeGrpc FromEntity(this DbMaterialType entity)
        {

            MaterialTypeGrpc grpc = new MaterialTypeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Code = entity.Code;
            grpc.Description = entity.Description;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbMaterialType ToEntity(this MaterialTypeGrpc grpc)
        {
            DbMaterialType entity = new DbMaterialType();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Code = grpc.Code;
            entity.Description = grpc.Description;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
