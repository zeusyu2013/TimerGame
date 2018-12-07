using System.Collections.Generic;
using LitJson;

public class BaseConfig : IConfig
{
    public class BaseConfigInfo
    {
        public int ID { get; set; }
        public int Config { get; set; }
        public int Level { get; set; }
        public int NeedMoney { get; set; }
        public int GetMoney { get; set; }
        public string Des { get; set; }
    }
    
    private static List<BaseConfigInfo> baseConfigList = new List<BaseConfigInfo>();
    public override void LoadConfig(string text, LoadConfigComplete cb)
    {
        baseConfigList = JsonMapper.ToObject<List<BaseConfigInfo>>(text);

        if (cb != null)
        {
            cb();
        }
    }

    public static BaseConfigInfo GetBaseConfigInfo(int id)
    {
        foreach (BaseConfigInfo info in baseConfigList)
        {
            if (info.ID == id)
            {
                return info;
            }
        }

        return null;
    }
}
