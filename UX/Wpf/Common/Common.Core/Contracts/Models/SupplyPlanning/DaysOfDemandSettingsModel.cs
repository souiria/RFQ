/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   DaysOfDemandSettingsModel.cs
Function           :  
Created By         :   Shivam Kalia
Created on         :   14-June-2021
Revision History   :   [18-Jun-2021] : Shivam Kalia
                   :   Added new field CustomerName in DaysOfDemandSettingsModel 

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
    /// Data Contract use for DaysOfDemandSettings Service
    /// </summary>
    [DataContract, Serializable]
    public class DaysOfDemandSettingsModel : BaseModel<Guid>
    {
        /// <summary>
        /// Local variable _supplySectionHierarchyDetailGuid     
        /// </summary>
        private Guid _supplySectionHierarchyDetailGuid;
        /// <summary>
        /// Get or Set for {SupplySectionHierarchyDetailGuid}.
        /// </summary>
        [DataMember]
        public Guid SupplySectionHierarchyDetailGuid
        {
            get => _supplySectionHierarchyDetailGuid;
            set => SetProperty(ref _supplySectionHierarchyDetailGuid, value);
        }

        /// <summary>
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

        /// <summary>
        /// Local variable _harnessFamily     
        /// </summary>
        private string _harnessFamily;
        /// <summary>
        /// Get or Set for {HarnessFamily}.
        /// </summary>
        [DataMember]
        public string HarnessFamily
        {
            get => _harnessFamily;
            set => SetProperty(ref _harnessFamily ,value);
        }

        /// <summary>
        /// Local variable _dCLocation     
        /// </summary>
        private string _dCLocation;
        /// <summary>
        /// Get or Set for {DCLocation}.
        /// </summary>
        [DataMember]
        public string DCLocation
        {
            get => _dCLocation;
            set => SetProperty(ref _dCLocation , value);
        }

        /// <summary>
        /// Local variable _manufacturingSite     
        /// </summary>
        private string _manufacturingSite;
        /// <summary>
        /// Get or Set for {ManufacturingSite}.
        /// </summary>
        [DataMember]
        public string ManufacturingSite
        {
            get => _manufacturingSite;
            set => SetProperty(ref _manufacturingSite , value);
        }

        /// <summary>
        /// Local variable _categoryA     
        /// </summary>
        private int _categoryA;
        /// <summary>
        /// Get or Set for {CategoryA}.
        /// </summary>
        [DataMember]
        public int CategoryA
        {
            get => _categoryA;
            set => SetProperty(ref _categoryA , value);
        }

        /// <summary>
        /// Local variable _categoryB     
        /// </summary>
        private int _categoryB;
        /// <summary>
        /// Get or Set for {CategoryB}.
        /// </summary>
        [DataMember]
        public int CategoryB
        {
            get => _categoryB;
            set => SetProperty(ref _categoryB , value);
        }

        /// <summary>
        /// Local variable _categoryC     
        /// </summary>
        private int _categoryC;
        /// <summary>
        /// Get or Set for {CategoryC}.
        /// </summary>
        [DataMember]
        public int CategoryC
        {
            get => _categoryC;
            set => SetProperty(ref _categoryC, value);
        }
    }

    /// <summary>
    /// Data Contract use for WMSDataSynchronizationETL Service in DaysOfDemandSettings endpoint for procedure parameter
    /// </summary>
    [DataContract, Serializable]
    public class DaysOfDemandSettingsByProcedureParameterModel
    {
        /// <summary>
        /// Local variable _customerName     
        /// </summary>
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }
    }
    }
