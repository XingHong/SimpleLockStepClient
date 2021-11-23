using System.Collections;
using System.Collections.Generic;

public class BaseGameServicesContainer : ServiceContainer
{
    public BaseGameServicesContainer()
    {
        RegisterService(new SimulatorService());
        RegisterService(new GameStateService());
        RegisterService(new GameResourceService());
    }
}
