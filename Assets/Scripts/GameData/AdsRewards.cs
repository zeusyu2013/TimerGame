using System.Collections.Generic;

public class AdsRewardsInfo
{
    public int rewardId;
    public int rewardItemId;
}

public class AdsRewards : IConfig
{
    private static List<AdsRewardsInfo> AdsRewardsInfos = new List<AdsRewardsInfo>();

    public override void LoadConfig(string text, LoadConfigComplete cb)
    {
        AdsRewardsInfos = LitJson.JsonMapper.ToObject<List<AdsRewardsInfo>>(text);

        if (cb != null)
        {
            cb(AdsRewardsInfos.Count > 0 ? true : false);
        }
    }

    public static AdsRewardsInfo GetAdsRewardsInfo(int id)
    {
        foreach (AdsRewardsInfo info in AdsRewardsInfos)
        {
            if (info == null)
            {
                continue;
            }

            if (info.rewardId == id)
            {
                return info;
            }
        }

        return null;
    }
}