namespace Transformation.Helpers
{
    public static class ErrorCheckHelper
    {
        public static void CheckLineLengthException(int length, int minLength, string line)
        {
            if (length < minLength)
            {
                throw new FormatException($"Line {line} does not contain correct number of elements as noted in dsi specification");
            }
        }

        public static DateTime CheckDateTimeFormatException(string dateTime)
        {
            string[] formats = { "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                    "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy,", "MM/dd/yyyy", "M/dd/yyyy", "M/d/yyyy", "MM/d/yyyy",
                    "MM/dd/yy", "M/d/yy", "M/d/yy", "MM/d/yy"};

            if (DateTime.TryParse(dateTime, out DateTime result))
            {
                return result;
            }

            if (DateTime.TryParseExact(dateTime, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result2))
            {
                return result2;
            }

            throw new FormatException($"DateTime {dateTime} is not in correct format DD/MM/YYYY as noted in dsi specification");
        }
    }
}
