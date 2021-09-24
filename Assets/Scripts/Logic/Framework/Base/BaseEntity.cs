
using Lockstep.Collision2D;
using System.Collections.Generic;

public class BaseEntity : BaseLifeCycle
{
    public int EntityId;
    public int PrefabId;

    public CTransform2D transform = new CTransform2D();
    protected List<BaseComponent> allComponents;

}
