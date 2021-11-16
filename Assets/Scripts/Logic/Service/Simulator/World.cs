using Lockstep.Math;
using System.Collections;
using System.Collections.Generic;

public class World : BaseSystem
{
    private List<BaseSystem> systems = new List<BaseSystem>();
    public int Tick { get; set; }

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
        Tick = 0;
    }

    public void StartGame()
    { 
    }

    private void RegisterSystems()
    {
        RegisterSystem(new HeroSystem());
    }

    private void RegisterSystem(BaseSystem mgr)
    {
        systems.Add(mgr);
    }

    public void Step()
    {
        var deltaTime = new LFloat(true, 30);
        foreach (var system in systems)
        {
            if (system.Enable)
            {
                system.DoUpdate(deltaTime);
            }
        }
        Tick++;
    }

    public override void DoDestroy()
    {
        base.DoDestroy();
        foreach (var mgr in systems)
        {
            mgr.DoDestroy();
        }
    }

    public override void OnApplicationQuit()
    {
        DoDestroy();
    }
}
