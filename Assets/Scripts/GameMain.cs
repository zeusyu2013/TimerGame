using UnityEngine;
using Tangzx.ABSystem;

public class GameMain : MonoBehaviour
{
    /// <summary>
    /// 初始化基础信息
    /// </summary>
    private void Awake()
    {
        
    }

    /// <summary>
    /// 初始化资源包，完成后才能正常加载资源。
    /// </summary>
    private void Start()
    {
        AssetBundleManager.Instance.Init(OnAssetBundleInitComplete);
    }

    /// <summary>
    /// 资源包初始化完成，开始游戏流程。
    /// </summary>
    private void OnAssetBundleInitComplete()
    {
        // 1.切换至游戏登录阶段
        GameStageMgr.Instance.ChangeStage(GAMESTAGE.GAMESTAGE_LOGIN);

        // 2.注册游戏配置加载完成回调
        DispatchMgr.Instance.RegisterEvent(Define.DISPATCHEVENT.DISPATCHEVENT_ALLCONFIGLOADED, ConfigAllLoadedComplete);

        // 3.打开loading界面
        UIMgr.Instance.Create("LoadingPanel");

        // 4.获取资源服基础配置
        WebRequestMgr.Instance.LoadJson("http://localhost/Global.json", (string content) =>
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            // 5.全局变量初始化
            WebRequestMgr.Instance.ParseGlobalJson(content);

            // 6.设置帧率
            Application.targetFrameRate = Global.TargetFrame;

            // 7.广告初始化
            AdsMgr.Instance.Init();
            
            // 8.json配置加载
            ConfigMgr.Instance.AddConfig(new BaseConfig(), "base_config");
            ConfigMgr.Instance.AddConfig(new UpgradeExp(), "upgrade_exp");
            ConfigMgr.Instance.AddConfig(new BuildingConfig(), "building");
            ConfigMgr.Instance.AddConfig(new AdsRewards(), "ads_rewards");
            ConfigMgr.Instance.AddConfig(new FlightConfig(), "flight_config");
            ConfigMgr.Instance.AddConfig(new PlayerExp(), "player_exp");
            ConfigMgr.Instance.LoadConfig();
        });
    }

    // 9.游戏配置加载完毕
    private void ConfigAllLoadedComplete(params object[] args)
    {
        OwnerData.Instance.DecodeDatas();
        UIMgr.Instance.Create("AirPortPanel");
    }

    /// <summary>
    /// 暂停游戏/恢复游戏
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        // 切到后台
        if (pause)
        {
            OwnerData.Instance.SaveAllDatas();
        }
        // 返回游戏
        else
        {

        }
    }

    /// <summary>
    /// 进程退出
    /// </summary>
    private void OnApplicationQuit()
    {
        DispatchMgr.Instance.UnregisterAll();
        OwnerData.Instance.SaveAllDatas();
    }

    /// <summary>
    /// 销毁所有组件
    /// </summary>
    private void OnDestroy()
    {
        
    }
}