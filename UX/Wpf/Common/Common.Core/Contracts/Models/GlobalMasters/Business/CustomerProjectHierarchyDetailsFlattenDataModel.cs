/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   CustomerProjectHierarchyDetailsFlattenDataModel.cs
Function           :   Customer Project HierarchyDetails Flatten Data
Created By         :   Shivam Dhingra 
Created on         :   23-Nov-2020
Revision History   :   [] :
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Contracts.Models.GlobalMasters.Business
{
    /// <summary>
    /// Data Contract for CustomerProjectHierarchyDetailsFlattenDataModel
    /// </summary>
    [DataContract,Serializable]
    public class CustomerProjectHierarchyDetailsFlattenDataModel 
    {
        private string _customerBusinessGroupCode;
        /// <summary>
        /// get or set for CustomerBusinessGroupCode
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupCode
        {
            get { return _customerBusinessGroupCode; }
            set { _customerBusinessGroupCode = value; }
        }

        private string _customerBusinessGroupName;
        /// <summary>
        /// get or set for CustomerBusinessGroupName
        /// </summary>
        [DataMember]
        public string CustomerBusinessGroupName
        {
            get { return _customerBusinessGroupName; }
            set { _customerBusinessGroupName = value; }
        }

        private string _customerCode;
        /// <summary>
        /// get or set for CustomerCode
        /// </summary>
        [DataMember]
        public string CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        private string _customerName;
        /// <summary>
        /// get or set for CustomerName
        /// </summary>
        [DataMember]
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        private string _streetNumber;
        /// <summary>
        /// get or set for StreetNumber
        /// </summary>
        [DataMember]
        public string StreetNumber
        {
            get { return _streetNumber; }
            set { _streetNumber = value; }
        }

        private string _streetName;
        /// <summary>
        /// get or set for StreetName
        /// </summary>
        [DataMember]
        public string StreetName
        {
            get { return _streetName; }
            set { _streetName = value; }
        }

        private string _city;
        /// <summary>
        /// get or set for City
        /// </summary>
        [DataMember]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _region;
        /// <summary>
        /// get or set for Region
        /// </summary>
        [DataMember]
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        private string _zipCode;
        /// <summary>
        /// get or set for ZipCode
        /// </summary>
        [DataMember]
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        private string _country;
        /// <summary>
        /// get or set for Country
        /// </summary>
        [DataMember]
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        private string _customerBusinessType;
        /// <summary>
        /// get or set for CustomerBusinessType
        /// </summary>
        [DataMember]
        public string CustomerBusinessType
        {
            get { return _customerBusinessType; }
            set { _customerBusinessType = value; }
        }

        private string _indexedMaterial;
        /// <summary>
        /// get or set for IndexedMaterial
        /// </summary>
        [DataMember]
        public string IndexedMaterial
        {
            get { return _indexedMaterial; }
            set { _indexedMaterial = value; }
        }

        private string _customerBusinessQualityManagerName;
        /// <summary>
        /// get or set for CustomerBusinessQualityManagerName
        /// </summary>
        [DataMember]
        public string CustomerBusinessQualityManagerName
        {
            get { return _customerBusinessQualityManagerName; }
            set { _customerBusinessQualityManagerName = value; }
        }

        private ObservableCollection<CustomerSalesEntityHierarchyModel> _customerSalesEntityHierarchy;
        /// <summary>
        /// get or set for CustomerSalesEntityHierarchy
        /// </summary>
        [DataMember]
        public ObservableCollection<CustomerSalesEntityHierarchyModel> CustomerSalesEntityHierarchy
        {
            get { return _customerSalesEntityHierarchy; }
            set { _customerSalesEntityHierarchy = value; }
        }

        private string _platformName;
        /// <summary>
        /// get or set for PlatformName
        /// </summary>
        [DataMember]
        public string PlatformName
        {
            get { return _platformName; }
            set { _platformName = value; }
        }

        private string _platformManagerName;
        /// <summary>
        /// get or set for PlatformManagerName
        /// </summary>
        [DataMember]
        public string PlatformManagerName
        {
            get { return _platformManagerName; }
            set { _platformManagerName = value; }
        }

        private string _programName;
        /// <summary>
        /// get or set for ProgramName
        /// </summary>
        [DataMember]
        public string ProgramName
        {
            get { return _programName; }
            set { _programName = value; }
        }

        private string _projectCode;
        /// <summary>
        /// get or set for ProjectCode
        /// </summary>
        [DataMember]
        public string ProjectCode
        {
            get { return _projectCode; }
            set { _projectCode = value; }
        }

        private string _projectName;
        /// <summary>
        /// get or set for ProjectName
        /// </summary>
        [DataMember]
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }

        private string _customerProjectCode;
        /// <summary>
        /// get or set for CustomerProjectCode
        /// </summary>
        [DataMember]
        public string CustomerProjectCode
        {
            get { return _customerProjectCode; }
            set { _customerProjectCode = value; }
        }

        private string _projectDescription;
        /// <summary>
        /// get or set for ProjectDescription
        /// </summary>
        [DataMember]
        public string ProjectDescription
        {
            get { return _projectDescription; }
            set { _projectDescription = value; }
        }

        private int _projectAnnualVolume;
        /// <summary>
        /// get or set for ProjectAnnualVolume
        /// </summary>
        [DataMember]
        public int ProjectAnnualVolume
        {
            get { return _projectAnnualVolume; }
            set { _projectAnnualVolume = value; }
        }

        private string _milestoneEventName;
        /// <summary>
        /// get or set for MilestoneEventName
        /// </summary>
        [DataMember]
        public string MilestoneEventName
        {
            get { return _milestoneEventName; }
            set { _milestoneEventName = value; }
        }

        private DateTime? _eventStartDate;
        /// <summary>
        /// get or set for EventStartDate
        /// </summary>
        [DataMember]
        public DateTime? EventStartDate
        {
            get { return _eventStartDate; }
            set { _eventStartDate = value; }
        }

        private DateTime? _eventEndDate;
        /// <summary>
        /// get or set for EventEndDate
        /// </summary>
        [DataMember]
        public DateTime? EventEndDate
        {
            get { return _eventEndDate; }
            set { _eventEndDate = value; }
        }

    }
}
