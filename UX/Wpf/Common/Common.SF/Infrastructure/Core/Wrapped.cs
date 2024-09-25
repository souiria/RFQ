namespace Common.SF.Infrastructure.Core
{
    internal abstract class Wrapped<T>
    {
        protected T Value { get; }

        protected Wrapped(T value)
        {
            Value = value;
        }
    }
}
