using System.Collections;
using System.Collections.Generic;

public class BaseGameService : BaseService
{
    protected IGameConfigService gameConfigService;
    protected IGameEffectService gameEffectService;
    protected IGameResourceService gameResourceService;

    public override void InitReference(IServiceContainer serviceContainer)
    {
        base.InitReference(serviceContainer);
        gameConfigService = serviceContainer.GetService<IGameConfigService>();
        gameEffectService = serviceContainer.GetService<IGameEffectService>();
        gameResourceService = serviceContainer.GetService<IGameResourceService>();
    }
}
