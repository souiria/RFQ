using SEWSE.H1.Common.Contracts;
using SEWSE.H1.Common.ServiceApi;
using System;

namespace SEWSE.H1.UX.Infrastructure.Core.Helpers
{
    public static class ClusterApiHelper
    {
        public static ServiceApi GetServiceApi(ServiceEndPointRoutes route) => new ServiceApi(EndpointHelper.EndpointAddress, "19081", route, ServiceFabricApplicationsNode.HarnessOneSF);
        public static ServiceApi GetServiceApi(ServiceEndPointRoutes route, Guid id) => new ServiceApi(EndpointHelper.EndpointAddress, "19081", route, id, ServiceFabricApplicationsNode.HarnessOneSF);
        //TODO: Remove method below. 
        public static ServiceApi GetServiceApi(ServiceEndPointRoutes route, string parameters) => new ServiceApi(EndpointHelper.EndpointAddress, "19081", route, parameters, ServiceFabricApplicationsNode.HarnessOneSF);
        public static ServiceApi GetLocalApi(ServiceEndPointRoutes route) => new ServiceApi("localhost", "19081", route, ServiceFabricApplicationsNode.HarnessOneSF);
        public static ServiceApi GetLocalApi(ServiceEndPointRoutes route, Guid id) => new ServiceApi("localhost", "19081", route, id, ServiceFabricApplicationsNode.HarnessOneSF);
        public static ServiceApi GetLocalApi(ServiceEndPointRoutes route, string parameters) => new ServiceApi("localhost", "19081", route, parameters, ServiceFabricApplicationsNode.HarnessOneSF);
    }
}