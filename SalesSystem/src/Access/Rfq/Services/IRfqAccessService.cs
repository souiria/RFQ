namespace Rfq.Services
{
    public interface IRfqAccessService
    {
        #region PartNumber
        Task<ListRfqDrawingPartNumbersGrpc> GetAllRfqDrawingPartNumbers(CancellationToken cancellationToken);
        Task<ListRfqDrawingPartNumbersGrpc> GetRfqDrawingPartNumbersByRowId(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken);
        Task<ListRfqDrawingPartNumbersGrpc> CreateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqDrawingPartNumbers(CancellationToken cancellationToken);
        Task<ListRfqProjectGrpc> GetAllRfqProjects(CancellationToken cancellationToken);
        Task<ListRfqProjectGrpc> GetRfqProjectByRowId(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        Task<ListRfqProjectGrpc> CreateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqProjects(CancellationToken cancellationToken);
        Task<ListRfqNotesGrpc> GetAllRfqNotes(CancellationToken cancellationToken);
        Task<ListRfqNotesGrpc> GetRfqNotesByRowId(RfqNotesGrpcRequest request,CancellationToken cancellationToken);
        Task<ListRfqNotesGrpc> CreateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqNotes(CancellationToken cancellationToken);
        Task<ListRfqReasonGrpc> GetAllRfqReasons(CancellationToken cancellationToken);
        Task<ListRfqReasonGrpc> GetRfqReasonsByRowId(RfqReasonGrpcRequest reason, CancellationToken cancellationToken);
        Task<ListRfqReasonGrpc> CreateRfqReason(RfqReasonGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqReasons(RfqReasonGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqReasons(CancellationToken cancellationToken);
        #endregion
    }
}
