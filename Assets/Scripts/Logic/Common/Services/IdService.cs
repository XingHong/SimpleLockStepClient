public class IdService : IIdService
{
    private int Id;
    public int GenId()
    {
        return Id++;
    }
}
