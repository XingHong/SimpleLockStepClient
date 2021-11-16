using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMono : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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

        GameInputService.CurGameInput = new PlayerInput()
        {
            op = op,
        };
    }
}
