/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerProductNumberXREFModel.cs
Function           :  
Created By         :   Prakhar Singh
Created on         :   28-Feb-2023
Revision History   :   [07-Mar-2023] : Ranjay 
                   :   Added new class CustomerProductNumberXREFErrorModel
                   :   [24-May-2023] : Vishwadeep Singh
                   :   [HD-00374786] : Added new class CustomerPartNumberModel
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.SupplyPlanning
{
    public class CustomerProductNumberXREFModel : BaseModel<Guid>
    {


        private string _unloadingPoint;
        /// <summary>
        /// Get or Set for {UnloadingPoint}.
        /// </summary>
        [DataMember]
        public string UnloadingPoint
        {
            get => _unloadingPoint;
            set => _unloadingPoint = value;
        }

        private Guid _customerGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => _customerGuid = value;
        }

        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }

        private Guid _unloadingPointGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        public Guid UnloadingPointGuid
        {
            get => _unloadingPointGuid;
            set => _unloadingPointGuid = value;
        }

        private string _sEWSEPartNumber;
        /// <summary>
        /// Get or Set for {SEWSEPartNumber}.
        /// </summary>
        [DataMember]
        public string SEWSEPartNumber
        {
            get => _sEWSEPartNumber;
            set => _sEWSEPartNumber = value;
        }

        private string _customerPartNumber;
        /// <summary>
        /// Get or Set for {CustomerPartNumber}.
        /// </summary>
        [DataMember]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => _customerPartNumber = value;
        }

    }

    [DataContract, Serializable]
    public class CustomerProductNumberXREFFilterModel
    {
        private Guid _unloadingPointGuid;
        /// <summary>
        /// Get or Set for {UnloadingPointGuid}.
        /// </summary>
        [DataMember]
        public Guid UnloadingPointGuid
        {
            get => _unloadingPointGuid;
            set => _unloadingPointGuid = value;
        }

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

    public class GetUnloadingpointModel
    {


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

        private Guid _Id;
        /// <summary>
        /// Get or Set for {Id}.
        /// </summary>
        [DataMember]
        public Guid Id
        {
            get => _Id;
            set => _Id = value;
        }

        private string _unloadingPointCode;
        /// <summary>
        /// Get or Set for {UnloadingPointCode}.
        /// </summary>
        [DataMember]
        public string UnloadingPointCode
        {
            get => _unloadingPointCode;
            set => _unloadingPointCode = value;
        }

    }

    [DataContract, Serializable]
    public class CustomerProductNumberXREFErrorModel
    {
        private string _customerName;
        /// <summary>
        /// Get or Set for {CustomerName}.
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => _customerName = value;
        }

        private string _unloadingPoint;
        /// <summary>
        /// Get or Set for {UnloadingPoint}.
        /// </summary>
        [DataMember]
        public string UnloadingPoint
        {
            get => _unloadingPoint;
            set => _unloadingPoint = value;
        }

        private string _customerPartNumber;
        /// <summary>
        /// Get or Set for {CustomerPartNumber}.
        /// </summary>
        [DataMember]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => _customerPartNumber = value;
        }

        private string _sEWSEPartNumber;
        /// <summary>
        /// Get or Set for {SEWSEPartNumber}.
        /// </summary>
        [DataMember]
        public string SEWSEPartNumber
        {
            get => _sEWSEPartNumber;
            set => _sEWSEPartNumber = value;
        }

        /// <summary>
        /// Local variable _Errors
        /// </summary>
        private string _Errors;
        /// <summary>
        /// Get or Set for {Errors}.
        /// </summary>
        [DataMember]
        public string Errors
        {
            get => _Errors;
            set => _Errors = value;
        }
    }

    [DataContract, Serializable]
    public class CustomerPartNumberModel
    {
        private string _customerPartNumber;
        /// <summary>
        /// Get or Set for {CustomerPartNumber}.
        /// </summary>
        [DataMember]
        public string CustomerPartNumber
        {
            get => _customerPartNumber;
            set => _customerPartNumber = value;
        }
    }

}



