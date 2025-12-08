namespace RfqModule.Services
{
    public interface IRfqManagerService
    {
        Task<GetAllCustomersGrpcResponse> GetAllCustomersGrpc (GetAllCustomersGrpcRequest request);
        Task<GetCustomersByUserIdGrpcResponse> GetCustomersByUserIdGrpc(GetCustomersByUserIdGrpcRequest request);
        Task<GetProjectAssociationsByCustomerIdResponse> GetProjectAssociationsByCustomerId(GetProjectAssociationsByCustomerIdRequest request);
        Task<GetRfqReasonsGrpcResponse> GetRfqReasonsGrpc(GetRfqReasonsGrpcRequest request);
        Task<UploadPartsRequestGrpcResponse> UploadPartsGrpc(UploadPartsRequestGrpcRequest request);
        Task<CreateRfqProjectGrpcResponse> CreateRfqProject(CreateRfqProjectGrpcRequest request);
        Task<GetAllRfqProjectGrpcResponse> GetAllRfqProjectGrpc(GetAllRfqProjectGrpcRequest request);
        Task<GetRfqProjectByIdGrpcResponse> GetRfqProjectByIdGrpc(GetRfqProjectByIdGrpcRequest request);
        Task<UpdateRfqProjectGrpcResponse> UpdateRfqProject(UpdateRfqProjectGrpcRequest request);
        Task<GetRfqDrawingPartNumbersByRfqIdGrpcResponse> GetRfqDrawingPartNumbersByRfqIdGrpc(GetRfqDrawingPartNumbersByRfqIdGrpcRequest request);
        Task<RfqCrudResponse> DeleteRfqProjectByRowIdGrpc(RfqProjectRequest request);
        Task<FilterGrpcResponse> FilterByCustomerId(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterByLocationId(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterByProjectCode(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterEmacsByExactPartNumber(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterEmacsByContainingPartNumber(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterAdssBySumitomoPartNumber(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterNPRBySumitomoPartNumber(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterCPDBySumitomoPartNumber(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterRFQBySumitomoPartNumber(FilterGrpcRequest request);
        Task<UpdateRfqDrawingPartNumbersGrpcResponse> UpdateRfqDrawingPartNumbers(UpdateRfqDrawingPartNumbersGrpcRequest request);
    }
}
