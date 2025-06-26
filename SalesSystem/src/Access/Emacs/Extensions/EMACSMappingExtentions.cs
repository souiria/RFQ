namespace Emacs.Extensions
{
    public static class EMACSMappingExtentions
    {
        #region CombinedParts
        public static CombinedPartsGrpc MapToCombinePartsData(this DbCombinedParts entity)
        {
            CombinedPartsGrpc data = new CombinedPartsGrpc();
            data.SumitomoNumber = entity.SumitomoNumber;
            data.CustomerNumber = entity.CustomerNumber;
            data.CustomerName = entity.CustomerName;
            data.SupplierNumber = entity.SupplierNumber;
            data.UniformSumitomoNumber = entity.UniformSumitomoNumber;
            data.UniformCustomerNumber = entity.UniformCustomerNumber;
            data.UniformSupplierNumber = entity.UniformSupplierNumber;
            
            return data;
        }
        #endregion

        #region PartCatogoryDetail
        public static PartCategoryDetailGrpc MapToPartCategoryDetailGrpc(this DbPartCategoryDetail entity)
        {
            PartCategoryDetailGrpc data = new PartCategoryDetailGrpc();
            data.CategoryCode = entity.CategoryCode;
            data.DetailedCategoryCode = entity.DetailedCategoryCode;
            data.CategoryName = entity.CategoryName;

            return data;
        }
        #endregion

        #region PartClassDetail
        public static PartClassDetailData MapToPartClassDetailData(this DbPartClassDetail entity)
        {
            PartClassDetailData data = new PartClassDetailData();
            data.Class1 = entity.Class1;
            data.Class1Name = entity.Class1Name;
            data.Class2 = entity.Class2;
            data.Class2Name = entity.Class2Name;

            return data;
        }
        #endregion

        #region PartGroups
        public static PartGroupsGrpc MapToPartGroupsGrpc(this DbPartGroups entity)
        {
            PartGroupsGrpc data = new PartGroupsGrpc();
            data.PartGroup = entity.PartGroup;
            data.GroupDescription = entity.GroupDescription;

            return data;
        }
        #endregion

        #region PartGroupsConst
        public static PartGroupsConstGrpc MapToPartGroupsConstGrpc(this DbPartGroupsConst entity)
        {
            PartGroupsConstGrpc data = new PartGroupsConstGrpc();
            data.Id = entity.Id;
            data.GroupNo = entity.GroupNo;
            data.GroupPos = entity.GroupPos;
            data.GroupName = entity.GroupName;
            data.Code = entity.Code;
            data.Description = entity.Description;

            return data;
        }
        #endregion

        #region CustomerData
        public static CustomerDataGrpc MapToCustomerDataDto(this DbCustomerData entity)
        {
            CustomerDataGrpc data = new CustomerDataGrpc();
            data.CustomerCode = entity.CustomerCode;
            data.Customer = entity.Customer;
            data.CustomerGroup = entity.CustomerGroup;

            return data;
        }
        #endregion

        #region ColourCode
        public static ColourCodeGrpc MapToColourCodeGrpc(this DbColourCode entity)
        {
            ColourCodeGrpc data = new ColourCodeGrpc();
            data.ClMk = entity.ClMk;
            data.ClCode = entity.ClCode;
            data.ColorName = entity.ColorName;
            data.WireUnitsFlag = entity.WireUnitsFlag;
            data.PartUnitsFlag = entity.PartUnitsFlag;

            return data;
        }
        #endregion

        #region MaterialGroups
        public static MaterialGroupsGrpc MapToMaterialGroupsGrpc(this DbMaterialGroups entity)
        {
            MaterialGroupsGrpc data = new MaterialGroupsGrpc();
            data.MaterialGroup = entity.MaterialGroup;
            data.GroupDescription = entity.GroupDescription;

            return data;
        }
        #endregion

        #region MaterialTypes
        public static MaterialTypesGrpc MapToMaterialTypesGrpc(this DbMaterialTypes entity)
        {
            MaterialTypesGrpc data = new MaterialTypesGrpc();
            data.MaterialGroup = entity.MaterialGroup;
            data.MaterialType = entity.MaterialType;
            data.TypeDescription = entity.TypeDescription;

            return data;
        }
        #endregion

        #region NPACustomer
        public static NPACustomerGrpc MapToNPACustomerGrpc(this DbNPACustomer entity)
        {
            NPACustomerGrpc data = new NPACustomerGrpc();
            data.Id = entity.Id;
            data.Code = entity.Code;
            data.Name = entity.Name;
            data.SubsidiaryId = entity.Subsidiary_id;
            data.BuyerId = entity.Buyer_id;
            data.Address = entity.Address;
            data.Phone = entity.Phone;
            data.Email = entity.Email;
            data.Contact = entity.Contact;
            data.AlternateContact = entity.Alternate_contact;
            data.Active = entity.Active;

            return data;
        }
        #endregion

        #region NPASupplier
        public static NPASupplierGrpc MapToNPASupplierGrpc(this DbNPASupplier entity)
        {
            NPASupplierGrpc data = new NPASupplierGrpc();
            data.Id = entity.Id;
            data.Code = entity.Code;
            data.Name = entity.Name;
            data.SubsidiaryId = entity.Subsidiary_id;
            data.BuyerId = entity.Buyer_id;
            data.Address = entity.Address;
            data.Phone = entity.Phone;
            data.Email = entity.Email;
            data.Contact = entity.Contact;
            data.AlternateContact = entity.Alternate_contact;
            data.Active = entity.Active;
            data.JSupplier = entity.J_Supplier;

            return data;
        }
        #endregion

        #region Suppliers
        public static SuppliersGrpc MapToSuppliersGrpc(this DbSuppliers entity)
        {
            SuppliersGrpc data = new SuppliersGrpc();
            data.SupplierCode = entity.SupplierCode;
            data.SupplierName = entity.SupplierName;

            return data;
        }
        #endregion

        #region EmacsRFIView
        public static EmacsRFIViewGrpc MapToEmacsRFIViewGrpc(this DbEmacsRFIView entity)
        {
            EmacsRFIViewGrpc data = new EmacsRFIViewGrpc();
            data.SumitomoNumber = entity.SumitomoNumber;
            data.SumitomoDescription = entity.SumitomoDescription;
            data.SumitomoDescriptionEnglish = entity.SumitomoDescriptionEnglish;
            data.PartGroup = entity.PartGroup;
            data.GroupDescription = entity.GroupDescription;
            data.Class1 = entity.Class1;
            data.Class1Name = entity.Class1Name;
            data.Class2 = entity.Class2;
            data.Class2Name = entity.Class2Name;
            data.ColourCode = entity.ColourCode;
            data.ColorName = entity.ColorName;
            data.MaterialGroup = entity.MaterialGroup;
            data.Expr1 = entity.Expr1;
            data.MaterialType = entity.MaterialType;
            data.TypeDescription = entity.TypeDescription;
            data.CategoryCode = entity.CategoryCode;
            data.Description = entity.Description;
            data.OldPartClass = entity.OldPartClass;
            data.OldMaterial = entity.OldMaterial;
            data.ClassDetailGroupCode = entity.ClassDetailGroupCode;
            data.ClassDetailId = entity.ClassDetailId;
            data.MaterialGroupId = entity.MaterialGroupId;
            data.MaterialTypeId = entity.MaterialTypeId;
            data.ColorCode = entity.ColorCode;
            data.NumberOfCavity = entity.NumberOfCavity;
            data.InsideDiameter = (double?)entity.InsideDiameter;
            data.WallThickness = (double?)entity.WallThickness;
            data.Length = (double?)entity.Length;
            data.WidthOrOutsideDiameter = (double?)entity.WidthOrOutsideDiameter;
            data.HoleDiameter = entity.HoleDiameter;
            data.ShrinkRateLength = entity.ShrinkRateLength;
            data.NumberOfTapingSpots = entity.NumberOfTapingSpots;
            data.MassOrWeight = (double?)entity.MassOrWeight;
            data.Quantity = (double?)entity.Quantity;
            data.UoM = entity.UoM;
            data.Group1 = entity.Group1;
            data.Group2 = entity.Group2;
            data.Group3 = entity.Group3;
            data.Group4 = entity.Group4;
            data.CavityCount = entity.CavityCount;
            data.Group6 = entity.Group6;
            data.Group7 = entity.Group7;
            data.Group8 = entity.Group8;
            data.CustomerId = entity.CustomerId;
            data.MassOrWeight2 = (double?)entity.MassOrWeight2;
            data.L1 = entity.L1;
            data.L2 = entity.L2;
            data.L3 = entity.L3;
            data.PitchWidth = (double?)entity.PitchWidth;
            data.Tilt = entity.Tilt;
            data.Grease = entity.Grease;
            data.CategoryCode = entity.CategoryCode;

            return data;
        }
        #endregion

        #region PARTMS
        public static PARTMSGrpc MapToPARTMSGrpc(this DbPARTMS entity)
        {
            PARTMSGrpc data = new PARTMSGrpc();
            data.SumitomoNumber = entity.SumitomoNumber;
            data.SumitomoDescription = entity.SumitomoDescription;
            data.SumitomoDescriptionEnglish = entity.SumitomoDescriptionEnglish;
            data.OldPartClass = entity.OldPartClass;
            data.OldMaterial = entity.OldMaterial;
            data.ClassDetailGroupCode = entity.ClassDetailGroupCode;
            data.ClassDetailId = entity.ClassDetailId;
            data.MaterialGroupId = entity.MaterialGroupId;
            data.MaterialTypeId = entity.MaterialTypeId;
            data.ColorCode = entity.ColorCode;
            data.NumberOfCavity = entity.NumberOfCavity;
            data.InsideDiameter = (double?)entity.InsideDiameter;
            data.WallThickness = (double?)entity.WallThickness;
            data.Length = (double?)entity.Length;
            data.WidthOrOutsideDiameter = (double?)entity.WidthOrOutsideDiameter;
            data.HoleDiameter = entity.HoleDiameter;
            data.ShrinkRateLength = entity.ShrinkRateLength;
            data.NumberOfTapingSpots = entity.NumberOfTapingSpots;
            data.MassOrWeight = (double?)entity.MassOrWeight;
            data.Quantity = (double?)entity.Quantity;
            data.UoM = entity.UoM;
            data.Group1 = entity.Group1;
            data.Group2 = entity.Group2;
            data.Group3 = entity.Group3;
            data.Group4 = entity.Group4;
            data.CavityCount = entity.CavityCount;
            data.Group6 = entity.Group6;
            data.Group7 = entity.Group7;
            data.Group8 = entity.Group8;
            data.CustomerId = entity.CustomerId;
            data.MassOrWeight2 = (double?)entity.MassOrWeight2;
            data.L1 = entity.L1;
            data.L2 = entity.L2;
            data.L3 = entity.L3;
            data.PitchWidth = (double?)entity.PitchWidth;
            data.Tilt = entity.Tilt;
            data.Grease = entity.Grease;
            data.CategoryCode = entity.CategoryCode;

            return data;
        }

        //public static PARTMS MapToPARTMS(this PARTMSDto dto)
        //{
        //    PARTMS entity = new PARTMS();
        //    entity.CPBUHINC = dto.SumitomoNumber;
        //    entity.CPBUHINNM = dto.SumitomoDescription;
        //    entity.CPBUHINENM = dto.SumitomoDescriptionEnglish;
        //    entity.CPOLDSYUBETU = dto.OldPartClass;
        //    entity.CPOLDZAISITU = dto.OldMaterial;
        //    entity.CPSYUBETU1 = dto.ClassDetailGroupCode;
        //    entity.CPSYUBETU2 = dto.ClassDetailId;
        //    entity.CPZAISITU1 = dto.MaterialGroupId;
        //    entity.CPZAISITU2 = dto.MaterialTypeId;
        //    entity.CPIRO = dto.ColorCode;
        //    entity.CPKYOKUSU = dto.NumberOfCavity;
        //    entity.CPSIZE1 = dto.InsideDiameter;
        //    entity.CPSIZE2 = dto.WallThickness;
        //    entity.CPSIZE3 = dto.Length;
        //    entity.CPSIZE4 = dto.WidthOrOutsideDiameter;
        //    entity.CPLAANAKEI = dto.HoleDiameter;
        //    entity.CPTPNOBIRITU = dto.ShrinkRateLength;
        //    entity.CPTPDOMESU = dto.NumberOfTapingSpots;
        //    entity.CPZYURYO = dto.MassOrWeight;
        //    entity.CPSURYO = dto.Quantity;
        //    entity.CPTANI = dto.UoM;
        //    entity.CPSOBETUK1 = dto.Group1;
        //    entity.CPSOBETUK2 = dto.Group2;
        //    entity.CPSOBETUK3 = dto.Group3;
        //    entity.CPSOBETUK4 = dto.Group4;
        //    entity.CPSOBETUK5 = dto.CavityCount;
        //    entity.CPSOBETUK6 = dto.Group6;
        //    entity.CPSOBETUK7 = dto.Group7;
        //    entity.CPSOBETUK8 = dto.Group8;
        //    entity.CPSINKIMAKER = dto.CustomerId;
        //    entity.CPSEKKEIZYURYO = dto.MassOrWeight2;
        //    entity.CPL1 = dto.L1;
        //    entity.CPL2 = dto.L2;
        //    entity.CPL3 = dto.L3;
        //    entity.CPPITCHHABA = dto.PitchWidth;
        //    entity.CPKATAMUKI = dto.Tilt;
        //    entity.CPGURISUA = dto.Grease;
        //    entity.CPHINMOKUC = dto.CategoryCode;

        //    return entity;
        //}
        #endregion
    }
}
