using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ETLSupplierCapacityPlanningGridModel : BaseModel<Guid>
    {
        private string _supplierCode;
        [DataMember]
        public string SupplierCode
        {
            get =>_supplierCode;
            set => SetProperty(ref _supplierCode, value);
        }
        private string _businessUnitCode;
        [DataMember]
        public string BusinessUnitCode
        {
            get =>_businessUnitCode;
            set => SetProperty(ref _businessUnitCode, value);
        }
        private string _materialNumber;
        [DataMember]
        public string MaterialNumber
        {
            get =>_materialNumber;
            set => SetProperty(ref _materialNumber, value);
        }
        private string _unitOfMeasure;
        [DataMember]
        public string UnitOfMeasure
        {
            get =>_unitOfMeasure;
            set => SetProperty(ref _unitOfMeasure, value);
        }
        private string _customerName;
        [DataMember]
        public string CustomerName
        {
            get =>_customerName;
            set => SetProperty(ref _customerName, value);
        }
        private string _vehicleName;
        [DataMember]
        public string VehicleName
        {
            get =>_vehicleName;
            set => SetProperty(ref _vehicleName, value);
        }
        private string _facilityName;
        [DataMember]
        public string FacilityName
        {
            get =>_facilityName;
            set => SetProperty(ref _facilityName, value);
        }

        private decimal _total_forecastAnnualQuanity;
        [DataMember]
        [DecimalPrecision(15, 0)]
        public decimal Total_ForecastAnnualQuanity
        {
            get =>_total_forecastAnnualQuanity;
            set => SetProperty(ref _total_forecastAnnualQuanity, value);
        }
        #region Year 1
        private decimal _y01_M01;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M01_ForecastAnnualQuanity
        {
            get =>_y01_M01;
            set => SetProperty(ref _y01_M01, value);
        }
        private decimal _y01_M02;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M02_ForecastAnnualQuanity
        {
            get =>_y01_M02;
            set => SetProperty(ref _y01_M02, value);
        }
        private decimal _y01_M03;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M03_ForecastAnnualQuanity
        {
            get =>_y01_M03;
            set => SetProperty(ref _y01_M03, value);
        }
        private decimal _y01_M04;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M04_ForecastAnnualQuanity
        {
            get =>_y01_M04;
            set => SetProperty(ref _y01_M04, value);
        }
        private decimal _y01_M05;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M05_ForecastAnnualQuanity
        {
            get =>_y01_M05;
            set => SetProperty(ref _y01_M05, value);
        }

        private decimal _y01_M06;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M06_ForecastAnnualQuanity
        {
            get =>_y01_M06;
            set => SetProperty(ref _y01_M06, value);
        }
        private decimal _y01_M07;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M07_ForecastAnnualQuanity
        {
            get =>_y01_M07;
            set => SetProperty(ref _y01_M07, value);
        }
        private decimal _y01_M08;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M08_ForecastAnnualQuanity
        {
            get =>_y01_M08;
            set => SetProperty(ref _y01_M08, value);
        }
        private decimal _y01_M09;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M09_ForecastAnnualQuanity
        {
            get =>_y01_M09;
            set => SetProperty(ref _y01_M09, value);
        }
        private decimal _y01_M10;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M10_ForecastAnnualQuanity
        {
            get =>_y01_M10;
            set => SetProperty(ref _y01_M10, value);
        }
        private decimal _y01_M11;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M11_ForecastAnnualQuanity
        {
            get =>_y01_M11;
            set => SetProperty(ref _y01_M11, value);
        }
        private decimal _y01_M12;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y01_M12_ForecastAnnualQuanity
        {
            get =>_y01_M12;
            set => SetProperty(ref _y01_M12, value);
        }
        #endregion
        #region Year 2
        private decimal _y02_M01;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M01_ForecastAnnualQuanity
        {
            get =>_y02_M01;
            set => SetProperty(ref _y02_M01, value);
        }
        private decimal _y02_M02;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M02_ForecastAnnualQuanity
        {
            get =>_y02_M02;
            set => SetProperty(ref _y02_M02, value);
        }
        private decimal _y02_M03;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M03_ForecastAnnualQuanity
        {
            get =>_y02_M03;
            set => SetProperty(ref _y02_M03, value);
        }
        private decimal _y02_M04;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M04_ForecastAnnualQuanity
        {
            get =>_y02_M04;
            set => SetProperty(ref _y02_M04, value);
        }
        private decimal _y02_M05;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M05_ForecastAnnualQuanity
        {
            get =>_y02_M05;
            set => SetProperty(ref _y02_M05, value);
        }

        private decimal _y02_M06;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M06_ForecastAnnualQuanity
        {
            get =>_y02_M06;
            set => SetProperty(ref _y02_M06, value);
        }
        private decimal _y02_M07;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M07_ForecastAnnualQuanity
        {
            get =>_y02_M07;
            set => SetProperty(ref _y02_M07, value);
        }
        private decimal _y02_M08;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M08_ForecastAnnualQuanity
        {
            get =>_y02_M08;
            set => SetProperty(ref _y02_M08, value);
        }
        private decimal _y02_M09;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M09_ForecastAnnualQuanity
        {
            get =>_y02_M09;
            set => SetProperty(ref _y02_M09, value);
        }
        private decimal _y02_M10;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M10_ForecastAnnualQuanity
        {
            get =>_y02_M10;
            set => SetProperty(ref _y02_M10, value);
        }
        private decimal _y02_M11;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M11_ForecastAnnualQuanity
        {
            get =>_y02_M11;
            set => SetProperty(ref _y02_M11, value);
        }
        private decimal _y02_M12;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y02_M12_ForecastAnnualQuanity
        {
            get =>_y02_M12;
            set => SetProperty(ref _y02_M12, value);
        }
        #endregion
        #region Year 3
        private decimal _y03_M01;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M01_ForecastAnnualQuanity
        {
            get =>_y03_M01;
            set => SetProperty(ref _y03_M01, value);
        }
        private decimal _y03_M02;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M02_ForecastAnnualQuanity
        {
            get =>_y03_M02;
            set => SetProperty(ref _y03_M02, value);
        }
        private decimal _y03_M03;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M03_ForecastAnnualQuanity
        {
            get =>_y03_M03;
            set => SetProperty(ref _y03_M03, value);
        }
        private decimal _y03_M04;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M04_ForecastAnnualQuanity
        {
            get =>_y03_M04;
            set => SetProperty(ref _y03_M04, value);
        }
        private decimal _y03_M05;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M05_ForecastAnnualQuanity
        {
            get =>_y03_M05;
            set => SetProperty(ref _y03_M05, value);
        }

        private decimal _y03_M06;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M06_ForecastAnnualQuanity
        {
            get =>_y03_M06;
            set => SetProperty(ref _y03_M06, value);
        }
        private decimal _y03_M07;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M07_ForecastAnnualQuanity
        {
            get =>_y03_M07;
            set => SetProperty(ref _y03_M07, value);
        }
        private decimal _y03_M08;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M08_ForecastAnnualQuanity
        {
            get =>_y03_M08;
            set => SetProperty(ref _y03_M08, value);
        }
        private decimal _y03_M09;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M09_ForecastAnnualQuanity
        {
            get =>_y03_M09;
            set => SetProperty(ref _y03_M09, value);
        }
        private decimal _y03_M10;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M10_ForecastAnnualQuanity
        {
            get =>_y03_M10;
            set => SetProperty(ref _y03_M10, value);
        }
        private decimal _y03_M11;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M11_ForecastAnnualQuanity
        {
            get =>_y03_M11;
            set => SetProperty(ref _y03_M11, value);
        }
        private decimal _y03_M12;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y03_M12_ForecastAnnualQuanity
        {
            get =>_y03_M12;
            set => SetProperty(ref _y03_M12, value);
        }
        #endregion
        #region Year 4
        private decimal _y04_M01;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M01_ForecastAnnualQuanity
        {
            get =>_y04_M01;
            set => SetProperty(ref _y04_M01, value);
        }
        private decimal _y04_M02;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M02_ForecastAnnualQuanity
        {
            get =>_y04_M02;
            set => SetProperty(ref _y04_M02, value);
        }
        private decimal _y04_M03;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M03_ForecastAnnualQuanity
        {
            get =>_y04_M03;
            set => SetProperty(ref _y04_M03, value);
        }
        private decimal _y04_M04;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M04_ForecastAnnualQuanity
        {
            get =>_y04_M04;
            set => SetProperty(ref _y04_M04, value);
        }
        private decimal _y04_M05;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M05_ForecastAnnualQuanity
        {
            get =>_y04_M05;
            set => SetProperty(ref _y04_M05, value);
        }

        private decimal _y04_M06;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M06_ForecastAnnualQuanity
        {
            get =>_y04_M06;
            set => SetProperty(ref _y04_M06, value);
        }
        private decimal _y04_M07;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M07_ForecastAnnualQuanity
        {
            get =>_y04_M07;
            set => SetProperty(ref _y04_M07, value);
        }
        private decimal _y04_M08;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M08_ForecastAnnualQuanity
        {
            get =>_y04_M08;
            set => SetProperty(ref _y04_M08, value);
        }
        private decimal _y04_M09;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M09_ForecastAnnualQuanity
        {
            get =>_y04_M09;
            set => SetProperty(ref _y04_M09, value);
        }
        private decimal _y04_M10;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M10_ForecastAnnualQuanity
        {
            get =>_y04_M10;
            set => SetProperty(ref _y04_M10, value);
        }
        private decimal _y04_M11;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M11_ForecastAnnualQuanity
        {
            get =>_y04_M11;
            set => SetProperty(ref _y04_M11, value);
        }
        private decimal _y04_M12;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y04_M12_ForecastAnnualQuanity
        {
            get =>_y04_M12;
            set => SetProperty(ref _y04_M12, value);
        }
        #endregion
        #region Year 5
        private decimal _y05_M01;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M01_ForecastAnnualQuanity
        {
            get =>_y05_M01;
            set => SetProperty(ref _y05_M01, value);
        }
        private decimal _y05_M02;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M02_ForecastAnnualQuanity
        {
            get =>_y05_M02;
            set => SetProperty(ref _y05_M02, value);
        }
        private decimal _y05_M03;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M03_ForecastAnnualQuanity
        {
            get =>_y05_M03;
            set => SetProperty(ref _y05_M03, value);
        }
        private decimal _y05_M04;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M04_ForecastAnnualQuanity
        {
            get =>_y05_M04;
            set => SetProperty(ref _y05_M04, value);
        }
        private decimal _y05_M05;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M05_ForecastAnnualQuanity
        {
            get =>_y05_M05;
            set => SetProperty(ref _y05_M05, value);
        }

        private decimal _y05_M06;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M06_ForecastAnnualQuanity
        {
            get =>_y05_M06;
            set => SetProperty(ref _y05_M06, value);
        }
        private decimal _y05_M07;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M07_ForecastAnnualQuanity
        {
            get =>_y05_M07;
            set => SetProperty(ref _y05_M07, value);
        }
        private decimal _y05_M08;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M08_ForecastAnnualQuanity
        {
            get =>_y05_M08;
            set => SetProperty(ref _y05_M08, value);
        }
        private decimal _y05_M09;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M09_ForecastAnnualQuanity
        {
            get =>_y05_M09;
            set => SetProperty(ref _y05_M09, value);
        }
        private decimal _y05_M10;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M10_ForecastAnnualQuanity
        {
            get =>_y05_M10;
            set => SetProperty(ref _y05_M10, value);
        }
        private decimal _y05_M11;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M11_ForecastAnnualQuanity
        {
            get =>_y05_M11;
            set => SetProperty(ref _y05_M11, value);
        }
        private decimal _y05_M12;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y05_M12_ForecastAnnualQuanity
        {
            get =>_y05_M12;
            set => SetProperty(ref _y05_M12, value);
        }
        #endregion
        #region Year 6
        private decimal _y06_M01;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M01_ForecastAnnualQuanity
        {
            get =>_y06_M01;
            set => SetProperty(ref _y06_M01, value);
        }
        private decimal _y06_M02;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M02_ForecastAnnualQuanity
        {
            get =>_y06_M02;
            set => SetProperty(ref _y06_M02, value);
        }
        private decimal _y06_M03;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M03_ForecastAnnualQuanity
        {
            get =>_y06_M03;
            set => SetProperty(ref _y06_M03, value);
        }
        private decimal _y06_M04;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M04_ForecastAnnualQuanity
        {
            get =>_y06_M04;
            set => SetProperty(ref _y06_M04, value);
        }
        private decimal _y06_M05;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M05_ForecastAnnualQuanity
        {
            get =>_y06_M05;
            set => SetProperty(ref _y06_M05, value);
        }

        private decimal _y06_M06;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M06_ForecastAnnualQuanity
        {
            get =>_y06_M06;
            set => SetProperty(ref _y06_M06, value);
        }
        private decimal _y06_M07;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M07_ForecastAnnualQuanity
        {
            get =>_y06_M07;
            set => SetProperty(ref _y06_M07, value);
        }
        private decimal _y06_M08;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M08_ForecastAnnualQuanity
        {
            get =>_y06_M08;
            set => SetProperty(ref _y06_M08, value);
        }
        private decimal _y06_M09;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M09_ForecastAnnualQuanity
        {
            get =>_y06_M09;
            set => SetProperty(ref _y06_M09, value);
        }
        private decimal _y06_M10;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M10_ForecastAnnualQuanity
        {
            get =>_y06_M10;
            set => SetProperty(ref _y06_M10, value);
        }
        private decimal _y06_M11;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M11_ForecastAnnualQuanity
        {
            get =>_y06_M11;
            set => SetProperty(ref _y06_M11, value);
        }
        private decimal _y06_M12;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y06_M12_ForecastAnnualQuanity
        {
            get =>_y06_M12;
            set => SetProperty(ref _y06_M12, value);
        }
        #endregion
        #region Year 7
        private decimal _y07_M01;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M01_ForecastAnnualQuanity
        {
            get =>_y07_M01;
            set => SetProperty(ref _y07_M01, value);
        }
        private decimal _y07_M02;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M02_ForecastAnnualQuanity
        {
            get =>_y07_M02;
            set => SetProperty(ref _y07_M02, value);
        }
        private decimal _y07_M03;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M03_ForecastAnnualQuanity
        {
            get =>_y07_M03;
            set => SetProperty(ref _y07_M03, value);
        }
        private decimal _y07_M04;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M04_ForecastAnnualQuanity
        {
            get =>_y07_M04;
            set => SetProperty(ref _y07_M04, value);
        }
        private decimal _y07_M05;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M05_ForecastAnnualQuanity
        {
            get =>_y07_M05;
            set => SetProperty(ref _y07_M05, value);
        }

        private decimal _y07_M06;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M06_ForecastAnnualQuanity
        {
            get =>_y07_M06;
            set => SetProperty(ref _y07_M06, value);
        }
        private decimal _y07_M07;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M07_ForecastAnnualQuanity
        {
            get =>_y07_M07;
            set => SetProperty(ref _y07_M07, value);
        }
        private decimal _y07_M08;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M08_ForecastAnnualQuanity
        {
            get =>_y07_M08;
            set => SetProperty(ref _y07_M08, value);
        }
        private decimal _y07_M09;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M09_ForecastAnnualQuanity
        {
            get =>_y07_M09;
            set => SetProperty(ref _y07_M09, value);
        }
        private decimal _y07_M10;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M10_ForecastAnnualQuanity
        {
            get =>_y07_M10;
            set => SetProperty(ref _y07_M10, value);
        }
        private decimal _y07_M11;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M11_ForecastAnnualQuanity
        {
            get =>_y07_M11;
            set => SetProperty(ref _y07_M11, value);
        }
        private decimal _y07_M12;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y07_M12_ForecastAnnualQuanity
        {
            get =>_y07_M12;
            set => SetProperty(ref _y07_M12, value);
        }
        #endregion
        #region Year 8
        private decimal _y08_M01;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M01_ForecastAnnualQuanity
        {
            get =>_y08_M01;
            set => SetProperty(ref _y08_M01, value);
        }
        private decimal _y08_M02;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M02_ForecastAnnualQuanity
        {
            get =>_y08_M02;
            set => SetProperty(ref _y08_M02, value);
        }
        private decimal _y08_M03;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M03_ForecastAnnualQuanity
        {
            get =>_y08_M03;
            set => SetProperty(ref _y08_M03, value);
        }
        private decimal _y08_M04;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M04_ForecastAnnualQuanity
        {
            get =>_y08_M04;
            set => SetProperty(ref _y08_M04, value);
        }
        private decimal _y08_M05;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M05_ForecastAnnualQuanity
        {
            get =>_y08_M05;
            set => SetProperty(ref _y08_M05, value);
        }

        private decimal _y08_M06;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M06_ForecastAnnualQuanity
        {
            get =>_y08_M06;
            set => SetProperty(ref _y08_M06, value);
        }
        private decimal _y08_M07;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M07_ForecastAnnualQuanity
        {
            get =>_y08_M07;
            set => SetProperty(ref _y08_M07, value);
        }
        private decimal _y08_M08;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M08_ForecastAnnualQuanity
        {
            get =>_y08_M08;
            set => SetProperty(ref _y08_M08, value);
        }
        private decimal _y08_M09;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M09_ForecastAnnualQuanity
        {
            get =>_y08_M09;
            set => SetProperty(ref _y08_M09, value);
        }
        private decimal _y08_M10;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M10_ForecastAnnualQuanity
        {
            get =>_y08_M10;
            set => SetProperty(ref _y08_M10, value);
        }
        private decimal _y08_M11;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M11_ForecastAnnualQuanity
        {
            get =>_y08_M11;
            set => SetProperty(ref _y08_M11, value);
        }
        private decimal _y08_M12;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y08_M12_ForecastAnnualQuanity
        {
            get =>_y08_M12;
            set => SetProperty(ref _y08_M12, value);
        }
        #endregion
        #region Year 9
        private decimal _y09_M01;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M01_ForecastAnnualQuanity
        {
            get =>_y09_M01;
            set => SetProperty(ref _y09_M01, value);
        }
        private decimal _y09_M02;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M02_ForecastAnnualQuanity
        {
            get =>_y09_M02;
            set => SetProperty(ref _y09_M02, value);
        }
        private decimal _y09_M03;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M03_ForecastAnnualQuanity
        {
            get =>_y09_M03;
            set => SetProperty(ref _y09_M03, value);
        }
        private decimal _y09_M04;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M04_ForecastAnnualQuanity
        {
            get =>_y09_M04;
            set => SetProperty(ref _y09_M04, value);
        }
        private decimal _y09_M05;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M05_ForecastAnnualQuanity
        {
            get =>_y09_M05;
            set => SetProperty(ref _y09_M05, value);
        }

        private decimal _y09_M06;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M06_ForecastAnnualQuanity
        {
            get =>_y09_M06;
            set => SetProperty(ref _y09_M06, value);
        }
        private decimal _y09_M07;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M07_ForecastAnnualQuanity
        {
            get =>_y09_M07;
            set => SetProperty(ref _y09_M07, value);
        }
        private decimal _y09_M08;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M08_ForecastAnnualQuanity
        {
            get =>_y09_M08;
            set => SetProperty(ref _y09_M08, value);
        }
        private decimal _y09_M09;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M09_ForecastAnnualQuanity
        {
            get =>_y09_M09;
            set => SetProperty(ref _y09_M09, value);
        }
        private decimal _y09_M10;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M10_ForecastAnnualQuanity
        {
            get =>_y09_M10;
            set => SetProperty(ref _y09_M10, value);
        }
        private decimal _y09_M11;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M11_ForecastAnnualQuanity
        {
            get =>_y09_M11;
            set => SetProperty(ref _y09_M11, value);
        }
        private decimal _y09_M12;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y09_M12_ForecastAnnualQuanity
        {
            get =>_y09_M12;
            set => SetProperty(ref _y09_M12, value);
        }
        #endregion
        #region Year 10
        private decimal _y10_M01;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M01_ForecastAnnualQuanity
        {
            get =>_y10_M01;
            set => SetProperty(ref _y10_M01, value);
        }
        private decimal _y10_M02;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M02_ForecastAnnualQuanity
        {
            get =>_y10_M02;
            set => SetProperty(ref _y10_M02, value);
        }
        private decimal _y10_M03;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M03_ForecastAnnualQuanity
        {
            get =>_y10_M03;
            set => SetProperty(ref _y10_M03, value);
        }
        private decimal _y10_M04;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M04_ForecastAnnualQuanity
        {
            get =>_y10_M04;
            set => SetProperty(ref _y10_M04, value);
        }
        private decimal _y10_M05;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M05_ForecastAnnualQuanity
        {
            get =>_y10_M05;
            set => SetProperty(ref _y10_M05, value);
        }

        private decimal _y10_M06;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M06_ForecastAnnualQuanity
        {
            get =>_y10_M06;
            set => SetProperty(ref _y10_M06, value);
        }
        private decimal _y10_M07;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M07_ForecastAnnualQuanity
        {
            get =>_y10_M07;
            set => SetProperty(ref _y10_M07, value);
        }
        private decimal _y10_M08;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M08_ForecastAnnualQuanity
        {
            get =>_y10_M08;
            set => SetProperty(ref _y10_M08, value);
        }
        private decimal _y10_M09;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M09_ForecastAnnualQuanity
        {
            get =>_y10_M09;
            set => SetProperty(ref _y10_M09, value);
        }
        private decimal _y10_M10;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M10_ForecastAnnualQuanity
        {
            get =>_y10_M10;
            set => SetProperty(ref _y10_M10, value);
        }
        private decimal _y10_M11;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M11_ForecastAnnualQuanity
        {
            get =>_y10_M11;
            set => SetProperty(ref _y10_M11, value);
        }
        private decimal _y10_M12;
        [DataMember]
        [DecimalPrecision(12, 0)]
        public decimal Y10_M12_ForecastAnnualQuanity
        {
            get =>_y10_M12;
            set => SetProperty(ref _y10_M12, value);
        }

        private DateTime _forecastStartDate;
        [DataMember]
        public DateTime ForecastStartDate
        {
            get => _forecastStartDate;
            set => SetProperty(ref _forecastStartDate, value);
        }

        private DateTime _forecastEndDate;
        [DataMember]
        public DateTime ForecastEndDate
        {
            get => _forecastEndDate;
            set => SetProperty(ref _forecastEndDate, value);
        }

        #endregion

    }
}