using Lockstep.Math;
public class BaseSystem : BaseGameService
{
    public bool Enable = true;
    public virtual void DoUpdate(LFloat deltaTime) { }
}
