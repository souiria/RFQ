using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Models.Core.Logging
{
    [DataContract, Serializable]
    public class AuditLoggingModel : BaseModel<Guid>
    {
        private bool? _isAuditLoggingEnabled = true;
        [DataMember]
        public bool? IsAuditLoggingEnabled
        {
            get => _isAuditLoggingEnabled;
            set => SetProperty(ref _isAuditLoggingEnabled, value);
        }

        private Guid _auditLoggingDBConnection_H1ConfigurationSettingGuid;
        [DataMember]
        [Required]
        public Guid AuditLoggingDBConnection_H1ConfigurationSettingGuid
        {
            get => _auditLoggingDBConnection_H1ConfigurationSettingGuid;
            set => SetProperty(ref _auditLoggingDBConnection_H1ConfigurationSettingGuid, value);
        }
        /// <summary>
        /// Compares the properties of two objects of the same type and returns if all properties are equal.
        /// </summary>
        /// <param name="objectA">The first object to compare.</param>
        /// <param name="objectB">The second object to compare.</param>
        /// <param name="ignoreList">A list of property names to ignore from the comparison.
        /// </param>
        /// <returns><c>true</c> if all property values
        ///           are equal, otherwise <c>false</c>.</returns>
        public List<AuditTrailModel> GetItemDifferencesForAudit(object objectA, object objectB, string[] ignoreList)
        {
            List<AuditTrailModel> Auditlogs = new List<AuditTrailModel>();
            if (objectA != null && objectB != null)
            {
                Type objectType;

                objectType = objectA.GetType();
                Guid itemGuid = (Guid)objectB.GetType().GetProperty("Id").GetValue(objectB);
                Guid batchGuid = Guid.NewGuid();

                var action = objectType.GetProperty("CrudOperationType").GetValue(objectB);

                if (action.ToString().ToLower() != "read")
                {
                    var modifiedBy = (Guid)objectType.GetProperty("ModifiedBy").GetValue(objectB);
                    var createdBy = (Guid)objectType.GetProperty("CreatedBy").GetValue(objectB);
                    var createdDate = (DateTime)objectType.GetProperty("CreatedDate").GetValue(objectB);
                    var modifiedDate = (DateTime)objectType.GetProperty("ModifiedDate").GetValue(objectB);

                    foreach (PropertyInfo propertyInfo in objectType.GetProperties(
                      BindingFlags.Public | BindingFlags.Instance).Where(
                      p => p.CanRead && !ignoreList.Contains(p.Name) && p.CustomAttributes.Count() > 0 && !Attribute.IsDefined(p, typeof(NotMappedAttribute))))
                    {
                        object valueA;
                        object valueB;

                        valueA = propertyInfo.GetValue(objectA, null);
                        valueB = propertyInfo.GetValue(objectB, null);
                        // if it is a primitive type, value type or implements
                        // IComparable, just directly try and compare the value
                        if (CanDirectlyCompare(propertyInfo.PropertyType))
                        {
                            if (!AreValuesEqual(valueA, valueB))
                            {
                                Auditlogs.Add(new AuditTrailModel()
                                {
                                    Id = Guid.NewGuid(),
                                    ModelName = objectType.Name,
                                    FieldName = propertyInfo.Name,
                                    OldValue = valueA != null ? valueA.ToString() : string.Empty,
                                    NewValue = valueB != null ? valueB.ToString() : string.Empty,
                                    Action = action.ToString(),
                                    ItemGuid = itemGuid,
                                    BatchGuid = batchGuid,
                                    CrudOperationType = CrudOperationType.Create,
                                    ModifiedBy = modifiedBy,
                                    CreatedBy = createdBy,
                                    CreatedDate = createdDate,
                                    ModifiedDate = modifiedDate
                                });
                            }
                        }
                    }
                }
            }
            return Auditlogs;
        }

        /// <summary>
        /// Determines whether value instances of the specified type can be directly compared.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///     <c>true</c> if this value instances of the specified
        ///           type can be directly compared; otherwise, <c>false</c>.
        /// </returns>
        private bool CanDirectlyCompare(Type type)
        {
            return typeof(IComparable).IsAssignableFrom(type) || type.IsPrimitive || type.IsValueType;
        }

        /// <summary>
        /// Compares two values and returns if they are the same.
        /// </summary>
        /// <param name="valueA">The first value to compare.</param>
        /// <param name="valueB">The second value to compare.</param>
        /// <returns><c>true</c> if both values match,
        //              otherwise <c>false</c>.</returns>
        private bool AreValuesEqual(object valueA, object valueB)
        {
            bool result;
            IComparable selfValueComparer;

            selfValueComparer = valueA as IComparable;

            if (valueA == null && valueB != null || valueA != null && valueB == null)
                result = false; // one of the values is null
            else if (selfValueComparer != null && selfValueComparer.CompareTo(valueB) != 0)
                result = false; // the comparison using IComparable failed
            else if (!Equals(valueA, valueB))
                result = false; // the comparison using Equals failed
            else
                result = true; // match

            return result;
        }
    }
}