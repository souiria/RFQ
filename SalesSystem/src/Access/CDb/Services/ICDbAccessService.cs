namespace CDb.Services
{
    public interface ICDbAccessService
    {
        //Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context);

        // Masters
        #region ClipType
        Task<ListClipTypeGrpc> ReadAllClipTypes(CancellationToken cancellationToken);
        Task<ListClipTypeGrpc> ReadManyClipTypes(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken);
        Task<ListClipTypeGrpc> ReadClipTypeById(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken);
        Task<ListClipTypeGrpc> CreateClipTypes(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken);
        Task<ListClipTypeGrpc> UpdateClipTypes(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken);
        #endregion

        // Main
        #region PartNumber
        //Task<ListPartNumberGrpc> GetAllPartNumbers(CancellationToken cancellationToken);
        //Task<ListPartNumberGrpc> GetManyPartNumbers(PartNumberRequest partNumberRequest, CancellationToken cancellationToken);
        //Task<PartNumberGrpc> GetPartNumberById(PartNumberRequest partNumberRequest, CancellationToken cancellationToken);
        //Task<ListPartNumberGrpc> CreatePartNumbers(PartNumberRequest partNumberRequest, CancellationToken cancellationToken);
        //Task<ListPartNumberGrpc> UpdatePartNumbers(PartNumberRequest partNumberRequest, CancellationToken cancellationToken);
        #endregion

        #region Tag
        //Task<ListTagGrpc> GetAllTags(CancellationToken cancellationToken);
        //Task<ListTagGrpc> GetManyTags(TagRequest tagRequest, CancellationToken cancellationToken);
        //Task<TagGrpc> GetTagById(TagRequest tagRequest, CancellationToken cancellationToken);
        //Task<ListTagGrpc> CreateTags(TagRequest tagRequest, CancellationToken cancellationToken);
        //Task<ListTagGrpc> UpdateTags(TagRequest tagRequest, CancellationToken cancellationToken);
        #endregion

        //Components
        #region CompositeComponent
        Task<ListCompositeComponentGrpc> CreateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> ReadAllCompositeComponents(CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> ReadManyCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> ReadCompositeComponentsById(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> ReadCompositeComponentsBySheetNumber(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> UpdateCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        Task<ListCompositeComponentGrpc> DeleteCompositeComponents(CompositeComponentGrpcRequest request, CancellationToken cancellationToken);
        #endregion
    }
}