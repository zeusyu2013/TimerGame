using System;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public static void LogInfo(string log)
    {
        if (Global.DebugMode)
        {        
            log = Utils.StringBuilder("[", DateTime.Now, "]", log);
            Debug.Log(log);
        }
    }

    public static void LogWarning(string log)
    {
        if (Global.DebugMode)
        {
            log = Utils.StringBuilder("[", DateTime.Now, "]", log);
            Debug.LogWarning(log);
        }
    }

    public static void LogError(string log)
    {
        if (Global.DebugMode)
        {
            log = Utils.StringBuilder("[", DateTime.Now, "]", log);
            Debug.LogError(log);
        }
    }
}
