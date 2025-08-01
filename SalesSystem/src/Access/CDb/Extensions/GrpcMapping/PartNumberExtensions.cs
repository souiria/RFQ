namespace CDb.Extensions.GrpcMapping
{
    public static class PartNumberExtensions
    {
        public static PartNumberGrpc FromEntity(this DbPartNumber entity)
        {

            PartNumberGrpc grpc = new PartNumberGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Name = entity.Name;
            grpc.Description = entity.Description;
            grpc.PartNumberType = (int)entity.PartNumberType;
            grpc.IsActive = entity.IsActive;
            return grpc;
        }
        public static DbPartNumber ToEntity(this PartNumberGrpc grpc)
        {
            DbPartNumber entity = new DbPartNumber();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Name = grpc.Name;
            entity.Description = grpc.Description;
            entity.PartNumberType = grpc.PartNumberType is null ? PartNumberType.UNKNOWN : (PartNumberType)grpc.PartNumberType;
            entity.IsActive = grpc.IsActive ?? false;
            return entity;
        }
    }
}
