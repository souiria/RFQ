using Emacs.Data.DTOs;

namespace Emacs.Services
{
    public static class SampleEmacsDataService
    {
        #region CombinedParts
        public static ListCombinedPartsData PopulateCombinedParts()
        {
            ListCombinedPartsData listCombinedPartsData = new ListCombinedPartsData();
            for (int i = 0; i < 5; i++)
            {
                CombinedPartsData combinedPartsData = new CombinedPartsData();
                combinedPartsData.SumitomoNumber = $"TestSumitomoNumber{i}";
                combinedPartsData.CustomerNumber = $"TestCustomerNumber{i}";
                combinedPartsData.CustomerName = $"TestCustomerName{i}";
                combinedPartsData.SupplierNumber = $"TestSupplierNumber{i}";
                combinedPartsData.UniformSumitomoNumber = $"TestUniformSumitomoNumber{i}";
                combinedPartsData.UniformCustomerNumber = $"TestUniformCustomerNumber{i}";
                combinedPartsData.UniformSupplierNumber = $"TestUniformSupplierNumber{i}";
                listCombinedPartsData.CombinedPartsData.Add(combinedPartsData);
            }

            CombinedPartsData fixedCombinedPartsData = new CombinedPartsData();
            fixedCombinedPartsData.SumitomoNumber = $"TestSumitomoNumber";
            fixedCombinedPartsData.CustomerNumber = $"TestCustomerNumber";
            fixedCombinedPartsData.CustomerName = $"TestCustomerName";
            fixedCombinedPartsData.SupplierNumber = $"TestSupplierNumber";
            fixedCombinedPartsData.UniformSumitomoNumber = $"TestUniformSumitomoNumber";
            fixedCombinedPartsData.UniformCustomerNumber = $"TestUniformCustomerNumber";
            fixedCombinedPartsData.UniformSupplierNumber = $"TestUniformSupplierNumber";
            listCombinedPartsData.CombinedPartsData.Add(fixedCombinedPartsData);
            return listCombinedPartsData;
        }
        #endregion

        #region PartCategoryDetail
        public static ListPartCategoryDetailData PopulatePartCategoryDetail()
        {
            ListPartCategoryDetailData listPartCategoryDetailData = new ListPartCategoryDetailData();
            for (int i = 0; i < 5; i++)
            {
                PartCategoryDetailData partCategoryDetailData = new PartCategoryDetailData();
                partCategoryDetailData.CategoryCode = $"TestCategoryCode{i}";
                partCategoryDetailData.DetailedCategoryCode = i;
                partCategoryDetailData.CategoryName = $"TestCategoryName{i}";
                listPartCategoryDetailData.PartCategoryDetailData.Add(partCategoryDetailData);
            }

            PartCategoryDetailData fixedPartCategoryDetailData = new PartCategoryDetailData();
            fixedPartCategoryDetailData.CategoryCode = $"TestCategoryCode";
            fixedPartCategoryDetailData.DetailedCategoryCode = 0;
            fixedPartCategoryDetailData.CategoryName = $"TestCategoryName";
            listPartCategoryDetailData.PartCategoryDetailData.Add(fixedPartCategoryDetailData);
            return listPartCategoryDetailData;
        }
        #endregion

        #region PartClassDetail
        public static ListPartClassDetailData PopulatePartClassDetail()
        {
            ListPartClassDetailData listPartClassDetailData = new ListPartClassDetailData();
            for (int i = 0; i < 5; i++)
            {
                PartClassDetailData partClassDetailData = new PartClassDetailData();
                partClassDetailData.Class1 = $"TestClass1{i}";
                partClassDetailData.Class1Name = $"TestClass2{i}";
                partClassDetailData.Class2 = i;
                partClassDetailData.Class2Name = $"TestClass2Name{i}";
                listPartClassDetailData.PartClassDetailData.Add(partClassDetailData);
            }

            PartClassDetailData fixedPartClassDetailData = new PartClassDetailData();
            fixedPartClassDetailData.Class1 = $"TestClass1";
            fixedPartClassDetailData.Class1Name = $"TestClass1Name";
            fixedPartClassDetailData.Class2 = 0;
            fixedPartClassDetailData.Class2Name = $"TestClass2Name";
            listPartClassDetailData.PartClassDetailData.Add(fixedPartClassDetailData);
            return listPartClassDetailData;
        }
        #endregion

        #region PartGroups
        public static ListPartGroupsData PopulatePartGroups()
        {
            ListPartGroupsData listPartGroupsData = new ListPartGroupsData();
            for (int i = 0; i < 5; i++)
            {
                PartGroupsData partGroupsData = new PartGroupsData();
                partGroupsData.PartGroup = $"TestPartGroup{i}";
                partGroupsData.GroupDescription = $"TestGroupDescription{i}";
                listPartGroupsData.PartGroupsData.Add(partGroupsData);
            }

            PartGroupsData fixedPartGroupsData = new PartGroupsData();
            fixedPartGroupsData.PartGroup = $"TestPartGroup";
            fixedPartGroupsData.GroupDescription = $"TestGroupDescription";
            listPartGroupsData.PartGroupsData.Add(fixedPartGroupsData);
            return listPartGroupsData;
        }
        #endregion

        #region PartGroupsConst
        public static ListPartGroupsConstData PopulatePartGroupsConst()
        {
            ListPartGroupsConstData listPartGroupsConstData = new ListPartGroupsConstData();
            for (int i = 0; i < 5; i++)
            {
                PartGroupsConstData partGroupsConstData = new PartGroupsConstData();
                partGroupsConstData.Id = i;
                partGroupsConstData.GroupNo = i;
                partGroupsConstData.GroupPos = i;
                partGroupsConstData.GroupName = $"TestGroupName{i}";
                partGroupsConstData.Code = $"TestCode{i}";
                partGroupsConstData.Description = $"TestDescription{i}";
                listPartGroupsConstData.PartGroupsConstData.Add(partGroupsConstData);
            }

            PartGroupsConstData fixedPartGroupsConstData = new PartGroupsConstData();
            fixedPartGroupsConstData.Id = 0;
            fixedPartGroupsConstData.GroupNo = 0;
            fixedPartGroupsConstData.GroupPos = 0;
            fixedPartGroupsConstData.GroupName = $"TestGroupName";
            fixedPartGroupsConstData.Code = $"TestCode";
            fixedPartGroupsConstData.Description = $"TestDescription";
            listPartGroupsConstData.PartGroupsConstData.Add(fixedPartGroupsConstData);
            return listPartGroupsConstData;
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
        public static ListColourCodeData PopulateColourCode()
        {
            ListColourCodeData listColourCodeData = new ListColourCodeData();
            for (int i = 0; i < 5; i++)
            {
                ColourCodeData colourCodeData = new ColourCodeData();
                colourCodeData.ClMk = $"TestClMk{i}";
                colourCodeData.ClCode = $"TestClCode{i}";
                colourCodeData.ColorName = $"TestColorName{i}";
                colourCodeData.WireUnitsFlag = 0;
                colourCodeData.PartUnitsFlag = 0;
                listColourCodeData.ColourCodeData.Add(colourCodeData);
            }

            ColourCodeData fixedColourCodeData = new ColourCodeData();
            fixedColourCodeData.ClMk = $"TestClMk";
            fixedColourCodeData.ClCode = $"TestClCode";
            fixedColourCodeData.ColorName = $"TestColorName";
            fixedColourCodeData.WireUnitsFlag = 0;
            fixedColourCodeData.PartUnitsFlag = 0;
            listColourCodeData.ColourCodeData.Add(fixedColourCodeData);
            return listColourCodeData;
        }
        #endregion

        #region MaterialGroups
        public static ListMaterialGroupsData PopulateMaterialGroups()
        {
            ListMaterialGroupsData listMaterialGroupsData = new ListMaterialGroupsData();
            for (int i = 0; i < 5; i++)
            {
                MaterialGroupsData materialGroupsData = new MaterialGroupsData();
                materialGroupsData.MaterialGroup = $"TestMaterialGroup{i}";
                materialGroupsData.GroupDescription = $"TestGroupDescription{i}";
                listMaterialGroupsData.MaterialGroupsData.Add(materialGroupsData);
            }

            MaterialGroupsData fixedMaterialGroupsData = new MaterialGroupsData();
            fixedMaterialGroupsData.MaterialGroup = $"TestMaterialGroup";
            fixedMaterialGroupsData.GroupDescription = $"TestGroupDescription";
            listMaterialGroupsData.MaterialGroupsData.Add(fixedMaterialGroupsData);
            return listMaterialGroupsData;
        }
        #endregion

        #region MaterialTypes
        public static ListMaterialTypesData PopulateMaterialTypes()
        {
            ListMaterialTypesData listMaterialTypesData = new ListMaterialTypesData();
            for (int i = 0; i < 5; i++)
            {
                MaterialTypesData materialTypesData = new MaterialTypesData();
                materialTypesData.MaterialGroup = $"TestMaterialGroup{i}";
                materialTypesData.MaterialType = $"TestMaterialType{i}";
                materialTypesData.TypeDescription = $"TestTypeDescription{i}";
                listMaterialTypesData.MaterialTypesData.Add(materialTypesData);
            }

            MaterialTypesData fixedMaterialTypesData = new MaterialTypesData();
            fixedMaterialTypesData.MaterialGroup = $"TestMaterialGroup";
            fixedMaterialTypesData.MaterialType = $"TestMaterialType";
            fixedMaterialTypesData.TypeDescription = $"TestTypeDescription";
            listMaterialTypesData.MaterialTypesData.Add(fixedMaterialTypesData);
            return listMaterialTypesData;
        }
        #endregion

        #region NPACustomer
        public static ListNPACustomerData PopulateNPACustomer()
        {
            ListNPACustomerData listNPACustomerData = new ListNPACustomerData();
            for (int i = 0; i < 5; i++)
            {
                NPACustomerData nPACustomerData = new NPACustomerData();
                nPACustomerData.Id = i;
                nPACustomerData.Code = $"TestCode{i}";
                nPACustomerData.Name = $"TestName{i}";
                nPACustomerData.SubsidiaryId = i;
                nPACustomerData.BuyerId = i;
                nPACustomerData.Address = $"TestAddress{i}";
                nPACustomerData.Phone = $"TestPhone{i}";
                nPACustomerData.Email = $"TestEmail{i}";
                nPACustomerData.Contact = $"TestContact{i}";
                nPACustomerData.AlternateContact = $"TestAlternateContact{i}";
                nPACustomerData.Active = true;
                listNPACustomerData.NPACustomerData.Add(nPACustomerData);
            }

            NPACustomerData fixedNPACustomerData = new NPACustomerData();
            fixedNPACustomerData.Id = 0;
            fixedNPACustomerData.Code = $"TestCode";
            fixedNPACustomerData.Name = $"TestName";
            fixedNPACustomerData.SubsidiaryId = 0;
            fixedNPACustomerData.BuyerId = 0;
            fixedNPACustomerData.Address = $"TestAddress";
            fixedNPACustomerData.Phone = $"TestPhone";
            fixedNPACustomerData.Email = $"TestEmail";
            fixedNPACustomerData.Contact = $"TestContact";
            fixedNPACustomerData.AlternateContact = $"TestAlternateContact";
            fixedNPACustomerData.Active = true;
            listNPACustomerData.NPACustomerData.Add(fixedNPACustomerData);
            return listNPACustomerData;
        }
        #endregion

        #region NPASupplier
        public static ListNPASupplierData PopulateNPASupplier()
        {
            ListNPASupplierData listNPASupplierData = new ListNPASupplierData();
            for (int i = 0; i < 5; i++)
            {
                NPASupplierData nPASupplierData = new NPASupplierData();
                nPASupplierData.Id = i;
                nPASupplierData.Code = $"TestCode{i}";
                nPASupplierData.Name = $"TestName{i}";
                nPASupplierData.SubsidiaryId = i;
                nPASupplierData.BuyerId = i;
                nPASupplierData.Address = $"TestAddress{i}";
                nPASupplierData.Phone = $"TestPhone{i}";
                nPASupplierData.Email = $"TestEmail{i}";
                nPASupplierData.Contact = $"TestContact{i}";
                nPASupplierData.AlternateContact = $"TestAlternateContact{i}";
                nPASupplierData.Active = true;
                nPASupplierData.JSupplier = true;
                listNPASupplierData.NPASupplierData.Add(nPASupplierData);
            }

            NPASupplierData fixedNPASupplierData = new NPASupplierData();
            fixedNPASupplierData.Id = 0;
            fixedNPASupplierData.Code = $"TestCode";
            fixedNPASupplierData.Name = $"TestName";
            fixedNPASupplierData.SubsidiaryId = 0;
            fixedNPASupplierData.BuyerId = 0;
            fixedNPASupplierData.Address = $"TestAddress";
            fixedNPASupplierData.Phone = $"TestPhone";
            fixedNPASupplierData.Email = $"TestEmail";
            fixedNPASupplierData.Contact = $"TestContact";
            fixedNPASupplierData.AlternateContact = $"TestAlternateContact";
            fixedNPASupplierData.Active = true;
            fixedNPASupplierData.JSupplier = true;
            listNPASupplierData.NPASupplierData.Add(fixedNPASupplierData);
            return listNPASupplierData;
        }
        #endregion

        #region Suppliers
        public static ListSuppliersData PopulateSuppliers()
        {
            ListSuppliersData listSuppliersData = new ListSuppliersData();
            for (int i = 0; i < 5; i++)
            {
                SuppliersData suppliersData = new SuppliersData();
                suppliersData.SupplierCode = i;
                suppliersData.SupplierName = $"TestSupplierName{i}";
                listSuppliersData.SuppliersData.Add(suppliersData);
            }

            SuppliersData fixedSuppliersData = new SuppliersData();
            fixedSuppliersData.SupplierCode = 0;
            fixedSuppliersData.SupplierName = $"TestSupplierName";
            listSuppliersData.SuppliersData.Add(fixedSuppliersData);
            return listSuppliersData;
        }
        #endregion

        #region PARTMS
        public static ListPARTMSData PopulatePARTMS()
        {
            ListPARTMSData listPARTMSData = new ListPARTMSData();
            for (int i = 0; i < 5; i++)
            {
                PARTMSData pARTMSData = new PARTMSData();
                pARTMSData.SumitomoNumber = $"TestSumitomoNumber{i}";
                pARTMSData.SumitomoDescription = $"TestSumitomoDescription{i}";
                pARTMSData.SumitomoDescriptionEnglish = $"TestSumitomoDescriptionEnglish{i}";
                pARTMSData.OldPartClass = $"TestOldPartClass{i}";
                pARTMSData.OldMaterial = $"TestOldMaterial{i}";
                pARTMSData.ClassDetailGroupCode = $"TestClassDetailGroupCode{i}";
                pARTMSData.ClassDetailId = $"TestClassDetailId{i}";
                pARTMSData.MaterialGroupId = $"TestMaterialGroupId{i}";
                pARTMSData.MaterialTypeId = $"TestMaterialTypeId{i}";
                pARTMSData.ColorCode = $"TestColorCode{i}";
                pARTMSData.NumberOfCavity = i;
                pARTMSData.InsideDiameter = i;
                pARTMSData.WallThickness = i;
                pARTMSData.Length = i;
                pARTMSData.WidthOrOutsideDiameter = i;
                pARTMSData.WidthOrOutsideDiameter = i;
                pARTMSData.HoleDiameter = i;
                pARTMSData.ShrinkRateLength = i;
                pARTMSData.NumberOfTapingSpots = i;
                pARTMSData.MassOrWeight = i;
                pARTMSData.Quantity = i;
                pARTMSData.UoM = $"TestUoM{i}";
                pARTMSData.Group1 = $"TestGroup1{i}";
                pARTMSData.Group2 = $"TestGroup2{i}";
                pARTMSData.Group3 = $"TestGroup3{i}";
                pARTMSData.Group4 = $"TestGroup4{i}";
                pARTMSData.CavityCount = $"TestCavityCount{i}";
                pARTMSData.Group6 = $"TestGroup6{i}";
                pARTMSData.Group7 = $"TestGroup7{i}";
                pARTMSData.Group8 = $"TestGroup8{i}";
                pARTMSData.CustomerId = $"TestCustomerId{i}";
                pARTMSData.MassOrWeight2 = i;
                pARTMSData.L1 = i;
                pARTMSData.L2 = i;
                pARTMSData.L3 = i;
                pARTMSData.PitchWidth = i;
                pARTMSData.Tilt = i;
                pARTMSData.Grease = i;
                pARTMSData.CategoryCode = $"TestCategoryCode{i}";
                listPARTMSData.PARTMSData.Add(pARTMSData);
            }

            PARTMSData fixedPARTMSData = new PARTMSData();
            fixedPARTMSData.SumitomoNumber = $"TestSumitomoNumber";
            fixedPARTMSData.SumitomoDescription = $"TestSumitomoDescription";
            fixedPARTMSData.SumitomoDescriptionEnglish = $"TestSumitomoDescriptionEnglish";
            fixedPARTMSData.OldPartClass = $"TestOldPartClass";
            fixedPARTMSData.OldMaterial = $"TestOldMaterial";
            fixedPARTMSData.ClassDetailGroupCode = $"TestClassDetailGroupCode";
            fixedPARTMSData.ClassDetailId = $"0";
            fixedPARTMSData.MaterialGroupId = $"TestMaterialGroupId";
            fixedPARTMSData.MaterialTypeId = $"TestMaterialTypeId";
            fixedPARTMSData.ColorCode = $"TestColorCode";
            fixedPARTMSData.NumberOfCavity = 0;
            fixedPARTMSData.InsideDiameter = 0;
            fixedPARTMSData.WallThickness = 0;
            fixedPARTMSData.Length = 0;
            fixedPARTMSData.WidthOrOutsideDiameter = 0;
            fixedPARTMSData.WidthOrOutsideDiameter = 0;
            fixedPARTMSData.HoleDiameter = 0;
            fixedPARTMSData.ShrinkRateLength = 0;
            fixedPARTMSData.NumberOfTapingSpots = 0;
            fixedPARTMSData.MassOrWeight = 0;
            fixedPARTMSData.Quantity = 0;
            fixedPARTMSData.UoM = $"TestUoM";
            fixedPARTMSData.Group1 = $"TestGroup1";
            fixedPARTMSData.Group2 = $"TestGroup2";
            fixedPARTMSData.Group3 = $"TestGroup3";
            fixedPARTMSData.Group4 = $"TestGroup4";
            fixedPARTMSData.CavityCount = $"TestCavityCount";
            fixedPARTMSData.Group6 = $"TestGroup6";
            fixedPARTMSData.Group7 = $"TestGroup7";
            fixedPARTMSData.Group8 = $"TestGroup8";
            fixedPARTMSData.CustomerId = $"TestCustomerId";
            fixedPARTMSData.MassOrWeight2 = 0;
            fixedPARTMSData.L1 = 0;
            fixedPARTMSData.L2 = 0;
            fixedPARTMSData.L3 = 0;
            fixedPARTMSData.PitchWidth = 0;
            fixedPARTMSData.Tilt = 0;
            fixedPARTMSData.Grease = 0;
            fixedPARTMSData.CategoryCode = $"TestCategoryCode";
            listPARTMSData.PARTMSData.Add(fixedPARTMSData);
            return listPARTMSData;
        }
        #endregion

    }
}
