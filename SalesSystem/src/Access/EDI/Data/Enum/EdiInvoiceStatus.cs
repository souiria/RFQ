namespace EDI.Data.Enum
{
    public enum EdiInvoiceStatus
    {
        New,
        Processing,
        HeldUp,
        ValidDispatchLine,
        SentToUnit4,
        ConfirmedInUnit4,
        Duplicate,
        Error,
        MissingPrice,
        MissingPart,
        ProcessingDuplicates
    }
}
