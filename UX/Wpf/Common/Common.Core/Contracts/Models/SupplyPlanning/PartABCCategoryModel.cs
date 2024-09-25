/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   PartABCCategory.cs
Function           :  
Created By         :   Ashish Dutta
Created on         :   03-Aug-2021
Revision History   :   [02-09-2021] : Ashish Dutta
                   :   Modified to change the datatype
                   :   [12-10-2021] : Ashish Dutta
                   :   adding more filter
                   :   [31-Jan-20222] : Shivam Dhingra
                   :   Renamed parameters for CustomerGuid
*                  :   [31-May-2022] : Sejal Srivastava
*                  :   Added a new column PartTotalSales
*                  :   [14-June-2022] : Sejal Srivastava
*                  :   [] : Added new parameter IsAdhoc in PartABCCategoryModelFilter
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    /// <summary>
    /// Data Contract use for DRPGenerationModule Service in PartABCCategoryAnalysis endpoint 
    /// </summary>
    [DataContract, Serializable]
    public class PartABCCategoryModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _projectGuid     
        /// </summary>
        private Guid _projectGuid;
        /// <summary>
        /// Get or Set for {ProjectGuid}.
        /// </summary>
        [DataMember]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => SetProperty(ref _projectGuid, value);
        }

        /// <summary>
        /// Local variable _harnessFamilyGuid     
        /// </summary>
        private Guid _harnessFamilyGuid;
        /// <summary>
        /// Get or Set for {HarnessFamilyGuid}.
        /// </summary>
        [DataMember]
        public Guid HarnessFamilyGuid
        {
            get => _harnessFamilyGuid;
            set => SetProperty(ref _harnessFamilyGuid, value);
        }

        /// <summary>
        /// Local variable _partNumber     
        /// </summary>
        private string _partNumber;
        /// <summary>
        /// Get or Set for {PartNumber}.
        /// </summary>
        [DataMember]
        public string PartNumber
        {
            get => _partNumber;
            set => SetProperty(ref _partNumber, value);
        }

        /// <summary>
        /// Local variable _partTotalSales     
        /// </summary>
        private Decimal _partTotalSales;
        /// <summary>
        /// Get or Set for {PartTotalSales}.
        /// </summary>
        [DataMember]
        public Decimal PartTotalSales
        {
            get => _partTotalSales;
            set => SetProperty(ref _partTotalSales, value);
        }
        /// <summary>
        /// Local variable _dailyAverageSales     
        /// </summary>
        private Decimal _dailyAverageSales;
        /// <summary>
        /// Get or Set for {DailyAverageSales}.
        /// </summary>
        [DataMember]
        public Decimal DailyAverageSales
        {
            get => _dailyAverageSales;
            set => SetProperty(ref _dailyAverageSales, value);
        }

        /// <summary>
        /// Local variable _totalFamilyDailyAverageSales     
        /// </summary>
        private Decimal _totalFamilyDailyAverageSales;
        /// <summary>
        /// Get or Set for {TotalFamilyDailyAverageSales}.
        /// </summary>
        [DataMember]
        public Decimal TotalFamilyDailyAverageSales
        {
            get => _totalFamilyDailyAverageSales;
            set => SetProperty(ref _totalFamilyDailyAverageSales, value);
        }

        /// Local variable _partCategory     
        /// </summary>
        private string _partCategory;
        /// <summary>
        /// Get or Set for {PartCategory}.
        /// </summary>
        [DataMember]
        public string PartCategory
        {
            get => _partCategory;
            set => SetProperty(ref _partCategory, value);
        }

        /// Local variable _endDate     
        /// </summary>
        private DateTime _endDate;
        /// <summary>
        /// Get or Set for {EndDate}.
        /// </summary>
        [DataMember]
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        /// Local variable _customerName     
        /// </summary>
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }

        /// Local variable _dCCode     
        /// </summary>
        private string _dCCode;
        /// <summary>
        /// Get or Set for {DCCode}.
        /// </summary>
        [DataMember]
        public string DCCode
        {
            get => _dCCode;
            set => SetProperty(ref _dCCode, value);
        }

    }


    /// <summary>
    /// Data Contract use for DRPGenerationModule Service in PartABCCategoryAnalysis endpoint for procedure parameter
    /// </summary>
    [DataContract, Serializable]
    public class PartABCCategoryModelFilter
    {
        ///// <summary>
        ///// Local variable _customerName     
        ///// </summary>
        //private string _customerName;
        ///// <summary>
        ///// Get or Set for {CustomerName}.
        ///// </summary>
        //[DataMember]
        //[StringLength(30)]
        //public string CustomerName
        //{
        //    get => _customerName;
        //    set => _customerName = value;
        //}


        public Guid _CustomerGuid;

        [DataMember]
        public Guid CustomerGuid
        {
            get => _CustomerGuid;
            set => _CustomerGuid = value;

        }
        /// <summary>
        /// Local variable _dCCode     
        /// </summary>
        private string _dCCode;
        /// <summary>
        /// Get or Set for {DCCode}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string DCCode
        {
            get => _dCCode;
            set => _dCCode = value;
        }

        public Guid _CreatedBy;

        [DataMember]
        public Guid CreatedBy
        {
            get => _CreatedBy;
            set => _CreatedBy = value;

        }

        public Guid _ModifiedBy;

        [DataMember]
        public Guid ModifiedBy
        {
            get => _ModifiedBy;
            set => _ModifiedBy = value;

        }
        public Guid _CustomerBusinessGroupGuid;

        [DataMember]
        public Guid CustomerBusinessGroupGuid
        {
            get => _CustomerBusinessGroupGuid;
            set => _CustomerBusinessGroupGuid = value;

        }

        public Guid _CustomerDeliveryPointGuid;

        [DataMember]
        public Guid CustomerDeliveryPointGuid
        {
            get => _CustomerDeliveryPointGuid;
            set => _CustomerDeliveryPointGuid = value;

        }
        public Guid _SupplyChainIDGuid;

        [DataMember]
        public Guid SupplyChainIDGuid
        {
            get => _SupplyChainIDGuid;
            set => _SupplyChainIDGuid = value;

        }

        public int _IsAdhoc;
        [DataMember]
        public int IsAdhoc
        {
            get => _IsAdhoc;
            set => _IsAdhoc = value;

        }

    }
}
