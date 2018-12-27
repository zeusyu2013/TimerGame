using UnityEngine;

public class PlayerPrefsMgr : MonoBehaviour
{
    public static string OwnerData
    {
        set { PlayerPrefs.SetString("OwnerData", value); }
        get { return PlayerPrefs.GetString("OwnerData", ""); }
    }

    public static float AudioVolume
    {
        set
        {
            PlayerPrefs.SetFloat("AudioVolume", value);
        }

        get
        {
            return PlayerPrefs.GetFloat("AudioVolume", 1.0f);
        }
    }
    
    public static float BgmVolume
    {
        set
        {
            PlayerPrefs.SetFloat("BgmVolume", value);
        }
        get
        {
            return PlayerPrefs.GetFloat("BgmVolume", 1.0f);
        }
    }
}