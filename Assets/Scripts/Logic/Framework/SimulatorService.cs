using System.Collections;
using System.Collections.Generic;
using Lockstep.Math;
//using Debug = Lockstep.Logging.Debug;
using Debug = UnityEngine.Debug;

public class SimulatorService : BaseGameService, ISimulatorService
{
    LFloat fAccumilatedTime;

    //下一个逻辑帧的时间
    LFloat fNextGameTime;

    //预定的每帧的时间长度
    LFloat fFrameLen;

    World world;

    public bool IsRunning { get; set; }

    public void StartSimulate()
    {
        if (IsRunning)
            return;
        IsRunning = true;
        world.StartGame();
    }

    public override void DoStart()
    {
        world = new World();
        int a = 1;
        int b = 33;
        fFrameLen = (LFloat)a / (LFloat)b;
        fAccumilatedTime = LFloat.zero;
        fNextGameTime = LFloat.zero;

        world.StartSimulate(serviceContainer, managerContainer);
    }

    public void DoUpdate(float deltaTime)
    {
        if (!IsRunning)
            return;
        UpdateLogic(deltaTime);
    }

    /// <summary>
    /// 单机帧同步
    /// </summary>
    private void UpdateLogic(float deltaTime)
    {
        /**************以下是帧同步的核心逻辑*********************/
        fAccumilatedTime = fAccumilatedTime + (LFloat)deltaTime;

        //如果真实累计的时间超过游戏帧逻辑原本应有的时间,则循环执行逻辑,确保整个逻辑的运算不会因为帧间隔时间的波动而计算出不同的结果
        while (fAccumilatedTime > fNextGameTime)
        {

            //运行与游戏相关的具体逻辑
            world.Step();

            //计算下一个逻辑帧应有的时间
            fNextGameTime += fFrameLen;

            //游戏逻辑帧自增
            //GameData.g_uGameLogicFrame += 1;
        }
    }

    private void OnGameCreate()
    { 
    }

    void OnEvent_Test(object param)
    {
        Debug.Log("OnEvent_Test!!!");
    }

    void OnEvent_OnGameCreate(object param)
    {
        Debug.Log("OnGameCreate!!!");
        StartSimulate();
    }
}
