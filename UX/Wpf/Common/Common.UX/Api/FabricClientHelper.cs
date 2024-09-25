using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Fabric;
using System.Fabric.Description;
using System.Fabric.Query;
using Common.UX.Contracts.Interfaces.Core;
using Common.UX.Helpers;
using Common.UX.Api.Endpoints;

namespace Common.UX.Api
{
    public sealed class FabricClientHelper
    {
        private readonly FabricClient fabricClient = new FabricClient($"{ EndpointHelper.EndpointAddress }:19000");
        public FabricClientHelper()
        {
            //fabricClient = new FabricClient($"{ EndpointHelper.EndpointAddress }:19000");
        }
        private static readonly Lazy<FabricClientHelper> Instance = new Lazy<FabricClientHelper>();
        public static FabricClientHelper GetInstance
        {
            get
            {
                return Instance.Value;
            }
        }
        public Uri GetUriFromServiceRoute(string serviceRoute)
        {
            string serviceFabricURI = string.Join("/", serviceRoute.Split('/').Take(2).ToArray());
            return new Uri($"fabric:/{ serviceFabricURI }");
        }
        public async Task<List<long>> GetServicePartitionsLowKeyAsync(ServiceEndpointRoutes serviceRoute)
        {
            List<long> PartitionsInformation = new List<long>();
            try
            {
                var partitions = await fabricClient.QueryManager.GetPartitionListAsync(GetUriFromServiceRoute(serviceRoute.ToString()));
                if (partitions.Count > 0)
                {
                    PartitionsInformation = partitions.Select(it => new
                    {
                        LowKey = it.PartitionInformation.Kind == System.Fabric.ServicePartitionKind.Singleton ? 0 : ((Int64RangePartitionInformation)it.PartitionInformation).LowKey,
                    }).Select(it => it.LowKey).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return PartitionsInformation;
        }
    }
}
