using System;
using System.Collections.Generic;

public class ManagerContainer : IManagerContainer
{
    private Dictionary<string, BaseService> name2Mgr = new Dictionary<string, BaseService>();
    public List<BaseService> AllMgrs = new List<BaseService>();

    public void RegisterManager(BaseService service)
    {
        var name = service.GetType().Name;
        if (name2Mgr.ContainsKey(name))
        {
            return;
        }

        name2Mgr.Add(name, service);
        AllMgrs.Add(service);
    }
    public T GetManager<T>() where T : BaseService
    {
        if (name2Mgr.TryGetValue(typeof(T).Name, out var val))
        {
            return val as T;
        }
        return null;
    }
}
