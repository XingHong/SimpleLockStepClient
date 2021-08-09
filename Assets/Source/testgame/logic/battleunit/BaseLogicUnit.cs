using System.Collections;
using System.Collections.Generic;
#if _CLIENTLOGIC_
using UnityEngine;
#endif

namespace LockStep
{
    public class BaseLogicUnit
    {
        protected FixVector3 m_fixv3LastPosition = new FixVector3(Fix64.Zero, Fix64.Zero, Fix64.Zero);
        //位置
        protected FixVector3 m_fixv3LogicPosition = new FixVector3(Fix64.Zero, Fix64.Zero, Fix64.Zero);
        //旋转
        protected FixVector3 m_fixv3LogicRotation = new FixVector3(Fix64.Zero, Fix64.Zero, Fix64.Zero);
        //缩放值
        protected FixVector3 m_fixv3LogicScale = new FixVector3(Fix64.One, Fix64.One, Fix64.One);

#if _CLIENTLOGIC_
        protected GameObject m_gameObject;
#endif

        public BaseLogicUnit()
        {

        }

        public void RecordLastPos()
        {
            m_fixv3LastPosition = m_fixv3LogicPosition;
        }

        public virtual void UpdateLogic()  
        { 
        }

        public virtual void UpdateRender(float interpolation)
        {
            UpdatePosition(interpolation);
        }

        private void UpdatePosition(float interpolation)
        {
            //只有会移动的对象才需要采用插值算法补间动画,不会移动的对象直接设置位置即可
            if (interpolation != 0)
            {
                m_gameObject.transform.localPosition = Vector3.Lerp(m_fixv3LastPosition.ToVector3(), m_fixv3LogicPosition.ToVector3(), interpolation);
            }
            else
            {
                m_gameObject.transform.localPosition = m_fixv3LogicPosition.ToVector3();
            }
        }
    }
}

