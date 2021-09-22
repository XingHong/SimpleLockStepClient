using System.Collections;
using System.Collections.Generic;
using Lockstep.Math;
using Debug = UnityEngine.Debug;

public class SimulatorService : BaseGameService, ISimulatorService
{
    LFloat fAccumilatedTime;

    //下一个逻辑帧的时间
    LFloat fNextGameTime;

    //预定的每帧的时间长度
    LFloat fFrameLen;

    //两帧之间的时间差
    LFloat fInterpolation;

    public void DoUpdate(float deltaTime)
    { 
    }

    /// <summary>
    /// 单机帧同步
    /// </summary>
    public void UpdateLogic(float deltaTime)
    {
        /**************以下是帧同步的核心逻辑*********************/
        fAccumilatedTime = fAccumilatedTime + (LFloat)deltaTime;

        //如果真实累计的时间超过游戏帧逻辑原本应有的时间,则循环执行逻辑,确保整个逻辑的运算不会因为帧间隔时间的波动而计算出不同的结果
        while (fAccumilatedTime > fNextGameTime)
        {

            //运行与游戏相关的具体逻辑
            //battleLogic.FrameLockLogic();

            //计算下一个逻辑帧应有的时间
            fNextGameTime += fFrameLen;

            //游戏逻辑帧自增
            //GameData.g_uGameLogicFrame += 1;
        }

        //计算两帧的时间差,用于运行补间动画
        fInterpolation = (fAccumilatedTime + fFrameLen - fNextGameTime) / fFrameLen;

        //更新表现层绘制位置
        //m_callUnit.updateRenderPosition(m_fInterpolation);
        /**************帧同步的核心逻辑完毕*********************/
    }

    void OnEvent_Test(object param)
    {
        Debug.Log("OnEvent_Test!!!");
    }
}
