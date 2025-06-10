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

        #region PartClassDetail
        public static PartClassDetailDto MapToPartClassDetailDto(this DbPartClassDetail entity)
        {
            PartClassDetailDto dto = new PartClassDetailDto();
            dto.Class1 = entity.Class1;
            dto.Class1Name = entity.Class1Name;
            dto.Class2 = entity.Class2;
            dto.Class2Name = entity.Class2Name;

            return dto;
        }

        public static PartClassDetail MapToPartClassDetailData(this PartClassDetailDto dto)
        {
            PartClassDetail entity = new PartClassDetail();
            entity.Class1 = dto.Class1;
            entity.Class1Name = dto.Class1Name;
            entity.Class2 = dto.Class2;
            entity.Class2Name = dto.Class2Name;

            return entity;
        }
        #endregion

        #region PartGroups
        public static PartGroupsDto MapToPartGroupsDto(this DbPartGroups entity)
        {
            PartGroupsDto dto = new PartGroupsDto();
            dto.PartGroup = entity.PartGroup;
            dto.GroupDescription = entity.GroupDescription;

            return dto;
        }

        public static PartGroups MapToPartGroupsData(this PartGroupsDto dto)
        {
            PartGroups entity = new PartGroups();
            entity.PartGroup = dto.PartGroup;
            entity.GroupDescription = dto.GroupDescription;

            return entity;
        }
        #endregion

        #region PartGroupsConst
        public static PartGroupsConstDto MapToPartGroupsConstDto(this DbPartGroupsConst entity)
        {
            PartGroupsConstDto dto = new PartGroupsConstDto();
            dto.Id = entity.Id;
            dto.GroupNo = entity.GroupNo;
            dto.GroupPos = entity.GroupPos;
            dto.GroupName = entity.GroupName;
            dto.Code = entity.Code;
            dto.Description = entity.Description;

            return dto;
        }

        public static PartGroupsConst MapToPartGroupsConstData(this PartGroupsConstDto dto)
        {
            PartGroupsConst entity = new PartGroupsConst();
            entity.Id = dto.Id;
            entity.GroupNo = dto.GroupNo;
            entity.GroupPos = dto.GroupPos;
            entity.GroupName = dto.GroupName;
            entity.Code = dto.Code;
            entity.Description = dto.Description;

            return entity;
        }
        #endregion

        #region CustomerData
        public static CustomerDataDto MapToCustomerDataDto(this DbCustomerData entity)
        {
            CustomerDataDto dto = new CustomerDataDto();
            dto.CustomerCode = entity.CustomerCode;
            dto.Customer = entity.Customer;
            dto.CustomerGroup = entity.CustomerGroup;

            return dto;
        }

        public static CustomerData MapToCustomerData(this CustomerDataDto dto)
        {
            CustomerData entity = new CustomerData();
            entity.CustomerCode = dto.CustomerCode;
            entity.Customer = dto.Customer;
            entity.CustomerGroup = dto.CustomerGroup;

            return entity;
        }
        #endregion

        #region ColourCode
        public static ColourCodeDto MapToColourCodeDto(this DbColourCode entity)
        {
            ColourCodeDto dto = new ColourCodeDto();
            dto.ClMk = entity.ClMk;
            dto.ClCode = entity.ClCode;
            dto.ColorName = entity.ColorName;
            dto.WireUnitsFlag = entity.WireUnitsFlag;
            dto.PartUnitsFlag = entity.PartUnitsFlag;

            return dto;
        }

        public static ColourCode MapToColourCode(this ColourCodeDto dto)
        {
            ColourCode entity = new ColourCode();
            entity.Clmk = dto.ClMk;
            entity.ClCode = dto.ClCode;
            entity.ColorName = dto.ColorName;
            entity.WireUnitsFlag = dto.WireUnitsFlag;
            entity.PartUnitsFlag = dto.PartUnitsFlag;

            return entity;
        }
        #endregion

        #region MaterialGroups
        public static MaterialGroupsDto MapToMaterialGroupsDto(this DbMaterialGroups entity)
        {
            MaterialGroupsDto dto = new MaterialGroupsDto();
            dto.MaterialGroup = entity.MaterialGroup;
            dto.GroupDescription = entity.GroupDescription;

            return dto;
        }

        public static MaterialGroups MapToMaterialGroups(this MaterialGroupsDto dto)
        {
            MaterialGroups entity = new MaterialGroups();
            entity.MaterialGroup = dto.MaterialGroup;
            entity.GroupDescription = dto.GroupDescription;

            return entity;
        }
        #endregion

        #region MaterialTypes
        public static MaterialTypesDto MapToMaterialTypesDto(this DbMaterialTypes entity)
        {
            MaterialTypesDto dto = new MaterialTypesDto();
            dto.MaterialGroup = entity.MaterialGroup;
            dto.MaterialType = entity.MaterialType;
            dto.TypeDescription = entity.TypeDescription;

            return dto;
        }

        public static MaterialTypes MapToMaterialTypes(this MaterialTypesDto dto)
        {
            MaterialTypes entity = new MaterialTypes();
            entity.MaterialGroup = dto.MaterialGroup;
            entity.MaterialType = dto.MaterialType;
            entity.TypeDescription = dto.TypeDescription;

            return entity;
        }
        #endregion
    }
}
