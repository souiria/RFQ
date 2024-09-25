using System;

namespace Common.UX.Wpf.Attributes
{
    //TODO: Confirm if still required
    
    [AttributeUsage(AttributeTargets.Class)]
    public class RolesAttribute : Attribute
    {
        public string[] Roles { get; set; }

        public RolesAttribute(params string[] roles)
        {
            Roles = roles;
        }

    }
}