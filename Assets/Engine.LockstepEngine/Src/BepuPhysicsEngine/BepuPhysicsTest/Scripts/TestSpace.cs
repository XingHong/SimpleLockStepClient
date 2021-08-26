using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BEPUphysics;
using FixMath.NET;

public class TestSpace : MonoBehaviour
{
    private BEPUphysics.Space _spcae;

    public float timeStepDuration = 0.01f;
    public float gravity = -9.81f;
    public float lockStepTime = 0.033f;

    public TestEntity[] entityList;

    void Start()
    {
        Time.fixedDeltaTime = lockStepTime;

        _spcae = new BEPUphysics.Space();
        TimeStepSettings timeStepSettings = _spcae.TimeStepSettings;
        timeStepSettings.TimeStepDuration = (Fix64)timeStepDuration;
        _spcae.TimeStepSettings = timeStepSettings;
        _spcae.ForceUpdater.Gravity = new BEPUutilities.Vector3(0, (Fix64)gravity, 0);

        foreach (TestEntity test in entityList)
        {
            _spcae.Add(test.entity);
        }
    }

    void FixedUpdate()
    {
        _spcae.Update((Fix64)lockStepTime);
    }
}
