using System.Collections;
using System.Collections.Generic;

public class World : BaseSystem
{
    private List<BaseSystem> systems = new List<BaseSystem>();

    public void StartSimulate(IServiceContainer serviceContainer, IManagerContainer mgrContainer)
    {
        RegisterSystems();
        InitReference(serviceContainer, mgrContainer);
        foreach (var mgr in systems)
        {
            mgr.InitReference(serviceContainer, mgrContainer);
        }

        foreach (var mgr in systems)
        {
            mgr.DoAwake(serviceContainer);
        }

        DoAwake(serviceContainer);
        foreach (var mgr in systems)
        {
            mgr.DoStart();
        }
    }

    private void RegisterSystems()
    { 
    }

    private void RegisterSystem(BaseSystem mgr)
    {
        systems.Add(mgr);
    }
}
