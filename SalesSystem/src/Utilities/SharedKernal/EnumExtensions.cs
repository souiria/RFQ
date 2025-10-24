namespace SharedKernel
{
    public static class EnumExtensions
    {
        public static int ToInt<T>(T enumValue) where T : Enum
        {
            return Convert.ToInt32(enumValue, CultureInfo.InvariantCulture);
        }

        public static T FromString<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public static T FromInt<T>(int intValue) where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), intValue);
        }
    }
}
