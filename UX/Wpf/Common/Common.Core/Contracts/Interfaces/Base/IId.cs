using System.Runtime.Serialization;

namespace Common.Core.Contracts.Interfaces.Base
{
    /// <summary>
    /// An interface for entities that contain an Id property.
    /// </summary>
    /// <typeparam name="T">The type of the Id.</typeparam>
    public interface IId<T>
    {
        /// <summary>
        /// The Id of the entity.
        /// </summary>
        [DataMember]
        T Id { get; set; }
    }
}
