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
        public static RfqProjectUx?ToRfqProjectUx(this RfqProject rfqProject)
        {
            if (rfqProject == null)
            {
                return null;
            }

            RfqProjectUx uxModel = new RfqProjectUx();
            uxModel.RowId = rfqProject.RowId;
            uxModel.RfqNumber = rfqProject.RfqNumber;
            uxModel.CustomerBusinessUnitId = rfqProject.CustomerBusinessUnitGuid.Trim().ToUpperInvariant();
            uxModel.CustomerLocationId = rfqProject.CustomerLocationGuid.Trim().ToUpperInvariant();
            uxModel.ProjectId = rfqProject.ProjectGuid.Trim().ToUpperInvariant();
            uxModel.RfqReasonId = rfqProject.RfqReasonId;
            uxModel.RfqResponseDeadline = rfqProject.RfqResponseDeadline?.ToDateTime();
            uxModel.CarModelId = rfqProject.CarModelGuid.Trim().ToUpperInvariant();
            uxModel.VehicleVolume = rfqProject.VehicleVolume;

            return uxModel;
        }
    }
}
