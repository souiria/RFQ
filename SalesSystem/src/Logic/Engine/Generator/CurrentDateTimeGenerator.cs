namespace Generator
{
    class CurrentDateTimeGenerator : ValueGenerator<DateTime>
    {
        readonly IDateTimeProvider _DateTimeProvider;

        public CurrentDateTimeGenerator(IDateTimeProvider dateTimeProvider)
        {
            _DateTimeProvider = dateTimeProvider;
        }

        public override bool GeneratesTemporaryValues => false;

        public override DateTime Next([NotNull] EntityEntry entry) => _DateTimeProvider.UtcNow;
    }
}
