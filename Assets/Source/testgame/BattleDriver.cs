using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LockStep;

public class BattleDriver : MonoBehaviour
{
    LockStep.BattleLogic m_logic;
    void Start()
    {
        m_logic = new LockStep.BattleLogic();
    }

    // Update is called once per frame
    void Update()
    {
        int op = -1;
        if (Input.GetKey(KeyCode.W))
        {
            op = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            op = 2;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            op = 3;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            op = 4;
        }
        //UnityTools.Log("Send op:" + op);
        m_logic.SetOperation(op);
        m_logic.Update();
    }
}