using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LockStep
{
    public class LockStepData
    {
        public int m_currentFrameID;
        public int m_netFrameID;
        //预定的每帧的时间长度
        public static Fix64 m_fFrameLen;
        public LockStepData()
        {
            m_currentFrameID = 0;
            m_netFrameID = -1;
        }
    }
}

