using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class DHSConsolidatedMRPErrorListProcedureModel : ExternalDataSourceModel<object>
    {
        private string _section_c;
        [DataMember]
        public string section_c
        {
            get => _section_c;
            set => SetProperty(ref _section_c, value);
        }
        private string _supplier_c;
        [DataMember]
        public string supplier_c
        {
            get => _supplier_c;
            set => SetProperty(ref _supplier_c, value);
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
        private string _bom_unit;
        [DataMember]
        public string bom_unit
        {
            get => _bom_unit;
            set => SetProperty(ref _bom_unit, value);
        }
        private int _reqd_qty;
        [DataMember]
        public int reqd_qty
        {
            get => _reqd_qty;
            set => SetProperty(ref _reqd_qty, value);
        }
        private string _message1;
        [DataMember]
        public string message1
        {
            get => _message1;
            set => SetProperty(ref _message1, value);
        }

        private string _upd;
        [DataMember]
        public string Upd
        {
            get => _upd;
            set => SetProperty(ref _upd, value);
        }

        private DateTime _fromDate;
        [DataMember]
        public DateTime Fr_Date
        {
            get => _fromDate;
            set => _fromDate = value;
        }
        private DateTime _dateTo;
        [DataMember]
        public DateTime To_Date
        {
            get => _dateTo;
            set => _dateTo = value;
        }

      
        private string _option;
        [DataMember]
        public string Option
        {
            get => _option;
            set => _option = value;
        }
       
    }
}
