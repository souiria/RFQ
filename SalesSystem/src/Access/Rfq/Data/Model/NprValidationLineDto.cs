namespace Rfq.Data.Model
{
    public sealed class NprValidationLineDto
    {
        public string? Id
        { get; set; }
        public bool IsValid
        { get; set; }

        public Collection<ValidationErrorDto> Errors
        { get; } = new Collection<ValidationErrorDto>();
    }

    public sealed class ValidationErrorDto
    {
        public string Field
        { get; set; } = string.Empty;
        public string Message
        { get; set; } = string.Empty;
    }
}
