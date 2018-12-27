using UnityEngine;

public class Define : MonoBehaviour
{
    public static string ResourcesPath = "Assets.Assets.";

    public enum DISPATCHEVENT
    {
        DISPATCHEVENT_NONE,
        DISPATCHEVENT_ALLCONFIGLOADED,

        DISPATCHEVENT_LOADINGSCHEDULE,
        DISPATCHEVENT_LOADINGEND,
        
        DISPATCHEVENT_ADDFLIGHT,
        DISPATCHEVENT_REMOVEFLIGHT,

        DISPATCHEVENT_MAX,
    }

    public static int AirportPlaneCount
    {
        get { return 5; }
    }
}