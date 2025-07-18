namespace CDb.Services
{
    public interface ICDbAccessService
    {
        //Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context);

        // Masters
        #region ClipType
        Task<ListClipTypeGrpc> GetAllClipTypes(CancellationToken cancellationToken);
        Task<ListClipTypeGrpc> GetManyClipTypes(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken);
        Task<ListClipTypeGrpc> GetClipTypeById(ClipTypeGrpcRequest clipTypeRequest, CancellationToken cancellationToken);
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

    }
}