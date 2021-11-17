using Lockstep.Math;

public class CMover : EntityComponent
{
    public Player player => (Player)entity;
    public PlayerInput input => player.input;

    public LFloat speed => player.moveSpd;

    public override void DoUpdate(LFloat deltaTime)
    {
        int op = input.op;
    }
}
