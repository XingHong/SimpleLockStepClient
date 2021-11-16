using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    private ServiceContainer serviceContainer;

    public Launcher GameLauncher = new Launcher();
    void Awake()
    {
        gameObject.AddComponent<InputMono>();
        serviceContainer = new BaseGameServicesContainer();
        GameLauncher.DoAwake(serviceContainer);
    }

    void Start()
    {
        GameLauncher.DoStart();
    }

    void Update()
    {
        GameLauncher.DoUpdate(Time.deltaTime);
    }

    void OnDestroy()
    {
        GameLauncher.DoDestroy();
    }

    void OnApplicationQuit()
    {
        GameLauncher.OnApplicationQuit();
    }
}
