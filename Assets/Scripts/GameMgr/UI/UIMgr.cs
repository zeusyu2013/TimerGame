using UnityEngine;
using Tangzx.ABSystem;
using System.Collections.Generic;

public class UIMgr : Singleton<UIMgr>
{
    private Transform rootTrans;
    private Dictionary<string, IUI> uiDic = new Dictionary<string, IUI>();
    
    private void Start()
    {
        rootTrans = GameObject.Find("Canvas").transform;
    }

    public void Create(string name)
    {
        if (uiDic.ContainsKey(name))
        {
            Debug.LogError("ui " + name + " already exists in uiDic!");
            return;
        }

        AssetBundleManager.Instance.Load(Define.ResourcesPath + "UI." + name + ".prefab", (o) =>
        {
            if (o == null)
            {
                Logger.LogError("o is null");
                return;
            }

            GameObject go = o.Instantiate();
            if (go == null)
            {
                Logger.LogError("ui " + name + " Instantiate failed!");
                return;
            }

            go.transform.SetParent(rootTrans);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            IUI ui = go.AddComponent(System.Type.GetType(name)) as IUI;
            if (ui == null)
            {
                Logger.LogError("ui " + name + " AddComponent failed!");
                return;
            }
            
            uiDic.Add(name, ui);
            ui.OnCreate();
        });
    }

    public void Destroy(string name)
    {
        if (!uiDic.ContainsKey(name))
        {
            Debug.LogError("ui " + name + " not exists in uiDic!");
            return;
        }

        IUI ui = uiDic[name];
        if (ui == null)
        {
            uiDic.Remove(name);

            Debug.LogError("ui " + name + " is null in uiDic!");
            return;
        }

        ui.OnDestroy();
        ui = null;
    }
}