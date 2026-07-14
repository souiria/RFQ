namespace CPD.Services
{
    public static class SampleCPDDataService
    {
        #region MattSuppMst
        public static ListMatSuppMstGrpc PopulateMatSuppMstView()
        {
            ListMatSuppMstGrpc listMatSuppMstViewGrpc = new ListMatSuppMstGrpc();
            for (int i = 0; i < 5; i++)
            {
                MatSuppMstViewGrpc matSuppMstViewGrpc = new MatSuppMstViewGrpc();
                matSuppMstViewGrpc.MaterialNo = $"TestMaterialNo{i}";
                matSuppMstViewGrpc.SupplierC = $"TestSupplierC{i}";
                matSuppMstViewGrpc.PoUnit = $"TestPoUnit{i}";
                matSuppMstViewGrpc.PoMinordQty = i;
                matSuppMstViewGrpc.PoPrice = i;
                matSuppMstViewGrpc.PoRatio = i;
                matSuppMstViewGrpc.OrderLTime = i;
                matSuppMstViewGrpc.IssueUnit = $"TestIssueUnit{i}";
                matSuppMstViewGrpc.UnitConfacPo = i;
                matSuppMstViewGrpc.UnitConfacIssue = i;
                matSuppMstViewGrpc.BagQty = i;
                matSuppMstViewGrpc.BoxQty = i;
                matSuppMstViewGrpc.SuppMatNo = $"TestSuppMatNo{i}";
                matSuppMstViewGrpc.SuppMatNm = $"TestSuppMatNm{i}";
                matSuppMstViewGrpc.UpdFlg = $"TestUpdFlg{i}";
                matSuppMstViewGrpc.Userid = $"TestUserid{i}";
                matSuppMstViewGrpc.EntDt = DateTime.Now.ToUniversalTime().ToTimestamp();
                matSuppMstViewGrpc.UpdDt = DateTime.Now.ToUniversalTime().ToTimestamp();
                matSuppMstViewGrpc.StandardBoxLength = i;
                matSuppMstViewGrpc.StandardBoxWidth = i;
                matSuppMstViewGrpc.StandardBoxHeigh = i;
                matSuppMstViewGrpc.StandardPackFactor = i;
                matSuppMstViewGrpc.CopperWt = i;
                matSuppMstViewGrpc.CopperRate = i;
                matSuppMstViewGrpc.POPriceExcopper = i;
                matSuppMstViewGrpc.InitialVolQty = i;
                matSuppMstViewGrpc.ReplaceMaterialNo = $"TestReplaceMaterialNo{i}";
                matSuppMstViewGrpc.FullBoxWeight = i;
                matSuppMstViewGrpc.Active = $"TestActive{i}";
                matSuppMstViewGrpc.Comments = $"TestActive{i}";
                matSuppMstViewGrpc.PRICETYPEDESC = $"TestActive{i}";
                matSuppMstViewGrpc.ExchangeRate = i;
                matSuppMstViewGrpc.ExchangeRateUpdDt = DateTime.Now.ToUniversalTime().ToTimestamp();
                listMatSuppMstViewGrpc.MatSuppMstViewGrpc.Add(matSuppMstViewGrpc);
            }

            MatSuppMstViewGrpc fixedMatSuppMstView = new MatSuppMstViewGrpc();
            fixedMatSuppMstView.MaterialNo = $"TestMaterialNo";
            fixedMatSuppMstView.SupplierC = $"TestSupplierC";
            fixedMatSuppMstView.PoUnit = $"TestPoUnit";
            fixedMatSuppMstView.PoMinordQty = 0;
            fixedMatSuppMstView.PoPrice = 0;
            fixedMatSuppMstView.PoRatio = 0;
            fixedMatSuppMstView.OrderLTime = 0;
            fixedMatSuppMstView.IssueUnit = $"TestIssueUnit";
            fixedMatSuppMstView.UnitConfacPo = 0;
            fixedMatSuppMstView.UnitConfacIssue = 0;
            fixedMatSuppMstView.BagQty = 0;
            fixedMatSuppMstView.BoxQty = 0;
            fixedMatSuppMstView.SuppMatNo = $"TestSuppMatNo";
            fixedMatSuppMstView.SuppMatNm = $"TestSuppMatNm";
            fixedMatSuppMstView.UpdFlg = $"TestUpdFlg";
            fixedMatSuppMstView.Userid = $"TestUserid";
            fixedMatSuppMstView.EntDt = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedMatSuppMstView.UpdDt = DateTime.Now.ToUniversalTime().ToTimestamp();
            fixedMatSuppMstView.StandardBoxLength = 0;
            fixedMatSuppMstView.StandardBoxWidth = 0;
            fixedMatSuppMstView.StandardBoxHeigh = 0;
            fixedMatSuppMstView.StandardPackFactor = 0;
            fixedMatSuppMstView.CopperWt = 0;
            fixedMatSuppMstView.CopperRate = 0;
            fixedMatSuppMstView.POPriceExcopper = 0;
            fixedMatSuppMstView.InitialVolQty = 0;
            fixedMatSuppMstView.ReplaceMaterialNo = $"TestReplaceMaterialNo";
            fixedMatSuppMstView.FullBoxWeight = 0;
            fixedMatSuppMstView.Active = $"TestActive";
            fixedMatSuppMstView.Comments = $"TestActive";
            fixedMatSuppMstView.PRICETYPEDESC = $"TestActive";
            fixedMatSuppMstView.ExchangeRate = 0;
            fixedMatSuppMstView.ExchangeRateUpdDt = DateTime.Now.ToUniversalTime().ToTimestamp();
            listMatSuppMstViewGrpc.MatSuppMstViewGrpc.Add(fixedMatSuppMstView);
            return listMatSuppMstViewGrpc;
        }
        #endregion

        #region HarnessCostingCalculationData
        public static ListHarnessCostingCalculationDataGrpc PopulateHarnessCostingCalculationDataView()
        {
            ListHarnessCostingCalculationDataGrpc listHarnessCostingCalculationDataGrpc = new ListHarnessCostingCalculationDataGrpc();
            for (int i = 0; i < 5; i++)
            {
                HarnessCostingCalculationDataGrpc harnessCostingCalculationDataGrpc = new HarnessCostingCalculationDataGrpc();
                harnessCostingCalculationDataGrpc.MaterialNo = $"TestMaterialNo{i}";
                harnessCostingCalculationDataGrpc.SupplierC = $"TestSupplierC{i}";
                harnessCostingCalculationDataGrpc.PoUnit = $"TestPoUnit{i}";
                harnessCostingCalculationDataGrpc.IssueUnit = $"TestIssueUnit{i}";
                harnessCostingCalculationDataGrpc.BomUnit = $"TestBomUnit{i}";
                harnessCostingCalculationDataGrpc.UnitConfacPo = i;
                harnessCostingCalculationDataGrpc.UnitConfacIssue = i;
                harnessCostingCalculationDataGrpc.PoPrice = i;
                harnessCostingCalculationDataGrpc.CurrC = $"TestCurrC{i}";
                harnessCostingCalculationDataGrpc.PoRatio = i;
                harnessCostingCalculationDataGrpc.ExchangeRate = i;
                harnessCostingCalculationDataGrpc.ExchangeRateUpdDt = DateTime.Now.ToUniversalTime().ToTimestamp();
                listHarnessCostingCalculationDataGrpc.HarnessCostingCalculationDataGrpc.Add(harnessCostingCalculationDataGrpc);
            }

            HarnessCostingCalculationDataGrpc fixedHarnessCostingCalculationDataGrpc = new HarnessCostingCalculationDataGrpc();
            fixedHarnessCostingCalculationDataGrpc.MaterialNo = $"TestMaterialNo";
            fixedHarnessCostingCalculationDataGrpc.SupplierC = $"TestSupplierC";
            fixedHarnessCostingCalculationDataGrpc.PoUnit = $"TestPoUnit";
            fixedHarnessCostingCalculationDataGrpc.IssueUnit = $"TestIssueUnit";
            fixedHarnessCostingCalculationDataGrpc.BomUnit = $"TestBomUnit";
            fixedHarnessCostingCalculationDataGrpc.UnitConfacPo = 0;
            fixedHarnessCostingCalculationDataGrpc.UnitConfacIssue = 0;
            fixedHarnessCostingCalculationDataGrpc.PoPrice = 0;
            fixedHarnessCostingCalculationDataGrpc.CurrC = $"TestCurrC";
            fixedHarnessCostingCalculationDataGrpc.PoRatio = 0;
            fixedHarnessCostingCalculationDataGrpc.ExchangeRate = 0;
            fixedHarnessCostingCalculationDataGrpc.ExchangeRateUpdDt = DateTime.Now.ToUniversalTime().ToTimestamp();
            listHarnessCostingCalculationDataGrpc.HarnessCostingCalculationDataGrpc.Add(fixedHarnessCostingCalculationDataGrpc);
            return listHarnessCostingCalculationDataGrpc;
        }
        #endregion
    }
}
