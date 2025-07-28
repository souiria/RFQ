namespace SalesSystem.ServiceDefaults
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider, ICustomAuthenticationProvider
    {
        readonly IHttpContextAccessor _HttpContextAccessor;
        public CustomAuthenticationStateProvider(IHttpContextAccessor httpContextAccessor)
        {
            _HttpContextAccessor = httpContextAccessor;
        }

        public Task<IIdentity> GetCurrentUser()
        {
            return Task.FromResult(_HttpContextAccessor.HttpContext!.User.Identity!);
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            IIdentity identity = _HttpContextAccessor.HttpContext!.User.Identity!;
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}
