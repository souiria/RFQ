namespace DSI.Services
{
    public interface IDSIAccessService
    {
        Task<ListBranchInsulationGrpc> GetAllBranchInsulation(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
      Task<ListWireSpecificationGrpc> GetAllWireSpecification(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
       Task<ListHarnessGrpc> GetAllHarness(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<ListCompositeDetailGrpc> GetAllCompositeDetail(
            CancellationToken cancellationToken,
            int position = 0,
            int takeAmount = 0);
        Task<ListCompositeDetailGrpc> GetCompositeDetailByHarnessName(string harnessName,CancellationToken cancellationToken);
        Task<ListComponentGrpc> GetComponentsByHarnessAndOptions(string harnessName, IEnumerable<string> compositeOptions, CancellationToken cancellationToken);
        Task<ListComponentGrpc> GetAllComponent(CancellationToken cancellationToken, int position = 0, int takeAmount = 0);
        Task<bool> PopulateComponent(CancellationToken cancellationToken);
        Task<bool> PopulateBranchInsulation(CancellationToken cancellationToken);
        Task<bool> PopulateWireSpecification(CancellationToken cancellationToken);
        Task<bool> PopulateHarness(CancellationToken cancellationToken);
        Task<bool> PopulateCompositeDetail(CancellationToken cancellationToken);
        Task HandleFilterCase<T>(string filterExpressionString, ParsingConfig parsingConfig,
            Action<IEnumerable<T>> setResponseCollection, CancellationToken cancellationToken);
       }
}
