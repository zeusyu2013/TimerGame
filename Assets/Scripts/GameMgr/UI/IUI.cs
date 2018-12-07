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

    public T GetChild<T>(string path) where T : MonoBehaviour
    {
        return transform.Find(path).GetComponent<T>();
    }
}
