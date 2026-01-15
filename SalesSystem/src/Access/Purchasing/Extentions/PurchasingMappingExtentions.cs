namespace Purchasing.Extentions
{
    public static class PurchasingMappingExtentions
    {
        public static H1CPDGrpc FromEntity(this DbH1CPD entity)
        {
            H1CPDGrpc data = new H1CPDGrpc();
            data.SumitomoNumber = entity.SumitomoNumber;
            data.UniformSumitomoNumber = entity.UniformSumitomoNumber;
            data.SupplierName = entity.SupplierName;
            data.SupplierNumber = entity.SupplierNumber;
            data.UniformSupplierNumber = entity.UniformSupplierNumber;
            data.CurrencyCode = entity.CurrencyCode;
            data.UnitOfMeasure = entity.UnitOfMeasure;
            data.Price = (double?)entity.Price;
            return data;
        }

        public static DbH1CPD ToEntity(this H1CPDGrpc data)
        {
            DbH1CPD entity = new DbH1CPD();
            entity.SumitomoNumber = data.SumitomoNumber;
            entity.UniformSumitomoNumber = data.UniformSumitomoNumber;
            entity.SupplierName = data.SupplierName;
            entity.SupplierNumber = data.SupplierNumber;
            entity.UniformSupplierNumber = data.UniformSupplierNumber;
            entity.CurrencyCode = data.CurrencyCode;
            entity.UnitOfMeasure = data.UnitOfMeasure;
            entity.Price = (decimal?)data.Price;
            return entity;
        }
    }
}
