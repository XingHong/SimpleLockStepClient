using Lockstep.Math;

public interface IEntityView : IView
{
    void OnTakeDamage(int amount, LVector3 hitPoint);
    void OnDead();
    void OnRollbackDestroy();
}
