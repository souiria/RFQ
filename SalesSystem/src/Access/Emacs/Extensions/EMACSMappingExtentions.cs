namespace Emacs.Extensions
{
    public static class EMACSMappingExtentions
    {
        #region CombinedParts
        public static CombinedPartsDto MapToCurrencyDto(this DbCombinedParts entity)
        {
            CombinedPartsDto dto = new CombinedPartsDto();
            dto.SumitomoNumber = entity.SumitomoNumber;
            dto.CustomerNumber = entity.CustomerNumber;
            dto.CustomerName = entity.CustomerName;
            dto.SupplierNumber = entity.SupplierNumber;
            dto.UniformSumitomoNumber = entity.UniformSumitomoNumber;
            dto.UniformCustomerNumber = entity.UniformCustomerNumber;
            dto.UniformSupplierNumber = entity.UniformSupplierNumber;
            
            return dto;
        }

        public static CombinedPartsData MapToCombinePartsData(this CombinedPartsDto dto)
        {
            CombinedPartsData combinePartsData = new CombinedPartsData();
            combinePartsData.SumitomoNumber = dto.SumitomoNumber;
            combinePartsData.CustomerNumber = dto.CustomerNumber;
            combinePartsData.CustomerName = dto.CustomerName;
            combinePartsData.SupplierNumber = dto.SupplierNumber;
            combinePartsData.UniformSumitomoNumber = dto.UniformSumitomoNumber;
            combinePartsData.UniformCustomerNumber = dto.UniformSumitomoNumber;
            combinePartsData.UniformSupplierNumber = dto.UniformSupplierNumber;

            return combinePartsData;
        }
        #endregion
    }
}
