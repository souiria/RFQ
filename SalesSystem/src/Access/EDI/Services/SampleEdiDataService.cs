namespace EDI.Services
{
    public static class SampleEdiDataService
    {
        #region EdiCustomerParameters
        public static ListEdiCustomerParameterGrpc PopulateEdiCustomerParameters()
        {
            ListEdiCustomerParameterGrpc listEdiCustomerParameterGrpc = new ListEdiCustomerParameterGrpc();
            for (int i = 0; i < 5; i++)
            {
                EdiCustomerParameterGrpc ediCustomerParameterGrpc = new EdiCustomerParameterGrpc();
                ediCustomerParameterGrpc.AllowZeroPrices = i % 2 == 0;
                ediCustomerParameterGrpc.CriticalPathAlert = i % 2 == 0;
                ediCustomerParameterGrpc.Customer = $"TestCustomerName{i}";
                ediCustomerParameterGrpc.CustomerGuid = Guid.NewGuid().ToString();
                ediCustomerParameterGrpc.CustomerLocation = $"TestCustomerLocationName{i}";
                ediCustomerParameterGrpc.CustomerLocationGuid = Guid.NewGuid().ToString();
                ediCustomerParameterGrpc.DimValue1 = $"TestDimValue1{i}";
                ediCustomerParameterGrpc.DimValue2 = $"TestDimValue2{i}";
                ediCustomerParameterGrpc.DimValue3 = $"TestDimValue3{i}";
                ediCustomerParameterGrpc.DimValue4 = $"TestDimValue4{i}";
                ediCustomerParameterGrpc.DimValue5 = $"TestDimValue5{i}";
                ediCustomerParameterGrpc.DimValue6 = $"TestDimValue6{i}";
                ediCustomerParameterGrpc.DimValue7 = $"TestDimValue7{i}";
                ediCustomerParameterGrpc.DistributionList = $"TestDistributionList{i}";
                ediCustomerParameterGrpc.FinanceCode = $"4010{i}";
                ediCustomerParameterGrpc.Id = Guid.NewGuid().ToString();
                ediCustomerParameterGrpc.IsAutomatingInvoices = i % 2 == 0;
                ediCustomerParameterGrpc.IsUsingCustomerDispatchNumber = i % 2 == 0;
                ediCustomerParameterGrpc.IsUsingH1CustomerOrderNumber = i % 2 == 0;
                ediCustomerParameterGrpc.IsUsingH1SchedulingAgreement = i % 2 == 0;
                ediCustomerParameterGrpc.IsUsingPartNumber = i % 2 == 0;
                ediCustomerParameterGrpc.RelAttrId = $"RelAttrId{i}";
                ediCustomerParameterGrpc.RelAttrId1 = $"RelAttrId1{i}";
                ediCustomerParameterGrpc.RelAttrId2 = $"RelAttrId2{i}";
                ediCustomerParameterGrpc.RelAttrId3 = $"RelAttrId3{i}";
                ediCustomerParameterGrpc.RelAttrId4 = $"RelAttrId4{i}";
                ediCustomerParameterGrpc.RelAttrId5 = $"RelAttrId5{i}";
                ediCustomerParameterGrpc.RelValue = $"RelValue{i}";
                ediCustomerParameterGrpc.RelValue1 = $"RelValue1{i}";
                ediCustomerParameterGrpc.RelValue2 = $"RelValue2{i}";
                ediCustomerParameterGrpc.RelValue3 = $"RelValue3{i}";
                ediCustomerParameterGrpc.RelValue4 = $"RelValue4{i}";
                ediCustomerParameterGrpc.RelValue5 = $"RelValue5{i}";

                listEdiCustomerParameterGrpc.EdiCustomerParameterGrpc.Add(ediCustomerParameterGrpc);
            }

            return listEdiCustomerParameterGrpc;
        }
        #endregion
    }
}
