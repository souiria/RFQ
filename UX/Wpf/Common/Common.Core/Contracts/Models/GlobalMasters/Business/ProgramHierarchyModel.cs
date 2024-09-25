/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ProgramHierarchyModel.cs
Function           :   Program Hierarchy Model
Created By         :   Amit Agarwal
Created on         :   29-Nov-2019
Revision History   :   [30-Nov-2019] : Pawan
                   :   [] : Added validation for each property  
                   :   [02-Dec-2019] : Nitin
                   :   [] : Added field length validation 
                   :   [03-Dec-2019] : Pawan
                   :   [] : Changed List to Observable Collection  
                   :   [22-Feb-2023]  : Vishwadeep Singh 
                   :   [] : Add property PlatformHierarchyGuid
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
    public class ProgramHierarchyModel : BaseModel<Guid>, IProgramHierarchy
    {
        private string _programName;
        
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string ProgramName
        {
            get => _programName;
            set => SetProperty(ref _programName, value);
        }

        ObservableCollection<ProjectHierarchyModel> _projectHierarchy;
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public ObservableCollection<ProjectHierarchyModel> ProjectHierarchy
        {
            get => _projectHierarchy;
            set => SetProperty(ref _projectHierarchy, value);
        }

        #region  -- Validation --
        /// <summary>
        /// Property to validate 
        /// </summary>
        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(Name),
            nameof(ProgramName)
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
                        case nameof(ProgramName) when string.IsNullOrWhiteSpace(_programName):
                            Error = "Program can not be empty."; break;

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

        // Added by vishwadeep singh
        private Guid _platformHierarchyGuid;

        /// <summary>
        /// PlatformHierarchyGuid
        /// </summary>
        [DataMember]
        public Guid PlatformHierarchyGuid
        {
            get => _platformHierarchyGuid;
            set => SetProperty(ref _platformHierarchyGuid, value);
        }

       
    }
}
