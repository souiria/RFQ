namespace RfqModule.Services
{
    public interface IRfqManagerService
    {
        Task<GetAllCustomersGrpcResponse> GetAllCustomersGrpc (GetAllCustomersGrpcRequest request);
        Task<GetCustomersByUserIdGrpcResponse> GetCustomersByUserIdGrpc(GetCustomersByUserIdGrpcRequest request);
        Task<GetLocationsByCustomerIdGrpcResponse> GetLocationsByCustomerIdGrpc(GetLocationsByCustomerIdGrpcRequest request);
        Task<GetProjectsByLocationIdGrpcResponse> GetProjectsByLocationIdGrpc(GetProjectsByLocationIdGrpcRequest request);
        Task<GetVehicleByProjectCodeGrpcResponse> GetVehiclesByProjectCodeGrpc(GetVehicleByProjectCodeGrpcRequest request);
        Task<GetRfqReasonsGrpcResponse> GetRfqReasonsGrpc(GetRfqReasonsGrpcRequest request);
        Task<UploadPartsRequestGrpcResponse> UploadPartsGrpc(UploadPartsRequestGrpcRequest request);
    }
}
