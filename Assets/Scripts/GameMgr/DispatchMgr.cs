using System.Collections.Generic;
using UnityEngine;

public delegate void EventFireCallback(params object[] args);

public class DispatchMgr : MonoBehaviour
{
    private static DispatchMgr _Instance = null;
    public static DispatchMgr Instance
    {
        get { return _Instance; }
    }

    private void Awake()
    {
        _Instance = this;
    }

    private Dictionary<Define.DISPATCHEVENT, List<EventFireCallback>> eventDic = 
        new Dictionary<Define.DISPATCHEVENT, List<EventFireCallback>>();

    public void RegisterEvent(Define.DISPATCHEVENT eventId, EventFireCallback cb, params object[] args)
    {
        if (eventDic.ContainsKey(eventId))
        {
            eventDic[eventId].Add(cb);
        }
        else
        {
            eventDic[eventId] = new List<EventFireCallback>();
            eventDic[eventId].Add(cb);
        }
    }

    public void UnregisterEvent(Define.DISPATCHEVENT eventId, EventFireCallback cb)
    {
        if (eventDic.ContainsKey(eventId))
        {
            eventDic[eventId].Remove(cb);
        }
    }

    public void UnregisterAllByEvent(Define.DISPATCHEVENT eventId)
    {
        if (eventDic.ContainsKey(eventId))
        {
            eventDic[eventId].Clear();
        }
    }

    public void UnregisterAll()
    {
        eventDic.Clear();
    }

    public void FireEvent(Define.DISPATCHEVENT eventId, params object[] args)
    {
        List<EventFireCallback> list = null;
        if (!eventDic.TryGetValue(eventId, out list))
        {
            return;
        }

        foreach (EventFireCallback ef in list)
        {
            if (ef == null)
            {
                continue;
            }

            ef.Invoke(args);
        }
    }
}
