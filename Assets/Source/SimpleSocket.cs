using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class SimpleSocket {

    private Socket socketClient;
    private static SimpleNet simpleNet;

    // Use this for initialization
    public void Init () {
        //创建实例
        socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //IPAddress ip = IPAddress.Parse("127.0.0.1");
        IPAddress ip = IPAddress.Parse("192.168.31.60");
        IPEndPoint point = new IPEndPoint(ip, 2333);
        //进行连接
        socketClient.Connect(point);

        //不停的接收服务器端发送的消息
        Thread thread = new Thread(Recive);
        thread.IsBackground = true;
        thread.Start(socketClient);
    }

    public void SetNet(SimpleNet sNet)
    {
        simpleNet = sNet;
    }

    /// <summary>
    /// 接收消息
    /// </summary>
    /// <param name="o"></param>
    static void Recive(object o)
    {
        var send = o as Socket;
        while (true)
        {
            //获取发送过来的消息
            byte[] buffer = new byte[2048];
            var effective = send.Receive(buffer);
            if (effective == 0)
            {
                break;
            }
            simpleNet.Recive(buffer[0], buffer);
        }
    }

    public void sendBattleRecordToServer(string record)
    {
        var buffter = Encoding.UTF8.GetBytes(record);
        var temp = socketClient.Send(buffter);
        //Thread.Sleep(1000);
    }

    public void SendBytes(byte[] bytes)
    {
        socketClient.Send(bytes);
    }

    private static byte[] int2bytes(Int32 intValue)
    {
        byte[] intBytes = BitConverter.GetBytes(intValue);
        return intBytes;
    }
}