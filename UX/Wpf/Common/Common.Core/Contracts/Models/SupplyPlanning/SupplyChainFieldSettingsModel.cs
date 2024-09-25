/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplyChainFieldSettingsModel.cs
Function           :   Data Contract for SupplyChainFieldSettings
Created By         :   Shivam Dhingra
Created on         :   14-May-2020
Revision History   :   [08-June-2020] :  Srashti Gupta
*                  :   Added property {FieldValue}
*                  :   [01-Oct-2020] :  Shivam Dhingra
*                  :   Added property {Length} and {Endpoint}
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
    ///  Data Contract for SupplyChainFieldSettings
    /// </summary>
    [DataContract, Serializable]
    public class SupplyChainFieldSettingsModel : BaseModel<Guid>
    {
        private string _fieldSection;
        /// <summary>
        /// Get or Set for {_fieldSection}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string FieldSection
        {
            get => _fieldSection;
            set => SetProperty(ref _fieldSection, value);
        }

        private string _fieldMapping;
        /// <summary>
        /// Get or Set for {_fieldMapping}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string FieldMapping
        {
            get => _fieldMapping;
            set => SetProperty(ref _fieldMapping, value);
        }

        private string _fieldDescription;
        /// <summary>
        /// Get or Set for {_fieldDescription}.
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string FieldDescription
        {
            get => _fieldDescription;
            set => SetProperty(ref _fieldDescription, value);
        }

        private string _fieldDataType;
        /// <summary>
        /// Get or Set for {_fieldDataType}.
        /// </summary>
        [DataMember]
        [StringLength(30)]
        public string FieldDataType
        {
            get => _fieldDataType;
            set => SetProperty(ref _fieldDataType, value);
        }

        private bool _isMandatory;
        /// <summary>
        /// Get or Set for {_isMandatory}.
        /// </summary>
        [DataMember]
        public bool IsMandatory
        {
            get => _isMandatory;
            set => SetProperty(ref _isMandatory, value);
        }

        private bool _isVisible;
        /// <summary>
        /// Get or Set for {_isVisible}.
        /// </summary>
        [DataMember]
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        private bool _lockField;
        /// <summary>
        /// Get or Set for {_lockField}.
        /// </summary>
        [DataMember]
        public bool LockField
        {
            get => _lockField;
            set => SetProperty(ref _lockField, value);
        }

        private int _fieldDisplayOrder;
        /// <summary>
        /// Get or Set for {_fieldDisplayOrder}.
        /// </summary>
        [DataMember]
        public int FieldDisplayOrder
        {
            get => _fieldDisplayOrder;
            set => SetProperty(ref _fieldDisplayOrder, value);
        }

        private int _fieldSequenceNumber;
        /// <summary>
        /// Get or Set for {_fieldSequenceNumber}.
        /// </summary>
        [DataMember]
        public int FieldSequenceNumber
        {
            get => _fieldSequenceNumber;
            set => SetProperty(ref _fieldSequenceNumber, value);
        }

        private string _fieldKey;
        /// <summary>
        /// Get or Set for {_fieldKey}.
        /// </summary>
        [DataMember]
        [StringLength(30)]
        public string FieldKey
        {
            get => _fieldKey;
            set => SetProperty(ref _fieldKey, value);
        }

        private string _fieldValue;
        /// <summary>
        /// Get or Set for {_fieldValue}.
        /// </summary>
        [DataMember]
        [StringLength(50)]
        public string FieldValue
        {
            get => _fieldValue;
            set => SetProperty(ref _fieldValue, value);
        }

        private string _endpoint;
        /// <summary>
        /// Get or Set for {Endpoint}.
        /// </summary>
        [DataMember]
        public string Endpoint
        {
            get => _endpoint;
            set => SetProperty(ref _endpoint, value);
        }

        private int _length;
        /// <summary>
        /// Get or Set for {Length}.
        /// </summary>
        [DataMember]
        public int Length
        {
            get => _length;
            set => SetProperty(ref _length, value);
        }
    }
}
