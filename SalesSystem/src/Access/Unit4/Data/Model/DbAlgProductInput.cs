namespace Unit4.Data.Model
{
    public class DbAlgProductInput : IAggregateRoot
    {
        public double Add_up
        { get; set; }
        public int Amount_set
        { get; set; }
        public string Apar_gr_id
        { get; set; } = string.Empty;
        public string Apar_id
        { get; set; } = string.Empty;
        public string Art_descr
        { get; set; } = string.Empty;
        public string Art_gr_id
        { get; set; } = string.Empty;
        public string Article
        { get; set; } = string.Empty;
        public string Asset_id
        { get; set; } = string.Empty;
        public string Batch_id
        { get; set; } = string.Empty;
        public int B_flag
        { get; set; }
        public int Bonus_type
        { get; set; }
        public string Client
        { get; set; } = string.Empty;
        public string Comp_article
        { get; set; } = string.Empty;
        public string Contract_ctr
        { get; set; } = string.Empty;
        public string Contract_id
        { get; set; } = string.Empty;
        public string Currency
        { get; set; } = string.Empty;
        public DateTime Date_col1
        { get; set; }
        public DateTime Date_col2
        { get; set; }
        public DateTime Date_col3
        { get; set; }
        public DateTime Date_col4
        { get; set; }
        public DateTime Date_from
        { get; set; }
        public int Date_limited
        { get; set; }
        public DateTime Date_to
        { get; set; }
        public int Deliv_day
        { get; set; }
        public string Description
        { get; set; } = string.Empty;
        public int Disc_type
        { get; set; }
        public string Ean
        { get; set; } = string.Empty;
        public int Fixed_contract
        { get; set; }
        public int Guarantee
        { get; set; }
        public string Image_source
        { get; set; } = string.Empty;
        public string Kit_type
        { get; set; } = string.Empty;
        public string Language
        { get; set; } = string.Empty;
        public int Line_no
        { get; set; }
        public string Location
        { get; set; } = string.Empty;
        public string Long_info
        { get; set; } = string.Empty;
        public int Lot_flag
        { get; set; }
        public double Max_level
        { get; set; }
        public string Message_text
        { get; set; } = string.Empty;
        public double Multiplier
        { get; set; }
        public string Nick_name
        { get; set; } = string.Empty;
        public string Old_rel_value
        { get; set; } = string.Empty;
        public double Order_level
        { get; set; }
        public double Order_val
        { get; set; }
        public double Overrun
        { get; set; }
        public string price_code
        { get; set; } = string.Empty;
        public string price_gr
        { get; set; } = string.Empty;
        public double purch_amt
        { get; set; }
        public double purch_price
        { get; set; }
        public string purch_rule
        { get; set; } = string.Empty;
        public string reference_1
        { get; set; } = string.Empty;
        public string rel_attr_id
        { get; set; } = string.Empty;
        public string rel_attr_id1
        { get; set; } = string.Empty;
        public string rel_attr_id2
        { get; set; } = string.Empty;
        public string rel_attr_id3
        { get; set; } = string.Empty;
        public string rel_attr_id4
        { get; set; } = string.Empty;
        public string rel_attr_id5
        { get; set; } = string.Empty;
        public string rel_value
        { get; set; } = string.Empty;
        public string rel_value1
        { get; set; } = string.Empty;
        public string rel_value2
        { get; set; } = string.Empty;
        public string rel_value3
        { get; set; } = string.Empty;
        public string rel_value4
        { get; set; } = string.Empty;
        public string rel_value5
        { get; set; } = string.Empty;
        public int rent_flag
        { get; set; }
        public double sales_amt
        { get; set; }
        public int serial_cat
        { get; set; }
        public int serial_flag
        { get; set; }
        public string serial_no
        { get; set; } = string.Empty;
        public string short_info
        { get; set; } = string.Empty;
        public string source_type
        { get; set; } = string.Empty;
        public string status
        { get; set; } = string.Empty;
        public int stock_flag
        { get; set; }
        public string sup_article
        { get; set; } = string.Empty;
        public string tax_code
        { get; set; } = string.Empty;
        public string text_type
        { get; set; } = string.Empty;
        public string text1
        { get; set; } = string.Empty;
        public string text2
        { get; set; } = string.Empty;
        public string text3
        { get; set; } = string.Empty;
        public string text4
        { get; set; } = string.Empty;
        public string trans_type
        { get; set; } = string.Empty;
        public string unit_code
        { get; set; } = string.Empty;
        public string unit_descr
        { get; set; } = string.Empty;
        public double unit_value
        { get; set; }
        public int update_flag
        { get; set; }
        public double value_1
        { get; set; }
        public double value_from
        { get; set; }
        public double value_to
        { get; set; }
        public double value1
        { get; set; }
        public double value2
        { get; set; }
        public double value3
        { get; set; }
        public double value4
        { get; set; }
        public double volume
        { get; set; }
        public string warehouse
        { get; set; } = string.Empty;
        public double weight
        { get; set; }

        public long agrtid
        { get; set; }
        public int external_flag
        { get; set; }
        public int info_flag
        { get; set; }
        public double min_order_qty
        { get; set; }
        public double order_qty_inc
        { get; set; }
        public int product_rank
        { get; set; }
        public int public_product
        { get; set; }
    }
}
