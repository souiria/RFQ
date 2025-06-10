namespace Emacs.Extensions
{
    public static class EMACSMappingExtentions
    {
        #region CombinedParts
        public static CombinedPartsDto MapToCombinePartsDto(this DbCombinedParts entity)
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

        #region PartCatogoryDetail
        public static PartCategoryDetailDto MapToPartCategoryDetailDto(this DbPartCategoryDetail entity)
        {
            PartCategoryDetailDto dto = new PartCategoryDetailDto();
            dto.CategoryCode = entity.CategoryCode;
            dto.DetailedCategoryCode = entity.DetailedCategoryCode;
            dto.CategoryName = entity.CategoryName;

            return dto;
        }

        public static PartCategoryDetail MapToPartCategoryDetailData(this PartCategoryDetailDto dto)
        {
            PartCategoryDetail entity = new PartCategoryDetail();
            entity.CategoryCode = dto.CategoryCode;
            entity.DetailedCategoryCode = dto.DetailedCategoryCode;
            entity.CategoryName = dto.CategoryName;

            return entity;
        }
        #endregion
    }
}
