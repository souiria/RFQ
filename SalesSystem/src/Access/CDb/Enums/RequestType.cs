namespace CDb.Enums
{
    public enum RequestType
    {
        None = 0,
        ReadAll = 1,
        ReadById = 2,
        ReadByIsActive = 3,
        ReadByComponentSheetNumber = 4,
        ReadByCode = 5,
        ReadByName = 6,
        Create = 70,
        Update = 80,
        Delete = 90
    }
}
