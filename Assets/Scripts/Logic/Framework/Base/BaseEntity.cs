
using Lockstep.Collision2D;
using Lockstep.Math;
using System.Collections.Generic;

public class BaseEntity : BaseLifeCycle
{
    public int EntityId;
    public int PrefabId;

    public CTransform2D transform = new CTransform2D();
    public object engineTransform;
    protected List<BaseComponent> allComponents;

    public IGameStateService GameStateService { get; set; }
    public IServiceContainer ServiceContainer { get; set; }

    public T GetService<T>() where T : IService
    {
        return ServiceContainer.GetService<T>();
    }

    public void DoBindRef()
    {
        BindRef();
    }

    protected virtual void BindRef()
    {
        allComponents?.Clear();
    }

    protected void RegisterComponent(BaseComponent comp)
    {
        if (allComponents == null)
        {
            allComponents = new List<BaseComponent>();
        }
        allComponents.Add(comp);
        comp.BindEntity(this);
    }

    public override void DoAwake()
    {
        if (allComponents == null) return;
        foreach (var comp in allComponents)
        {
            comp.DoAwake();
        }
    }

    public override void DoStart()
    {
        if (allComponents == null) return;
        foreach (var comp in allComponents)
        {
            comp.DoStart();
        }
    }

    public override void DoUpdate(LFloat deltaTime)
    {
        if (allComponents == null) return;
        foreach (var comp in allComponents)
        {
            comp.DoUpdate(deltaTime);
        }
    }

    public override void DoDestroy()
    {
        if (allComponents == null) return;
        foreach (var comp in allComponents)
        {
            comp.DoDestroy();
        }
    }

}
