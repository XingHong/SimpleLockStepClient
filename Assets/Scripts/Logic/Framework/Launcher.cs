using System.Collections;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;

public class Launcher : ILifeCycle
{
    private ServiceContainer serviceContainer;
    private ManagerContainer mgrContainer;
    private IEventRegisterService eventService;

    public static Launcher Instance { get; private set; }

    public void DoAwake(IServiceContainer container)
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
        serviceContainer = container as ServiceContainer;
        mgrContainer = new ManagerContainer();
        eventService = new EventRegisterService();

        var svcs = serviceContainer.GetAllServices();
        foreach (var service in svcs)
        {
            if (service is BaseService baseService)
            {
                mgrContainer.RegisterManager(baseService);
            }
        }

        serviceContainer.RegisterService(eventService);
    }

    public void DoStart()
    {
        foreach (var mgr in mgrContainer.AllMgrs)
        {
            mgr.InitReference(serviceContainer, mgrContainer);
        }

        foreach (var mgr in mgrContainer.AllMgrs)
        {
            eventService.RegisterEvent<EEvent, GlobalEventHandler>("OnEvent", EventHelper.AddListener, mgr);
        }

        foreach (var mgr in mgrContainer.AllMgrs)
        {
            mgr.DoAwake(serviceContainer);
        }

        foreach (var mgr in mgrContainer.AllMgrs)
        {
            mgr.DoStart();
        }

        EventHelper.Trigger(EEvent.Test);
        EventHelper.Trigger(EEvent.OnGameCreate);
    }

    public void DoUpdate(float deltaTime)
    {

    }

    public void DoDestroy()
    {
        if (Instance == null)
            return;
        foreach (var mgr in mgrContainer.AllMgrs)
        {
            mgr.DoDestroy();
        }
        Instance = null;
    }

    public void OnApplicationQuit()
    {
        DoDestroy();
    }
}
