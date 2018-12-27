using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloMsg
{
    public Dictionary<string, string> Hello;
}

public class Proto : MonoBehaviour
{
    public static object Hello(params object[] args)
    {
        HelloMsg msg = new HelloMsg();
        msg.Hello = new Dictionary<string, string>();
        msg.Hello.Add("Name", args[0].ToString());
        return msg;
    }
}
