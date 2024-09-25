using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Common.Core.Contracts.Interfaces.Base;

namespace Common.Core.Contracts.Models.Base
{
    [DataContract, Serializable]
    public class ExternalDataSourceModel<T> : BindableBaseEntity, IEntity<T>
    {
        [NotMapped]
        public T Id { get; set; }
        object IEntity.Id
        {
            get => Id;
            set => Id = (T)Convert.ChangeType(value, typeof(T));
        }
        [NotMapped]
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public DateTime? ModifiedDate { get; set; }
        [NotMapped]
        public Guid CreatedBy { get; set; }
        [NotMapped]
        public Guid ModifiedBy { get; set; }
        [NotMapped]
        public byte[] Version { get; set; }
    }
}
