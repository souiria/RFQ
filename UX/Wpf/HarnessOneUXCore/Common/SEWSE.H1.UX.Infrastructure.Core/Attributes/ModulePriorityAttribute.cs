using System;

namespace SEWSE.H1.UX.Infrastructure.Core.Attributes
{
    /// <summary>
    /// Allows the order of module loading to be controlled.  Where dependencies
    /// allow, module loading order will be controlled by relative values of priority
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public sealed class ModulePriorityAttribute : Attribute
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="priority">the priority to assign</param>
        public ModulePriorityAttribute(int priority)
        {
            this.Priority = priority;
        }

        /// <summary>
        /// Gets or sets the priority of the module.
        /// </summary>
        /// <value>The priority of the module.</value>
        public int Priority { get; private set; }
    }
}