using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMgr : MonoBehaviour
{
    private static ObjMgr _Instance = null;
    public static ObjMgr Instance
    {
        get { return _Instance; }
    }

    private void Awake()
    {
        _Instance = this;
    }
}
