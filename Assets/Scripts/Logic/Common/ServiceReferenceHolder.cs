public class ServiceReferenceHolder
{
    protected IServiceContainer serviceContainer;
    protected IManagerContainer managerContainer;
    protected IMapService mapService;
    protected IEventRegisterService eventRegiserService;
    protected IIdService idService;
    protected IResService resService;
    protected ICommonStateService commonStateService;
    protected IRandomService randomService;
    protected IInputService inputService;
    protected IEffectService effectService;
    protected IDebugService debugService;

    protected T GetService<T>() where T : IService
    {
        return serviceContainer.GetService<T>();
    }

    public virtual void InitReference(IServiceContainer serviceContainer, IManagerContainer managerContainer)
    {
        this.serviceContainer = serviceContainer;
        this.managerContainer = managerContainer;
        mapService = serviceContainer.GetService<IMapService>();
        eventRegiserService = serviceContainer.GetService<IEventRegisterService>();
        idService = serviceContainer.GetService<IIdService>();
        resService = serviceContainer.GetService<IResService>();
        commonStateService = serviceContainer.GetService<ICommonStateService>();
        randomService = serviceContainer.GetService<IRandomService>();
        inputService = serviceContainer.GetService<IInputService>();
        effectService = serviceContainer.GetService<IEffectService>();
        debugService = serviceContainer.GetService<IDebugService>();
    }
}
