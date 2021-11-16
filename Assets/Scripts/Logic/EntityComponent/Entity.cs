

using Lockstep.Math;

public partial class Entity : BaseEntity
{
    public LFloat moveSpd = 5;
    public LFloat turnSpd = 360;

    protected override void BindRef()
    {
        base.BindRef();
    }
}
