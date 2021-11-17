public class EntityComponent : BaseComponent
{
    public Entity entity => (Entity)baseEntity;
    public IGameStateService GameStateService => entity.GameStateService;
    public IDebugService DebugService => entity.DebugService;
}
