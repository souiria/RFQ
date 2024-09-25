namespace UX.Commercial.Quotation;

[ModuleDependency("Themes, v1.0.0.0")]
[Roles("H1 Users")]
[Module(ModuleName = "Commercial Quotation Module, v1.0.0.0", OnDemand = false)]
public class QuotationModule : IModule
{
    private readonly IRegionManager _regionManager;
    private readonly IUnityContainer _unityContainer;

    public QuotationModule(IRegionManager regionManager, IUnityContainer unityContainer)
    {
        _regionManager = regionManager;
        _unityContainer = unityContainer;
    }

    public void Initialize()
    {
        _unityContainer.RegisterTypeForNavigation<QuotationMainWindow>();
    }
}