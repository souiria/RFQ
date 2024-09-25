using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Common.Core.Contracts.Interfaces.Base;
using Common.Core.Infrastructure.Extensions;

namespace Common.SF.Contracts.Models.Core.Proxy
{
    [DataContract]
    public class Range : IEquatable<Range>, IEquatable<long>
    {
        /// <summary>
        /// The low value of the range (Inclusive)
        /// </summary>
        [DataMember]
        public long Low { get; set; }

        /// <summary>
        /// The high value of the range (Inclusive)
        /// </summary>
        [DataMember]
        public long High { get; set; }

        /// <summary>
        /// Creates a new instance of a range item
        /// </summary>
        /// <param name="low">The low value of the range (Incluseive)</param>
        /// <param name="high">The high value of the range (Inclusive)</param>
        public Range(long low, long high)
        {
            Low = low;
            High = high;
        }

        /// <summary>
        /// Determines whether a value is within range. Both the low and high values are inclusive
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Within(long value)
        {
            if (value >= Low && value <= High)
                return true;
            return false;
        }

        /// <summary>
        /// Compares against another range object to see if they are equal. If the two ranges overlap, even partially,
        /// they are determined to be equal. Ranges do not have to have the same low and high values to be determined as equal
        /// </summary>
        /// <param name="other">The range to compare against</param>
        /// <returns>Whether the ranges are equal or overlap</returns>
        public bool Equals(Range other)
        {
            if (Within(other.Low) || Within(other.High))
                return true;
            return false;
        }

        /// <summary>
        /// Compares against a value to see whether they overlap. If they overlap they are determined to be equal.
        /// </summary>
        /// <param name="other">The value to compare against</param>
        /// <returns>Whether the value is within the range</returns>
        public bool Equals(long other)
        {
            if (Within(other))
                return true;
            return false;
        }

        public IEnumerable<T> GetModelsWithinRange<T>(IEnumerable<T> models) where T : IEntity<Guid>
        {
            return models.Where(model => Within(model.Id.ToPartitionKey()));
        }

        public List<T> GetModelsWithinRange<T>(List<T> models) where T : IEntity<Guid>
        {
            return models.Where(model => Within(model.Id.ToPartitionKey())).ToList();
        }
    }
}
