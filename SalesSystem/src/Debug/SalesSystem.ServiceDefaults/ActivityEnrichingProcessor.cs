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
        /// <summary>
        /// ICustomAuthenticationProvider _CustomAuthenticationProvider;
        /// </summary>
        /// <param name="authenticationStateProvider"></param>
        public ActivityEnrichingProcessor() 
        { 
       // _CustomAuthenticationProvider = authenticationStateProvider;
        }
        public override void OnEnd(Activity activity)
        {
           // if (_CustomAuthenticationProvider != null)
           // {
                // The updated activity will be available to all processors which are called after this processor.
                //var test = context.User.Identity.Name;
               // IIdentity user = await _CustomAuthenticationProvider.GetCurrentUser();
              //  string? userName = "testUser";
              //  if (userName != null)
              //  {
                   // activity?.SetTag("enduser.id", userName);
              //  }
            //} 
        }
    }
}
