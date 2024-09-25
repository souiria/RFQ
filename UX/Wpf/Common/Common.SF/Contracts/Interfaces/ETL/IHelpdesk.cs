using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Core.Contracts.Models.Administration.Security;
using Common.Core.Contracts.Models.ETL.Helpdesk;
using Microsoft.ServiceFabric.Services.Remoting;

namespace Common.SF.Contracts.Interfaces.ETL
{
    public interface IHelpdesk : IService
    {
        Task<HelpdeskCallLog> GetHelpdeskCallById(string callId);
        Task<IEnumerable<HelpdeskApproval>> GetHelpdeskCallApprovalsById(string callId);
        Task<HelpdeskApproval> GetHelpdeskCallApprovalByApprovalId(string approvalId);
        Task<HelpdeskUserPreferences> GetHelpdeskUserPreferencesByUsername(string username);
        Task<HelpdeskCallLog> CreateHelpdeskCall(HelpdeskCallLog modelList);
        Task<IEnumerable<HelpdeskApproval>> CreateHelpdeskApprovals(IEnumerable<HelpdeskApproval> modelList);
        Task<HelpdeskCallLog> UpdateHelpdeskCall(HelpdeskCallLog helpdeskCall);
        Task<bool> IsApproved(string callId);
    }
}
