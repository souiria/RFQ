using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class CPDSupplierCapacityPlanningProcedureModel : ExternalDataSourceModel<object>
    {
        private string _SUPPLIER_C;
        [DataMember]
        public string SUPPLIER_C
        {
            get => _SUPPLIER_C;
            set => SetProperty(ref _SUPPLIER_C, value);
        }
        private string _MATERIAL_NO;
        [DataMember]
        public string MATERIAL_NO
        {
            get => _MATERIAL_NO;
            set => SetProperty(ref _MATERIAL_NO, value);
        }
        private string _UOM;
        [DataMember]
        public string UOM
        {
            get => _UOM;
            set => SetProperty(ref _UOM, value);
        }
        private string _SECTION_DETAIL;
        [DataMember]
        public string SECTION_DETAIL
        {
            get => _SECTION_DETAIL;
            set => SetProperty(ref _SECTION_DETAIL, value);
        }
        private decimal _TOTAL_DETAIL;
        [DataMember]
        [DecimalPrecision(15, 0)]
        public decimal TOTAL_DETAIL
        {
            get => _TOTAL_DETAIL;
            set => SetProperty(ref _TOTAL_DETAIL, value);
        }
        #region Months Forecast

        private decimal _MON1;
        [DataMember]
        public decimal MON1
        {
            get => _MON1;
            set => SetProperty(ref _MON1, value);
        }
        private decimal _MON2;
        [DataMember]
        public decimal MON2
        {
            get => _MON2;
            set => SetProperty(ref _MON2, value);
        }
        private decimal _MON3;
        [DataMember]
        public decimal MON3
        {
            get => _MON3;
            set => SetProperty(ref _MON3, value);
        }
        private decimal _MON4;
        [DataMember]
        public decimal MON4
        {
            get => _MON4;
            set => SetProperty(ref _MON4, value);
        }
        private decimal _MON5;
        [DataMember]
        public decimal MON5
        {
            get => _MON5;
            set => SetProperty(ref _MON5, value);
        }
        private decimal _MON6;
        [DataMember]
        public decimal MON6
        {
            get => _MON6;
            set => SetProperty(ref _MON6, value);
        }
        private decimal _MON7;
        [DataMember]
        public decimal MON7
        {
            get => _MON7;
            set => SetProperty(ref _MON7, value);
        }
        private decimal _MON8;
        [DataMember]
        public decimal MON8
        {
            get => _MON8;
            set => SetProperty(ref _MON8, value);
        }
        private decimal _MON9;
        [DataMember]
        public decimal MON9
        {
            get => _MON9;
            set => SetProperty(ref _MON9, value);
        }
        private decimal _MON10;
        [DataMember]
        public decimal MON10
        {
            get => _MON10;
            set => SetProperty(ref _MON10, value);
        }
        private decimal _MON11;
        [DataMember]
        public decimal MON11
        {
            get => _MON11;
            set => SetProperty(ref _MON11, value);
        }
        private decimal _MON12;
        [DataMember]
        public decimal MON12
        {
            get => _MON12;
            set => SetProperty(ref _MON12, value);
        }
        private decimal _MON13;
        [DataMember]
        public decimal MON13
        {
            get => _MON13;
            set => SetProperty(ref _MON13, value);
        }
        private decimal _MON14;
        [DataMember]
        public decimal MON14
        {
            get => _MON14;
            set => SetProperty(ref _MON14, value);
        }
        private decimal _MON15;
        [DataMember]
        public decimal MON15
        {
            get => _MON15;
            set => SetProperty(ref _MON15, value);
        }
        private decimal _MON16;
        [DataMember]
        public decimal MON16
        {
            get => _MON16;
            set => SetProperty(ref _MON16, value);
        }
        private decimal _MON17;
        [DataMember]
        public decimal MON17
        {
            get => _MON17;
            set => SetProperty(ref _MON17, value);
        }

        private decimal _MON18;
        [DataMember]
        public decimal MON18
        {
            get => _MON18;
            set => SetProperty(ref _MON18, value);
        }
        #endregion
       
        private int _ROWID;
        [DataMember]
        public int ROWID
        {
            get => _ROWID;
            set => SetProperty(ref _ROWID, value);
        }
        private DateTime _FCSTARTDATE;
        [DataMember]
        public DateTime FCSTARTDATE
        {
            get => _FCSTARTDATE;
            set => SetProperty(ref _FCSTARTDATE, value);
        }

        private DateTime _FCENDDATE;
        [DataMember]
        public DateTime FCENDDATE
        {
            get => _FCENDDATE;
            set => SetProperty(ref _FCENDDATE, value);
        }

        private string _CUSTOMER_NM;
        [DataMember]
        public string CUSTOMER_NM
        {
            get => _CUSTOMER_NM;
            set => SetProperty(ref _CUSTOMER_NM, value);
        }
        private string _VEHICLE_NM;
        [DataMember]
        public string VEHICLE_NM
        {
            get => _VEHICLE_NM;
            set => SetProperty(ref _VEHICLE_NM, value);
        }
        private string _FACILITY_NM;
        [DataMember]
        public string FACILITY_NM
        {
            get => _FACILITY_NM;
            set => SetProperty(ref _FACILITY_NM, value);
        }

    }
}
