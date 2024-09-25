namespace Edi.DataProcessor.Access.Data.Models;

public class DbAlgBatchInput : IAggregateRoot
{
    public string account { get; set; } = string.Empty;
    public string accountable { get; set; } = string.Empty;
    public string address { get; set; } = string.Empty;
    public int allocation_key { get; set; }
    public double amount { get; set; }
    public int amount_set { get; set; }
    public string apar_id { get; set; } = string.Empty;
    public string apar_id_ref { get; set; } = string.Empty;
    public string apar_name { get; set; } = string.Empty;
    public string art_descr { get; set; } = string.Empty;
    public string article { get; set; } = string.Empty;
    public string att_1_id { get; set; } = string.Empty;
    public string att_2_id { get; set; } = string.Empty;
    public string att_3_id { get; set; } = string.Empty;
    public string att_4_id { get; set; } = string.Empty;
    public string att_5_id { get; set; } = string.Empty;
    public string att_6_id { get; set; } = string.Empty;
    public string att_7_id { get; set; } = string.Empty;
    public string bank_account { get; set; } = string.Empty;
    public string batch_id { get; set; } = string.Empty;
    public string client { get; set; } = string.Empty;
    public string client_ref { get; set; } = string.Empty;
    public string confirm_date { get; set; } = string.Empty;
    public string control { get; set; } = string.Empty;
    public double cur_amount { get; set; }
    public string currency { get; set; } = string.Empty;
    public string del_met_descr { get; set; } = string.Empty;
    public string del_term_descr { get; set; } = string.Empty;
    public string deliv_addr { get; set; } = string.Empty;
    public string deliv_attention { get; set; } = string.Empty;
    public string deliv_countr { get; set; } = string.Empty;
    public DateTime deliv_date { get; set; } = new DateTime(1900, 01, 01);
    public string deliv_method { get; set; } = string.Empty;
    public string deliv_terms { get; set; } = string.Empty;
    public string delivery_descr { get; set; } = string.Empty;
    public string dim_1 { get; set; } = string.Empty;
    public string dim_2 { get; set; } = string.Empty;
    public string dim_3 { get; set; } = string.Empty;
    public string dim_4 { get; set; } = string.Empty;
    public string dim_5 { get; set; } = string.Empty;
    public string dim_6 { get; set; } = string.Empty;
    public string dim_7 { get; set; } = string.Empty;
    public string dim_value_1 { get; set; } = string.Empty;
    public string dim_value_2 { get; set; } = string.Empty;
    public string dim_value_3 { get; set; } = string.Empty;
    public string dim_value_4 { get; set; } = string.Empty;
    public string dim_value_5 { get; set; } = string.Empty;
    public string dim_value_6 { get; set; } = string.Empty;
    public string dim_value_7 { get; set; } = string.Empty;
    public double disc_percent { get; set; }
    public double discount { get; set; }
    public string ean { get; set; } = string.Empty;
    public double exch_rate { get; set; }
    public string ext_ord_ref { get; set; } = string.Empty;
    public string intrule_id { get; set; } = string.Empty;
    public int line_no { get; set; }
    public string location { get; set; } = string.Empty;
    public string long_info1 { get; set; } = string.Empty;
    public string long_info2 { get; set; } = string.Empty;
    public string lot { get; set; } = string.Empty;
    public string main_apar_id { get; set; } = string.Empty;
    public string mark_attention { get; set; } = string.Empty;
    public string markings { get; set; } = string.Empty;
    public DateTime obs_date { get; set; } = new DateTime(1900, 01, 01);
    public DateTime order_date { get; set; } = new DateTime(1900, 01, 01);
    public long order_id { get; set; }
    public string order_type { get; set; } = string.Empty;
    public string pay_method { get; set; } = string.Empty;
    public string pay_temp_id { get; set; } = string.Empty;
    public int period { get; set; }
    public string place { get; set; } = string.Empty;
    public string province { get; set; } = string.Empty;
    public string rel_value { get; set; } = string.Empty;
    public int rent_flag { get; set; }
    public string responsible { get; set; } = string.Empty;
    public string responsible2 { get; set; } = string.Empty;
    public int sequence_no { get; set; }
    public int sequence_ref { get; set; }
    public string serial_no { get; set; } = string.Empty;
    public string short_info { get; set; } = string.Empty;
    public string status { get; set; } = string.Empty;
    public string sup_article { get; set; } = string.Empty;
    public string tax_code { get; set; } = string.Empty;
    public string tax_system { get; set; } = string.Empty;
    public int template_id { get; set; }
    public string terms_id { get; set; } = string.Empty;
    public string text1 { get; set; } = string.Empty;
    public string text2 { get; set; } = string.Empty;
    public string text3 { get; set; } = string.Empty;
    public string text4 { get; set; } = string.Empty;
    public string trans_type { get; set; } = string.Empty;
    public string unit_code { get; set; } = string.Empty;
    public string unit_descr { get; set; } = string.Empty;
    public double unit_price { get; set; }
    public double value_1 { get; set; }
    public long voucher_ref { get; set; }
    public string voucher_type { get; set; } = string.Empty;
    public string warehouse { get; set; } = string.Empty;
    public string zip_code { get; set; } = string.Empty;

    public long agrtid { get; set; }
    public string clearing_code { get; set; } = string.Empty;
    public string ext_order_id { get; set; } = string.Empty;
    public string swift { get; set; } = string.Empty;
    public string vat_reg_no { get; set; } = string.Empty;
    public string contract_id { get; set; } = string.Empty;
    public string terms_descr { get; set; } = string.Empty;
    public string wf_state { get; set; } = string.Empty;
    public DateTime det_deliv_date { get; set; } = new DateTime(1900, 01, 01);
}
