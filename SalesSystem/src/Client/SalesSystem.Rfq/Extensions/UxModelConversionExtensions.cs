using Google.Protobuf;

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
            string[]? ar = dto.OriginalPartNumber?.Split('|');
            if(ar is not null && 0 <= ar.Length)
            {
                switch(ar.Length)
                {
                    case 1:
                        uxModel.CustomerPartNumber = ar[0] ?? "N/A";
                        uxModel.DrawingPartNumber = "N/A";
                        break;
                    case 2:
                        uxModel.CustomerPartNumber = ar[0] ?? "N/A";
                        uxModel.DrawingPartNumber = ar[1] ?? "N/A";
                        break;
                }
            }
            else
            {
                uxModel.CustomerPartNumber = dto.OriginalPartNumber;
                uxModel.DrawingPartNumber = "N/A";
            }

            uxModel.DrawingPartNumberPrice = dto.OriginalPartNumberPrice != 0 ? Convert.ToDecimal(dto.OriginalPartNumberPrice) : null;
            uxModel.SwappedPartNumber = dto.SwappedPartNumber;
            uxModel.SwappedPartNumberPrice = dto.SwappedPartNumberPrice != 0 ? Convert.ToDecimal(dto.SwappedPartNumberPrice) : null;
            uxModel.PriceSource = dto.PriceSource;
            uxModel.IsExactMatch = dto.IsExactMatch;
            uxModel.IsSwapped = dto.IsSwapped;
            uxModel.Comments = dto.Comments;

            uxModel.IsMatched = dto.IsExactMatch;

            return uxModel;
        }
        #endregion
        #region SearchResultUx
        public static SearchResultUx ToUx(this FilterGrpcResponse searchResult)
        {
            if (searchResult == null)
            {
                throw new ArgumentNullException(nameof(searchResult));
            }

            SearchResultUx resultUx = new SearchResultUx();
            resultUx.StringList.Clear();
            foreach (string? item in searchResult.StringList)
            {
                resultUx.StringList.Add(item);
            }

            resultUx.IntList.Clear();
            foreach (int? item in searchResult.IntList)
            {
                if (item.HasValue)
                {
                    resultUx.IntList.Add(item.Value);
                }
            }

            resultUx.ByteList.Clear();
            foreach (ByteString item in searchResult.ByteList)
            {
                byte[] arr = item.ToByteArray();
                resultUx.ByteList.Add(arr);
            }

            resultUx.DoubleList.Clear();
            foreach (double? item in searchResult.DoubleList)
            {
                if (item.HasValue)
                {
                    resultUx.DoubleList.Add(item.Value);
                }
            }

            resultUx.StringList2.Clear();
            foreach (string? item in searchResult.StringList2)
            {
                resultUx.StringList2.Add(item);
            }

            return resultUx;
        }   
        #endregion
    }
}
