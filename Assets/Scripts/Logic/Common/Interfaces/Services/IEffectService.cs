using Lockstep.Math;

public interface IEffectService : IService
{
    void CreateEffect(int assetId, LVector2 pos);
    void DestroyEffect(object node);
}
