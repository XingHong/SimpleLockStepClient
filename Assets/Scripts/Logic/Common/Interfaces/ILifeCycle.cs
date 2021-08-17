interface ILifeCycle
{
    void DoAwake(IServiceContainer container);
    void DoStart();
    void DoDestroy();
    void OnApplicationQuit();
}

