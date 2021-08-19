public class BaseService : ServiceReferenceHolder, ILifeCycle, IService, IHashCode
{
    public void DoAwake(IServiceContainer container)
    {
        throw new System.NotImplementedException();
    }

    public void DoDestroy()
    {
        throw new System.NotImplementedException();
    }

    public void DoStart()
    {
        throw new System.NotImplementedException();
    }

    public int GetHash(ref int idx)
    {
        throw new System.NotImplementedException();
    }

    public void OnApplicationQuit()
    {
        throw new System.NotImplementedException();
    }
}
