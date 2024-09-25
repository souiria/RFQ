/**************************************************************************************************
(C) 2018 SEWS-E Ltd.= All rights reserved
File Name          :   CiresModel.cs
Function           :   Data contract for Cires Model
Created By         :   Srashti Gupta
Created on         :   15-July-2020
Revision History   :   [21-Jul-2020] Pawan 
                   :   Added field for liability and defect type 
                   :   [14-Jan-2021] Srashti 
                   :   Added field for PartNumber
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Yokoten
{
    [DataContract, Serializable]
    public class CiresModel
    {
        private string _cIReSNo;
        /// <summary>
        /// This field will set CIReSNo
        /// </summary>
        [DataMember]
        [StringLength(8000)]
        public string CIReSNo
        {
            get => _cIReSNo;
            set => _cIReSNo= value;
        }
        private string _customer;
        /// <summary>
        /// This field will set CUSTOMER
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string CUSTOMER
        {
            get => _customer;
            set => _customer= value;
        }

        private string _defect_item_description;
        /// <summary>
        /// This field will set defect_item_description
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string defect_item_description
        {
            get => _defect_item_description;
            set => _defect_item_description= value;
        }

        private string _function_problem;
        /// <summary>
        /// This field will set function_problem
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string function_problem
        {
            get => _function_problem;
            set => _function_problem= value;
        }

        private string _plant_name;
        /// <summary>
        /// This field will set plant_name
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string plant_name
        {
            get => _plant_name;
            set => _plant_name= value;
        }

        private string _CAR_NAME;
        /// <summary>
        /// This field will set CAR_NAME
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string CAR_NAME
        {
            get => _CAR_NAME;
            set => _CAR_NAME= value;
        }
        private string _harness_family;
        /// <summary>
        /// This field will set HARNESS_FAMILIY
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string HARNESS_FAMILIY
        {
            get => _harness_family;
            set => _harness_family= value;
        }
        private string _part_no;
        /// <summary>
        /// This field will set PART_NO
        /// </summary>
        [DataMember]
        [StringLength(30)]
        public string PART_NO
        {
            get => _part_no;
            set => _part_no= value;
        }

        private string _defect_liability_name;
        /// <summary>
        /// This field will set DEFECT_LIABILITY_NAME
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DEFECT_LIABILITY_NAME
        {
            get => _defect_liability_name;
            set => _defect_liability_name= value;
        }

        private string _test_datetime;
        /// <summary>
        /// This field will set test_datetime
        /// </summary>
        [DataMember]
        [StringLength(17)]
        public string test_datetime
        {
            get => _test_datetime;
            set => _test_datetime= value;
        }
        
        private string _concern_raised_on;
        /// <summary>
        /// This field will set concern_raised_on
        /// </summary>
        [DataMember]
        [StringLength(35)]
        public string concern_raised_on
        {
            get => _concern_raised_on;
            set => _concern_raised_on= value;
        }
        private string _category_id;
        /// <summary>
        /// This field will set category_id
        /// </summary>
        [DataMember]
        [StringLength(5)]
        public string category_id
        {
            get => _category_id;
            set => _category_id= value;
        }
        private string _yokoten;
        /// <summary>
        /// This field will set Yokoten
        /// </summary>
        [DataMember]
        [StringLength(3)]
        public string Yokoten
        {
            get => _yokoten;
            set => _yokoten= value;
        }
        private string _yokoten_comment;
        /// <summary>
        /// This field will set YOKOTEN_COMMENT
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string YOKOTEN_COMMENT
        {
            get => _yokoten_comment;
            set => _yokoten_comment= value;
        }
    }
    [DataContract, Serializable]
    public class CiresFilteredData
    {
        private string _cIReSNo;
        /// <summary>
        /// This field will set CIReSNo
        /// </summary>
        [DataMember]
        [StringLength(8000)]
        public string CIReSNo
        {
            get => _cIReSNo;
            set => _cIReSNo =  value;
        }

        private string _function_problem;
        /// <summary>
        /// This field will set function_problem
        /// </summary>
        [DataMember]
        [StringLength(500)]
        public string function_problem
        {
            get => _function_problem;
            set => _function_problem= value;
        }

        private string _liabilityType;
        /// <summary>
        /// This field will set LiabilityType
        /// </summary>
        [DataMember]
        public string LiabilityType
        {
            get => _liabilityType;
            set => _liabilityType = value;
        }

        private string _defectType;
        /// <summary>
        /// This field will set DefectType
        /// </summary>
        [DataMember]
        public string DefectType
        {
            get => _defectType;
            set => _defectType = value;
        }
        private string _partNumber;
        /// <summary>
        /// This field will set PartNumber
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => _partNumber = value;
        }

    }
}
