using System.Collections;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;

public class SimulatorService : BaseGameService, ISimulatorService
{
    void OnEvent_Test(object param)
    {
        Debug.Log("OnEvent_Test!!!");
    }
}
