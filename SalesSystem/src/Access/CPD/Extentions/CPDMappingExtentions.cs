namespace CPD.Extentions
{
    public static class CPDMappingExtentions
    {
        #region MatSuppMst
        public static MatSuppMstViewGrpc MapToMatSuppMstViewGrpc(this DbMattSuppMstView entity)
        {
            MatSuppMstViewGrpc data = new MatSuppMstViewGrpc();
            data.MaterialNo = entity.Material_No;
            data.SupplierC = entity.Supplier_C;
            data.PoUnit = entity.Po_Unit;
            data.PoMinordQty = entity.Po_Minord_Qty;
            data.PoPrice = (double?)entity.Po_Price;
            data.PoRatio = entity.Po_Ratio;
            data.OrderLTime = entity.Order_LTime;
            data.IssueUnit = entity.Issue_Unit;
            data.IssueMinLot = entity.Issue_Min_Lot;
            data.UnitConfacPo = entity.Unit_Confac_Po;
            data.UnitConfacIssue = entity.Unit_Confac_Issue;
            data.BagQty = entity.Bag_Qty;
            data.BoxQty = entity.Box_Qty;
            data.SuppMatNo = entity.Supp_Mat_No;
            data.SuppMatNm = entity.Supp_Mat_Nm;
            data.UpdFlg = entity.Upd_Flg;
            data.Userid = entity.Userid;
            data.EntDt = entity.Ent_Dt?.ToUniversalTime().ToTimestamp();
            data.UpdDt = entity.Upd_Dt?.ToUniversalTime().ToTimestamp();
            data.StandardBoxLength = (double?)entity.Standard_Box_Length;
            data.StandardBoxWidth = (double?)entity.Standard_Box_Width;
            data.StandardBoxHeigh = (double?)entity.Standard_Box_Heigh;
            data.StandardPackFactor = entity.Standard_Pack_Factor;
            data.CopperWt = (double?)entity.Copper_Wt;
            data.CopperRate = (double?)entity.Copper_Rate;
            data.POPriceExcopper = (double?)entity.PO_Price_Excopper;
            data.InitialVolQty = (double?)entity.Initial_Vol_Qty;
            data.ReplaceMaterialNo = entity.Replace_Material_No;
            data.FullBoxWeight = (double?)entity.Full_Box_Weight;
            data.Active = entity.Active;
            data.Comments = entity.Comments;
            data.PRICETYPEDESC = entity.PRICETYPE_DESC;
            data.ExchangeRate = (double?)entity.ExchangeRate;
            data.ExchangeRateUpdDt = entity.ExchangeRate_Upd_Dt?.ToUniversalTime().ToTimestamp();
            return data;
        }
        #endregion

        #region HarnessCostingCalculationData
        public static HarnessCostingCalculationDataGrpc MapToHarnessCostingCalculationDataGrpc(this DbHarnessCostingCalculationDataView entity)
        {
            HarnessCostingCalculationDataGrpc data = new HarnessCostingCalculationDataGrpc();
            data.MaterialNo = entity.Material_No;
            data.SupplierC = entity.Supplier_C;
            data.PoUnit = entity.Po_Unit;
            data.IssueUnit = entity.Issue_Unit;
            data.BomUnit = entity.Bom_Unit;
            data.UnitConfacPo = entity.Unit_Confac_Po;
            data.UnitConfacIssue = entity.Unit_Confac_Issue;
            data.PoPrice = (double?)entity.Po_Price;
            data.CurrC = entity.Curr_C;
            data.PoRatio = entity.Po_Ratio;
            data.ExchangeRate = (double?)entity.ExchangeRate;
            data.ExchangeRateUpdDt = entity.ExchangeRate_Upd_Dt?.ToUniversalTime().ToTimestamp();
            return data;
        }
        #endregion
    }
}
