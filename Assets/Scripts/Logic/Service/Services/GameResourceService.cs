using System.Collections.Generic;
using UnityEngine;
public class GameResourceService : BaseGameService, IGameResourceService
{
    public string pathPrefix = "Prefabs/";
    private Dictionary<int, GameObject> id2Prefab = new Dictionary<int, GameObject>();

    public object LoadPrefab(int id)
    {
        if (id2Prefab.TryGetValue(id, out var val))
        {
            return val;
        }
        var prefab = (GameObject)Resources.Load(pathPrefix + "Tower");
        id2Prefab[id] = prefab;
        return prefab;
    }
}
