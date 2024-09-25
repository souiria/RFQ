/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ForecastAnnualBySiteModel.cs
Function           :   Fore cast Annual By Site Model
Created By         :   Dharmendra
Created on         :   02-May-2020
Revision History   :  [02-May-2020]  Dharmendra Kumar
                   :  [] Comment SupplierMaterialAssociationGuid fields and Add Two New Fields MaterailGuid and SupplierGuid
****************************************************************************************************/


using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;
using Common.Core.Infrastructure.Attributes;

namespace Common.Core.Contracts.Models.Purchasing
{
    [DataContract, Serializable]
    public class ForecastAnnualBySiteModel : BaseModel<Guid>
    {
        private Guid _businessUnitGuid;
        [DataMember]
        public Guid BusinessUnitGuid
        {
            get => _businessUnitGuid;
            set => SetProperty(ref _businessUnitGuid, value);
        }

        //private Guid _supplierMaterialAssociationGuid;
        //[DataMember]
        //public Guid SupplierMaterialAssociationGuid
        //{
        //    get => _supplierMaterialAssociationGuid;
        //    set => SetProperty(ref _supplierMaterialAssociationGuid, value);
        //}
        private Guid _materialGuid;
        [DataMember]
        public Guid MaterailGuid
        {
            get => _materialGuid;
            set => SetProperty(ref _materialGuid, value);
        }
        private Guid _supplierGuid;
        [DataMember]
        public Guid SupplierGuid
        {
            get => _supplierGuid;
            set => SetProperty(ref _supplierGuid, value);
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
        private string _requirementMonthYear;
        [DataMember]
        public string RequirementMonthYear
        {
            get => _requirementMonthYear;
            set => SetProperty(ref _requirementMonthYear, value);
        }
        private decimal _requiredQuantity;
        [DataMember]
        [DecimalPrecision(15, 0)]
        public decimal RequiredQuantity
        {
            get => _requiredQuantity;
            set => SetProperty(ref _requiredQuantity, value);
        }
        private Guid _unitOfMeasureGuid;
        [DataMember]
        public Guid UnitOfMeasureGuid
        {
            get => _unitOfMeasureGuid;
            set => SetProperty(ref _unitOfMeasureGuid, value);
        }
        private Guid _customerGuid;
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }
        private Guid _vehicleGuid;
        [DataMember]
        public Guid VehicleGuid
        {
            get => _vehicleGuid;
            set => SetProperty(ref _vehicleGuid, value);
        }
        private Guid _facilityGuid;
        [DataMember]
        public Guid FacilityGuid
        {
            get => _facilityGuid;
            set => SetProperty(ref _facilityGuid, value);
        }

    }
    [DataContract, Serializable]
    public class CPDForecastAnnualBySiteModel : ExternalDataSourceModel<object>
    {
        private string _Section_c;
        [DataMember]
        public string Section_c
        {
            get => _Section_c;
            set => SetProperty(ref _Section_c, value);
        }
        private DateTime _fc_data_range_fr;
        [DataMember]
        public DateTime fc_data_range_fr
        {
            get => _fc_data_range_fr;
            set => SetProperty(ref _fc_data_range_fr, value);
        }

        private DateTime _fc_data_range_to;
        [DataMember]
        public DateTime fc_data_range_to
        {
            get => _fc_data_range_to;
            set => SetProperty(ref _fc_data_range_to, value);
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
        private string _month_Year_ID;
        [DataMember]
        public string Month_Year_ID
        {
            get => _month_Year_ID;
            set => SetProperty(ref _month_Year_ID, value);
        }
        private decimal _REQ_qty;
        [DataMember]
        [DecimalPrecision(15, 0)]
        public decimal REQ_qty
        {
            get => _REQ_qty;
            set => SetProperty(ref _REQ_qty, value);
        }
        private string _userid;
        [DataMember]
        public string userid
        {
            get => _userid;
            set => SetProperty(ref _userid, value);
        }

        private DateTime _ent_dt;
        [DataMember]
        public DateTime ent_dt
        {
            get => _ent_dt;
            set => SetProperty(ref _ent_dt, value);
        }
        private string _uom;
        [DataMember]
        public string uom
        {
            get => _uom;
            set => SetProperty(ref _uom, value);
        }
        private string _customer_nm;
        [DataMember]
        public string customer_nm
        {
            get => _customer_nm;
            set => SetProperty(ref _customer_nm, value);
        }
        private string _vehicle_nm;
        [DataMember]
        public string vehicle_nm
        {
            get => _vehicle_nm;
            set => SetProperty(ref _vehicle_nm, value);
        }
        private string _facility_nm;
        [DataMember]
        public string facility_nm
        {
            get => _facility_nm;
            set => SetProperty(ref _facility_nm, value);
        }

    }
}