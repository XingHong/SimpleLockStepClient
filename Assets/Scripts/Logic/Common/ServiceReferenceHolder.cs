public class ServiceReferenceHolder
{
    protected IServiceContainer _serviceContainer;

    protected T GetService<T>() where T : IService
    {
        return _serviceContainer.GetService<T>();
    }

    public virtual void InitReference(IServiceContainer serviceContainer)
    {
    }
}
