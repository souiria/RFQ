/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierMaterialChangeLogGridModel.cs
Function           :   Supplier Material Change Log
Created By         :   Shivam Dhingra
Created on         :   13-Jul-2020
Revision History   :  [17-May-2022] : Dharmendra Kumar
*                  :   Change data tyep byte to Int16 for order_ltime 
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
   public class ETLSupplierMaterialChangeLogGridModel : BaseModel<Guid>
    {
        private string _material_no;
        [DataMember]
        public string material_no
        {
            get => _material_no;
            set => SetProperty(ref _material_no, value);
        }

        private string _material_nm;
        [DataMember]
        public string material_nm
        {
            get => _material_nm;
            set => SetProperty(ref _material_nm, value);
        }


        private string _material_tp;
        [DataMember]
        public string material_tp
        {
            get => _material_tp;
            set => SetProperty(ref _material_tp, value);
        }

        private string _supplier_c;
        [DataMember]
        public string supplier_c
        {
            get => _supplier_c;
            set => SetProperty(ref _supplier_c, value);
        }

        private string _supp_mat_no;
        [DataMember]
        public string supp_mat_no
        {
            get => _supp_mat_no;
            set => SetProperty(ref _supp_mat_no, value);
        }

        private string _supp_mat_nm;
        [DataMember]
        public string supp_mat_nm
        {
            get => _supp_mat_nm;
            set => SetProperty(ref _supp_mat_nm, value);
        }

        private byte _po_ratio;
        [DataMember]
        public byte po_ratio
        {
            get => _po_ratio;
            set => SetProperty(ref _po_ratio, value);
        }


        private string _po_unit;
        [DataMember]
        public string po_unit
        {
            get => _po_unit;
            set => SetProperty(ref _po_unit, value);
        }


        private int _po_minord_qty;
        [DataMember]
        public int po_minord_qty
        {
            get => _po_minord_qty;
            set => SetProperty(ref _po_minord_qty, value);
        }


        private decimal _po_price;
        [DataMember]
        public decimal po_price
        {
            get => _po_price;
            set => SetProperty(ref _po_price, value);
        }


        private int _unit_confac_po;
        [DataMember]
        public int unit_confac_po
        {
            get => _unit_confac_po;
            set => SetProperty(ref _unit_confac_po, value);
        }


        private string _issue_unit;
        [DataMember]
        public string issue_unit
        {
            get => _issue_unit;
            set => SetProperty(ref _issue_unit, value);
        }

        private int _unit_confac_issue;
        [DataMember]
        public int unit_confac_issue
        {
            get => _unit_confac_issue;
            set => SetProperty(ref _unit_confac_issue, value);
        }

        private int _bag_qty;
        [DataMember]
        public int bag_qty
        {
            get => _bag_qty;
            set => SetProperty(ref _bag_qty, value);
        }

        private decimal _standard_box_length_in_meter;
        [DataMember]
        public decimal standard_box_length_in_meter
        {
            get => _standard_box_length_in_meter;
            set => SetProperty(ref _standard_box_length_in_meter, value);
        }


        private decimal _standard_box_width_in_meter;
        [DataMember]
        public decimal standard_box_width_in_meter
        {
            get => _standard_box_width_in_meter;
            set => SetProperty(ref _standard_box_width_in_meter, value);
        }

        private decimal _standard_box_heigh_in_meter;
        [DataMember]
        public decimal standard_box_heigh_in_meter
        {
            get => _standard_box_heigh_in_meter;
            set => SetProperty(ref _standard_box_heigh_in_meter, value);
        }


        private int _standard_pack_factor;
        [DataMember]
        public int standard_pack_factor
        {
            get => _standard_pack_factor;
            set => SetProperty(ref _standard_pack_factor, value);
        }

        private decimal _full_box_weight_in_kg;
        [DataMember]
        public decimal full_box_weight_in_kg
        {
            get => _full_box_weight_in_kg;
            set => SetProperty(ref _full_box_weight_in_kg, value);
        }


        private decimal _copper_wt_in_kg;
        [DataMember]
        public decimal copper_wt_in_kg
        {
            get => _copper_wt_in_kg;
            set => SetProperty(ref _copper_wt_in_kg, value);
        }

        private decimal _copper_rate;
        [DataMember]
        public decimal copper_rate
        {
            get => _copper_rate;
            set => SetProperty(ref _copper_rate, value);
        }


        private decimal _po_price_excopper;
        [DataMember]
        public decimal po_price_excopper
        {
            get => _po_price_excopper;
            set => SetProperty(ref _po_price_excopper, value);
        }


        private string _material_TpNm;
        [DataMember]
        public string material_TpNm
        {
            get => _material_TpNm;
            set => SetProperty(ref _material_TpNm, value);
        }


        private string _mode;
        [DataMember]
        public string mode
        {
            get => _mode;
            set => SetProperty(ref _mode, value);
        }

        private string _userid;
        [DataMember]
        public string userid
        {
            get => _userid;
            set => SetProperty(ref _userid, value);
        }

        private DateTime _create_date;
        [DataMember]
        public DateTime create_date
        {
            get => _create_date;
            set => SetProperty(ref _create_date, value);
        }

        private DateTime _update_date;
        [DataMember]
        public DateTime update_date
        {
            get => _update_date;
            set => SetProperty(ref _update_date, value);
        }


        private Int16 _order_ltime;
        [DataMember]
        public Int16 order_ltime
        {
            get => _order_ltime;
            set => SetProperty(ref _order_ltime, value);
        }


        private int _issue_min_lot;
        [DataMember]
        public int issue_min_lot
        {
            get => _issue_min_lot;
            set => SetProperty(ref _issue_min_lot, value);
        }


        private int _box_qty;
        [DataMember]
        public int box_qty
        {
            get => _box_qty;
            set => SetProperty(ref _box_qty, value);
        }




        private decimal _initial_vol_qty;
        [DataMember]
        public decimal initial_vol_qty
        {
            get => _initial_vol_qty;
            set => SetProperty(ref _initial_vol_qty, value);
        }


        private string _replace_material_no;
        [DataMember]
        public string replace_material_no
        {
            get => _replace_material_no;
            set => SetProperty(ref _replace_material_no, value);
        }

        private string _Active;
        [DataMember]
        public string Active
        {
            get => _Active;
            set => SetProperty(ref _Active, value);
        }

        private string _comments;
        [DataMember]
        public string Comments
        {
            get => _comments;
            set => SetProperty(ref _comments, value);
        }





    }
}
