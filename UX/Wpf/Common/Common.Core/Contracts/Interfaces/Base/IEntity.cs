using System;
using System.Runtime.Serialization;

namespace Common.Core.Contracts.Interfaces.Base
{
    public interface IEntity
    {
        [DataMember]
        object Id { get; set; }
        [DataMember]
        DateTime CreatedDate { get; set; }
        [DataMember]
        DateTime? ModifiedDate { get; set; }
        [DataMember]
        Guid CreatedBy { get; set; }
        [DataMember]
        Guid ModifiedBy { get; set; }
    }

    public interface IEntity<T> : IEntity, IId<T>
    {
        [DataMember]
        new T Id { get; set; }
    }
}
