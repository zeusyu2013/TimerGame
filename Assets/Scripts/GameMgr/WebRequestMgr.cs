using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;

public delegate void LoadJsonComplete(string content);

public class WebRequestMgr : Singleton<WebRequestMgr>
{
    public void LoadJson(string url, LoadJsonComplete com)
    {
        if (com == null)
        {
            return;
        }

        if (string.IsNullOrEmpty(url))
        {
            com("");
            return;
        }

        StartCoroutine(LoadJsontor(url, com));
    }

    IEnumerator LoadJsontor(string url, LoadJsonComplete com)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Logger.LogError(request.error);
            yield break;
        }

        if (request.isDone)
        {
            com(request.downloadHandler.text);
        }
    }

    public void ParseGlobalJson(string json)
    {
        if (string.IsNullOrEmpty(json))
        {
            return;
        }

        JsonData data = JsonMapper.ToObject(json);
        if (data == null)
        {
            return;
        }

        Global.DebugMode = data.Keys.Contains("DebugMode") ? 
            data["DebugMode"].ToString().Equals("True") ? true : false 
            : false;
        Global.TargetFrame = data.Keys.Contains("TargetFrame") ?
            Utils.GetJsonInt(data["TargetFrame"]) : 30;
    }
}
