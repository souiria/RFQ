using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Infrastructure.Endpoints
{
    public partial class NetCoreServiceEndpointRoutes
    {
        protected readonly string Name;

        protected NetCoreServiceEndpointRoutes(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public static implicit operator string(NetCoreServiceEndpointRoutes @enum)
        {
            return @enum.Name;
        }
    }
}
