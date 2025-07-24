namespace CDb.Enums
{
    public enum TagType
    {
        Unknown = 0,
        None,
        [Description("System")]
        System,
        // Life cycle tags
        // PROTOTYPE - new component
        // VALIDATION REQUESTED
        // VALIDATION ACCEPTED
        // VALIDATION REFUSED
        // VALIDATED
        // OBSOLETE
        // tag name is the project name
        [Description("Project")]
        Project,
        // tag name is the vehicle name
        [Description("Vehicle")]
        Vehicle,
        // not yet, this needs a specialzed UI
        //[Description("User")]
        //UserTag,

    }
}
