namespace Purchasing.Services
{
    public static class SamplePurchasingDataService
    {
        #region H1CPD

        public static ListH1CPDGrpc PopulateH1CPDGrpc()
        {
            ListH1CPDGrpc listH1CPDGrpc = new ListH1CPDGrpc();
            for (int i = 0; i < 5; i++)
            {
                H1CPDGrpc h1CPDGrpc = new H1CPDGrpc();
                h1CPDGrpc.SumitomoNumber = $"SumitomoNumber{i}";
                h1CPDGrpc.UniformSumitomoNumber = $"UniformSumitomoNumber{i}";
                h1CPDGrpc.SupplierName = $"SupplierName{i}";
                h1CPDGrpc.SupplierNumber = $"SupplierNumber{i}";
                h1CPDGrpc.UniformSupplierNumber = $"UniformSupplierNumber{i}";
                h1CPDGrpc.MainSupplier = true;
                h1CPDGrpc.CurrencyCode = $"CurrencyCode{i}";
                h1CPDGrpc.UnitOfMeasure = $"UnitOfMeasure{i}";
                h1CPDGrpc.Price = i;
                listH1CPDGrpc.H1CPD.Add(h1CPDGrpc);
            }

            H1CPDGrpc fixedh1CPDGrpc = new H1CPDGrpc();
            fixedh1CPDGrpc.SumitomoNumber = $"TestSumitomoNumber";
            fixedh1CPDGrpc.UniformSumitomoNumber = $"TestUniformSumitomoNumber";
            fixedh1CPDGrpc.SupplierName = $"TestSupplierName";
            fixedh1CPDGrpc.SupplierNumber = $"TestSupplierNumber";
            fixedh1CPDGrpc.UniformSupplierNumber = $"TestUniformSupplierNumber";
            fixedh1CPDGrpc.MainSupplier = true;
            fixedh1CPDGrpc.CurrencyCode = $"TestCurrencyCode";
            fixedh1CPDGrpc.UnitOfMeasure = $"TestUnitOfMeasure";
            fixedh1CPDGrpc.Price = 6;
            listH1CPDGrpc.H1CPD.Add(fixedh1CPDGrpc);
            return listH1CPDGrpc;
        }
        #endregion
    }
}
