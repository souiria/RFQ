/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ProjectEngineeringAssociationModel.cs
Function           :   ProjectEngineeringAssociationModel
Created By         :   Pawan Kumar
Created on         :   31-Jul-2019
Revision History   :   [21-Jul-2022] : Ranjay
                   :   [] : Added class ProjectEngineeringAssociationCustomerModel
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMastersAssociation
{
    /// <summary>
    /// Maintain Association of Project Code with Engineer
    /// </summary>
    [DataContract, Serializable]
    public class ProjectEngineeringAssociationModel : BaseModel<Guid>
    {
        private Guid _projectGuid;
        /// <summary>
        /// Project Code Guid
        /// </summary>
        [DataMember]
        [Required]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => SetProperty(ref _projectGuid, value);
        }

        private string _engineeringADName;
        /// <summary>
        /// Engineer User Name
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string EngineeringADName
        {
            get => _engineeringADName;
            set => SetProperty(ref _engineeringADName, value);
        }

        private string _engineeringFullName;
        /// <summary>
        /// Engineer Name
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string EngineeringFullName
        {
            get => _engineeringFullName;
            set => SetProperty(ref _engineeringFullName, value);
        }

        private string _emailAddress;
        /// <summary>
        /// Engineer Email-Id
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string EmailAddress
        {
            get => _emailAddress;
            set => SetProperty(ref _emailAddress, value);
        }

        private Guid _customerGuid;
        /// <summary>
        /// Customer Guid
        /// </summary>
        [DataMember]
        [Required]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }
    }

    public class ProjectEngineeringAssociationCustomerModel : BaseModel<Guid>
    {
        private Guid _projectGuid;
        /// <summary>
        /// Project Guid
        /// </summary>
        [DataMember]
        public Guid ProjectGuid
        {
            get => _projectGuid;
            set => SetProperty(ref _projectGuid, value);
        }

        private Guid _customerGuid;
        /// <summary>
        /// Customer Guid
        /// </summary>
        [DataMember]
        public Guid CustomerGuid
        {
            get => _customerGuid;
            set => SetProperty(ref _customerGuid, value);
        }

        private string _customerCode;
        /// <summary>
        /// Customer Name
        /// </summary>
        [DataMember]
        public string CustomerCode
        {
            get => _customerCode;
            set => SetProperty(ref _customerCode, value);
        }

        private string _customerName;
        /// <summary>
        /// Customer Name
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }
    }

}
