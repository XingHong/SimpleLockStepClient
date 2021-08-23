public class BaseService : ServiceReferenceHolder, ILifeCycle, IService, IHashCode
{
    public virtual void DoInit(object objParent) { }

    public virtual void DoAwake(IServiceContainer container) { }

    public virtual void DoDestroy() { }

    public virtual void DoStart() { }

    public virtual int GetHash(ref int idx)
    {
        return 0;
    }

    public virtual void OnApplicationQuit() { }
}
