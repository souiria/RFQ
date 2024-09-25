/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ReportSection1SitesWithMaterialNumberModel.cs
Function           :   Data contract for  Get Sites Used by Material Number
Created By         :   Dharmendra Kumar
Created on         :   08-Sep-2020
RevisionHistory    :   [11-Sept-2020] : Shivam Dhingra
*                  :   Added new field for supplier
*                  :   [14-Sept-2020] : Shivam Dhingra
*                  :   Added new field for BusinessUnitName and SupplierName
*                  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    /// <summary>
    /// Data contract ReportSection1SitesWithMaterialNumberModel
    /// </summary>
    [DataContract, Serializable]
    public class ReportSection1SitesWithMaterialNumberModel : ExternalDataSourceModel<object>
    {
        private string _section_c;
        /// <summary>
        /// get or set for section_c
        /// </summary>
        [DataMember]
        public string section_c
        {
            get => _section_c;
            set => SetProperty(ref _section_c, value);
        }
        private string _material_no;
        /// <summary>
        /// get or set for material_no
        /// </summary>
        [DataMember]
        public string material_no
        {
            get => _material_no;
            set => SetProperty(ref _material_no, value);
        }
        private string _spqr_no;
        /// <summary>
        /// get or set for spqr_no
        /// </summary>
        [DataMember]
        public string spqr_no
        {
            get => _spqr_no;
            set => SetProperty(ref _spqr_no, value);
        }

        private string _supplier_c;
        /// <summary>
        /// get or set for supplier_c
        /// </summary>
        [DataMember]
        public string supplier_c
        {
            get => _supplier_c;
            set => SetProperty(ref _supplier_c, value);
        }


        private string _businessunit_name;
        /// <summary>
        /// get or set for businessunit_name
        /// </summary>
        [DataMember]
        public string businessunit_name
        {
            get => _businessunit_name;
            set => SetProperty(ref _businessunit_name, value);
        }


        private string _supplier_name;
        /// <summary>
        /// get or set for supplier_name
        /// </summary>
        [DataMember]
        public string supplier_name
        {
            get => _supplier_name;
            set => SetProperty(ref _supplier_name, value);
        }


    }
}
