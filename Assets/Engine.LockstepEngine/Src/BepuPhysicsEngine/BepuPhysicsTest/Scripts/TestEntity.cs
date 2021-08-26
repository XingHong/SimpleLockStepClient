using System.Collections;
using System.Collections.Generic;
using BEPUphysics.Entities;
using BEPUphysics.Entities.Prefabs;
using BEPUutilities;
using FixMath.NET;
using UnityEngine;
using ConversionHelper;

public class TestEntity : MonoBehaviour
{
    public bool isDynamic = true;
    private UnityEngine.Vector3 _centerPos = UnityEngine.Vector3.zero;

    private Entity _entity;
    public Entity entity
    {
        get
        {
            return _entity;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        UnityEngine.Vector3 curPos = this.transform.position;
        UnityEngine.Vector3 curScale = this.transform.lossyScale;

        Collider collider = this.GetComponent<Collider>();
        if (collider is BoxCollider)
        {
            BoxCollider box = (BoxCollider)collider;
            _centerPos = box.center;
            BEPUutilities.Vector3 initPos = MathConverter.Convert(curPos + _centerPos);
            _entity = new Box(initPos, (Fix64)(box.size.x * curScale.x), (Fix64)(box.size.y * curScale.y), (Fix64)(box.size.z * curScale.z), isDynamic ? 1 : 0);
        }
        else if (collider is SphereCollider)
        {
            SphereCollider sphere = (SphereCollider)collider;
            _centerPos = sphere.center;
            BEPUutilities.Vector3 initPos = MathConverter.Convert(curPos + _centerPos);
            _entity = new Sphere(initPos, (Fix64)(sphere.radius * Mathf.Max(curScale.x, curScale.y, curScale.z)), isDynamic ? 1 : 0);
        }
        if (_entity != null)
        {
            _entity.Orientation = MathConverter.Convert(this.transform.rotation);
        }
    }

    void Update()
    {
        
        UnityEngine.Vector3 curPosition = MathConverter.Convert(_entity.Position);
        this.transform.position = curPosition - _centerPos;
        UnityEngine.Quaternion curRotation = MathConverter.Convert(_entity.Orientation);
        this.transform.rotation = curRotation;
    }

}
