namespace RfqModule.Services
{
    public interface IRfqManagerService
    {
        Task<GetAllCustomersGrpcResponse> GetAllCustomersGrpc (GetAllCustomersGrpcRequest request);
        //Task<GetCustomersByUserIdGrpcResponse> GetCustomersByUserIdGrpc(GetCustomersByUserIdGrpcRequest request);
        Task<GetProjectAssociationsByCustomerIdResponse> GetProjectAssociationsByCustomerId(GetProjectAssociationsByCustomerIdRequest request);
        Task<GetRfqReasonsGrpcResponse> GetRfqReasonsGrpc(GetRfqReasonsGrpcRequest request);
        Task<UploadPartsRequestGrpcResponse> UploadPartsGrpc(UploadPartsRequestGrpcRequest request);
        Task<CreateRfqProjectGrpcResponse> CreateRfqProject(CreateRfqProjectGrpcRequest request);
        Task<GetAllRfqProjectGrpcResponse> GetAllRfqProjectGrpc(GetAllRfqProjectGrpcRequest request);
        Task<GetRfqProjectByIdGrpcResponse> GetRfqProjectByIdGrpc(GetRfqProjectByIdGrpcRequest request);
        Task<UpdateRfqProjectGrpcResponse> UpdateRfqProject(UpdateRfqProjectGrpcRequest request);
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
        Task<ListRfqDrawingPartNumberGrpc> GetRfqDrawingPartNumbersByRfqIdGrpc(RfqDrawingPartNumbersGrpcRequest request);
        Task<RfqCrudResponse> DeleteRfqDrawingPartNumbersGrpc(RfqDrawingPartNumbersGrpcRequest request);
        Task<RfqCrudResponse> UpdateRfqDrawingPartNumbers(RfqDrawingPartNumbersGrpcRequest request);
        Task<GetCustomerLocationsByUserIdResponse> GetCustomerLocationsByUserId(string userId);
        Task<GetCustomerBusinessUnitsByUserIdResponse> GetCustomerBusinessUnitsByUserId(string userId);
        Task<GetAlternativePartInfoBySumitomoNumberResponse> GetAlternativePartInfoBySumitomoNumberResponse (string sumitomoNumber);
        Task<GetAllAlternativePartsGrpcResponse> GetAllAlternativePartsGrpc(GetAllAlternativePartsGrpcRequest request, CancellationToken cancellation);
        Task<GetRfqNprRequestByRfqNumberGrpcResponse> GetRfqNprRequestByRfqNumberGrpc(GetRfqNprRequestByRfqNumberGrpcRequest request);
        Task<GetRfqNprRequestByRfqProjectIdGrpcResponse> GetRfqNprRequestByRfqProjectIdGrpc(GetRfqNprRequestByRfqProjectIdGrpcRequest request);
        Task<GetRfqNprRequestByIdGrpcResponse> GetRfqNprRequestByIdGrpc(GetRfqNprRequestByIdGrpcRequest request);
        Task<GetAllRfqNprRequestGrpcResponse> GetAllRfqNprRequestGrpc(GetAllRfqNprRequestGrpcRequest request);
        Task<CreateRfqNprRequestGrpcResponse> CreateRfqNprRequestGrpc(CreateRfqNprRequestGrpcRequest request);
        Task<UpdateRfqNprRequestGrpcResponse> UpdateRfqNprRequestGrpc(UpdateRfqNprRequestGrpcRequest request);
        Task<UpdateRfqNprRequestStatusGrpcResponse> UpdateRfqNprRequestStatusGrpc(UpdateRfqNprRequestStatusGrpcRequest request);
        Task<DeleteRfqNprRequestByIdGrpcResponse> DeleteRfqNprRequestByIdGrpc(DeleteRfqNprRequestByIdGrpcRequest request);
        Task<GetAllSuppliersGrpcResponse> GetAllSuppliersGrpc(GetAllSuppliersGrpcRequest request);
        Task<GetAllSupplierGroupsGrpcResponse> GetAllSupplierGroupsGrpc(GetAllSupplierGroupsGrpcRequest request);
        Task<SearchPartPricesGrpcResponse> SearchPartPricesGrpc(SearchPartPricesGrpcRequest request);
        Task<GetAllUnitOfMeasuresResponse> GetAllUnitOfMeasuresGrpc(GetAllUnitOfMeasuresRequest request);
        Task<GetAllBusinessUnitsGrpcResponse> GetAllBusinessUnitsGrpc(GetAllBusinessUnitsGrpcRequest request);
        Task<CreateNprGrpcResponse> CreateNprGrpc(CreateNprGrpcRequest request);
        Task<GetAllHarnessModuleResponse> GetAllHarnessGrpc(GetAllHarnessModuleRequest request);
        Task<GetHarnessByIdGrpcResponse> GetHarnessByIdGrpc(GetHarnessByIdGrpcRequest request);
        Task<GetCompositeDetailByHarnessResponse> GetCompositeDetailByHarnessGrpc(GetCompositeDetailByHarnessRequest request);
        Task<GetCompositeDetailByHarnessNameResponse> GetCompositeDetailByHarnessNameGrpc(GetCompositeDetailByHarnessNameRequest request);
        Task<GetWireSpecificationByCompositeOptionResponse> GetWireSpecificationByCompositeOptionGrpc(GetWireSpecificationByCompositeOptionRequest request);
        Task<ListComponentGrpc> GetComponentsByHarnessAndOptionsGrpc(GetComponentsByHarnessAndOptionsRequest request);
     }
}

