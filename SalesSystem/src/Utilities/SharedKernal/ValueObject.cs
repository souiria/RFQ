namespace SharedKernel
{
    /// <summary>
    /// NOTE: Use `readonly record struct` for most cases in C# 10+
    /// See: https://nietras.com/2021/06/14/csharp-10-record-struct/
    /// 
    /// For this class implementation, reference:
    /// See: https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
    /// </summary>
    [Serializable]
    public abstract class ValueObject : IComparable, IComparable<ValueObject>
    {
        int? _CachedHashCode;

        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (GetUnproxiedType(this) != GetUnproxiedType(obj))
            {
                return false;
            }

            ValueObject valueObject = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            if (!_CachedHashCode.HasValue)
            {
                _CachedHashCode = GetEqualityComponents()
                    .Aggregate(1, (current, obj) =>
                    {
                        unchecked
                        {
                            return current * 23 + (obj?.GetHashCode() ?? 0);
                        }
                    });
            }

            return _CachedHashCode.Value;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Type thisType = GetUnproxiedType(this);
            Type otherType = GetUnproxiedType(obj);

            if (thisType != otherType)
            {
                return string.Compare(thisType.ToString(), otherType.ToString(), StringComparison.Ordinal);
            }

            ValueObject other = (ValueObject)obj;

            object[] components = GetEqualityComponents().ToArray();
            object[] otherComponents = other.GetEqualityComponents().ToArray();

            for (int i = 0; i < components.Length; i++)
            {
                int comparison = CompareComponents(components[i], otherComponents[i]);
                if (comparison != 0)
                {
                    return comparison;
                }
            }

            return 0;
        }

        static int CompareComponents(object? object1, object? object2)
        {
            if (object1 is null && object2 is null)
            {
                return 0;
            }

            if (object1 is null)
            {
                return -1;
            }

            if (object2 is null)
            {
                return 1;
            }

            if (object1 is IComparable comparable1 && object2 is IComparable comparable2)
            {
                return comparable1.CompareTo(comparable2);
            }

            return object1.Equals(object2) ? 0 : -1;
        }

        public int CompareTo(ValueObject? other)
        {
            return CompareTo(other as object);
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }

        internal static Type GetUnproxiedType(object obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            const string eFCoreProxyPrefix = "Castle.Proxies.";
            const string nHibernateProxyPostfix = "Proxy";

            Type type = obj.GetType();
            string typeString = type.ToString();

            if (typeString.Contains(eFCoreProxyPrefix, StringComparison.Ordinal) || typeString.EndsWith(nHibernateProxyPostfix, StringComparison.Ordinal))
            {
                return type.BaseType!;
            }

            return type;
        }
        public static bool operator <(ValueObject left, ValueObject right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(ValueObject left, ValueObject right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(ValueObject left, ValueObject right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(ValueObject left, ValueObject right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}
