/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ETLMaterialSiteChangeLogGridModel.cs
Function           :   Material Site Change Log 
Created By         :   Shivam Dhingra
Created on         :   13-Jul-2020
Revision History   :   [16-Jul-2020] : Shivam Dhingra
*                  :   Corrected FieldName to upd_date
*                  :   [17-May-2022] : Dharmendra Kumar
*                  :   Change data tyep byte to Int16 for order_ltime and trans_time
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
   public class ETLMaterialSiteChangeLogGridModel : BaseModel<Guid>
    {
        private string _section_c;
        [DataMember]
        public string section_c
        {
            get => _section_c;
            set => SetProperty(ref _section_c, value);
        }

        private string _section_nm;
        [DataMember]
        public string section_nm
        {
            get => _section_nm;
            set => SetProperty(ref _section_nm, value);
        }

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

        private string _supplier_c;
        [DataMember]
        public string supplier_c
        {
            get => _supplier_c;
            set => SetProperty(ref _supplier_c, value);
        }


        private byte _po_ratio;
        [DataMember]
        public byte po_ratio
        {
            get => _po_ratio;
            set => SetProperty(ref _po_ratio, value);
        }



        private Int16 _order_ltime;
        [DataMember]
        public Int16 order_ltime
        {
            get => _order_ltime;
            set => SetProperty(ref _order_ltime, value);
        }


        private Int16 _trans_time;
        [DataMember]
        public Int16 trans_time
        {
            get => _trans_time;
            set => SetProperty(ref _trans_time, value);
        }


        private decimal _std_cost;
        [DataMember]
        public decimal std_cost
        {
            get => _std_cost;
            set => SetProperty(ref _std_cost, value);
        }

        private string _mrp_flg;
        [DataMember]
        public string mrp_flg
        {
            get => _mrp_flg;
            set => SetProperty(ref _mrp_flg, value);
        }

        private string _kit_issue_flg;
        [DataMember]
        public string kit_issue_flg
        {
            get => _kit_issue_flg;
            set => SetProperty(ref _kit_issue_flg, value);
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

        private DateTime _upd_date;
        [DataMember]
        public DateTime upd_date
        {
            get => _upd_date;
            set => SetProperty(ref _upd_date, value);
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
