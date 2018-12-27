using System.Collections.Generic;

public class UpgradeExpInfo
{
    public int Level;
    public int Exp;
}

public class UpgradeExp : IConfig
{
    private static List<UpgradeExpInfo> UpgradeExpList = new List<UpgradeExpInfo>();

    public override void LoadConfig(string text, LoadConfigComplete cb)
    {
        UpgradeExpList = LitJson.JsonMapper.ToObject<List<UpgradeExpInfo>>(text);

        if (cb != null)
        {
            cb(UpgradeExpList.Count > 0 ? true : false);
        }
    }

    public static int GetExp(int level)
    {
        foreach (UpgradeExpInfo info in UpgradeExpList)
        {
            if (info.Level == level)
            {
                return info.Exp;
            }
        }

        return -1;
    }
}
