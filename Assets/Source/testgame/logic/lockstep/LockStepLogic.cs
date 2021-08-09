using System.Collections;
using System.Collections.Generic;

namespace LockStep
{ 
    public class LockStepLogic
    {

        Fix64 m_fAccumilatedTime;

        //下一个逻辑帧的时间
        Fix64 m_fNextGameTime;

        //预定的每帧的时间长度
        Fix64 m_fFrameLen;

        //两帧之间的时间差
        Fix64 m_fInterpolation;

        //上次逻辑帧的时间
        float m_lastRenderTime;

        BattleLogic m_battleLogic;
        LockStepData m_locksStepData;
        public LockStepLogic(BattleLogic battle, LockStepData data)
        {
            m_battleLogic = battle;
            m_locksStepData = data;
            Init();
        }

        public void Init()
        {
            //每秒帧的速度
            float frame_interval = 1.0f / 20;
            m_fFrameLen = (Fix64)frame_interval;
            LockStepData.m_fFrameLen = m_fFrameLen;

            m_fAccumilatedTime = Fix64.Zero;

            m_fNextGameTime = Fix64.Zero;

            m_fInterpolation = Fix64.Zero;
        }

        /// <summary>
        /// 网络驱动帧同步
        /// </summary>
        public void UpdateNetFrame()
        {
            while(m_locksStepData.m_currentFrameID <= m_locksStepData.m_netFrameID)
            {
                UnityTools.Log("UpdateNetFrame:" + m_locksStepData.m_currentFrameID);
#if _CLIENTLOGIC_
                m_lastRenderTime = UnityEngine.Time.realtimeSinceStartup;
#endif
                m_battleLogic.FrameLockLogic();
                ++m_locksStepData.m_currentFrameID;
            }
#if _CLIENTLOGIC_
            m_fInterpolation = (UnityEngine.Time.realtimeSinceStartup - m_lastRenderTime) / m_fFrameLen;
#endif
            m_battleLogic.UpdateRender((float)m_fInterpolation);
        }

        /// <summary>
        /// 单机帧同步
        /// </summary>
        public void UpdateLogic()
        {
            float deltaTime = 0;
#if _CLIENTLOGIC_
            deltaTime = UnityEngine.Time.deltaTime;
#else
            deltaTime = 0.1f;
#endif

            /**************以下是帧同步的核心逻辑*********************/
            m_fAccumilatedTime = m_fAccumilatedTime + deltaTime;

            //如果真实累计的时间超过游戏帧逻辑原本应有的时间,则循环执行逻辑,确保整个逻辑的运算不会因为帧间隔时间的波动而计算出不同的结果
            while (m_fAccumilatedTime > m_fNextGameTime)
            {

                //运行与游戏相关的具体逻辑
                m_battleLogic.FrameLockLogic();

                //计算下一个逻辑帧应有的时间
                m_fNextGameTime += m_fFrameLen;

                //游戏逻辑帧自增
                //GameData.g_uGameLogicFrame += 1;
            }

            //计算两帧的时间差,用于运行补间动画
            m_fInterpolation = (m_fAccumilatedTime + m_fFrameLen - m_fNextGameTime) / m_fFrameLen;

            //更新表现层绘制位置
            //m_callUnit.updateRenderPosition(m_fInterpolation);
            /**************帧同步的核心逻辑完毕*********************/
        }
    }
}
