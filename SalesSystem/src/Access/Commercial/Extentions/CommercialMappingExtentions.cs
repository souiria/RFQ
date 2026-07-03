namespace Commercial.Extentions
{
    public static class CommercialMappingExtentions
    {
        public static PurchaseOrderDataGrpc MapToPurchaseOrderDataGrpc(this DbPurchaseOrder dbPurchaseOrder)
        {
            PurchaseOrderDataGrpc purchaseOrderDataGrpc = new PurchaseOrderDataGrpc();
            purchaseOrderDataGrpc.Id = dbPurchaseOrder.Id;
            purchaseOrderDataGrpc.MaterialNumber = dbPurchaseOrder.MaterialNumber;
            purchaseOrderDataGrpc.SiteCode = dbPurchaseOrder.SiteCode;
            purchaseOrderDataGrpc.SupplierCode = dbPurchaseOrder.SupplierCode;
            purchaseOrderDataGrpc.PORatio = dbPurchaseOrder.PORatio;
            purchaseOrderDataGrpc.POUnit = dbPurchaseOrder.POUnit;
            purchaseOrderDataGrpc.POPrice = dbPurchaseOrder.POPrice.HasValue ? (double?)dbPurchaseOrder.POPrice.Value : null;
            purchaseOrderDataGrpc.UnitConfacPO = dbPurchaseOrder.UnitConfacPO;
            purchaseOrderDataGrpc.IndexedMaterialWeight = dbPurchaseOrder.IndexedMaterialWeight.HasValue ? (double?)dbPurchaseOrder.IndexedMaterialWeight.Value : null;
            purchaseOrderDataGrpc.IndexedMaterialRate = dbPurchaseOrder.IndexedMaterialRate.HasValue ? (double?)dbPurchaseOrder.IndexedMaterialRate.Value : null;
            purchaseOrderDataGrpc.POPriceExCopper = dbPurchaseOrder.POPriceExCopper.HasValue ? (double?)dbPurchaseOrder.POPriceExCopper.Value : null;
            purchaseOrderDataGrpc.ExternalDataSource = dbPurchaseOrder.ExternalDataSource;
            purchaseOrderDataGrpc.CurrencyCode = dbPurchaseOrder.CurrencyCode;
            purchaseOrderDataGrpc.RaisedDate = dbPurchaseOrder.RaisedDate.HasValue ? dbPurchaseOrder.RaisedDate.Value.ToUniversalTime().ToTimestamp() : null;
            purchaseOrderDataGrpc.SourceSystemTableId = dbPurchaseOrder.SourceSystemTableId;
            purchaseOrderDataGrpc.IndexedMaterial = dbPurchaseOrder.IndexedMaterial;
            purchaseOrderDataGrpc.ExpiryDate = dbPurchaseOrder.ExpiryDate.HasValue ? dbPurchaseOrder.ExpiryDate.Value.ToUniversalTime().ToTimestamp() : null;
            purchaseOrderDataGrpc.ExchangeRate = dbPurchaseOrder.ExchangeRate.HasValue ? (double?)dbPurchaseOrder.ExchangeRate.Value : null;
            purchaseOrderDataGrpc.CpdMaterialUom = dbPurchaseOrder.CpdMaterialUom;
            purchaseOrderDataGrpc.CountryOfOriginCode = dbPurchaseOrder.CountryOfOriginCode;
            purchaseOrderDataGrpc.CreateDate = dbPurchaseOrder.CreateDate.HasValue ? dbPurchaseOrder.CreateDate.Value.ToUniversalTime().ToTimestamp() : null;
            purchaseOrderDataGrpc.CurrentExchangeRate = dbPurchaseOrder.CurrentExchangeRate.HasValue ? (double?)dbPurchaseOrder.CurrentExchangeRate.Value : null;
            purchaseOrderDataGrpc.ExchangeRateUpdateDate = dbPurchaseOrder.ExchangeRateUpdateDate.HasValue ? dbPurchaseOrder.ExchangeRateUpdateDate.Value.ToUniversalTime().ToTimestamp() : null;
            return purchaseOrderDataGrpc;
        }
    }
}
