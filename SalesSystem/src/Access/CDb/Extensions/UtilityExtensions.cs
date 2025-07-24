namespace CDb.Extensions
{
    public static class UtilityExtensions
    {
        public static decimal ToDecimal(this double? dbl)
        {
            return dbl.HasValue && dbl <= (double)decimal.MaxValue ? (decimal)dbl : decimal.MaxValue;
        }
    }
}
