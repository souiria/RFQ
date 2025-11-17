namespace SalesSystem.Rfq.Extensions
{
    public static class UxModelConversionExtensions

    {
        #region ProjectAssociationUx Conversion
        public static ProjectAssociationUx? ToUx(this ProjectAssociation association)
        {
            if (association == null)
            {
                return null;
            }

            ProjectAssociationUx projectAssociation = new ProjectAssociationUx();
            projectAssociation.ProjectId = association.CustomerProjectGuid.ToUpperInvariant();
            projectAssociation.ProjectName = association.CustomerProjectName;
            projectAssociation.CustomerId = association.CustomerLocationGuid.ToUpperInvariant();
            projectAssociation.CustomerName = association.CustomerLocationName;
            projectAssociation.Id = association.Id.ToUpperInvariant();
            return projectAssociation;
        }
        #endregion

        #region RfqProjectUx Conversion
        public static RfqProjectUx? ToUx(this RfqProject rfqProject)
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
        public static CustomerUx? ToUx(this CustomerGrpc customerGrpc)
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

        #region RfqDrawingPartNumberUx Conversion
        public static RfqDrawingPartNumberUx? ToUx(this RfqDrawingPartNumber dto)
        {
            if (dto == null)
            {
                return null;
            }

            RfqDrawingPartNumberUx uxModel = new RfqDrawingPartNumberUx();

            uxModel.RowId = dto.RowId;
            uxModel.RfqId = dto.RfqId;
            uxModel.OriginalPartNumber = dto.OriginalPartNumber;
            uxModel.OriginalPartNumberPrice = dto.OriginalPartNumberPrice != 0 ? Convert.ToDecimal(dto.OriginalPartNumberPrice) : null;
            uxModel.SwappedPartNumber = dto.SwappedPartNumber;
            uxModel.SwappedPartNumberPrice = dto.SwappedPartNumberPrice != 0 ? Convert.ToDecimal(dto.SwappedPartNumberPrice) : null;
            uxModel.PriceSource = dto.PriceSource;
            uxModel.IsExactMatch = dto.IsExactMatch;
            uxModel.IsSwapped = dto.IsSwapped;
            uxModel.Comments = dto.Comments;

            return uxModel;
        }
        #endregion
    }
}
