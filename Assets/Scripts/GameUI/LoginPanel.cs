using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : IUI
{
    private Button connect;

    public override void OnCreate()
    {
        base.OnCreate();

        connect = transform.Find("Button").GetComponent<Button>();
        connect.onClick.AddListener(OnClick);

        connect = transform.Find("Send").GetComponent<Button>();
        connect.onClick.AddListener(OnUpgrade);
    }

    public override void OnDestroy()
    {
        Debug.Log("LoginPanel OnDestroy");

        base.OnDestroy();
    }

    public void OnClick()
    {
        AdsMgr.Instance.ShowAds(1, null);
        NetMgr.Instance.InitNetwork();
        NetMgr.Instance.Connect("127.0.0.1", 3563);
    }

    public void OnUpgrade()
    {
        NetMgr.Instance.Send(Proto.Hello("Zeusyu"));
    }
}
