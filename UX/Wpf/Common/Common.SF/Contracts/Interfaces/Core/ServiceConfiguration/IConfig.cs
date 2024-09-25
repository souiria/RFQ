using Microsoft.ServiceFabric.Services.Remoting;
using Microsoft.ServiceFabric.Services.Runtime;

namespace Common.SF.Contracts.Interfaces.Core.Settings
{
    /// <summary>
    /// This interface is used during the start-up of <see cref="StatefulServiceBase"/>. If a Stateful Service is marked as
    /// <see cref="IConfig"/>, it will not attempt to retrieve any service settings from <see cref="IH1ServiceConfigurationSetting"/>s service 
    /// and will be given default settings instead.
    /// </summary>
    public interface IConfig :IService
    {
    }
}
