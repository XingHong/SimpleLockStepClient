
public class UnityGameViewService : BaseGameService, IGameViewService
{
    public void BindView(BaseEntity entity, BaseEntity oldEntity = null)
    {
        throw new System.NotImplementedException();
    }

    public void UnbindView(BaseEntity entity)
    {
        entity.OnRollbackDestroy();
    }
}
