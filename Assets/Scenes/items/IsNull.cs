public class IsNull
{
    void Awake()
    {
    }

     public bool Judge<T>(T obj) where T : class
    {
        return obj == null;
    }
}
