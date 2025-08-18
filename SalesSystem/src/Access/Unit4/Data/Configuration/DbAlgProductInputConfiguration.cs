namespace Unit4.Data.Configuration
{
    class DbAlgProductInputConfiguration : IEntityTypeConfiguration<DbAlgProductInput>
    {
        public void Configure(EntityTypeBuilder<DbAlgProductInput> builder)
        {
            ((EntityTypeBuilder)builder).ToTable("algproductinput");
            builder.HasKey(x => x.agrtid);
            builder.Property(x => x.Add_up).HasColumnName("add_up").HasColumnType("decimal(28, 8)");
            builder.Property(x => x.Amount_set).HasColumnName("amount_set");
            builder.Property(x => x.Apar_gr_id).HasColumnName("apar_gr_id");
            builder.Property(x => x.Apar_id).HasColumnName("apar_id");
            builder.Property(x => x.Art_descr).HasColumnName("art_descr");
            builder.Property(x => x.Art_gr_id).HasColumnName("art_gr_id");
            builder.Property(x => x.Article).HasColumnName("article");
            builder.Property(x => x.Asset_id).HasColumnName("asset_id");
            builder.Property(x => x.Batch_id).HasColumnName("batch_id");
            builder.Property(x => x.B_flag).HasColumnName("bflag");
            builder.Property(x => x.Bonus_type).HasColumnName("bonus_type");
            builder.Property(x => x.Client).HasColumnName("client");
            builder.Property(x => x.Comp_article).HasColumnName("comp_article");
            builder.Property(x => x.Contract_ctr).HasColumnName("contract_ctr");
            builder.Property(x => x.Contract_id).HasColumnName("contract_id");
            builder.Property(x => x.Currency).HasColumnName("currency");
            builder.Property(x => x.Date_col1).HasColumnName("date_col1");
            builder.Property(x => x.Date_col2).HasColumnName("date_col2");
            builder.Property(x => x.Date_col3).HasColumnName("date_col3");
            builder.Property(x => x.Date_col4).HasColumnName("date_col4");
            builder.Property(x => x.Date_from).HasColumnName("date_from");
            builder.Property(x => x.Date_limited).HasColumnName("date_limitted");
            builder.Property(x => x.Date_to).HasColumnName("date_to");
            builder.Property(x => x.Deliv_day).HasColumnName("deliv_day");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.Disc_type).HasColumnName("disc_type");
            builder.Property(x => x.Ean).HasColumnName("ean");
            builder.Property(x => x.Fixed_contract).HasColumnName("fixed_contract");
            builder.Property(x => x.Guarantee).HasColumnName("guarantee");
            builder.Property(x => x.Image_source).HasColumnName("image_source");
            builder.Property(x => x.Kit_type).HasColumnName("kit_type");
            builder.Property(x => x.Language).HasColumnName("language");
            builder.Property(x => x.Line_no).HasColumnName("line_no");
            builder.Property(x => x.Location).HasColumnName("location");
            builder.Property(x => x.Long_info).HasColumnName("long_info");
            builder.Property(x => x.Lot_flag).HasColumnName("lot_flag");
            builder.Property(x => x.Max_level).HasColumnName("max_level").HasColumnType("decimal(28, 8)");
            builder.Property(x => x.Message_text).HasColumnName("message_text");
            builder.Property(x => x.Multiplier).HasColumnName("multiplier").HasColumnType("decimal(28, 8)");
            builder.Property(x => x.Nick_name).HasColumnName("nick_name");
            builder.Property(x => x.Old_rel_value).HasColumnName("old_rel_value");
            builder.Property(x => x.Order_level).HasColumnName("order_level").HasColumnType("decimal(28, 8)");
            builder.Property(x => x.Order_val).HasColumnName("order_val").HasColumnType("decimal(28, 8)");
            builder.Property(x => x.Overrun).HasColumnName("overrun").HasColumnType("decimal(28, 8)");
            builder.Property(x => x.Amount_set).HasColumnName("amount_set");
            builder.Property(x => x.Amount_set).HasColumnName("amount_set");
            builder.Property(x => x.Amount_set).HasColumnName("amount_set");
            builder.Property(x => x.Amount_set).HasColumnName("amount_set");
            builder.Property(x => x.Amount_set).HasColumnName("amount_set");
            builder.Property(x => x.Amount_set).HasColumnName("amount_set");
            builder.Property(x => x.Amount_set).HasColumnName("amount_set");
            builder.Property(x => x.Amount_set).HasColumnName("amount_set");
            builder.Property(x => x.Amount_set).HasColumnName("amount_set");



            
            builder.Property(x => x.purch_amt).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.purch_price).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.sales_amt).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.unit_value).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.value_1).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.value_from).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.value_to).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.value1).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.value2).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.value3).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.value4).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.volume).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.weight).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.min_order_qty).HasColumnType("decimal(28, 8)");
            builder.Property(x => x.order_qty_inc).HasColumnType("decimal(28, 8)");
        }
    }
}
