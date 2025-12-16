using System.Globalization;
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
        public static RfqProjectUx? ToUx(this RfqProject? rfqProject)
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
            uxModel.IsActive = rfqProject.IsActive ?? false;

            return uxModel;
        }
        public static RfqProject ToDto(this RfqProjectUx uxModel)
        {
            if (uxModel == null)
            {
                throw new ArgumentNullException(nameof(uxModel));
            }

            RfqProject dto = new RfqProject();

            dto.RowId = uxModel.RowId;
            dto.RfqNumber = uxModel.RfqNumber;
            dto.CustomerBusinessUnitGuid = uxModel.CustomerBusinessUnitId.Trim().ToUpperInvariant();
            dto.CustomerLocationGuid = uxModel.CustomerLocationId.Trim().ToUpperInvariant();
            dto.ProjectGuid = uxModel.ProjectId.Trim().ToUpperInvariant();
            dto.RfqReasonId = uxModel.RfqReasonId;
            if (uxModel.RfqResponseDeadline.HasValue)
            {
                DateTime utc = uxModel.RfqResponseDeadline.Value.ToUniversalTime();
                dto.RfqResponseDeadline = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(utc);
            }

            dto.CarModelGuid = uxModel.CarModelId.Trim().ToUpperInvariant();
            dto.VehicleVolume = uxModel.VehicleVolume;
            dto.IsActive = uxModel.IsActive;

            return dto;
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
            if(!string.IsNullOrEmpty(dto.OriginalPartNumber) 
                && (string.IsNullOrEmpty(dto.SumitomoPartNumber) || dto.SumitomoPartNumber == "0000000"))
            {
                uxModel.CustomerPartNumber = dto.OriginalPartNumber;
                uxModel.DrawingPartNumber = string.Empty;
            }
            else
            {
                uxModel.CustomerPartNumber = dto.OriginalPartNumber;
                uxModel.DrawingPartNumber = dto.SumitomoPartNumber;
            }

            uxModel.DrawingPartNumberPrice = dto.OriginalPartNumberPrice != 0 ? Convert.ToDecimal(dto.OriginalPartNumberPrice) : null;
            uxModel.SwappedPartNumber = dto.SwappedPartNumber;
            uxModel.SwappedPartNumberPrice = dto.SwappedPartNumberPrice != 0 ? Convert.ToDecimal(dto.SwappedPartNumberPrice) : null;
            uxModel.PriceSource = dto.PriceSource;
            if (dto.IsSwapped)
            {
                uxModel.IsExactMatch = false;
                uxModel.IsSwapped = true;
            }
            else if (dto.IsExactMatch && !dto.IsSwapped)
            {
                uxModel.IsExactMatch = true;
                uxModel.IsSwapped = false;
            }
            else
            {
                uxModel.IsExactMatch = false;
                uxModel.IsSwapped = false;
            }

            uxModel.Comments = dto.Comments;

            return uxModel;
        }
        public static RfqDrawingPartNumber ToDto(this RfqDrawingPartNumberUx uxModel)
        {
            if (uxModel == null)
            {
                throw new ArgumentNullException(nameof(uxModel));
            }

            RfqDrawingPartNumber dto = new RfqDrawingPartNumber();

            dto.RowId = uxModel.RowId;
            dto.RfqId = uxModel.RfqId;
            dto.OriginalPartNumber = uxModel.CustomerPartNumber;
            dto.SumitomoPartNumber = uxModel.DrawingPartNumber;
            dto.OriginalPartNumberPrice = uxModel.DrawingPartNumberPrice.HasValue ? Convert.ToDouble(uxModel.DrawingPartNumberPrice.Value) : 0;
            dto.SwappedPartNumber = uxModel.SwappedPartNumber;
            dto.SwappedPartNumberPrice = uxModel.SwappedPartNumberPrice.HasValue ? Convert.ToDouble(uxModel.SwappedPartNumberPrice.Value) : 0;
            dto.PriceSource = uxModel.PriceSource;
            dto.IsExactMatch = uxModel.IsExactMatch ?? false;
            dto.IsSwapped = uxModel.IsSwapped ?? false;
            // dto.IsActive = uxModel.IsActive;
            if(!string.IsNullOrEmpty(uxModel.Comments) && uxModel.Comments.Contains("||<<<", StringComparison.OrdinalIgnoreCase))
            {
                dto.Comments = uxModel.Comments.Split("||<<<", StringSplitOptions.None)[0];
            }
            else
            {
                dto.Comments = uxModel.Comments;
            }

            return dto;
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
