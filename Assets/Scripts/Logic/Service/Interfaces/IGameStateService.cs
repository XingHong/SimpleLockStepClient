using Lockstep.Math;
public interface IGameStateService : IService
{
    Player[] GetPlayers();

    T CreateEntity<T>(int prefabId, LVector3 position) where T : BaseEntity, new();
}
