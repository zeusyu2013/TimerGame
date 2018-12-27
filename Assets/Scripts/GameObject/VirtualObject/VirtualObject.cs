using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualObjectInfo
{
    public bool enable;
    public GameObject go;
}

public class VirtualObject : Singleton<VirtualObject>
{
//     private Dictionary<int, VirtualObjectInfo> VirtualObjectDic = 
//         new Dictionary<int, VirtualObjectInfo>();

    public void Init()
    {

    }
}