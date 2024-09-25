namespace Common.UX.Api.Endpoints
{
    public partial class ServiceEndpointRoutes
    {
        protected readonly string Name;

        protected ServiceEndpointRoutes(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static implicit operator string(ServiceEndpointRoutes @enum)
        {
            return @enum.Name;
        }
    }
}
