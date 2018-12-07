using UnityEngine;

public class Define : MonoBehaviour
{
    public static string ResourcesPath = "Assets/Assets/";

    public enum DISPATCHEVENT
    {
        DISPATCHEVENT_NONE,
        DISPATCHEVENT_LOADINGSCHEDULE,
        DISPATCHEVENT_LOADINGEND,
        DISPATCHEVENT_MAX,
    }
}