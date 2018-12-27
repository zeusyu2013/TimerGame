public delegate void LoadConfigComplete(bool success);

public class IConfig
{
    public virtual void LoadConfig(string text, LoadConfigComplete cb)
    {
        
    }
}