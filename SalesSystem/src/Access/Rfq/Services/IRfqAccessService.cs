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

        #endregion

        #region Project

        Task<ListRfqProjectGrpc> GetAllRfqProjects(CancellationToken cancellationToken);
        Task<ListRfqProjectGrpc> GetRfqProjectByRowId(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        Task<ListRfqProjectGrpc> CreateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqProjects(RfqProjectGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqProjects(CancellationToken cancellationToken);

        #endregion

        #region Notes

        Task<ListRfqNotesGrpc> GetAllRfqNotes(CancellationToken cancellationToken);
        Task<ListRfqNotesGrpc> GetRfqNotesByRowId(RfqNotesGrpcRequest request,CancellationToken cancellationToken);
        Task<ListRfqNotesGrpc> CreateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqNotes(RfqNotesGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqNotes(CancellationToken cancellationToken);

        #endregion

        #region Reason

        Task<ListRfqReasonGrpc> GetAllRfqReasons(CancellationToken cancellationToken);
        Task<ListRfqReasonGrpc> GetRfqReasonsByRowId(RfqReasonGrpcRequest reason, CancellationToken cancellationToken);
        Task<ListRfqReasonGrpc> CreateRfqReason(RfqReasonGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateRfqReasons(RfqReasonGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateRfqReasons(CancellationToken cancellationToken);
        #endregion

        #region DsiBend

        Task<ListDsiBendGrpc> GetAllDsiBends(CancellationToken cancellationToken);
        Task<ListDsiBendGrpc> GetDsiBendsByRowId(DsiBendGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiBendGrpc> CreateDsiBends(DsiBendGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBends(DsiBendGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBends(CancellationToken cancellationToken);

        #endregion

        #region DsiBranchConfiguration

        Task<ListDsiBranchConfigurationGrpc> GetAllDsiBranchConfigurations(CancellationToken cancellationToken);
        Task<ListDsiBranchConfigurationGrpc> GetDsiBranchConfigurationsByRowId(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiBranchConfigurationGrpc> CreateDsiBranchConfigurations(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBranchConfigurations(DsiBranchConfigurationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBranchConfigurations(CancellationToken cancellationToken);

        #endregion

        #region DsiBranchConfigurationBendAssociation

        Task<ListDsiBranchConfigurationBendAssociationGrpc> GetAllDsiBranchConfigurationBendAssociations(CancellationToken cancellationToken);
        Task<ListDsiBranchConfigurationBendAssociationGrpc> GetDsiBranchConfigurationBendAssociationsByRowId(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiBranchConfigurationBendAssociationGrpc> CreateDsiBranchConfigurationBendAssociations(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBranchConfigurationBendAssociations(DsiBranchConfigurationBendAssociationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBranchConfigurationBendAssociations(CancellationToken cancellationToken);

        #endregion

        #region DsiBranchInsulation

        Task<ListDsiBranchInsulationGrpc> GetAllDsiBranchInsulations(CancellationToken cancellationToken);
        Task<ListDsiBranchInsulationGrpc> GetDsiBranchInsulationsByRowId(DsiBranchInsulationGrpcRequest request, CancellationToken cancellationToken);
        Task<ListDsiBranchInsulationGrpc> CreateDsiBranchInsulations(DsiBranchInsulationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> UpdateDsiBranchInsulations(DsiBranchInsulationGrpcRequest request, CancellationToken cancellationToken);
        Task<bool> PopulateDsiBranchInsulations(CancellationToken cancellationToken);

        #endregion
    }
}
