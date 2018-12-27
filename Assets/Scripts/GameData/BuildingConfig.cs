using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo
{
    public int Config;
    public string Name;
    public int MaxLevel;
    public int GenerateBaseMoney;
}

public class BuildingConfig : IConfig
{
    private static List<BuildingInfo> buildingInfo = new List<BuildingInfo>();

    public override void LoadConfig(string text, LoadConfigComplete cb)
    {
        buildingInfo = LitJson.JsonMapper.ToObject<List<BuildingInfo>>(text);

        if (cb != null)
        {
            cb(buildingInfo.Count > 0 ? true : false);
        }
    }

    public static BuildingInfo GetBuildingInfo(int config)
    {
        foreach (BuildingInfo info in buildingInfo)
        {
            if (info == null)
            {
                continue;
            }

            if (info.Config == config)
            {
                return info;
            }
        }

        return null;
    }
}
