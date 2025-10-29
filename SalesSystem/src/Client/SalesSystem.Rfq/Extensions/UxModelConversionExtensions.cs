using System.Threading.Tasks;

namespace SalesSystem.Rfq.Extensions
{
    public static class UxModelConversionExtensions

    {
        public static CustomerProjectUx? ToCustomerProjectUx(this ProjectAssociation association)
        {
            if (association == null)
            {
                return null;
            }

            CustomerProjectUx projectAssociation = new CustomerProjectUx();
            projectAssociation.ProjectId = association.CustomerProjectGuid;
            projectAssociation.ProjectName = association.CustomerProjectName;
            projectAssociation.CustomerId = association.CustomerLocationGuid;
            projectAssociation.CustomerName = association.CustomerLocationName;
            projectAssociation.Id = association.Id;
            return projectAssociation;
        }
        public static async Task<RfqProjectUx?> ToRfqProjectUx(this RfqProject rfqProject, RfqUxClientService uxClientService)
        {
            if (rfqProject == null)
            {
                return null;
            }

            RfqProjectUx uxModel = new RfqProjectUx();
            uxModel.RowId = rfqProject.RowId;
            uxModel.RfqNumber = rfqProject.RfqNumber;
            uxModel.CustomerBusinessUnitGuid = Guid.Parse(rfqProject.CustomerBusinessUnitGuid);
            uxModel.CustomerLocationGuid = Guid.Parse(rfqProject.CustomerLocationGuid);
            uxModel.ProjectGuid = Guid.Parse(rfqProject.ProjectGuid);
            uxModel.RfqReasonId = rfqProject.RfqReasonId;
            uxModel.RfqResponseDeadline = rfqProject.RfqResponseDeadline?.ToDateTime();
            uxModel.CarModelGuid = Guid.Parse(rfqProject.CarModelGuid);
            uxModel.VehicleVolume = rfqProject.VehicleVolume;

            if(0 <= uxClientService.Reasons.Count)
            {
                await uxClientService.GetRfqReasonsAsync();
            }

            RfqReasonGrpc? reason = uxClientService.Reasons.FirstOrDefault(r => r.RowId == rfqProject.RfqReasonId);
            uxModel.RfqReason = reason?.RfqReasonTitle;

            return uxModel;
        }
    }
}
