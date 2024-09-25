namespace Edi.Common.Enums;
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
    MissingPart

}
