namespace SharedKernel
{
   public interface ICustomAuthenticationProvider
    {
        Task<IIdentity> GetCurrentUser();
    }
}
