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
        Task<FilterDataGrpcResponse> FilterDataGrpc(FilterDataGrpcRequest request);
    }
}
