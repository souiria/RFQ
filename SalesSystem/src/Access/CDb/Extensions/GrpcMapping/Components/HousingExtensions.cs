namespace CDb.Extensions.GrpcMapping.Components
{
    public static class HousingExtensions
    {
        public static HousingGrpc FromEntity(this DbHousing entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            HousingGrpc grpc = new HousingGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Description = entity.Description;
            grpc.RowCount = entity.RowCount;

            return grpc;
        }
        public static void ToEntity(this HousingGrpc grpc, DbHousing entity)
        {
            entity.Id = Guid.Parse(grpc.Id);
            entity.Description = grpc.Description;
            entity.RowCount = grpc.RowCount ?? 1;
        }
    }
}
