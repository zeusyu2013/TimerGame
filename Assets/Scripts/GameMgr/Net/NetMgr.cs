using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class NetMgr : MonoBehaviour
{
    private static NetMgr _Instance = null;
    public static NetMgr Instance
    {
        get { return _Instance; }
    }

    private void Awake()
    {
        _Instance = this;
    }

    private Socket socket;

    private string ipString;
    private int port;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ip"></param>
    /// <param name="port"></param>
    public void InitNetwork()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public void Connect(string ipString, int port)
    {
        this.ipString = ipString;
        this.port = port;

        socket.Connect(IPAddress.Parse(ipString), port);
    }

    public void Send(string msg)
    {
        byte[] msgBytes = System.Text.UTF8Encoding.UTF8.GetBytes(msg);
        socket.Send(msgBytes);
    }

    public void Disconnect()
    {
        //socket.Disconnect(false);
        socket = null;
    }

    private void Update()
    {
        
    }
}