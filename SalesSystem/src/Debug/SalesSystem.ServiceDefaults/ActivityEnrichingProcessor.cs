using OpenTelemetry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel;
using System.Security.Claims;
using System.Security.Principal;

namespace SalesSystem.ServiceDefaults
{
    public class ActivityEnrichingProcessor : BaseProcessor<Activity>
    {
        ICustomAuthenticationProvider _CustomAuthenticationProvider;
        public ActivityEnrichingProcessor(ICustomAuthenticationProvider authenticationStateProvider) 
        { 
        _CustomAuthenticationProvider = authenticationStateProvider;
        }
        public override async void OnEnd(Activity activity)
        {
            // The updated activity will be available to all processors which are called after this processor.
            //var test = context.User.Identity.Name;
            IIdentity user = await _CustomAuthenticationProvider.GetCurrentUser();
            string? userName = user.Name;
            if (user != null)
            {
                activity?.SetTag("enduser.id", userName);
            }
        }
    }
}
