using System.Collections;
using System.Collections.Generic;
using Tangzx.ABSystem;
using UnityEngine;

public class ConfigMgr : MonoBehaviour
{
    private static ConfigMgr _Instance = null;
    public static ConfigMgr Instance
    {
        get { return _Instance; }
    }

    private void Awake()
    {
        _Instance = this;
    }

    private int configCounter = 0;
    private Dictionary<IConfig, string> confDic = new Dictionary<IConfig, string>();

    public void AddConfig(IConfig conf, string path)
    {
        if (confDic.ContainsKey(conf))
        {
            return;
        }

        confDic.Add(conf, path);
    }

    public void LoadConfig()
    {
        foreach (KeyValuePair<IConfig, string> kvp in confDic)
        {
            IConfig conf = kvp.Key;
            if (conf == null)
            {
                continue;
            }

            AssetBundleManager.Instance.Load(Define.ResourcesPath + "Config/" + kvp.Value + ".json", (o) =>
            {
                if (o == null || o.mainObject == null)
                {
                    return;
                }

                TextAsset text = o.mainObject as TextAsset;
                conf.LoadConfig(text.text, OnLoadConfigComplete);
            });
        }
    }

    public void OnLoadConfigComplete()
    {
        configCounter++;

        if (confDic.Count != 0)
        {
            DispatchMgr.Instance.FireEvent(Define.DISPATCHEVENT.DISPATCHEVENT_LOADINGSCHEDULE,
            new object[] { (float)configCounter / (float)(confDic.Count) });
        }
    }

    private void Update()
    {
        if (configCounter < confDic.Count)
        {
            return;
        }


    }
}