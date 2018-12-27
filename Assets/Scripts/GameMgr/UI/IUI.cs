using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUI : MonoBehaviour
{
    public string uiName;

    public virtual void OnCreate()
    {

    }

    public virtual void OnShow()
    {

    }

    public virtual void OnHide()
    {

    }

    public virtual void OnDestroy()
    {
        Destroy(gameObject);
    }

    public Transform GetChild(string path)
    {
        return transform.Find(path);
    }

    public T GetChild<T>(string path) where T : MonoBehaviour
    {
        return transform.Find(path).GetComponent<T>();
    }
}
