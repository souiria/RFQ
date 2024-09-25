/**************************************************************************************************
(C) 2018 SEWS-E Ltd., All rights reserved
File Name          :   SupplierRFQFieldSettingsModel.cs
Function           :   This model will represent the data that holds the information, the description, the active state and the mandatory state of the various components as stated by the supplier.
Created By         :   Pawan
Created on         :   11-Jun-2019
Revision History   :   [25-June-2019] : Srashti
*                  :   [ ] :Added FieldDisplayOrder Property
*                  :   [26-Aug-2019] : Srashti
*                  :   [ ] :Added LockField Property
****************************************************************************************************/

using Common.Core.Contracts.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Models.Purchasing
{
    /// <summary>
    /// Types of Field Section
    /// </summary>
    public enum FieldSection
    {
        /// <summary>
        /// Fields that are linked with Engineering
        /// </summary>
        Engineering,
        /// <summary>
        /// Fields that are linked with Purchasing
        /// </summary>
        Purchasing
    }
    /// <summary>
    /// Item of RFQ Field Mapping Model
    /// </summary>
    [DataContract, Serializable]
    public class SupplierRFQFieldSettingsModel : BaseModel<Guid>
    {

        /// <summary>
        /// Local status of Field Section Item
        /// </summary>
        private FieldSection _fieldSection = FieldSection.Purchasing;
        /// <summary>
        /// Field Section Item
        /// </summary>
        [DataMember]
        public FieldSection FieldSection
        {
            get => _fieldSection;
            set => SetProperty(ref _fieldSection, value);
        }

        /// <summary>
        /// Local Reference of Field Sequence Number
        /// </summary>
        private int _fieldSequenceNumber;
        /// <summary>
        /// Sequence Number of each Fields
        /// </summary>
        [DataMember]
        public int FieldSequenceNumber
        {
            get => _fieldSequenceNumber;
            set => SetProperty(ref _fieldSequenceNumber, value);
        }

        /// <summary>
        /// Local Reference of Field Key
        /// </summary>
        private string _fieldKey;
        /// <summary>
        /// Field Key
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string FieldKey
        {
            get => _fieldKey;
            set => SetProperty(ref _fieldKey, value);
        }

        /// <summary>
        /// Local Reference of Field Mapping
        /// </summary>
        private string _fieldMapping;
        /// <summary>
        /// Field Mapping with field key
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string FieldMapping
        {
            get => _fieldMapping;
            set => SetProperty(ref _fieldMapping, value);
        }

        /// <summary>
        /// Local Reference of Field Description
        /// </summary>
        private string _fieldDescription;
        /// <summary>
        /// Field Description 
        /// </summary>
        [DataMember]
        [StringLength(100)]
        public string FieldDescription
        {
            get => _fieldDescription;
            set => SetProperty(ref _fieldDescription, value);
        }

        /// <summary>
        /// Local Reference of Field Data Type
        /// </summary>
        private string _fieldDataType;
        /// <summary>
        /// Field Description for field
        /// </summary>
        [DataMember]
        [StringLength(20)]
        public string FieldDataType
        {
            get => _fieldDataType;
            set => SetProperty(ref _fieldDataType, value);
        }

        /// <summary>
        /// Local Reference of Mandatory
        /// </summary>
        private bool _isMandatory;

        /// <summary>
        /// Public Reference of Is Mandatory
        /// </summary>
        [DataMember]
        [Required]
        public bool IsMandatory
        {
            get => _isMandatory;
            set => SetProperty(ref _isMandatory, value);
        }

        /// <summary>
        /// Local Reference of Is Visible
        /// </summary>
        private bool _isVisible;

        /// <summary>
        /// Public Reference of Is Visible
        /// </summary>
        [DataMember]
        [Required]
        public bool IsVisible
        {
            get => _isVisible;
            set => SetProperty(ref _isVisible, value);
        }

        /// <summary>
        /// Local status of Lock Field Item
        /// </summary>
        private bool _lockField;
        /// <summary>
        /// Lock Field Item
        /// </summary>
        [DataMember]
        public bool LockField
        {
            get => _lockField;
            set => SetProperty(ref _lockField, value);
        }

        /// <summary>
        /// Local Reference of FieldDisplayOrder
        /// </summary>
        private int _fieldDisplayOrder;

        /// <summary>
        /// Public Reference of FieldDisplayOrder
        /// </summary>
        [DataMember]
        [Required]
        public int FieldDisplayOrder
        {
            get => _fieldDisplayOrder;
            set => SetProperty(ref _fieldDisplayOrder, value);
        }
    }
}
