namespace CDb.Extensions.GrpcMapping
{
    public static class CompositeComponentExtensions
    {
        public static CompositeComponentGrpc FromDb(this DbCable entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            ComponentGrpc componentGrpc = ((DbComponent)entity).FromDb();

            CompositeComponentGrpc grpc = new CompositeComponentGrpc();
            grpc.ComponentGrpc = componentGrpc;
            grpc.CableGrpc = CableExtensions.FromDb(entity);

            return grpc;
        }
        public static CompositeComponentGrpc FromDb(this DbClip entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
            }

            ComponentGrpc componentGrpc = ((DbComponent)entity).FromDb();

            CompositeComponentGrpc grpc = new CompositeComponentGrpc();
            grpc.ComponentGrpc = componentGrpc;
            grpc.ClipGrpc = ClipExtensions.FromDb(entity);

            return grpc;
        }
    }
}
