namespace SalesSystem.Rfq.Extensions
{
    public static class UxModelConversionExtensions

    {
        #region CustomerProjectUx Conversion
        public static CustomerProjectUx? ToCustomerProjectUx(this ProjectAssociation association)
        {
            if (association == null)
            {
                return null;
            }

            CustomerProjectUx projectAssociation = new CustomerProjectUx();
            projectAssociation.ProjectId = association.CustomerProjectGuid.ToUpperInvariant();
            projectAssociation.ProjectName = association.CustomerProjectName;
            projectAssociation.CustomerId = association.CustomerLocationGuid.ToUpperInvariant();
            projectAssociation.CustomerName = association.CustomerLocationName;
            projectAssociation.Id = association.Id.ToUpperInvariant();
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
        #endregion

        #region CustomerUx Conversion
        public static CustomerUx? ToCustomerUx(this CustomerGrpc customerGrpc)
        {
            if (customerGrpc == null)
            {
                return null;
            }

            CustomerUx customerUx = new CustomerUx();
            customerUx.Id = customerGrpc.Id?.ToUpperInvariant();
            customerUx.CustomerBusinessGroupCode = customerGrpc.CustomerBusinessGroupCode;
            customerUx.CustomerBusinessGroupName = customerGrpc.CustomerBusinessGroupName;
            customerUx.SEWSEBusinessTeam = customerGrpc.SEWSEBusinessTeam;
            customerUx.IsActive = customerGrpc.IsActive ?? false;
            return customerUx;
        }
        #endregion
    }
}
