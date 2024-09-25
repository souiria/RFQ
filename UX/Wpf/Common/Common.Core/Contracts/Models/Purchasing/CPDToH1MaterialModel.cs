using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class CPDToH1MaterialModel : ExternalDataSourceModel<object>
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
        private decimal ? _cut_length;
        [DataMember]
        public decimal ? cut_length
        {
            get => _cut_length;
            set => SetProperty(ref _cut_length, value);
        }

        private string _commodity_nm;
        [DataMember]
        public string commodity_nm
        {
            get => _commodity_nm;
            set => SetProperty(ref _commodity_nm, value);
        }        

        private string _upd_flg;
        [DataMember]
        public string upd_flg
        {
            get => _upd_flg;
            set => SetProperty(ref _upd_flg, value);
        }       

        private DateTime _ent_dt;
        [DataMember]
        public DateTime ent_dt
        {
            get => _ent_dt;
            set => SetProperty(ref _ent_dt, value);
        }
        private DateTime _upd_dt;
        [DataMember]
        public DateTime upd_dt
        {
            get => _upd_dt;
            set => SetProperty(ref _upd_dt, value);
        }
        private string _userid;
        [DataMember]
        public string userid
        {
            get => _userid;
            set => SetProperty(ref _userid, value);
        }

        private decimal _unit_weight;
        [DataMember]
        public decimal unit_weight
        {
            get => _unit_weight;
            set => SetProperty(ref _unit_weight, value);
        }

    }
}
