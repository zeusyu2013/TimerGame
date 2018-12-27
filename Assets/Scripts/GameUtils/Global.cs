using UnityEngine;

public class Global
{
    private static bool _DebugMode = true;
    public static bool DebugMode
    {
        set { _DebugMode = value; }
        get { return _DebugMode; }
    }

    private static int _TargetFrame = 30;
    public static int TargetFrame
    {
        set { _TargetFrame = value; }
        get { return _TargetFrame; }
    }

    public static string DeviceUID
    {
        get { return SystemInfo.deviceUniqueIdentifier; }
    }
}