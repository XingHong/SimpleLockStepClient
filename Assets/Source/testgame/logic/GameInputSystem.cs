using System.Collections;
using System.Collections.Generic;

public class GameInputSystem
{
    private int m_op = -1;
    public void SetOperation(int op)
    {
        m_op = op;
    }
    public int GetOperation()
    {
        return m_op;
    }
}
