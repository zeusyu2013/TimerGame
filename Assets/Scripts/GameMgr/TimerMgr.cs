using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public enum TIMERTYPE
{
    TIMERTYPE_NONE,
    TIMERTYPE_REPEAT,
    TIMERTYPE_ONCE,
    TIMERTYPE_COUNTER,
    TIMERTYPE_DELAY,
    TIMERTYPE_MAX,
}

/// <summary>
/// 
/// </summary>
public delegate void TimerCallback();

/// <summary>
/// 
/// </summary>
public class TimerData
{
    public string timerName;
    public TIMERTYPE timerType;
    public float timerInval;
    public float timerEndTime;
    public int timerCounter;
    public float timerDelay;
    public TimerCallback timerCB;
}

public class TimerMgr : Singleton<TimerMgr>
{
    private Dictionary<string, TimerData> timerExcuteDic = new Dictionary<string, TimerData>();
    private Dictionary<string, TimerData> timerAddDic = new Dictionary<string, TimerData>();
    private List<string> timerDelList = new List<string>();

    public void AddTimer(string name, TIMERTYPE type, float inval, TimerCallback cb, int counter = 0, float delay = 0.0f)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("Add Timer Name is Null");
        }

        TimerData data = new TimerData();
        data.timerName = name;
        data.timerType = type;
        data.timerInval = inval;
        data.timerEndTime = Time.realtimeSinceStartup + inval;
        data.timerCounter = counter;
        data.timerDelay = delay;
        data.timerCB = cb;

        if (timerAddDic.ContainsKey(name))
        {
            Debug.LogError("Repeat Add Timer " + name);
            return;
        }

        timerAddDic.Add(name, data);
    }

    public void DelTimer(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.LogError("Del Timer Name is Null");
            return;
        }

        if (timerDelList.Contains(name))
        {
            Debug.LogError("Repeat Del Timer " + name);
            return;
        }

        timerDelList.Add(name);
    }

    private void Update()
    {
        foreach (string name in timerDelList)
        {
            if (timerAddDic.ContainsKey(name))
            {
                timerAddDic.Remove(name);
            }

            if (timerExcuteDic.ContainsKey(name))
            {
                timerExcuteDic.Remove(name);
            }
        }

        timerDelList.Clear();

        //---------------------------------------------------------------//

        foreach (KeyValuePair<string, TimerData> data in timerAddDic)
        {
            if (timerExcuteDic.ContainsKey(data.Key))
            {
                Debug.LogError("Repeat in TimerExcute, Timer " + data.Key);
                continue;
            }

            timerExcuteDic.Add(data.Key, data.Value);
        }

        timerAddDic.Clear();

        //---------------------------------------------------------------//

        float currentTime = Time.realtimeSinceStartup;
        foreach (KeyValuePair<string, TimerData> kvp in timerExcuteDic)
        {
            TimerData data = kvp.Value;
            if (data.timerEndTime > currentTime)
            {
                continue;
            }

            switch (data.timerType)
            {
                case TIMERTYPE.TIMERTYPE_REPEAT:
                    {
                        if (data.timerCB != null)
                        {
                            data.timerCB();
                        }

                        data.timerEndTime += data.timerInval;
                    }
                    break;

                case TIMERTYPE.TIMERTYPE_ONCE:
                    {
                        if (data.timerCB != null)
                        {
                            data.timerCB();
                        }

                        timerDelList.Add(data.timerName);
                    }
                    break;

                case TIMERTYPE.TIMERTYPE_COUNTER:
                    {
                        if (data.timerCB != null)
                        {
                            data.timerCB();
                        }

                        data.timerCounter--;
                        if (data.timerCounter < 1)
                        {
                            timerDelList.Add(data.timerName);
                        }
                    }
                    break;

                case TIMERTYPE.TIMERTYPE_DELAY:
                    break;
                default:
                    break;
            }
        }
    }
}