/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   ConcernCodeModel.cs
Function           :   Concern Code Model
Created By         :   Sachin Pandey
Created on         :   05-Oct-2023
Revision History   :   []
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.ConcernLogSystem
{
    /// <summary>
    /// Model for Concern Code Screen
    /// </summary>
    [DataContract, Serializable]
    public class ConcernCodeModel : BaseModel<Guid>
    {
       

        private string _description;
        /// <summary>
        /// Get or Set for {Description}.
        /// </summary>
        [DataMember]
        public string Description
        {
            get => _description;
            set => _description = value;
        }

        private string _subCategory;
        /// <summary>
        /// Get or Set for {SubCategory}.
        /// </summary>
        [DataMember]
        public string SubCategory
        {
            get => _subCategory;
            set => _subCategory = value;
        }

        private bool _isActive = true;
        [DataMember]

        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value);
        }
    }
}
