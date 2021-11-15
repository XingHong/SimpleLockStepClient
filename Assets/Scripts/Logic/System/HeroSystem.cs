using Lockstep.Math;

public class HeroSystem : BaseSystem
{
    public override void DoUpdate(LFloat deltaTime)
    {
        foreach (var player in gameStateService.GetPlayers())
        {
            player.DoUpdate(deltaTime);
        }
    }

}
