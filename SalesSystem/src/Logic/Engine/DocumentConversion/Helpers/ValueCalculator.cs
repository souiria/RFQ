namespace DocumentConversion.Helpers
{
    public static class ValueCalculator
    {
        public static bool CalculateLogicalValue(string value, bool defaultValue)
        {
            value = value.ToUpperInvariant();
            if (value == "Y" || value == "T" || value == "YES" || value == "TRUE" || value == "1")
            {
                return true;
            }
            else if (value == "N" || value == "F" || value == "NO" || value == "false" || value == "0")
            {
                return false;
            }
            else
            {
                return defaultValue;
            }
        }

        public static string SetDefaultValue(string value, string defaultValue, string[] possibleValues)
        {
            if (possibleValues.Any(m => m.ToUpperInvariant() == value.ToUpperInvariant()))
            {
                return value;
            }
            else
            {
                return defaultValue;
            }
        }
    }
}
