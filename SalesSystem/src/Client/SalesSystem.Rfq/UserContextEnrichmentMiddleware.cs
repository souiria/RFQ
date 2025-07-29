
namespace SalesSystem.Rfq
{
    public sealed class UserContextEnrichmentMiddleware(
        RequestDelegate next,
        ILogger<UserContextEnrichmentMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            // string? userId = context.User?.FindFirstValue(ClaimTypes.NameIdentifier);
             string? userId = context.User?.Identity?.Name;
            string? displayName = string.Empty;
#pragma warning disable CA1416 // Validate platform compatibility
            using (PrincipalContext context2 = new PrincipalContext(ContextType.Domain))
            {
                UserPrincipal principal = UserPrincipal.FindByIdentity(context2, userId);
              //  string firstName = principal.GivenName;
               // string lastName = principal.Surname;
               displayName = principal?.DisplayName;

            }
#pragma warning restore CA1416 // Validate platform compatibility

            //string? userId = "Dazza";
            if (displayName is not null)
            {
                string guid = Guid.NewGuid().ToString();
                Activity.Current?.SetTag("enduser.id", displayName);
                Activity.Current?.SetTag("enduser.pseudo.id", guid);

                Dictionary<string, object> data = new Dictionary<string, object>();
                //{
                //   // ["UserId"] = displayName!
                //};

                using (logger.BeginScope(data))
                {
                    await next(context);
                }
            }
            else
            {
                await next(context);
            }
        }
    }
}
