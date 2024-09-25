/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   NPRPartSearchModel.cs
Function           :   NPRPartSearchModel
Created By         :   Dharmendra Kumar
Created on         :   23-Jul-2019
Revision History   :   [] :                  
****************************************************************************************************/
using Common.Core.Contracts.Models.Base;
using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.NPR
{
    [DataContract, Serializable]
   public class NPRPartSearchModel :BaseModel<Guid>
    {

        /// <summary>
        /// Local Reference of HeirarchyCategory
        /// </summary>
        private string _matchType;
        /// <summary>
        /// Get or Sets the value of indicating {Match Type} 
        /// </summary>
        [DataMember]
        public string MatchType
        {
            get => _matchType;
            set => SetProperty(ref _matchType, value);
        }
        /// <summary>
        /// Local Reference of RequestID
        /// </summary>
        private string _sourceName;
        /// <summary>
        /// Get or Sets the value from source
        /// </summary>
        [DataMember]
        public string SourceName
        {
            get => _sourceName;
            set => _sourceName = value;
        }      

        /// <summary>
        /// Local reference of when NPR is modified.
        /// </summary>
        private DateTime ? _lastModifiedDate;
        /// <summary>
        /// Gets of Sets the value of indicating {Modified Date} of NPR
        /// </summary>
        [DataMember]
        public DateTime ?  LastModifiedDate
        {
            get => _lastModifiedDate;
            set => _lastModifiedDate=value;
        }

        /// <summary>
        /// Local reference of SumitomoMaterialNumber
        /// </summary>
        private string _sumitomoMaterialNumber;
        /// <summary>
        /// Gets of Sets the value of indicating {SumitomoMaterialNumber} of NPR
        /// </summary>
        [DataMember]        
        public string SumitomoMaterialNumber
        {
            get => _sumitomoMaterialNumber;
            set => _sumitomoMaterialNumber = value;
        }


        /// <summary>
        /// Local reference of ReferenceNumber
        /// </summary>
        private string _referenceNumber;
        /// <summary>
        /// Gets of Sets the value of indicating {ReferenceNumber} of NPR
        /// </summary>
        [DataMember]       
        public string ReferenceNumber
        {
            get => _referenceNumber;
            set => _referenceNumber = value;
        }
       


    }
}
