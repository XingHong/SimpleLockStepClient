using System.Collections;
using System.Collections.Generic;

namespace LockStep
{ 
    public class BattleLogic
    {
        private LockStepLogic m_lockStepLogic;
        private GameInputSystem m_inputSystem;
        private BattleUnitSystem m_battleUnitSystem;
#if _CLIENTLOGIC_
        private SimpleNet m_net;
#endif
        private LockStepData m_lockStepData;

        public BattleLogic()
        {
            Init();
        }
        public void Init()
        {
            UnityTools.Log("BattleLogic");
            m_lockStepData = new LockStepData();
            m_lockStepLogic = new LockStepLogic(this, m_lockStepData);
            m_inputSystem = new GameInputSystem();
            m_battleUnitSystem = new BattleUnitSystem();
#if _CLIENTLOGIC_
            m_net = new SimpleNet();
            m_net.Init(this);
#endif
        }

        public void Update()
        {
            SendOperation();
            m_lockStepLogic.UpdateNetFrame();
        }

        private void SendOperation()
        {
#if _CLIENTLOGIC_
            int op = m_inputSystem.GetOperation();
            m_net.SendOp(m_lockStepData.m_currentFrameID, op);
#endif
        }

        public void FrameLockLogic()
        {
            RecordLastPos();
            FrameData curData;
#if _CLIENTLOGIC_
            curData = m_net.GetFrameData(m_lockStepData.m_currentFrameID);
#endif
            m_battleUnitSystem.UpdateLogic(curData);
        }

        private void RecordLastPos()
        {
            m_battleUnitSystem.RecordLastPos();
        }

        public void UpdateRender(float interpolation)
        {
            m_battleUnitSystem.UpdateRender(interpolation);
        }

        public void SetOperation(int op)
        {
            m_inputSystem.SetOperation(op);
        }

        public void SetFrameId(int frameId)
        {
            m_lockStepData.m_netFrameID = frameId;
        }
    }
}
