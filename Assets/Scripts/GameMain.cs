using UnityEngine;
using Tangzx.ABSystem;

public class GameMain : MonoBehaviour
{
    /// <summary>
    /// 加载基础组件
    /// </summary>
    private void Awake()
    {
        gameObject.AddComponent<DispatchMgr>();
        gameObject.AddComponent<ConfigMgr>();
        gameObject.AddComponent<TimerMgr>();
        gameObject.AddComponent<UIMgr>();
        gameObject.AddComponent<GameStageMgr>();
        gameObject.AddComponent<AssetBundleManager>();
        gameObject.AddComponent<NetMgr>();
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
        GameStageMgr.Instance.ChangeStage(GAMESTAGE.GAMESTAGE_LOGIN);

        UIMgr.Instance.Create("LoadingPanel");

        ConfigMgr.Instance.AddConfig(new BaseConfig(), "base_config");
        ConfigMgr.Instance.LoadConfig();
    }

    /// <summary>
    /// 暂停游戏/恢复游戏
    /// </summary>
    /// <param name="pause"></param>
    private void OnApplicationPause(bool pause)
    {
        
    }

    /// <summary>
    /// 进程退出
    /// </summary>
    private void OnApplicationQuit()
    {
        
    }

    /// <summary>
    /// 销毁所有组件
    /// </summary>
    private void OnDestroy()
    {
        NetMgr.Instance.Disconnect();
    }
}