public class ServiceReferenceHolder
{
    protected IServiceContainer serviceContainer;
    protected IMapService mapService;
    protected IEventRegisterService eventRegiserService;
    protected IIdService idService;

    protected T GetService<T>() where T : IService
    {
        return serviceContainer.GetService<T>();
    }

    public virtual void InitReference(IServiceContainer serviceContainer)
    {
        this.serviceContainer = serviceContainer;
        mapService = serviceContainer.GetService<IMapService>();
        eventRegiserService = serviceContainer.GetService<IEventRegisterService>();
        idService = serviceContainer.GetService<IIdService>();
    }
}
