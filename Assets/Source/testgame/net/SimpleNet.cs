using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using LockStep;

public class SimpleNet
{
    private SimpleSocket m_socket;
    private LockStep.BattleLogic m_battleLogic;
    private Dictionary<int, FrameData> m_FrameDataList;
    public void Init(LockStep.BattleLogic battleLogic)
    {
        m_battleLogic = battleLogic;
        m_socket = new SimpleSocket();
        m_socket.Init();
        m_socket.SetNet(this);
        m_FrameDataList = new Dictionary<int, FrameData>();
    }

    public void Recive(int eventId, byte[] buffer)
    {
        //返回当前帧的操作
        if (eventId == 1)
        {
            byte[] tmp = new byte[4];
            Array.Copy(buffer, 1, tmp, 0, 4);
            int frameId = BitConverter.ToInt32(tmp, 0);
            Array.Copy(buffer, 5, tmp, 0, 4);
            Console.WriteLine("frameId: " + frameId);
            int op = BitConverter.ToInt32(tmp, 0);
            Console.WriteLine("op: " + op);
            FrameData data = new FrameData();
            data.frameId = frameId;
            data.op = op;
            if (!m_FrameDataList.ContainsKey(frameId))
            { 
                m_FrameDataList.Add(frameId, data);
                m_battleLogic.SetFrameId(frameId);
            }
        }
    }

    public FrameData GetFrameData(int frameId)
    {
        if (m_FrameDataList.ContainsKey(frameId))
        {
            return m_FrameDataList[frameId];
        }
        return null;
    }

    public void SendOp(int frameId, int op)
    {
        List<byte> info = new List<byte>();
        info.Add(1);        //1代表是发送操作数。
        info.AddRange(int2bytes(frameId));      //当前帧号
        info.AddRange(int2bytes(op));
        byte[] buffer = info.ToArray();
        m_socket.SendBytes(info.ToArray());
    }

    private byte[] int2bytes(Int32 intValue)
    {
        byte[] intBytes = BitConverter.GetBytes(intValue);
        return intBytes;
    }
}
