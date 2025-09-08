namespace Rfq.Services
{
    public static class SampleRfqDataService
    {
        #region RfqDrawingPartNumber
        public static ListRfqDrawingPartNumbersGrpc PopulateRfqDrawingPartNumbersGrpc()
        {
            ListRfqDrawingPartNumbersGrpc listRfqDrawingPartNumbersGrpc = new ListRfqDrawingPartNumbersGrpc();
            for (int i = 0; i < 5; i++)
            {
                RfqDrawingPartNumbersGrpc rfqDrawingPartNumbersGrpc = new RfqDrawingPartNumbersGrpc();
                rfqDrawingPartNumbersGrpc.RowId = i;
                rfqDrawingPartNumbersGrpc.RfqId = i;
                rfqDrawingPartNumbersGrpc.OriginalPartNumber = $"OriginalPartNumber{i}";
                rfqDrawingPartNumbersGrpc.OriginalPartNumberPrice = 30;
                rfqDrawingPartNumbersGrpc.SwappedPartNumber = $"SwappedPartNumber{i}";
                rfqDrawingPartNumbersGrpc.SwappedPartNumberPrice = 35;
                rfqDrawingPartNumbersGrpc.PriceSource = $"PriceSource{i}";
                rfqDrawingPartNumbersGrpc.IsExactMatch = false;
                rfqDrawingPartNumbersGrpc.IsSwapped = true;
                rfqDrawingPartNumbersGrpc.Comments = $"Comments{i}";
                listRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Add(rfqDrawingPartNumbersGrpc);
            }

            RfqDrawingPartNumbersGrpc fixedrfqDrawingPartNumbersGrpc = new RfqDrawingPartNumbersGrpc();
            fixedrfqDrawingPartNumbersGrpc.RowId = 6;
            fixedrfqDrawingPartNumbersGrpc.RfqId = 6;
            fixedrfqDrawingPartNumbersGrpc.OriginalPartNumber = $"TestOriginalPartNumber";
            fixedrfqDrawingPartNumbersGrpc.OriginalPartNumberPrice = 10;
            fixedrfqDrawingPartNumbersGrpc.SwappedPartNumber = $"TestSwappedPartNumber";
            fixedrfqDrawingPartNumbersGrpc.SwappedPartNumberPrice = 20;
            fixedrfqDrawingPartNumbersGrpc.PriceSource = $"TestPriceSource";
            fixedrfqDrawingPartNumbersGrpc.IsExactMatch = false;
            fixedrfqDrawingPartNumbersGrpc.IsSwapped = true;
            fixedrfqDrawingPartNumbersGrpc.Comments = $"TestComments";
            listRfqDrawingPartNumbersGrpc.RfqDrawingPartNumbers.Add(fixedrfqDrawingPartNumbersGrpc);
            return listRfqDrawingPartNumbersGrpc;
        }
        #endregion

        #region RfqProject
        public static ListRfqProjectGrpc PopulateRfqProjectGrpc()
        {
            ListRfqProjectGrpc listRfqProjectGrpc = new ListRfqProjectGrpc();
            for (int i = 0; i < 5; i++)
            {
                RfqProjectGrpc rfqProjectGrpc = new RfqProjectGrpc();
                rfqProjectGrpc.RowId = i;
                rfqProjectGrpc.RfqNumber = $"RfqNumber{i}";
                rfqProjectGrpc.CustomerBusinessUnitGuid = $"CustomerBuisnessUnitGuid{i}";
                rfqProjectGrpc.ProjectGuid = $"ProjectGuid{i}";
                rfqProjectGrpc.RfqReasonId = i;
                rfqProjectGrpc.RfqResponseDeadline = DateTime.UtcNow.ToTimestamp();
                rfqProjectGrpc.CarModelGuid = $"CarModelGuid{i}";
                rfqProjectGrpc.VehicleVolume = i;
                listRfqProjectGrpc.RfqProjects.Add(rfqProjectGrpc);
            }

            RfqProjectGrpc fixedRfqProjectGrpc = new RfqProjectGrpc();
            fixedRfqProjectGrpc.RowId = 6;
            fixedRfqProjectGrpc.RfqNumber = $"TestRfqNumber";
            fixedRfqProjectGrpc.CustomerBusinessUnitGuid = $"TestCustomerBuisnessUnitGuid";
            fixedRfqProjectGrpc.ProjectGuid = $"TestProjectGuid";
            fixedRfqProjectGrpc.RfqReasonId = 6;
            fixedRfqProjectGrpc.RfqResponseDeadline = DateTime.UtcNow.ToTimestamp();
            fixedRfqProjectGrpc.CarModelGuid = $"TetstCarModelGuid";
            fixedRfqProjectGrpc.VehicleVolume = 6;
            listRfqProjectGrpc.RfqProjects.Add(fixedRfqProjectGrpc);
            return listRfqProjectGrpc;
        }
        #endregion

        #region RfqNotes
        public static ListRfqNotesGrpc PopulateRfqNotesGrpc()
        {
            ListRfqNotesGrpc listRfqNotesGrpc = new ListRfqNotesGrpc();
            for (int i = 0; i < 5; i++)
            {
                RfqNotesGrpc rfqNotesGrpc = new RfqNotesGrpc();
                rfqNotesGrpc.RowId = i;
                rfqNotesGrpc.RfqId = i;
                rfqNotesGrpc.Note = $"Note{i}";
                rfqNotesGrpc.UserGuid = $"UserGuid{i}";
                rfqNotesGrpc.LastModifiedOn = DateTime.UtcNow.ToTimestamp();
                listRfqNotesGrpc.RfqNotes.Add(rfqNotesGrpc);
            }

            RfqNotesGrpc fixedRfqNotesGrpc = new RfqNotesGrpc();
            fixedRfqNotesGrpc.RowId = 6;
            fixedRfqNotesGrpc.RfqId = 6;
            fixedRfqNotesGrpc.Note = $"TestNote";
            fixedRfqNotesGrpc.UserGuid = $"TestUserGuid";
            fixedRfqNotesGrpc.LastModifiedOn = DateTime.UtcNow.ToTimestamp();
            listRfqNotesGrpc.RfqNotes.Add(fixedRfqNotesGrpc);
            return listRfqNotesGrpc;
        }
        #endregion

        #region RfqReason
        public static ListRfqReasonGrpc PopulateRfqReasonGrpc()
        {
            ListRfqReasonGrpc listRfqReasonGrpc = new ListRfqReasonGrpc();
            for (int i = 0; i < 5; i++)
            {
                RfqReasonGrpc rfqReasonGrpc = new RfqReasonGrpc();
                rfqReasonGrpc.RowId = i;
                rfqReasonGrpc.ReasonTitle = $"ReasonTitle{i}";
                listRfqReasonGrpc.RfqReasons.Add(rfqReasonGrpc);
            }

            RfqReasonGrpc fixedRfqReasonGrpc = new RfqReasonGrpc();
            fixedRfqReasonGrpc.RowId = 6;
            fixedRfqReasonGrpc.ReasonTitle = $"TestReasonTitle";
            listRfqReasonGrpc.RfqReasons.Add(fixedRfqReasonGrpc);
            return listRfqReasonGrpc;
        }
        #endregion
    }
}
