using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class MaterialDataSynchronizationModel : BaseModel<Guid>
    {
        private string _material_no;
        [DataMember]
        public string material_no
        {
            get => _material_no;
            set => _material_no = value;
        }
        private string _material_nm;
        [DataMember]
        public string material_nm
        {
            get => _material_nm;
            set => _material_nm = value;
        }

        private string _material_tp;
        [DataMember]
        public string material_tp
        {
            get => _material_tp;
            set => _material_tp = value;
        }

        private string _bom_unit;
        [DataMember]
        public string bom_unit
        {
            get => _bom_unit;
            set => _bom_unit = value;
        }

        private string _supplier_c;
        [DataMember]
        public string supplier_c
        {
            get => _supplier_c;
            set => _supplier_c = value;
        }

        private string _po_unit;
        [DataMember]
        public string po_unit
        {
            get => _po_unit;
            set => _po_unit = value;
        }

        private int _po_minord_qty;
        [DataMember]
        public int po_minord_qty
        {
            get => _po_minord_qty;
            set => _po_minord_qty = value;
        }
        private decimal _po_price;
        [DataMember]
        [DecimalPrecision(13, 5)]
        public decimal po_price
        {
            get => _po_price;
            set => _po_price = value;
        }
        private Int16 _order_ltime;
        [DataMember]
        public Int16 order_ltime
        {
            get => _order_ltime;
            set => _order_ltime = value;
        }
        private int _unit_confac_po;
        [DataMember]
        public int unit_confac_po
        {
            get => _unit_confac_po;
            set => _unit_confac_po = value;
        }
        private string _supp_mat_no;
        [DataMember]
        public string supp_mat_no
        {
            get => _supp_mat_no;
            set => _supp_mat_no = value;
        }
        private string _tariff_c;
        [DataMember]
        public string tariff_c
        {
            get => _tariff_c;
            set => _tariff_c = value;
        }
        private string _origin_country_c;
        [DataMember]
        public string origin_country_c
        {
            get => _origin_country_c;
            set => _origin_country_c = value;
        }

        private string _origin_status;
        [DataMember]
        public string origin_status
        {
            get => _origin_status;
            set => _origin_status = value;
        }

        private DateTime _expiry_dt;
        [DataMember]
        public DateTime expiry_dt
        {
            get => _expiry_dt;
            set => _expiry_dt = value;
        }

        private string _rmks;
        [DataMember]
        public string rmks
        {
            get => _rmks;
            set => _rmks = value;
        }
        private string _section_c;
        [DataMember]
        public string section_c
        {
            get => _section_c;
            set => _section_c = value;
        }

        private int _bag_qty;

        [DataMember]
        public int bag_qty
        {
            get => _bag_qty;
            set => _bag_qty = value;
        }

        private decimal _copper_wt;
        [DataMember]
        public decimal copper_wt
        {
            get => _copper_wt;
            set => _copper_wt = value;
        }

        private decimal _initial_vol_qty = 1;
        [DataMember]
        public decimal initial_vol_qty
        {
            get => _initial_vol_qty;
            set => _initial_vol_qty = value;
        }

        private string _Replace_material_no= "Replace material number";
        [DataMember]
        public string Replace_material_no
        {
            get => _Replace_material_no;
            set => _Replace_material_no = value;
        }

        private decimal _Copper_rate = 0;
        [DataMember]
        [DecimalPrecision(16, 6)]
        public decimal Copper_rate
        {
            get => _Copper_rate;
            set => _Copper_rate = value;
        }

        private decimal _Standard_box_length = 1;
        [DataMember]
        [DecimalPrecision(5, 3)]
        public decimal Standard_box_length
        {
            get => _Standard_box_length;
            set => _Standard_box_length = value;
        }

        private decimal _Standard_box_heigh=1;
        [DataMember]
        [DecimalPrecision(5, 3)]
        public decimal Standard_box_heigh
        {
            get => _Standard_box_heigh;
            set => _Standard_box_heigh = value;
        }
        private decimal _Standard_box_width=1;
        [DataMember]
        [DecimalPrecision(5,3)]
        public decimal Standard_box_width
        {
            get => _Standard_box_width;
            set => _Standard_box_width = value;
        }
        private int _Standard_pack_factor;
        [DataMember]
        public int Standard_pack_factor
        {
            get => _Standard_pack_factor;
            set => _Standard_pack_factor = value;
        }

        private decimal _full_box_weight = 0;
        [DataMember]
        [DecimalPrecision(6, 2)]
        public decimal full_box_weight
        {
            get => _full_box_weight = 0;
            set => _full_box_weight = value;
        }
    }
}
