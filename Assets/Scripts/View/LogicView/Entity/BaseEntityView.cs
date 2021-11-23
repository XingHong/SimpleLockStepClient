using Lockstep.Math;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntityView : MonoBehaviour, IEntityView
{
    public BaseEntity baseEntity;

    public void BindEntity(BaseEntity e, BaseEntity oldEntity = null)
    {
        e.EntityView = this;
        this.baseEntity = e;
        var updateEntity = oldEntity ?? e;
        transform.position = updateEntity.transform.Pos3.ToVector3();
        transform.rotation = Quaternion.Euler(0, updateEntity.transform.deg.ToFloat(), 0);
    }

    public void OnDead()
    {
        GameObject.Destroy(gameObject);
    }

    public void OnRollbackDestroy()
    {
        GameObject.Destroy(gameObject);
    }

    public void OnTakeDamage(int amount, LVector3 hitPoint)
    {
        //throw new System.NotImplementedException();
    }
}
