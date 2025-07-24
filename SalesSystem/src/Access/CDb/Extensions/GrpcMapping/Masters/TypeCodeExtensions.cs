namespace CDb.Extensions.GrpcMapping.Masters
{
    public static class TypeCodeExtensions
    {
        public static TypeCodeGrpc FromEntity(this DbTypeCode entity)
        {

            TypeCodeGrpc grpc = new TypeCodeGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Code = entity.Code;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbTypeCode ToEntity(this TypeCodeGrpc grpc)
        {
            DbTypeCode entity = new DbTypeCode();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Code = grpc.Code;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
