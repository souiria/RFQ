/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ProjectHierarchyModel.cs
Function           :   Project Hierarchy Model
Created By         :   Amit Agarwal
Created on         :   29-Nov-2019
Revision History   :   [30-Nov-2019] : Pawan
                   :   [] : Added validation for each property 
                   :   [02-Dec-2019] : Nitin
                   :   [] : Added field length validation 
                   :   [03-Dec-2019] : Pawan
                   :   [] : Changed List to Observable Collection  
                   :   [22-Feb-2023]  : Vishwadeep Singh 
                   :   [] : Add property ProgramHierarchyGuid
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using Common.SF.Contracts.Interfaces.GlobalMasters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.GlobalMasters
{
    [DataContract]
    public class ProjectHierarchyModel : BaseModel<Guid>, IProjectHierarchy
    {
        private string _projectCode;

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(10)]
        public string ProjectCode
        {
            get => _projectCode;
            set => SetProperty(ref _projectCode, value);
        }

        private string _projectName;

        [DataMember]
        [StringLength(100)]
        public string ProjectName
        {
            get => _projectName;
            set => SetProperty(ref _projectName, value);
        }

        private string _customerProjectCode;

        [DataMember]
        public string CustomerProjectCode
        {
            get => _customerProjectCode;
            set => SetProperty(ref _customerProjectCode, value);
        }

        private string _projectDescription;

        [DataMember]
        public string ProjectDescription
        {
            get => _projectDescription;
            set => SetProperty(ref _projectDescription, value);
        }

        private int _projectAnnualVolume;

        [DataMember]
        public int ProjectAnnualVolume
        {
            get => _projectAnnualVolume;
            set => SetProperty(ref _projectAnnualVolume, value);
        }
        private ObservableCollection<MilestoneHierarchyModel> _milestoneHierarchy;
        [JsonIgnore]
        public ObservableCollection<MilestoneHierarchyModel> MilestoneHierarchy
        {
            get => _milestoneHierarchy;
            set => SetProperty(ref _milestoneHierarchy, value);
        }

        // Added by vishwadeep singh
        private Guid _programHierarchyGuid;

        /// <summary>
        /// ProgramHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid ProgramHierarchyGuid
        {
            get => _programHierarchyGuid;
            set => SetProperty(ref _programHierarchyGuid, value);
        }

        #region  -- Validation --
        /// <summary>
        /// Property to validate 
        /// </summary>
        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(ProjectName),
            nameof(ProjectCode),
            nameof(CustomerProjectCode)
        };
        /// <summary>
        /// Method to validate properties
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public override string this[string propertyName]
        {
            get
            {
                Error = string.Empty;
                try
                {
                    switch (propertyName)
                    {
                        case nameof(ProjectName) when string.IsNullOrWhiteSpace(_projectName):
                            Error = "Project must not be empty";break;
                        case nameof(CustomerProjectCode) when string.IsNullOrWhiteSpace(_customerProjectCode):
                            Error = "Customer Project Code must not be empty"; break;
						case nameof(ProjectAnnualVolume) when string.IsNullOrWhiteSpace(_projectAnnualVolume.ToString()) || _projectAnnualVolume < 0:
							Error = "Project Annual Volume must not be Negative"; break;
						default:
                            Error = null; break;
                    }
                    UpdateErrors(propertyName, Error);
                }
                catch (Exception) { }
                return Error;
            }
        }

        #endregion
    }
}
