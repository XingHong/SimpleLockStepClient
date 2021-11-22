using Lockstep.Math;

public class CMover : EntityComponent
{
    public Player player => (Player)entity;
    public PlayerInput input => player.input;

    public LFloat speed => player.moveSpd;

    public override void DoUpdate(LFloat deltaTime)
    {
        int op = input.op;

        if (op < 0)
            return;

        LVector2 direct = LVector2.zero;
        switch (op)
        {
            case 1:
                direct.y = 1 * speed * deltaTime;
                break;
            case 2:
                direct.y = -1 * speed * deltaTime;
                break;
            case 3:
                direct.x = -1 * speed * deltaTime;
                break;
            case 4:
                direct.x = 1 * speed * deltaTime;
                break;
        }
        
        transform.pos = transform.pos + direct * speed * deltaTime;
    }
}
