using Lockstep.Math;
using Lockstep.Collision2D;
public class BaseComponent
{
    public BaseEntity baseEntity { get; private set; }
    public CTransform2D transform { get; private set; }

    public virtual void BindEntity(BaseEntity entity)
    {
        this.baseEntity = entity;
        transform = entity.transform;
    }

    public virtual void DoAwake() { }
    public virtual void DoStart() { }
    public virtual void DoUpdate(LFloat deltaTime) { }
    public virtual void DoDestroy() { }
}
