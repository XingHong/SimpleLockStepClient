public class UnityServiceContainer : BaseGameServicesContainer
{
    public UnityServiceContainer() : base()
    {
        RegisterService(new UnityGameViewService());
    }
}
