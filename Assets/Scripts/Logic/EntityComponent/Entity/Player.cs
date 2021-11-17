

using Lockstep.Math;

public class Player : Entity
{
    public int localId;
    public PlayerInput input = new PlayerInput();

    public override void DoUpdate(LFloat deltaTime)
    {
        base.DoUpdate(deltaTime);
    }
}
