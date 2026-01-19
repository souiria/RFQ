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
                CombinedPartsGrpc combinedPartsGrpc = new CombinedPartsGrpc();
                combinedPartsGrpc.SumitomoNumber = $"TestSumitomoNumber{i}";
                combinedPartsGrpc.CustomerNumber = $"TestCustomerNumber{i}";
                combinedPartsGrpc.CustomerName = $"TestCustomerName{i}";
                combinedPartsGrpc.SupplierNumber = $"TestSupplierNumber{i}";
                combinedPartsGrpc.UniformSumitomoNumber = $"TestUniformSumitomoNumber{i}";
                combinedPartsGrpc.UniformCustomerNumber = $"TestUniformCustomerNumber{i}";
                combinedPartsGrpc.UniformSupplierNumber = $"TestUniformSupplierNumber{i}";
                listCombinedPartsGrpc.CombinedPartsGrpc.Add(combinedPartsGrpc);
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
                PartCategoryDetailGrpc partCategoryDetailGrpc = new PartCategoryDetailGrpc();
                partCategoryDetailGrpc.CategoryCode = $"TestCategoryCode{i}";
                partCategoryDetailGrpc.DetailedCategoryCode = i;
                partCategoryDetailGrpc.CategoryName = $"TestCategoryName{i}";
                listPartCategoryDetailGrpc.PartCategoryDetailGrpc.Add(partCategoryDetailGrpc);
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
                PartClassDetailGrpc partClassDetailGrpc = new PartClassDetailGrpc();
                partClassDetailGrpc.Class1 = $"TestClass1{i}";
                partClassDetailGrpc.Class1Name = $"TestClass2{i}";
                partClassDetailGrpc.Class2 = i;
                partClassDetailGrpc.Class2Name = $"TestClass2Name{i}";
                listPartClassDetailGrpc.PartClassDetailGrpc.Add(partClassDetailGrpc);
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
                PartGroupsGrpc partGroupsGrpc = new PartGroupsGrpc();
                partGroupsGrpc.PartGroup = $"TestPartGroup{i}";
                partGroupsGrpc.GroupDescription = $"TestGroupDescription{i}";
                listPartGroupsGrpc.PartGroupsGrpc.Add(partGroupsGrpc);
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
                PartGroupsConstGrpc partGroupsConstGrpc = new PartGroupsConstGrpc();
                partGroupsConstGrpc.Id = i;
                partGroupsConstGrpc.GroupNo = i;
                partGroupsConstGrpc.GroupPos = i;
                partGroupsConstGrpc.GroupName = $"TestGroupName{i}";
                partGroupsConstGrpc.Code = $"TestCode{i}";
                partGroupsConstGrpc.Description = $"TestDescription{i}";
                listPartGroupsConstGrpc.PartGroupsConstGrpc.Add(partGroupsConstGrpc);
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
                ColourCodeGrpc colourCodeGrpc = new ColourCodeGrpc();
                colourCodeGrpc.ClMk = $"TestClMk{i}";
                colourCodeGrpc.ClCode = $"TestClCode{i}";
                colourCodeGrpc.ColorName = $"TestColorName{i}";
                colourCodeGrpc.WireUnitsFlag = 0;
                colourCodeGrpc.PartUnitsFlag = 0;
                listColourCodeGrpc.ColourCodeGrpc.Add(colourCodeGrpc);
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
                MaterialGroupsGrpc materialGroupsGrpc = new MaterialGroupsGrpc();
                materialGroupsGrpc.MaterialGroup = $"TestMaterialGroup{i}";
                materialGroupsGrpc.GroupDescription = $"TestGroupDescription{i}";
                listMaterialGroupsGrpc.MaterialGroupsGrpc.Add(materialGroupsGrpc);
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
                MaterialTypesGrpc materialTypesGrpc = new MaterialTypesGrpc();
                materialTypesGrpc.MaterialGroup = $"TestMaterialGroup{i}";
                materialTypesGrpc.MaterialType = $"TestMaterialType{i}";
                materialTypesGrpc.TypeDescription = $"TestTypeDescription{i}";
                listMaterialTypesGrpc.MaterialTypesGrpc.Add(materialTypesGrpc);
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
                NPACustomerGrpc nPACustomerGrpc = new NPACustomerGrpc();
                nPACustomerGrpc.Id = i;
                nPACustomerGrpc.Code = $"TestCode{i}";
                nPACustomerGrpc.Name = $"TestName{i}";
                nPACustomerGrpc.SubsidiaryId = i;
                nPACustomerGrpc.BuyerId = i;
                nPACustomerGrpc.Address = $"TestAddress{i}";
                nPACustomerGrpc.Phone = $"TestPhone{i}";
                nPACustomerGrpc.Email = $"TestEmail{i}";
                nPACustomerGrpc.Contact = $"TestContact{i}";
                nPACustomerGrpc.AlternateContact = $"TestAlternateContact{i}";
                nPACustomerGrpc.Active = true;
                listNPACustomerGrpc.NPACustomerGrpc.Add(nPACustomerGrpc);
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
                NPASupplierGrpc nPASupplierGrpc = new NPASupplierGrpc();
                nPASupplierGrpc.Id = i;
                nPASupplierGrpc.Code = $"TestCode{i}";
                nPASupplierGrpc.Name = $"TestName{i}";
                nPASupplierGrpc.SubsidiaryId = i;
                nPASupplierGrpc.BuyerId = i;
                nPASupplierGrpc.Address = $"TestAddress{i}";
                nPASupplierGrpc.Phone = $"TestPhone{i}";
                nPASupplierGrpc.Email = $"TestEmail{i}";
                nPASupplierGrpc.Contact = $"TestContact{i}";
                nPASupplierGrpc.AlternateContact = $"TestAlternateContact{i}";
                nPASupplierGrpc.Active = true;
                nPASupplierGrpc.JSupplier = true;
                listNPASupplierGrpc.NPASupplierGrpc.Add(nPASupplierGrpc);
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
                SuppliersGrpc suppliersGrpc = new SuppliersGrpc();
                suppliersGrpc.SupplierCode = i;
                suppliersGrpc.SupplierName = $"TestSupplierName{i}";
                listSuppliersGrpc.SuppliersGrpc.Add(suppliersGrpc);
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
                PARTMSGrpc pARTMSGrpc = new PARTMSGrpc();
                pARTMSGrpc.SumitomoNumber = $"TestSumitomoNumber{i}";
                pARTMSGrpc.SumitomoDescription = $"TestSumitomoDescription{i}";
                pARTMSGrpc.SumitomoDescriptionEnglish = $"TestSumitomoDescriptionEnglish{i}";
                pARTMSGrpc.OldPartClass = $"TestOldPartClass{i}";
                pARTMSGrpc.OldMaterial = $"TestOldMaterial{i}";
                pARTMSGrpc.ClassDetailGroupCode = $"TestClassDetailGroupCode{i}";
                pARTMSGrpc.ClassDetailId = $"TestClassDetailId{i}";
                pARTMSGrpc.MaterialGroupId = $"TestMaterialGroupId{i}";
                pARTMSGrpc.MaterialTypeId = $"TestMaterialTypeId{i}";
                pARTMSGrpc.ColorCode = $"TestColorCode{i}";
                pARTMSGrpc.NumberOfCavity = i;
                pARTMSGrpc.InsideDiameter = i;
                pARTMSGrpc.WallThickness = i;
                pARTMSGrpc.Length = i;
                pARTMSGrpc.WidthOrOutsideDiameter = i;
                pARTMSGrpc.WidthOrOutsideDiameter = i;
                pARTMSGrpc.HoleDiameter = i;
                pARTMSGrpc.ShrinkRateLength = i;
                pARTMSGrpc.NumberOfTapingSpots = i;
                pARTMSGrpc.MassOrWeight = i;
                pARTMSGrpc.Quantity = i;
                pARTMSGrpc.UoM = $"TestUoM{i}";
                pARTMSGrpc.Group1 = $"TestGroup1{i}";
                pARTMSGrpc.Group2 = $"TestGroup2{i}";
                pARTMSGrpc.Group3 = $"TestGroup3{i}";
                pARTMSGrpc.Group4 = $"TestGroup4{i}";
                pARTMSGrpc.CavityCount = $"TestCavityCount{i}";
                pARTMSGrpc.Group6 = $"TestGroup6{i}";
                pARTMSGrpc.Group7 = $"TestGroup7{i}";
                pARTMSGrpc.Group8 = $"TestGroup8{i}";
                pARTMSGrpc.CustomerId = $"TestCustomerId{i}";
                pARTMSGrpc.MassOrWeight2 = i;
                pARTMSGrpc.L1 = i;
                pARTMSGrpc.L2 = i;
                pARTMSGrpc.L3 = i;
                pARTMSGrpc.PitchWidth = i;
                pARTMSGrpc.Tilt = i;
                pARTMSGrpc.Grease = i;
                pARTMSGrpc.CategoryCode = $"TestCategoryCode{i}";
                listPARTMSGrpc.PARTMSGrpc.Add(pARTMSGrpc);
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

        #region AlternativeParts

        public static ListAlternativePartsGrpc PopulateAlternativePartsGrpc()
        {
            ListAlternativePartsGrpc listAlternativePartsGrpc = new ListAlternativePartsGrpc();
            for (int i = 0; i < 5; i++)
            {
                AlternativePartsGrpc alternativePartsGrpc = new AlternativePartsGrpc();
                alternativePartsGrpc.SumitomoNumber = $"SumitomoNumber{i}";
                alternativePartsGrpc.SumitomoDescription = $"SumitomoDescription{i}";
                alternativePartsGrpc.MainSupplier = true;
                alternativePartsGrpc.SupplierName = $"SupplierName{i}";
                alternativePartsGrpc.SupplierNumber = $"SupplierNumber{i}";
                alternativePartsGrpc.Price = i;
                alternativePartsGrpc.CurrencyCode = $"CurrencyCode{i}";
                alternativePartsGrpc.UnitOfMeasure = $"UnitOfMeasure{i}";
                alternativePartsGrpc.PartGroup = $"PartGroup{i}";
                alternativePartsGrpc.GroupDescription = $"GroupDescription{i}";
                alternativePartsGrpc.Class1 = $"Class1{i}";
                alternativePartsGrpc.Class1Name = $"Class1Name{i}";
                alternativePartsGrpc.Class2 = i;
                alternativePartsGrpc.Class2Name = $"Class2Name{i}";
                alternativePartsGrpc.ColourCode = $"ColourCode{i}";
                alternativePartsGrpc.ColorName = $"ColorName{i}";
                alternativePartsGrpc.MaterialGroup = $"MaterialGroup{i}";
                alternativePartsGrpc.Expr1 = $"Expr1{i}";
                alternativePartsGrpc.MaterialType = $"MaterialType{i}";
                alternativePartsGrpc.TypeDescription = $"TypeDescription{i}";
                alternativePartsGrpc.CategoryCode = $"CategoryCode{i}";
                alternativePartsGrpc.DetailedCategoryCode = i;
                alternativePartsGrpc.CategoryName = $"CategoryName{i}";
                alternativePartsGrpc.PartGroupCode = $"PartGroupCode{i}";
                alternativePartsGrpc.Description = $"Description{i}";
                alternativePartsGrpc.OldPartClass = $"OldPartClass{i}";
                alternativePartsGrpc.OldMaterial = $"OldMaterial{i}";
                alternativePartsGrpc.ClassDetailGroupCode = $"ClassDetailGroupCode{i}";
                alternativePartsGrpc.ClassDetailId = $"ClassDetailId{i}";
                alternativePartsGrpc.MaterialGroupId = $"MaterialGroupId{i}";
                alternativePartsGrpc.MaterialTypeId = $"MaterialTypeId{i}";
                alternativePartsGrpc.ColorCode = $"ColorCode{i}";
                alternativePartsGrpc.NumberOfCavity = i;
                alternativePartsGrpc.InsideDiameter = i;
                alternativePartsGrpc.WallThickness = i;
                alternativePartsGrpc.Length = i;
                alternativePartsGrpc.WidthOrOutsideDiameter = i;
                alternativePartsGrpc.HoleDiameter = i;
                alternativePartsGrpc.ShrinkRateLength = i;
                alternativePartsGrpc.NumberOfTapingSpots = i;
                alternativePartsGrpc.MassOrWeight = i;
                alternativePartsGrpc.Quantity = i;
                alternativePartsGrpc.UoM = $"UoM{i}";
                alternativePartsGrpc.Group1 = $"Group1{i}";
                alternativePartsGrpc.Group2 = $"Group2{i}";
                alternativePartsGrpc.Group3 = $"Group3{i}";
                alternativePartsGrpc.Group4 = $"Group4{i}";
                alternativePartsGrpc.Group5 = $"Group5{i}";
                alternativePartsGrpc.Group6 = $"Group6{i}";
                alternativePartsGrpc.Group7 = $"Group7{i}";
                alternativePartsGrpc.Group8 = $"Group8{i}";
                alternativePartsGrpc.CustomerId = $"CustomerId{i}";
                alternativePartsGrpc.CustomerCode = $"CustomerCode{i}";
                alternativePartsGrpc.MassOrWeight2 = i;
                alternativePartsGrpc.L1 = i;
                alternativePartsGrpc.L2 = i;
                alternativePartsGrpc.L3 = i;
                alternativePartsGrpc.PitchWidth = i;
                alternativePartsGrpc.Tilt = i;
                alternativePartsGrpc.Grease = i;
                alternativePartsGrpc.CategoryCode2 = $"CategoryCode2{i}";
                listAlternativePartsGrpc.AlternativePartsGrpc.Add(alternativePartsGrpc);
            }

            AlternativePartsGrpc fixedAlternativePartsGrpc = new AlternativePartsGrpc();
            fixedAlternativePartsGrpc.SumitomoNumber = $"TestSumitomoNumber";
            fixedAlternativePartsGrpc.SumitomoDescription = $"TestSumitomoDescription";
            fixedAlternativePartsGrpc.MainSupplier = true;
            fixedAlternativePartsGrpc.SupplierName = $"TestSupplierName";
            fixedAlternativePartsGrpc.SupplierNumber = $"TestSupplierNumber";
            fixedAlternativePartsGrpc.Price = 0;
            fixedAlternativePartsGrpc.CurrencyCode = $"TestCurrencyCode";
            fixedAlternativePartsGrpc.UnitOfMeasure = $"TestUnitOfMeasure";
            fixedAlternativePartsGrpc.PartGroup = $"TestPartGroup";
            fixedAlternativePartsGrpc.GroupDescription = $"TestGroupDescription";
            fixedAlternativePartsGrpc.Class1 = $"TestClass1";
            fixedAlternativePartsGrpc.Class1Name = $"TestClass1Name";
            fixedAlternativePartsGrpc.Class2 = 0;
            fixedAlternativePartsGrpc.Class2Name = $"TestClass2Name";
            fixedAlternativePartsGrpc.ColourCode = $"TestColourCode";
            fixedAlternativePartsGrpc.ColorName = $"TestColorName";
            fixedAlternativePartsGrpc.MaterialGroup = $"TestMaterialGroup";
            fixedAlternativePartsGrpc.Expr1 = $"TestExpr1";
            fixedAlternativePartsGrpc.MaterialType = $"TestMaterialType";
            fixedAlternativePartsGrpc.TypeDescription = $"TestTypeDescription";
            fixedAlternativePartsGrpc.CategoryCode = $"TestCategoryCode";
            fixedAlternativePartsGrpc.DetailedCategoryCode = 0;
            fixedAlternativePartsGrpc.CategoryName = $"TestCategoryName";
            fixedAlternativePartsGrpc.PartGroupCode = $"TestPartGroupCode";
            fixedAlternativePartsGrpc.Description = $"TestDescription";
            fixedAlternativePartsGrpc.OldPartClass = $"TestOldPartClass";
            fixedAlternativePartsGrpc.OldMaterial = $"TestOldMaterial";
            fixedAlternativePartsGrpc.ClassDetailGroupCode = $"TestClassDetailGroupCode";
            fixedAlternativePartsGrpc.ClassDetailId = $"TestClassDetailId";
            fixedAlternativePartsGrpc.MaterialGroupId = $"TestMaterialGroupId";
            fixedAlternativePartsGrpc.MaterialTypeId = $"TestMaterialTypeId";
            fixedAlternativePartsGrpc.ColorCode = $"TestColorCode";
            fixedAlternativePartsGrpc.NumberOfCavity = 0;
            fixedAlternativePartsGrpc.InsideDiameter = 0;
            fixedAlternativePartsGrpc.WallThickness = 0;
            fixedAlternativePartsGrpc.Length = 0;
            fixedAlternativePartsGrpc.WidthOrOutsideDiameter = 0;
            fixedAlternativePartsGrpc.HoleDiameter = 0;
            fixedAlternativePartsGrpc.ShrinkRateLength = 0;
            fixedAlternativePartsGrpc.NumberOfTapingSpots = 0;
            fixedAlternativePartsGrpc.MassOrWeight = 0;
            fixedAlternativePartsGrpc.Quantity = 0;
            fixedAlternativePartsGrpc.UoM = $"TestUoM";
            fixedAlternativePartsGrpc.Group1 = $"TestGroup1";
            fixedAlternativePartsGrpc.Group2 = $"TestGroup2";
            fixedAlternativePartsGrpc.Group3 = $"TestGroup3";
            fixedAlternativePartsGrpc.Group4 = $"TestGroup4";
            fixedAlternativePartsGrpc.Group5 = $"TestGroup5";
            fixedAlternativePartsGrpc.Group6 = $"TestGroup6";
            fixedAlternativePartsGrpc.Group7 = $"TestGroup7";
            fixedAlternativePartsGrpc.Group8 = $"TestGroup8";
            fixedAlternativePartsGrpc.CustomerId = $"TestCustomerId";
            fixedAlternativePartsGrpc.CustomerCode = $"TestCustomerCode";
            fixedAlternativePartsGrpc.MassOrWeight2 = 0;
            fixedAlternativePartsGrpc.L1 = 0;
            fixedAlternativePartsGrpc.L2 = 0;
            fixedAlternativePartsGrpc.L3 = 0;
            fixedAlternativePartsGrpc.PitchWidth = 0;
            fixedAlternativePartsGrpc.Tilt = 0;
            fixedAlternativePartsGrpc.Grease = 0;
            fixedAlternativePartsGrpc.CategoryCode2 = $"TestCategoryCode2";
            listAlternativePartsGrpc.AlternativePartsGrpc.Add(fixedAlternativePartsGrpc);
            return listAlternativePartsGrpc;
        }

        #endregion

    }
}
