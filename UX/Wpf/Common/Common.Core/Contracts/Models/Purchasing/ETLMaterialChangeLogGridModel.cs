/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ETLMaterialChangeLogGridModel.cs
Function           :   Material Change Log
Created By         :   Shivam Dhingra
Created on         :   13-Jul-2020
Revision History   :   
                   :   
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
   /// <summary>
   /// Data contract for Material ChangeLog
   /// </summary>
    [DataContract, Serializable]
   
    public class ETLMaterialChangeLogGridModel : BaseModel<Guid>
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



        private string _bom_unit;
        [DataMember]
        public string bom_unit
        {
            get => _bom_unit;
            set => SetProperty(ref _bom_unit, value);
        }

        private string _pack_form;
        [DataMember]
        public string pack_form
        {
            get => _pack_form;
            set => SetProperty(ref _pack_form, value);
        }


        private decimal _cut_length;
        [DataMember]
        public decimal cut_length
        {
            get => _cut_length;
            set => SetProperty(ref _cut_length, value);
        }


        private decimal _unit_weight;
        [DataMember]
        public decimal unit_weight
        {
            get => _unit_weight;
            set => SetProperty(ref _unit_weight, value);
        }

        private string _remarks;
        [DataMember]
        public string remarks
        {
            get => _remarks;
            set => SetProperty(ref _remarks, value);
        }


        private string _commodity_nm;
        [DataMember]
        public string commodity_nm
        {
            get => _commodity_nm;
            set => SetProperty(ref _commodity_nm, value);
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

        private string _material_TpNm;
        [DataMember]
        public string material_TpNm
        {
            get => _material_TpNm;
            set => SetProperty(ref _material_TpNm, value);
        }

    }
}
