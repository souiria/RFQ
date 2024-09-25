using System.ComponentModel;
using System.Linq;
using Common.Core.Contracts.Models.Base;

namespace Common.Core.Contracts.Interfaces.Base
{
    public interface IValidatable : IDataErrorInfo
    {
        bool IsValid { get; }
    }

    public static class ValidatableExtensions
    {
        public static bool IsValid(this NodeCollection node)
        {
            return ((IValidatable) node.Value).IsValid && node.Nodes.All(child => child.IsValid());
        }
    }
}
