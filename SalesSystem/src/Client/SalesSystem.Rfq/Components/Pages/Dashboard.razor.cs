namespace SalesSystem.Rfq.Components.Pages
{
    class EarningReport
    {
        public string? Avatar;
        public string? Name;
        public string? Title;
        public Color Severity;
        public string? SeverityTitle;
        public string? Salary;
    }
    public partial class Dashboard
    {
        bool _ShowAdmin;
        string _AdminName = string.Empty;

        EarningReport[] _EarningReports = new EarningReport[]
        {
                new EarningReport { Name = "Lunees", Title = "Reactor Engineer", Avatar = "https://avatars2.githubusercontent.com/u/71094850?s=460&u=66c16f5bb7d27dc751f6759a82a3a070c8c7fe4b&v=4", Salary = "$0            .99", Severity = Color.Success, SeverityTitle = "Low"},
                new EarningReport { Name = "Mikes-gh", Title = "Developer", Avatar = "https://avatars.githubusercontent.com/u/16208742?s=120&v=4", Salary = "$19.12K", Severity = Color.Secondary, SeverityTitle = "Medium"},
                new EarningReport { Name = "Garderoben", Title = "CSS Magician", Avatar = "https://avatars2.githubusercontent.com/u/10367109?s=460&amp;u=2abf95f9e01132e8e2915def42895ffe99c5d2c6&amp;v=4", Salary = "$1337", Severity = Color.Primary, SeverityTitle = "High"},
        };
        public Dashboard()
        {
            _ShowAdmin = false;
            _AdminName = string.Empty;
        }

        [Parameter] public Guid? UserId
        { get; set; }

        [SupportedOSPlatform("windows")]
        protected override async Task OnInitializedAsync()
        {
            Guid? userId;
            string? userName;
            string? firstName;
            string? displayName;

            if (UserId == null || UserId == Guid.Empty)
            {
                AuthenticationState authState = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
                ClaimsPrincipal user = authState.User;
                if (user.Identity!.IsAuthenticated)
                {
                    userName = user.Identity.Name;
                    Logger.GenericLogInformation($">>> Loading Rfq.Dashboard with authenticated user: {userName}");
                    if (!string.IsNullOrEmpty(userName) && userName.Trim().ToUpperInvariant().EndsWith("CANACHL", StringComparison.OrdinalIgnoreCase))
                    {
                        _ShowAdmin = true;
                        _AdminName = userName;
                    }
                }
                else
                {
                    userName = "Anonymous";
                    Logger.GenericLogInformation($">>> Loading Rfq.Dashboard, cannot get authenticated user");
                }

#if DEBUG
                using (PrincipalContext context2 = new PrincipalContext(ContextType.Domain))
                {
                    UserPrincipal principal = UserPrincipal.FindByIdentity(context2, "williad");
                    firstName = principal?.GivenName;
                    // string lastName = principal.Surname;
                    displayName = principal?.DisplayName;
                    userId = new Guid("86380EFD-5651-4552-8145-E59E785F099A");
                }
#else
                using (PrincipalContext context2 = new PrincipalContext(ContextType.Domain))
                {
                    UserPrincipal principal = UserPrincipal.FindByIdentity(context2, userName);
                    firstName = principal?.GivenName;
                    // string lastName = principal.Surname;
                    displayName = principal?.DisplayName;
                    userId = principal?.Guid;
                }
#endif
                UserId = userId;

                // Preload alternative parts in background
                _ = PreloadAlternativePartsAsync();
            }
        }

        // preload Alternative parts as they are about 55K
        async Task PreloadAlternativePartsAsync()
        {
            try
            {
                if (RfqUxClientService.AlternativeParts.Count == 0)
                {
                    Logger.GenericLogInformation("Dashboard - Preloading alternative parts...");
                    Stopwatch sw = Stopwatch.StartNew();

                    int count = await RfqUxClientService.GetAllAlternativePartsAsync(0, -1);

                    sw.Stop();
                    Logger.GenericLogInformation($"Dashboard - Preloaded {count} alternative parts in {sw.ElapsedMilliseconds}ms");
                }
            }
            catch (InvalidOperationException ex)
            {
                Logger.GenericLogError("Dashboard - Error preloading alternative parts (InvalidOperationException)", ex);
            }
            catch (ArgumentException ex)
            {
                Logger.GenericLogError("Dashboard - Error preloading alternative parts (ArgumentException)", ex);
            }
            catch (Exception)
            {
                // Rethrow unexpected exceptions to avoid swallowing them
                throw;
            }
        }
    }
}    