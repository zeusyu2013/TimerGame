using System.Collections.Generic;
using Tangzx.ABSystem;
using UnityEngine;

public class ConfigMgr : Singleton<ConfigMgr>
{
    private int configCounter = 0;
    private bool configAllLoaded = false;
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

            AssetBundleManager.Instance.Load(Define.ResourcesPath + "Config." + kvp.Value + ".json", (o) =>
            {
                if (o == null)
                {
                    return;
                }

                TextAsset text = o.Require<TextAsset>(this);
                conf.LoadConfig(text.text, OnLoadConfigComplete);
            });
        }
    }

    public void OnLoadConfigComplete(bool success)
    {
        if (!success)
        {
            Logger.LogError("LoadConfig Failed! Config Index is " + configCounter);
            return;
        }

        configCounter++;

        if (confDic.Count != 0)
        {
            DispatchMgr.Instance.FireEvent(Define.DISPATCHEVENT.DISPATCHEVENT_LOADINGSCHEDULE,
            new object[] { (float)configCounter / (float)(confDic.Count) });
        }

        if (configCounter == confDic.Count)
        {
            configAllLoaded = true;
            DispatchMgr.Instance.FireEvent(Define.DISPATCHEVENT.DISPATCHEVENT_ALLCONFIGLOADED);
        }
    }

    public bool GetAllConfigLoaded()
    {
        return configAllLoaded;
    }
}