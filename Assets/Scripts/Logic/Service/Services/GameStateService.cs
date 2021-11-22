
using Lockstep.Math;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameStateService : BaseGameService, IGameStateService
{
    private Dictionary<Type, IList> type2Entities = new Dictionary<Type, IList>();
    private Dictionary<int, BaseEntity> id2Entities = new Dictionary<int, BaseEntity>();
    private void AddEntity<T>(T e) where T : BaseEntity
    {
        var t = e.GetType();
        if (type2Entities.TryGetValue(t, out var lstObj))
        {
            var lst = lstObj as List<T>;
            lst.Add(e);
        }
        else
        {
            var lst = new List<T>();
            type2Entities.Add(t, lst);
            lst.Add(e);
        }

        id2Entities[e.EntityId] = e;
    }

    public T CreateEntity<T>(int prefabId, LVector3 position) where T : BaseEntity, new()
    {
        var baseEntity = new T();
        baseEntity.EntityId = idService.GenId();
        baseEntity.PrefabId = prefabId;
        baseEntity.GameStateService = gameStateService;
        baseEntity.ServiceContainer = serviceContainer;
        baseEntity.DebugService = debugService;
        baseEntity.transform.Pos3 = position;
        debugService.Trace($"CreateEntity {prefabId} pos {prefabId} entityId:{baseEntity.EntityId}");
        baseEntity.DoBindRef();
        if (baseEntity is Entity entity)
        {
            //PhysicSystem.Instance.RegisterEntity(prefabId, entity);
        }

        baseEntity.DoAwake();
        baseEntity.DoStart();
        gameViewService.BindView(baseEntity);
        AddEntity(baseEntity);
        return baseEntity;
    }

    public Player[] GetPlayers()
    {
        return null;
    }
}
