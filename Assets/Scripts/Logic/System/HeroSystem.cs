using Lockstep.Math;

public class HeroSystem : BaseSystem
{
    public override void DoUpdate(LFloat deltaTime)
    {
        if (gameStateService.GetPlayers() == null)
            return;
        foreach (var player in gameStateService.GetPlayers())
        {
            player.DoUpdate(deltaTime);
        }
    }

}
