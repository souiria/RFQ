namespace Rfq.Extensions
{
    public static class RfqMappingExtentions
    {
        #region RfqDrawingPartNumber
        public static RfqDrawingPartNumbersGrpc FromEntity(this DbRfqDrawingPartNumber entity)
        {
            RfqDrawingPartNumbersGrpc data = new RfqDrawingPartNumbersGrpc();
            data.RowId = entity.RowId;
            data.RfqId = entity.RfqId;
            data.OriginalPartNumber = entity.OriginalPartNumber;
            data.OriginalPartNumberPrice = (double?)entity.OriginalPartNumberPrice;
            data.SwappedPartNumber = entity.SwappedPartNumber;
            data.SwappedPartNumberPrice = (double?)entity.SwappedPartNumberPrice;
            data.PriceSource = entity.PriceSource;
            data.IsExactMatch = entity.IsExactMatch;
            data.IsSwapped = entity.IsSwapped;
            data.Comments = entity.Comments;
            data.SumitomoPartNumber = entity.SumitomoPartNumber;
            data.SupplierPartNumber = entity.SupplierPartNumber;
            data.NprId = entity.NprId?.ToString();
            return data;
        }

        public static DbRfqDrawingPartNumber ToEntity(this RfqDrawingPartNumbersGrpc grpc)
        {
            DbRfqDrawingPartNumber data = new DbRfqDrawingPartNumber();
            data.RowId = grpc.RowId;
            data.RfqId = grpc.RfqId;
            data.OriginalPartNumber = grpc.OriginalPartNumber;
            data.OriginalPartNumberPrice = (decimal?)grpc.OriginalPartNumberPrice;
            data.SwappedPartNumber = grpc.SwappedPartNumber;
            data.SwappedPartNumberPrice = (decimal?)grpc.SwappedPartNumberPrice;
            data.PriceSource = grpc.PriceSource;
            data.IsExactMatch = grpc.IsExactMatch;
            data.IsSwapped = grpc.IsSwapped;
            data.Comments = grpc.Comments;
            data.SumitomoPartNumber = grpc.SumitomoPartNumber;
            data.SupplierPartNumber = grpc.SupplierPartNumber;
            data.NprId = string.IsNullOrEmpty(grpc.NprId) ? null : Guid.Parse(grpc.NprId);
            return data;
        }
        #endregion

        #region RfqProject
        public static RfqProjectGrpc FromEntity(this DbRfqProject entity)
        {
            RfqProjectGrpc data = new RfqProjectGrpc();
            data.RowId = entity.RowId;
            data.RfqNumber = entity.RfqNumber;
            data.CustomerBusinessUnitGuid = entity.CustomerBusinessUnitGuid.ToString();
            data.CustomerLocationGuid = entity.CustomerLocationGuid.ToString();
            data.ProjectGuid = entity.ProjectGuid.ToString();
            data.RfqReasonId = entity.RfqReasonId;
            data.RfqResponseDeadline = entity.RfqResponseDeadline?.ToUniversalTime().ToTimestamp();
            data.CarModelGuid = entity.CarModelGuid.ToString();
            data.VehicleVolume = entity.VehicleVolume;
            data.CreatedDate = entity.CreatedDate?.ToUniversalTime().ToTimestamp();
            return data;
        }
        public static DbRfqProject ToEntity(this RfqProjectGrpc grpc)
        {
            DbRfqProject data = new DbRfqProject();
            data.RowId = grpc.RowId;
            data.RfqNumber = grpc.RfqNumber;
            data.CustomerBusinessUnitGuid = Guid.Parse(grpc.CustomerBusinessUnitGuid);
            data.CustomerLocationGuid = Guid.Parse(grpc.CustomerLocationGuid);
            data.ProjectGuid = Guid.Parse(grpc.ProjectGuid);
            data.RfqReasonId = grpc.RfqReasonId;
            data.RfqResponseDeadline = grpc.RfqResponseDeadline?.ToDateTime().ToLocalTime();
            data.CarModelGuid = Guid.Parse(grpc.CarModelGuid);
            data.VehicleVolume = grpc.VehicleVolume;
            data.CreatedDate = grpc.CreatedDate.ToDateTime().ToLocalTime();
            return data;
        }
        #endregion

        #region RfqNotes
        public static RfqNotesGrpc FromEntity(this DbRfqNotes entity)
        {
            RfqNotesGrpc data = new RfqNotesGrpc();
            data.RowId = entity.RowId;
            data.RfqId = entity.RfqId;
            data.Note = entity.Note;
            data.UserGuid = entity.UserGuid.ToString();
            data.LastModifiedOn = entity.LastModifiedOn?.ToUniversalTime().ToTimestamp();
            return data;
        }
        public static DbRfqNotes ToEntity(this RfqNotesGrpc grpc)
        {
            DbRfqNotes data = new DbRfqNotes();
            data.RowId = grpc.RowId;
            data.RfqId = grpc.RfqId;
            data.Note = grpc.Note;
            data.UserGuid = Guid.Parse(grpc.UserGuid);
            data.LastModifiedOn = DateTime.Now.ToLocalTime();
            return data;
        }
        #endregion

        #region RfqReason

        public static RfqReasonGrpc FromEntity(this DbRfqReason entity)
        {
            RfqReasonGrpc data = new RfqReasonGrpc();
            data.RowId = entity.RowId;
            data.ReasonTitle = entity.ReasonTitle;
            return data;
        }
        public static DbRfqReason ToEntity(this RfqReasonGrpc grpc)
        {
            DbRfqReason data = new DbRfqReason();
            data.RowId = grpc.RowId;
            data.ReasonTitle = grpc.ReasonTitle;
            return data;
        }

        #endregion
    }
}
