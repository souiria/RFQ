using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Administration.Security
{
    /// <inheritdoc />
    /// <summary>
    /// Represents a row of FieldSecurityOverride data.
    /// </summary>
    [DataContract, Serializable]
    public class FieldOverrideModel : BaseModel<Guid>
    {
        public FieldOverrideModel() : base() { }

        public FieldOverrideModel(Guid id)
        {
            Id = id;
        }

        public FieldOverrideModel(FieldHierarchyModel field, Guid userGuid)
        {
            if (field == null) throw new ArgumentNullException(nameof(field));

            ViewId = field.ViewId;
            FieldId = field.Id;
            UserGuid = userGuid;
            CreatedDate = DateTime.UtcNow;
            //CreatedBy = createdBy;
            ModifiedDate = CreatedDate;
            ModifiedBy = CreatedBy;
            VariableName = field.VariableName;
        }

        /// <summary>
        /// Gets or sets a Guid value for the Security ViewId column.
        /// </summary>
        [DataMember]
        public Guid ViewId { get; set; }

        /// <summary>
        /// Gets or sets a Guid value for the Security FieldId column.
        /// </summary>
        [DataMember]
        public Guid FieldId { get; set; }

        /// <summary>
        /// Gets or sets a bool value for the Security FieldValue column.
        /// </summary>
        [DataMember]
        public bool FieldValue { get; set; }

        /// <summary>
        /// Gets or sets a Guid value for the Security UserGuid column.
        /// </summary>
        [DataMember]
        public Guid UserGuid { get; set; }

        [DataMember, NotMapped]
        public string VariableName { get; set; }

        ///// <summary>
        ///// Gets or sets a string value for the Security ViewName column.
        ///// </summary>
        //[DataMember, NotMapped]
        //public string ViewName { get; set; }

        ///// <summary>
        ///// Gets or sets a string value for the Security FieldName column.
        ///// </summary>
        //[DataMember, NotMapped]
        //public string FieldName { get; set; }
    }
}