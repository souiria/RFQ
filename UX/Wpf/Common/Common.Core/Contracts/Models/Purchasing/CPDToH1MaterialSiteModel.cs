using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class CPDToH1MaterialSiteModel : ExternalDataSourceModel<object>
    {

        private string _section_c;
        [DataMember]
        public string section_c
        {
            get => _section_c;
            set => SetProperty(ref _section_c, value);
        }

        private string _material_no;
        [DataMember]

        public string material_no
        {
            get => _material_no;
            set => SetProperty(ref _material_no, value);
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

        private Int16 _trans_ltime;
        [DataMember]
        public Int16 trans_ltime
        {
            get => _trans_ltime;
            set => SetProperty(ref _trans_ltime, value);
        }
        private Int16 _order_ltime;
        [DataMember]
        public Int16 order_ltime
        {
            get => _order_ltime;
            set => SetProperty(ref _order_ltime, value);
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
        private string _upd_flg;
        [DataMember]
        public string upd_flg
        {
            get => _upd_flg;
            set => SetProperty(ref _upd_flg, value);
        }

        private string _userid;
        [DataMember]
        public string userid
        {
            get => _userid;
            set => SetProperty(ref _userid, value);
        }

    }
}
