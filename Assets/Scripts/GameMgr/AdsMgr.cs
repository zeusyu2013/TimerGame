using UnityEngine.Advertisements;

public delegate void AdsComplete(bool success, int rewardId);

public class AdsMgr : Singleton<AdsMgr>
{
    private int mRewardId = 0;
    private AdsComplete mAdsCompleteCallback = null;

    public void Init()
    {
        Advertisement.Initialize("", Global.DebugMode);
    }

    public void ShowAds(int rewardId, AdsComplete cb)
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            ShowOptions options = new ShowOptions { resultCallback = HandleShowResult };
            mRewardId = rewardId;
            mAdsCompleteCallback = cb;
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        if (mAdsCompleteCallback == null)
        {
            return;
        }

        switch (result)
        {
            case ShowResult.Finished:
                mAdsCompleteCallback(true, mRewardId);
                break;

            case ShowResult.Skipped:
                mAdsCompleteCallback(false, mRewardId);
                break;

            case ShowResult.Failed:
                mAdsCompleteCallback(false, mRewardId);
                break;

            default:
                break;
        }

        mRewardId = 0;
        mAdsCompleteCallback = null;
    }
}
