using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : IUI
{
    private Button connect;

    public override void OnCreate()
    {
        base.OnCreate();

        connect = transform.Find("Button").GetComponent<Button>();
        connect.onClick.AddListener(OnConnect);

        connect = transform.Find("Send").GetComponent<Button>();
        connect.onClick.AddListener(Send);
    }

    public override void OnDestroy()
    {
        Debug.Log("LoginPanel OnDestroy");

        base.OnDestroy();
    }

    public void OnConnect()
    {
        NetMgr.Instance.Connect("127.0.0.1", 9001);
    }

    public void Send()
    {
        NetMgr.Instance.Send("testtesttesttesttesttesttest");
    }
}
