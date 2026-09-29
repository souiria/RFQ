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

        //public static T FromInt<T>(int intValue) where T : Enum
        //{
        //    return (T)Enum.ToObject(typeof(T), intValue);
        //}
        public static T FromInt<T>(this int value) where T : Enum
        {
            if (Enum.IsDefined(typeof(T), value))
            {
                return (T)Enum.ToObject(typeof(T), value);
            }

            throw new ArgumentException($"Value '{value}' is not defined for enum '{typeof(T).FullName}'.");
        }
    }
}
