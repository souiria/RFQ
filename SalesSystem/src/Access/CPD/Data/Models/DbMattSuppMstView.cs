namespace CPD.Data.Models
{
    public class DbMattSuppMstView : IAggregateRoot
    {
        public string? Material_No
        { get; set; }
        public string? Supplier_C
        { get; set; }
        public string? Po_Unit
        { get; set; }
        public int? Po_Minord_Qty
        { get; set; }
        public decimal? Po_Price
        { get; set; }
        public byte? Po_Ratio
        { get; set; }
        public short? Order_LTime
        { get; set; }
        public string? Issue_Unit
        { get; set; }
        public int? Issue_Min_Lot
        { get; set; }
        public int? Unit_Confac_Po
        { get; set; }
        public int? Unit_Confac_Issue
        { get; set; }
        public int? Bag_Qty
        { get; set; }
        public int? Box_Qty
        { get; set; }
        public string? Supp_Mat_No
        { get; set; }
        public string? Supp_Mat_Nm
        { get; set; }
        public string? Upd_Flg
        { get; set; }
        public string? Userid
        { get; set; }
        public DateTime? Ent_Dt
        { get; set; }
        public DateTime? Upd_Dt
        { get; set; }
        public decimal? Standard_Box_Length
        { get; set; }
        public decimal? Standard_Box_Width
        { get; set; }
        public decimal? Standard_Box_Heigh
        { get; set; }
        public int? Standard_Pack_Factor
        { get; set; }
        public decimal? Copper_Wt
        { get; set; }
        public decimal? Copper_Rate
        { get; set; }
        public decimal? PO_Price_Excopper
        { get; set; }
        public decimal? Initial_Vol_Qty
        { get; set; }
        public string? Replace_Material_No
        { get; set; }
        public decimal? Full_Box_Weight
        { get; set; }
        public string? Active
        { get; set; }
        public string? Comments
        { get; set; }
        public string? PRICETYPE_DESC
        { get; set; }
        public decimal? ExchangeRate
        { get; set; }
        public DateTime? ExchangeRate_Upd_Dt
        { get; set; }
    }
}
