namespace CDb.Extensions
{
    public static class EnumExtension
    {
        public static T GetEnumValueByDescription<T>(this string description) where T : System.Enum
        {
            System.Type t = typeof(T);
            if (!t.IsEnum)
            {
                throw new ArgumentException("Type is not an enum.", nameof(T));
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be null or empty.", nameof(description));
            }

            Array values = System.Enum.GetValues(t);
            foreach (System.Enum enumItem in values)
            {
                if (enumItem.GetEnumDescription() == description)
                {
                    return (T)enumItem;
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
        }
        public static string GetEnumDescription(this System.Enum enumValue)
        {
            string s = enumValue.ToString();
            FieldInfo? field = enumValue.GetType().GetField(s);
            if (field == null)
            {
                throw new ArgumentException("Field not found.", nameof(enumValue));
            }

            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            throw new ArgumentException("Not found.", nameof(enumValue));
        }
    }
}
