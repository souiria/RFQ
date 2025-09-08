namespace Generator
{
    public class SumitomoNumberGenerator<TSet> : ValueGenerator<string> where TSet : class
    {
        readonly IDateTimeProvider _DateTime;
        readonly int _TypeNumber;
        readonly Expression<Func<TSet, string>> _PropertySelector;

        /// <inheritdoc/>
        public override bool GeneratesTemporaryValues => false;

        /// <summary>
        /// Creates a new <see cref="SumitomoNumberGenerator{TSet}"/>.
        /// </summary>
        /// <param name="dateTime">The provider of the date time.</param>
        /// <param name="typeNumber">The number of the entity type.</param>
        /// <param name="propertySelector"></param>
        public SumitomoNumberGenerator(IDateTimeProvider dateTime, int typeNumber, Expression<Func<TSet, string>> propertySelector)
        {
            _DateTime = dateTime;

            if (typeNumber < 25 || typeNumber > 49)
            {
                throw new InvalidOperationException("The type number exceeds the allowed value for this system. Numbers must be unique and be between 025 and 049");
            }

            _TypeNumber = typeNumber;
            _PropertySelector = propertySelector;
        }

        /// <inheritdoc/>
        public override string Next(EntityEntry entry)
        {
            Func<TSet, string> selector = _PropertySelector.Compile();
            DbSet<TSet> set = entry.Context.Set<TSet>() ?? throw new InvalidOperationException($"Provided value was not of an expected type. Type was {entry.Entity.GetType().Name}");
            TSet? databaseLast = set.OrderBy(_PropertySelector).LastOrDefault();
            TSet? localLast = set.Local.OrderBy(selector).LastOrDefault();
            return GetNextSumitomoNumber(databaseLast, localLast, selector);

        }
        //throw new InvalidOperationException($"Value generator for SumitomoNumber cannot get the next value synchronously. When using CRUD operations, use the asynchronous version (eg. AddAsync()).");

        /// <inheritdoc/>
        public override async ValueTask<string> NextAsync(EntityEntry entry, CancellationToken cancellationToken = default)
        {
            object? value = await NextValueAsync(entry, cancellationToken);
            if (value != null)
            {
                return (string)value;
            }

            return string.Empty;
        }

        /// <inheritdoc/>
        protected override async ValueTask<object?> NextValueAsync(EntityEntry entry, CancellationToken cancellationToken = default)
        {
            Func<TSet, string> selector = _PropertySelector.Compile();
            DbSet<TSet> set = entry.Context.Set<TSet>() ?? throw new InvalidOperationException($"Provided value was not of an expected type. Type was {entry.Entity.GetType().Name}");
            TSet? databaseLast = await set.OrderBy(_PropertySelector).LastOrDefaultAsync(cancellationToken: cancellationToken);
            TSet? localLast = set.Local.OrderBy(_PropertySelector.Compile()).LastOrDefault();
            return GetNextSumitomoNumber(databaseLast, localLast, selector);
        }

        string GetNextSumitomoNumber([AllowNull] TSet databaseLast, [AllowNull] TSet localLast, Func<TSet, string> selector)
        {
            string uid = string.Empty;
            string year = new string(_DateTime.UtcNow.Year.ToString(CultureInfo.InvariantCulture).TakeLast(2).ToArray());
            if (databaseLast == null && localLast == null)
            {
                uid = $"{1:000000}";
            }
            else
            {
                TSet? last = null;
                if (databaseLast == null && localLast != null)
                {
                    last = localLast;
                }
                else if (localLast == null && databaseLast != null)
                {
                    last = databaseLast;
                }
                else if (databaseLast != null && localLast != null)
                {
                    last = new[] { databaseLast, localLast }.OrderBy(selector).Last();
                }

                if (last != null)
                {
                    string sumitomoNumber = selector.Invoke(last);
                    string lastUid = sumitomoNumber[(sumitomoNumber.LastIndexOf("-", StringComparison.InvariantCulture) + 1)..];
                    uint value = uint.Parse(lastUid, CultureInfo.InvariantCulture) + 1;
                    uid = $"{value:000000}";
                }
                else
                {
                    uid = $"{1:000000}";
                }
            }

            return $"SEWS-{year:00}-{_TypeNumber:000}-{uid}";
        }
    }
}
