namespace RfqModule.Services
{
    public interface IRfqManagerService
    {
        Task<GetCustomersGrpcResponse> GetCustomersGrpc(GetCustomersGrpcRequest request);
        Task<GetLocationsByCustomerIdGrpcResponse> GetLocationsByCustomerIdGrpc(GetLocationsByCustomerIdGrpcRequest request);
        Task<GetProjectsByLocationIdGrpcResponse> GetProjectsByLocationIdGrpc(GetProjectsByLocationIdGrpcRequest request);
        Task<GetVehicleByProjectCodeGrpcResponse> GetVehiclesByProjectCodeGrpc(GetVehicleByProjectCodeGrpcRequest request);
        Task<GetRfqReasonsGrpcResponse> GetRfqReasonsGrpc(GetRfqReasonsGrpcRequest request);
        Task<UploadPartsRequestGrpcResponse> UploadPartsGrpc(UploadPartsRequestGrpcRequest request);
        Task<FilterGrpcResponse> FilterByCustomerId(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterByLocationId(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterByProjectCode(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterEmacsByExactPartNumber(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterEmacsByContainingPartNumber(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterAdssBySumitomoPartNumber(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterNPRBySumitomoPartNumber(FilterGrpcRequest request);
        Task<FilterGrpcResponse> FilterCPDBySumitomoPartNumber(FilterGrpcRequest request);
    }
}
