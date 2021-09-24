using Lockstep.Math;
using System;
[Serializable]
public class BaseLifeCycle
{
    public virtual void DoAwake() { }
    public virtual void DoStart() { }
    public virtual void DoUpdate(LFloat deltaTime) { }
    public virtual void DoDestroy() { }
}