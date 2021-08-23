using Lockstep.Math;
public class BaseSystem : BaseService
{
    public bool Enable = true;
    public virtual void DoUpdate(LFloat deltaTime) { }
}
