namespace CDb.Extensions.GrpcMapping.Components
{
    public static class HousingExtensions
    {
        public static HousingGrpc FromDb(this DbHousing entity)
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
        public static DbHousing ToDb(this HousingGrpc grpc)
        {
            if (grpc == null)
            {
                throw new ArgumentNullException(nameof(grpc), "GRPC object cannot be null.");
            }

            DbHousing entity = new DbHousing();
            entity.Id = Guid.Parse(grpc.Id);
            entity.Description = grpc.Description;
            entity.RowCount = grpc.RowCount ?? 1;
            return entity;
        }
    }
}
