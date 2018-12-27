using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _Instance = null;
    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                _Instance = FindObjectOfType<T>();
                if (_Instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name);
                    go.transform.SetParent(GameObject.Find("GameMain").transform);
                    go.hideFlags = HideFlags.HideAndDontSave;
                    _Instance = go.AddComponent<T>();
                }
            }
            return _Instance;
        }
    }
}