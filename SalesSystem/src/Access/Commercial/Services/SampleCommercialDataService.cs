namespace Commercial.Services
{
    public static class SampleCommercialDataService
    {
        public static ListPurchaseOrderDataGrpc PopulatePurchaseOrderData()
        {
            ListPurchaseOrderDataGrpc listPurchaseOrderDataGrpc = new ListPurchaseOrderDataGrpc();
            for(int i = 1; i < 5; i++)
            {
                PurchaseOrderDataGrpc purchaseOrderDataGrpc = new PurchaseOrderDataGrpc();
                purchaseOrderDataGrpc.Id = i;
                purchaseOrderDataGrpc.MaterialNumber = $"MaterialNumber-{i}";
                purchaseOrderDataGrpc.SiteCode = $"SiteCode-{i}";
                purchaseOrderDataGrpc.SupplierCode = $"SupplierCode-{i}";
                purchaseOrderDataGrpc.PORatio = i;
                purchaseOrderDataGrpc.POUnit = $"POUnit-{i}";
                purchaseOrderDataGrpc.POPrice = i;
                purchaseOrderDataGrpc.UnitConfacPO = i;
                purchaseOrderDataGrpc.IndexedMaterialWeight = i;
                purchaseOrderDataGrpc.IndexedMaterialRate = i;
                purchaseOrderDataGrpc.POPriceExCopper = i;
                purchaseOrderDataGrpc.ExternalDataSource = $"ExternalDataSource-{i}";
                purchaseOrderDataGrpc.CurrencyCode = $"CurrencyCode-{i}";
                purchaseOrderDataGrpc.RaisedDate = DateTime.UtcNow.ToTimestamp();
                purchaseOrderDataGrpc.SourceSystemTableId = i;
                purchaseOrderDataGrpc.IndexedMaterial = $"IndexedMaterial-{i}";
                purchaseOrderDataGrpc.ExpiryDate = DateTime.UtcNow.ToTimestamp();
                purchaseOrderDataGrpc.ExchangeRate = i;
                purchaseOrderDataGrpc.CpdMaterialUom = $"CpdMaterialUom-{i}";
                purchaseOrderDataGrpc.CountryOfOriginCode = $"CountryOfOriginCode-{i}";
                purchaseOrderDataGrpc.PriceType = $"PriceType-{i}";
                purchaseOrderDataGrpc.CreateDate = DateTime.UtcNow.ToTimestamp();
                purchaseOrderDataGrpc.CurrentExchangeRate = i;
                purchaseOrderDataGrpc.ExchangeRateUpdateDate = DateTime.UtcNow.ToTimestamp();
                listPurchaseOrderDataGrpc.PurchaseOrderData.Add(purchaseOrderDataGrpc);
            }

            PurchaseOrderDataGrpc fixedPurchaseOrderDataGrpc = new PurchaseOrderDataGrpc();
            fixedPurchaseOrderDataGrpc.Id = 0;
            fixedPurchaseOrderDataGrpc.MaterialNumber = $"TestMaterialNumber";
            fixedPurchaseOrderDataGrpc.SiteCode = $"TestSiteCode";
            fixedPurchaseOrderDataGrpc.SupplierCode = $"TestSupplierCode";
            fixedPurchaseOrderDataGrpc.PORatio = 0;
            fixedPurchaseOrderDataGrpc.POUnit = $"TestPOUnit";
            fixedPurchaseOrderDataGrpc.POPrice = 0;
            fixedPurchaseOrderDataGrpc.UnitConfacPO = 0;
            fixedPurchaseOrderDataGrpc.IndexedMaterialWeight = 0;
            fixedPurchaseOrderDataGrpc.IndexedMaterialRate = 0;
            fixedPurchaseOrderDataGrpc.POPriceExCopper = 0;
            fixedPurchaseOrderDataGrpc.ExternalDataSource = $"TestExternalDataSource";
            fixedPurchaseOrderDataGrpc.CurrencyCode = $"TestCurrencyCode";
            fixedPurchaseOrderDataGrpc.RaisedDate = DateTime.UtcNow.ToTimestamp();
            fixedPurchaseOrderDataGrpc.SourceSystemTableId = 0;
            fixedPurchaseOrderDataGrpc.IndexedMaterial = $"TestIndexedMaterial";
            fixedPurchaseOrderDataGrpc.ExpiryDate = DateTime.UtcNow.ToTimestamp();
            fixedPurchaseOrderDataGrpc.ExchangeRate = 0;
            fixedPurchaseOrderDataGrpc.CpdMaterialUom = $"TestCpdMaterialUom";
            fixedPurchaseOrderDataGrpc.CountryOfOriginCode = $"TestCountryOfOriginCode";
            fixedPurchaseOrderDataGrpc.PriceType = $"TestPriceType";
            fixedPurchaseOrderDataGrpc.CreateDate = DateTime.UtcNow.ToTimestamp();
            fixedPurchaseOrderDataGrpc.CurrentExchangeRate = 0;
            fixedPurchaseOrderDataGrpc.ExchangeRateUpdateDate = DateTime.UtcNow.ToTimestamp();
            listPurchaseOrderDataGrpc.PurchaseOrderData.Add(fixedPurchaseOrderDataGrpc);
            return listPurchaseOrderDataGrpc;
        }
    }
}
