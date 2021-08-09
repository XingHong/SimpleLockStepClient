using System.Collections;
using System.Collections.Generic;

namespace LockStep
{ 
    public class PlayerUnit : BaseLogicUnit
    {
        private Fix64 speed = (Fix64)10.0f;
        public PlayerUnit()
        {
#if _CLIENTLOGIC_
            m_gameObject = UnityEngine.GameObject.Find("Player");
            m_gameObject.transform.localPosition = m_fixv3LogicPosition.ToVector3();
            m_gameObject.transform.localEulerAngles = m_fixv3LogicRotation.ToVector3();
            m_gameObject.transform.localScale = m_fixv3LogicScale.ToVector3();
#endif
        }
        public void Input(int op)
        {
            if (op < 0)
                return;

            FixVector3 direct = new FixVector3(Fix64.Zero, Fix64.Zero, Fix64.Zero);
            switch (op)
            {
                case 1:
                    direct.z = Fix64.One * speed * LockStepData.m_fFrameLen;
                    break;
                case 2:
                    direct.z = -Fix64.One * speed * LockStepData.m_fFrameLen;
                    break;
                case 3:
                    direct.x = -Fix64.One * speed * LockStepData.m_fFrameLen;
                    break;
                case 4:
                    direct.x = Fix64.One * speed * LockStepData.m_fFrameLen;
                    break;
            }
            m_fixv3LogicPosition = m_fixv3LogicPosition + direct;
        }
    }
}
