namespace UX.Commercial.Pricing;

[ModuleDependency("Themes, v1.0.0.0")]
[Roles("H1 Users")]
[Module(ModuleName = "Commercial Pricing Module, v1.0.0.0", OnDemand = false)]
public class PricingModule : IModule
{
    private readonly IRegionManager _regionManager;
    private readonly IUnityContainer _unityContainer;

    public PricingModule(IRegionManager regionManager, IUnityContainer unityContainer)
    {
        _regionManager = regionManager;
        _unityContainer = unityContainer;
    }

    public void Initialize()
    {
        _unityContainer.RegisterTypeForNavigation<PricingMainWindow>();
        _unityContainer.RegisterTypeForNavigation<Welcome>();
    }
}