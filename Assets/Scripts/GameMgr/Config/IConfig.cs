public delegate void LoadConfigComplete();

public class IConfig
{
    public virtual void LoadConfig(string text, LoadConfigComplete cb)
    {
        
    }
}