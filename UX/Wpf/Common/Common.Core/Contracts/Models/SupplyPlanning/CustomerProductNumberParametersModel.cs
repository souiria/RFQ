/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerProductNumberParametersModel.cs
Function           :  
Created By         :   Shivam Kalia
Created on         :   27-July-2021
Revision History   :   [28-July-2021] Shivam Kalia
*                  :   Changed Datalength for ParameterDescription
                   :   [02-Aug-2021] : Shivam Kalia
                   :   [] Added new field ProjectGuid
                   :   [27-Aug-2021] : Shivam Kalia
                   :   [] Added new class CustomerProductNumberParameterModelFilter and added a field AutoInc in CustomerProductNumberParametersModel        
                   :   [22-July-2022] : Virendra
                   :   [] Added new field CustomerGuid in class CustomerProductNumberParameterModelFilter and CustomerProductNumberParametersModel        

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
    /// Data Contract use for CustomerProductNumberParametersModel Service
    /// </summary>
    [DataContract, Serializable]
    public class CustomerProductNumberParametersModel : BaseModel<Guid>
    {
        private Guid _projectGuid;
        /// <summary>
        /// ProjectGuid
        /// </summary>
        [DataMember]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => SetProperty(ref _projectGuid, value);
        }

        private Guid _customerGuid;
        /// <summary>
        /// CustomerGuid
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }

        /// <summary>
        /// Local variable _projectName     
        /// </summary>
        private string _projectName;
        [DataMember]
        [StringLength(100)]
        /// <summary>
        /// Get or Set for {ProjectName}.
        /// </summary>
        public string ProjectName
        {
            get => _projectName;
            set => SetProperty(ref _projectName, value);
        }

        /// <summary>
        /// Local variable _parameterKey     
        /// </summary>
        private string _parameterKey;
        [DataMember]
        [StringLength(50)]
        /// <summary>
        /// Get or Set for {ParameterKey}.
        /// </summary>
        public string ParameterKey
        {
            get => _parameterKey;
            set => SetProperty(ref _parameterKey, value);
        }

        /// <summary>
        /// Local variable _parameterDescription     
        /// </summary>
        private string _parameterDescription;
        [DataMember]
        [StringLength(150)]
        /// <summary>
        /// Get or Set for {ParameterDescription}.
        /// </summary>
        public string ParameterDescription
        {
            get => _parameterDescription;
            set => SetProperty(ref _parameterDescription, value);
        }

        /// <summary>
        /// Local variable _parameterValue1     
        /// </summary>
        private string _parameterValue1;
        [DataMember]
        [StringLength(50)]
        /// <summary>
        /// Get or Set for {ParameterValue1}.
        /// </summary>
        public string ParameterValue1
        {
            get => _parameterValue1;
            set => SetProperty(ref _parameterValue1, value);
        }

        /// Local variable _parameterValue2     
        /// </summary>
        private string _parameterValue2;
        [DataMember]
        [StringLength(50)]
        /// <summary>
        /// Get or Set for {ParameterValue2}.
        /// </summary>
        public string ParameterValue2
        {
            get => _parameterValue2;
            set => SetProperty(ref _parameterValue2, value);
        }

        /// Local variable _parameterValue3     
        /// </summary>
        private string _parameterValue3;
        [DataMember]
        [StringLength(50)]
        /// <summary>
        /// Get or Set for {ParameterValue3}.
        /// </summary>
        public string ParameterValue3
        {
            get => _parameterValue3;
            set => SetProperty(ref _parameterValue3, value);
        }

        /// Local variable _isActive     
        /// </summary>
        private bool _isActive = true;
        [DataMember]
        /// <summary>
        /// Get or Set for {IsActive}.
        /// </summary>
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }

        /// Local variable _AutoInc    
        /// </summary>
        private int _AutoInc = 0;
        [DataMember]
        /// <summary>
        /// Get or Set for {AutoInc}.
        /// </summary>
        public int AutoInc
        {
            get => _AutoInc;
            set => SetProperty(ref _AutoInc, value);
        }


    }

    /// <summary>
    /// Data Contract use for DRPGenerationModule Service in CustomerProductNumberParameter endpoint for procedure parameter
    /// </summary>
    [DataContract, Serializable]
    public class CustomerProductNumberParameterModelFilter
    {
        /// <summary>
        /// Local variable _Parameter_Key  
        /// </summary>
        private string _Parameter_Key;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string Parameter_Key
        {
            get => _Parameter_Key;
            set => _Parameter_Key = value;
        }

        /// <summary>
        /// Local variable _ProjectGuid  
        /// </summary>
        private Guid _ProjectGuid;
        /// <summary>
        /// Get or Set for {ProjectGuid}.
        /// </summary>
        [DataMember]
        public Guid ProjectGuid
        {
            get => _ProjectGuid;
            set => _ProjectGuid = value;
        }

        /// <summary>
        /// Local variable _customerGuid  
        /// </summary>
        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {CustomerGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }


        
    }
}