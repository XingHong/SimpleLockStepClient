using System.Collections;
using System.Collections.Generic;

public class BaseGameService : BaseService
{
    protected IGameConfigService gameConfigService;
    protected IGameEffectService gameEffectService;
    protected IGameResourceService gameResourceService;
    protected IGameStateService gameStateService;

    public override void InitReference(IServiceContainer serviceContainer, IManagerContainer managerContainer)
    {
        base.InitReference(serviceContainer, managerContainer);
        gameConfigService = serviceContainer.GetService<IGameConfigService>();
        gameEffectService = serviceContainer.GetService<IGameEffectService>();
        gameResourceService = serviceContainer.GetService<IGameResourceService>();
        gameStateService = serviceContainer.GetService<IGameStateService>();
    }
}
