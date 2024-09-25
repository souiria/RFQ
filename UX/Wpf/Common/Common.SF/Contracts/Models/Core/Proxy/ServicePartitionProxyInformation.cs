namespace Common.SF.Contracts.Models.Core.Proxy
{
    public class ServicePartitionProxyInformation<T>
    {
        public T ServicePartitionReference { get; set; }
        public long PartitionKey { get; set; }
    }
}
