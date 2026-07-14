namespace SalesSystem.Rfq.Enums
{
    public enum RfqDrawingPartNumberStatus
    {
        New = 0,
        ExactMatch = 10,
        ContainsMatch = 15,
        NprSearched = 20,
        AlternativePartSelected = 30,
        NprRequested = 40,
        Completed = 50
    }
}

