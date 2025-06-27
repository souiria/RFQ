using Emacs.Data.DTOs;

namespace Emacs.Services
{
    public static class SampleEmacsDataService
    {
        #region CombinedParts
        public static ListCombinedPartsGrpc PopulateCombinedParts()
        {
            ListCombinedPartsGrpc listCombinedPartsGrpc = new ListCombinedPartsGrpc();
            for (int i = 0; i < 5; i++)
            {
                CombinedPartsGrpc CombinedPartsGrpc = new CombinedPartsGrpc();
                CombinedPartsGrpc.SumitomoNumber = $"TestSumitomoNumber{i}";
                CombinedPartsGrpc.CustomerNumber = $"TestCustomerNumber{i}";
                CombinedPartsGrpc.CustomerName = $"TestCustomerName{i}";
                CombinedPartsGrpc.SupplierNumber = $"TestSupplierNumber{i}";
                CombinedPartsGrpc.UniformSumitomoNumber = $"TestUniformSumitomoNumber{i}";
                CombinedPartsGrpc.UniformCustomerNumber = $"TestUniformCustomerNumber{i}";
                CombinedPartsGrpc.UniformSupplierNumber = $"TestUniformSupplierNumber{i}";
                listCombinedPartsGrpc.CombinedPartsGrpc.Add(CombinedPartsGrpc);
            }

            CombinedPartsGrpc fixedCombinedPartsGrpc = new CombinedPartsGrpc();
            fixedCombinedPartsGrpc.SumitomoNumber = $"TestSumitomoNumber";
            fixedCombinedPartsGrpc.CustomerNumber = $"TestCustomerNumber";
            fixedCombinedPartsGrpc.CustomerName = $"TestCustomerName";
            fixedCombinedPartsGrpc.SupplierNumber = $"TestSupplierNumber";
            fixedCombinedPartsGrpc.UniformSumitomoNumber = $"TestUniformSumitomoNumber";
            fixedCombinedPartsGrpc.UniformCustomerNumber = $"TestUniformCustomerNumber";
            fixedCombinedPartsGrpc.UniformSupplierNumber = $"TestUniformSupplierNumber";
            listCombinedPartsGrpc.CombinedPartsGrpc.Add(fixedCombinedPartsGrpc);
            return listCombinedPartsGrpc;
        }
        #endregion

        #region PartCategoryDetail
        public static ListPartCategoryDetailGrpc PopulatePartCategoryDetail()
        {
            ListPartCategoryDetailGrpc listPartCategoryDetailGrpc = new ListPartCategoryDetailGrpc();
            for (int i = 0; i < 5; i++)
            {
                PartCategoryDetailGrpc PartCategoryDetailGrpc = new PartCategoryDetailGrpc();
                PartCategoryDetailGrpc.CategoryCode = $"TestCategoryCode{i}";
                PartCategoryDetailGrpc.DetailedCategoryCode = i;
                PartCategoryDetailGrpc.CategoryName = $"TestCategoryName{i}";
                listPartCategoryDetailGrpc.PartCategoryDetailGrpc.Add(PartCategoryDetailGrpc);
            }

            PartCategoryDetailGrpc fixedPartCategoryDetailGrpc = new PartCategoryDetailGrpc();
            fixedPartCategoryDetailGrpc.CategoryCode = $"TestCategoryCode";
            fixedPartCategoryDetailGrpc.DetailedCategoryCode = 0;
            fixedPartCategoryDetailGrpc.CategoryName = $"TestCategoryName";
            listPartCategoryDetailGrpc.PartCategoryDetailGrpc.Add(fixedPartCategoryDetailGrpc);
            return listPartCategoryDetailGrpc;
        }
        #endregion

        #region PartClassDetail
        public static ListPartClassDetailGrpc PopulatePartClassDetail()
        {
            ListPartClassDetailGrpc listPartClassDetailGrpc = new ListPartClassDetailGrpc();
            for (int i = 0; i < 5; i++)
            {
                PartClassDetailGrpc PartClassDetailGrpc = new PartClassDetailGrpc();
                PartClassDetailGrpc.Class1 = $"TestClass1{i}";
                PartClassDetailGrpc.Class1Name = $"TestClass2{i}";
                PartClassDetailGrpc.Class2 = i;
                PartClassDetailGrpc.Class2Name = $"TestClass2Name{i}";
                listPartClassDetailGrpc.PartClassDetailGrpc.Add(PartClassDetailGrpc);
            }

            PartClassDetailGrpc fixedPartClassDetailGrpc = new PartClassDetailGrpc();
            fixedPartClassDetailGrpc.Class1 = $"TestClass1";
            fixedPartClassDetailGrpc.Class1Name = $"TestClass1Name";
            fixedPartClassDetailGrpc.Class2 = 0;
            fixedPartClassDetailGrpc.Class2Name = $"TestClass2Name";
            listPartClassDetailGrpc.PartClassDetailGrpc.Add(fixedPartClassDetailGrpc);
            return listPartClassDetailGrpc;
        }
        #endregion

        #region PartGroups
        public static ListPartGroupsGrpc PopulatePartGroups()
        {
            ListPartGroupsGrpc listPartGroupsGrpc = new ListPartGroupsGrpc();
            for (int i = 0; i < 5; i++)
            {
                PartGroupsGrpc PartGroupsGrpc = new PartGroupsGrpc();
                PartGroupsGrpc.PartGroup = $"TestPartGroup{i}";
                PartGroupsGrpc.GroupDescription = $"TestGroupDescription{i}";
                listPartGroupsGrpc.PartGroupsGrpc.Add(PartGroupsGrpc);
            }

            PartGroupsGrpc fixedPartGroupsGrpc = new PartGroupsGrpc();
            fixedPartGroupsGrpc.PartGroup = $"TestPartGroup";
            fixedPartGroupsGrpc.GroupDescription = $"TestGroupDescription";
            listPartGroupsGrpc.PartGroupsGrpc.Add(fixedPartGroupsGrpc);
            return listPartGroupsGrpc;
        }
        #endregion

        #region PartGroupsConst
        public static ListPartGroupsConstGrpc PopulatePartGroupsConst()
        {
            ListPartGroupsConstGrpc listPartGroupsConstGrpc = new ListPartGroupsConstGrpc();
            for (int i = 0; i < 5; i++)
            {
                PartGroupsConstGrpc PartGroupsConstGrpc = new PartGroupsConstGrpc();
                PartGroupsConstGrpc.Id = i;
                PartGroupsConstGrpc.GroupNo = i;
                PartGroupsConstGrpc.GroupPos = i;
                PartGroupsConstGrpc.GroupName = $"TestGroupName{i}";
                PartGroupsConstGrpc.Code = $"TestCode{i}";
                PartGroupsConstGrpc.Description = $"TestDescription{i}";
                listPartGroupsConstGrpc.PartGroupsConstGrpc.Add(PartGroupsConstGrpc);
            }

            PartGroupsConstGrpc fixedPartGroupsConstGrpc = new PartGroupsConstGrpc();
            fixedPartGroupsConstGrpc.Id = 0;
            fixedPartGroupsConstGrpc.GroupNo = 0;
            fixedPartGroupsConstGrpc.GroupPos = 0;
            fixedPartGroupsConstGrpc.GroupName = $"TestGroupName";
            fixedPartGroupsConstGrpc.Code = $"TestCode";
            fixedPartGroupsConstGrpc.Description = $"TestDescription";
            listPartGroupsConstGrpc.PartGroupsConstGrpc.Add(fixedPartGroupsConstGrpc);
            return listPartGroupsConstGrpc;
        }
        #endregion

        #region CustomerDataGrpc
        public static ListCustomerDataGrpc PopulateCustomerDataGrps()
        {
            ListCustomerDataGrpc listCustomerData = new ListCustomerDataGrpc();
            for (int i = 0; i < 5; i++)
            {
                CustomerDataGrpc customerData = new CustomerDataGrpc();
                customerData.CustomerCode = $"TestCustomerCode{i}";
                customerData.Customer = $"TestCustomer{i}";
                customerData.CustomerGroup = $"TestCustomerGroup{i}";
                listCustomerData.CustomerDataGrpc.Add(customerData);
            }

            CustomerDataGrpc fixedCustomerData = new CustomerDataGrpc();
            fixedCustomerData.CustomerCode = $"TestCustomerCode";
            fixedCustomerData.Customer = $"TestCustomer";
            fixedCustomerData.CustomerGroup = $"TestCustomerGroup";
            listCustomerData.CustomerDataGrpc.Add(fixedCustomerData);
            return listCustomerData;
        }
        #endregion

        #region ColourCode
        public static ListColourCodeGrpc PopulateColourCode()
        {
            ListColourCodeGrpc listColourCodeGrpc = new ListColourCodeGrpc();
            for (int i = 0; i < 5; i++)
            {
                ColourCodeGrpc ColourCodeGrpc = new ColourCodeGrpc();
                ColourCodeGrpc.ClMk = $"TestClMk{i}";
                ColourCodeGrpc.ClCode = $"TestClCode{i}";
                ColourCodeGrpc.ColorName = $"TestColorName{i}";
                ColourCodeGrpc.WireUnitsFlag = 0;
                ColourCodeGrpc.PartUnitsFlag = 0;
                listColourCodeGrpc.ColourCodeGrpc.Add(ColourCodeGrpc);
            }

            ColourCodeGrpc fixedColourCodeGrpc = new ColourCodeGrpc();
            fixedColourCodeGrpc.ClMk = $"TestClMk";
            fixedColourCodeGrpc.ClCode = $"TestClCode";
            fixedColourCodeGrpc.ColorName = $"TestColorName";
            fixedColourCodeGrpc.WireUnitsFlag = 0;
            fixedColourCodeGrpc.PartUnitsFlag = 0;
            listColourCodeGrpc.ColourCodeGrpc.Add(fixedColourCodeGrpc);
            return listColourCodeGrpc;
        }
        #endregion

        #region MaterialGroups
        public static ListMaterialGroupsGrpc PopulateMaterialGroups()
        {
            ListMaterialGroupsGrpc listMaterialGroupsGrpc = new ListMaterialGroupsGrpc();
            for (int i = 0; i < 5; i++)
            {
                MaterialGroupsGrpc MaterialGroupsGrpc = new MaterialGroupsGrpc();
                MaterialGroupsGrpc.MaterialGroup = $"TestMaterialGroup{i}";
                MaterialGroupsGrpc.GroupDescription = $"TestGroupDescription{i}";
                listMaterialGroupsGrpc.MaterialGroupsGrpc.Add(MaterialGroupsGrpc);
            }

            MaterialGroupsGrpc fixedMaterialGroupsGrpc = new MaterialGroupsGrpc();
            fixedMaterialGroupsGrpc.MaterialGroup = $"TestMaterialGroup";
            fixedMaterialGroupsGrpc.GroupDescription = $"TestGroupDescription";
            listMaterialGroupsGrpc.MaterialGroupsGrpc.Add(fixedMaterialGroupsGrpc);
            return listMaterialGroupsGrpc;
        }
        #endregion

        #region MaterialTypes
        public static ListMaterialTypesGrpc PopulateMaterialTypes()
        {
            ListMaterialTypesGrpc listMaterialTypesGrpc = new ListMaterialTypesGrpc();
            for (int i = 0; i < 5; i++)
            {
                MaterialTypesGrpc MaterialTypesGrpc = new MaterialTypesGrpc();
                MaterialTypesGrpc.MaterialGroup = $"TestMaterialGroup{i}";
                MaterialTypesGrpc.MaterialType = $"TestMaterialType{i}";
                MaterialTypesGrpc.TypeDescription = $"TestTypeDescription{i}";
                listMaterialTypesGrpc.MaterialTypesGrpc.Add(MaterialTypesGrpc);
            }

            MaterialTypesGrpc fixedMaterialTypesGrpc = new MaterialTypesGrpc();
            fixedMaterialTypesGrpc.MaterialGroup = $"TestMaterialGroup";
            fixedMaterialTypesGrpc.MaterialType = $"TestMaterialType";
            fixedMaterialTypesGrpc.TypeDescription = $"TestTypeDescription";
            listMaterialTypesGrpc.MaterialTypesGrpc.Add(fixedMaterialTypesGrpc);
            return listMaterialTypesGrpc;
        }
        #endregion

        #region NPACustomer
        public static ListNPACustomerGrpc PopulateNPACustomer()
        {
            ListNPACustomerGrpc listNPACustomerGrpc = new ListNPACustomerGrpc();
            for (int i = 0; i < 5; i++)
            {
                NPACustomerGrpc NPACustomerGrpc = new NPACustomerGrpc();
                NPACustomerGrpc.Id = i;
                NPACustomerGrpc.Code = $"TestCode{i}";
                NPACustomerGrpc.Name = $"TestName{i}";
                NPACustomerGrpc.SubsidiaryId = i;
                NPACustomerGrpc.BuyerId = i;
                NPACustomerGrpc.Address = $"TestAddress{i}";
                NPACustomerGrpc.Phone = $"TestPhone{i}";
                NPACustomerGrpc.Email = $"TestEmail{i}";
                NPACustomerGrpc.Contact = $"TestContact{i}";
                NPACustomerGrpc.AlternateContact = $"TestAlternateContact{i}";
                NPACustomerGrpc.Active = true;
                listNPACustomerGrpc.NPACustomerGrpc.Add(NPACustomerGrpc);
            }

            NPACustomerGrpc fixedNPACustomerGrpc = new NPACustomerGrpc();
            fixedNPACustomerGrpc.Id = 0;
            fixedNPACustomerGrpc.Code = $"TestCode";
            fixedNPACustomerGrpc.Name = $"TestName";
            fixedNPACustomerGrpc.SubsidiaryId = 0;
            fixedNPACustomerGrpc.BuyerId = 0;
            fixedNPACustomerGrpc.Address = $"TestAddress";
            fixedNPACustomerGrpc.Phone = $"TestPhone";
            fixedNPACustomerGrpc.Email = $"TestEmail";
            fixedNPACustomerGrpc.Contact = $"TestContact";
            fixedNPACustomerGrpc.AlternateContact = $"TestAlternateContact";
            fixedNPACustomerGrpc.Active = true;
            listNPACustomerGrpc.NPACustomerGrpc.Add(fixedNPACustomerGrpc);
            return listNPACustomerGrpc;
        }
        #endregion

        #region NPASupplier
        public static ListNPASupplierGrpc PopulateNPASupplier()
        {
            ListNPASupplierGrpc listNPASupplierGrpc = new ListNPASupplierGrpc();
            for (int i = 0; i < 5; i++)
            {
                NPASupplierGrpc NPASupplierGrpc = new NPASupplierGrpc();
                NPASupplierGrpc.Id = i;
                NPASupplierGrpc.Code = $"TestCode{i}";
                NPASupplierGrpc.Name = $"TestName{i}";
                NPASupplierGrpc.SubsidiaryId = i;
                NPASupplierGrpc.BuyerId = i;
                NPASupplierGrpc.Address = $"TestAddress{i}";
                NPASupplierGrpc.Phone = $"TestPhone{i}";
                NPASupplierGrpc.Email = $"TestEmail{i}";
                NPASupplierGrpc.Contact = $"TestContact{i}";
                NPASupplierGrpc.AlternateContact = $"TestAlternateContact{i}";
                NPASupplierGrpc.Active = true;
                NPASupplierGrpc.JSupplier = true;
                listNPASupplierGrpc.NPASupplierGrpc.Add(NPASupplierGrpc);
            }

            NPASupplierGrpc fixedNPASupplierGrpc = new NPASupplierGrpc();
            fixedNPASupplierGrpc.Id = 0;
            fixedNPASupplierGrpc.Code = $"TestCode";
            fixedNPASupplierGrpc.Name = $"TestName";
            fixedNPASupplierGrpc.SubsidiaryId = 0;
            fixedNPASupplierGrpc.BuyerId = 0;
            fixedNPASupplierGrpc.Address = $"TestAddress";
            fixedNPASupplierGrpc.Phone = $"TestPhone";
            fixedNPASupplierGrpc.Email = $"TestEmail";
            fixedNPASupplierGrpc.Contact = $"TestContact";
            fixedNPASupplierGrpc.AlternateContact = $"TestAlternateContact";
            fixedNPASupplierGrpc.Active = true;
            fixedNPASupplierGrpc.JSupplier = true;
            listNPASupplierGrpc.NPASupplierGrpc.Add(fixedNPASupplierGrpc);
            return listNPASupplierGrpc;
        }
        #endregion

        #region Suppliers
        public static ListSuppliersGrpc PopulateSuppliers()
        {
            ListSuppliersGrpc listSuppliersGrpc = new ListSuppliersGrpc();
            for (int i = 0; i < 5; i++)
            {
                SuppliersGrpc SuppliersGrpc = new SuppliersGrpc();
                SuppliersGrpc.SupplierCode = i;
                SuppliersGrpc.SupplierName = $"TestSupplierName{i}";
                listSuppliersGrpc.SuppliersGrpc.Add(SuppliersGrpc);
            }

            SuppliersGrpc fixedSuppliersGrpc = new SuppliersGrpc();
            fixedSuppliersGrpc.SupplierCode = 0;
            fixedSuppliersGrpc.SupplierName = $"TestSupplierName";
            listSuppliersGrpc.SuppliersGrpc.Add(fixedSuppliersGrpc);
            return listSuppliersGrpc;
        }
        #endregion

        #region PARTMS
        public static ListPARTMSGrpc PopulatePARTMS()
        {
            ListPARTMSGrpc listPARTMSGrpc = new ListPARTMSGrpc();
            for (int i = 0; i < 5; i++)
            {
                PARTMSGrpc PARTMSGrpc = new PARTMSGrpc();
                PARTMSGrpc.SumitomoNumber = $"TestSumitomoNumber{i}";
                PARTMSGrpc.SumitomoDescription = $"TestSumitomoDescription{i}";
                PARTMSGrpc.SumitomoDescriptionEnglish = $"TestSumitomoDescriptionEnglish{i}";
                PARTMSGrpc.OldPartClass = $"TestOldPartClass{i}";
                PARTMSGrpc.OldMaterial = $"TestOldMaterial{i}";
                PARTMSGrpc.ClassDetailGroupCode = $"TestClassDetailGroupCode{i}";
                PARTMSGrpc.ClassDetailId = $"TestClassDetailId{i}";
                PARTMSGrpc.MaterialGroupId = $"TestMaterialGroupId{i}";
                PARTMSGrpc.MaterialTypeId = $"TestMaterialTypeId{i}";
                PARTMSGrpc.ColorCode = $"TestColorCode{i}";
                PARTMSGrpc.NumberOfCavity = i;
                PARTMSGrpc.InsideDiameter = i;
                PARTMSGrpc.WallThickness = i;
                PARTMSGrpc.Length = i;
                PARTMSGrpc.WidthOrOutsideDiameter = i;
                PARTMSGrpc.WidthOrOutsideDiameter = i;
                PARTMSGrpc.HoleDiameter = i;
                PARTMSGrpc.ShrinkRateLength = i;
                PARTMSGrpc.NumberOfTapingSpots = i;
                PARTMSGrpc.MassOrWeight = i;
                PARTMSGrpc.Quantity = i;
                PARTMSGrpc.UoM = $"TestUoM{i}";
                PARTMSGrpc.Group1 = $"TestGroup1{i}";
                PARTMSGrpc.Group2 = $"TestGroup2{i}";
                PARTMSGrpc.Group3 = $"TestGroup3{i}";
                PARTMSGrpc.Group4 = $"TestGroup4{i}";
                PARTMSGrpc.CavityCount = $"TestCavityCount{i}";
                PARTMSGrpc.Group6 = $"TestGroup6{i}";
                PARTMSGrpc.Group7 = $"TestGroup7{i}";
                PARTMSGrpc.Group8 = $"TestGroup8{i}";
                PARTMSGrpc.CustomerId = $"TestCustomerId{i}";
                PARTMSGrpc.MassOrWeight2 = i;
                PARTMSGrpc.L1 = i;
                PARTMSGrpc.L2 = i;
                PARTMSGrpc.L3 = i;
                PARTMSGrpc.PitchWidth = i;
                PARTMSGrpc.Tilt = i;
                PARTMSGrpc.Grease = i;
                PARTMSGrpc.CategoryCode = $"TestCategoryCode{i}";
                listPARTMSGrpc.PARTMSGrpc.Add(PARTMSGrpc);
            }

            PARTMSGrpc fixedPARTMSGrpc = new PARTMSGrpc();
            fixedPARTMSGrpc.SumitomoNumber = $"TestSumitomoNumber";
            fixedPARTMSGrpc.SumitomoDescription = $"TestSumitomoDescription";
            fixedPARTMSGrpc.SumitomoDescriptionEnglish = $"TestSumitomoDescriptionEnglish";
            fixedPARTMSGrpc.OldPartClass = $"TestOldPartClass";
            fixedPARTMSGrpc.OldMaterial = $"TestOldMaterial";
            fixedPARTMSGrpc.ClassDetailGroupCode = $"TestClassDetailGroupCode";
            fixedPARTMSGrpc.ClassDetailId = $"0";
            fixedPARTMSGrpc.MaterialGroupId = $"TestMaterialGroupId";
            fixedPARTMSGrpc.MaterialTypeId = $"TestMaterialTypeId";
            fixedPARTMSGrpc.ColorCode = $"TestColorCode";
            fixedPARTMSGrpc.NumberOfCavity = 0;
            fixedPARTMSGrpc.InsideDiameter = 0;
            fixedPARTMSGrpc.WallThickness = 0;
            fixedPARTMSGrpc.Length = 0;
            fixedPARTMSGrpc.WidthOrOutsideDiameter = 0;
            fixedPARTMSGrpc.WidthOrOutsideDiameter = 0;
            fixedPARTMSGrpc.HoleDiameter = 0;
            fixedPARTMSGrpc.ShrinkRateLength = 0;
            fixedPARTMSGrpc.NumberOfTapingSpots = 0;
            fixedPARTMSGrpc.MassOrWeight = 0;
            fixedPARTMSGrpc.Quantity = 0;
            fixedPARTMSGrpc.UoM = $"TestUoM";
            fixedPARTMSGrpc.Group1 = $"TestGroup1";
            fixedPARTMSGrpc.Group2 = $"TestGroup2";
            fixedPARTMSGrpc.Group3 = $"TestGroup3";
            fixedPARTMSGrpc.Group4 = $"TestGroup4";
            fixedPARTMSGrpc.CavityCount = $"TestCavityCount";
            fixedPARTMSGrpc.Group6 = $"TestGroup6";
            fixedPARTMSGrpc.Group7 = $"TestGroup7";
            fixedPARTMSGrpc.Group8 = $"TestGroup8";
            fixedPARTMSGrpc.CustomerId = $"TestCustomerId";
            fixedPARTMSGrpc.MassOrWeight2 = 0;
            fixedPARTMSGrpc.L1 = 0;
            fixedPARTMSGrpc.L2 = 0;
            fixedPARTMSGrpc.L3 = 0;
            fixedPARTMSGrpc.PitchWidth = 0;
            fixedPARTMSGrpc.Tilt = 0;
            fixedPARTMSGrpc.Grease = 0;
            fixedPARTMSGrpc.CategoryCode = $"TestCategoryCode";
            listPARTMSGrpc.PARTMSGrpc.Add(fixedPARTMSGrpc);
            return listPARTMSGrpc;
        }
        #endregion

    }
}
