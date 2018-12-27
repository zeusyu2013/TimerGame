using System.Collections.Generic;

public class PlayerExpInfo
{
    public int Level;
    public int Exp;
}

public class PlayerExp : IConfig
{
    private static List<PlayerExpInfo> PlayerExpInfos = new List<PlayerExpInfo>();

    public override void LoadConfig(string text, LoadConfigComplete cb)
    {
        PlayerExpInfos = LitJson.JsonMapper.ToObject<List<PlayerExpInfo>>(text);
        if (cb != null)
        {
            cb(PlayerExpInfos.Count > 0 ? true : false);
        }
    }

    public static PlayerExpInfo GetPlayerExpInfo(int level)
    {
        foreach (PlayerExpInfo info in PlayerExpInfos)
        {
            if (info == null)
            {
                continue;
            }

            if (info.Level == level)
            {
                return info;
            }
        }

        return null;
    }
}
