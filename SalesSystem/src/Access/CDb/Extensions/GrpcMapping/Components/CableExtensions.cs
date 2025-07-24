namespace CDb.Extensions.GrpcMapping.Components
{
    public static class CableExtensions
    {
        public static CableGrpc FromDb(this DbCable entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            CableGrpc grpc = new CableGrpc();
            grpc.Id = entity.Id.ToString();
            grpc.Color = (int)entity.Color;
            grpc.WireCount = entity.WireCount;
            grpc.WireCountCode = entity.WireCountCode;
            grpc.Length = (double)entity.Length;
            grpc.IsShielded = entity.IsShielded;

            return grpc;
        }
    }
}
