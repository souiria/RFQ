using System;

namespace Common.UX.Wpf.Attributes
{
    //TODO: Confirm if still required

    /// <summary>
    /// Allows the order of module loading to be controlled.  Where dependencies
    /// allow, module loading order will be controlled by relative values of priority
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ModulePriorityAttribute : Attribute
    {
        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="priority">the priority to assign</param>
        public ModulePriorityAttribute(int priority)
        {
            Priority = priority;
        }

        /// <summary>
        /// Gets or sets the priority of the module.
        /// </summary>
        /// <value>The priority of the module.</value>
        public int Priority { get; }
    }
}