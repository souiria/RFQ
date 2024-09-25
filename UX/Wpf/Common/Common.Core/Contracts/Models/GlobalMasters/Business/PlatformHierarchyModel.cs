/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   PlatformHierarchyModel.cs
Function           :   Platform Hierarchy Model
Created By         :   Amit Agarwal
Created on         :   29-Nov-2019
Revision History   :   [30-Nov-2019] : Pawan
                   :   [] : Added validation for each property       
                   :   [02-Dec-2019] : Nitin
                   :   [] : Added field length validation 
                   :   [03-Dec-2019] : Pawan
                   :   [] : Changed List to Observable Collection         
                   :   [10-Jun-2020] : Pawan
                   :   [] : Added field for Platform Manager
                   :   [15-Jun-2020] : Srashti
                   :   [] : Added field for Platform Manager Name
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
    public class PlatformHierarchyModel : BaseModel<Guid>, IPlatformHierarchy

    {
        private string _platformName;

        [DataMember]
        [StringLength(100)]
        public string PlatformName
        {
            get => _platformName;
            set => SetProperty(ref _platformName, value);
        }

        private Guid _platformManagerGuid;
        /// <summary>
        /// Platform Manager Guid
        /// </summary>
        [DataMember]
        public Guid PlatformManagerGuid
        {
            get => _platformManagerGuid;
            set => SetProperty(ref _platformManagerGuid, value);
        }

        private string _platformManagerName;
        /// <summary>
        /// Platform Manager Name
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string PlatformManagerName
        {
            get => _platformManagerName;
            set => SetProperty(ref _platformManagerName, value);
        }
        private ObservableCollection<ProgramHierarchyModel> _programHierarchy;
        [JsonIgnore]
        public ObservableCollection<ProgramHierarchyModel> ProgramHierarchy
        {
            get => _programHierarchy;
            set => SetProperty(ref _programHierarchy, value);
        }
        #region  -- Validation --
        /// <summary>
        /// Property to validate 
        /// </summary>
        public bool IsValid => ValidatedProperties.All(property => string.IsNullOrEmpty(this[property]));

        private static readonly string[] ValidatedProperties =
        {
            nameof(Name),
            nameof(PlatformName)
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
                        case nameof(PlatformName) when string.IsNullOrWhiteSpace(_platformName):
                            Error = "Platform can not be empty."; break;

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
