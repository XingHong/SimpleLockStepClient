using System;
using System.Collections.Generic;
using System.Linq;

public class ServiceContainer : IServiceContainer
{
    protected Dictionary<Type, IService> allServices = new Dictionary<Type, IService>();

    public void RegisterService(IService service)
    {
        var interfaceTypes = service.GetType().FindInterfaces((type, criteria) =>
        type.GetInterfaces().Any(t => t == typeof(IService)), service).ToArray();

        foreach (var type in interfaceTypes)
        {
            if (!allServices.ContainsKey(type))
            {
                allServices.Add(type, service);
            }
        }
    }

    public IService[] GetAllServices()
    {
        return allServices.Values.ToArray();
    }

    public T GetService<T>() where T : IService
    {
        var key = typeof(T);
        if (!allServices.ContainsKey(key))
        {
            return default(T);
        }
        return (T)allServices[key];

    }
}

