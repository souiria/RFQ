namespace CDb.Enums
{
    public enum PersonType
    {
        Unknown = 0,   // unknown person type
        Responsible,    // company person - manages client relation
        Contact,        // partner person - customer or supplier
        Buyer,          // company person who buys for the company
    }
}