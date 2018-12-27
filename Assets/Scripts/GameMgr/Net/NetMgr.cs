using System;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class NetMgr : Singleton<NetMgr>
{
    private Socket socket;
    
    private const int RECEIVEBUFFERSIZE = 64 * 1024;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ip"></param>
    /// <param name="port"></param>
    public void InitNetwork()
    {
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        if (socket == null)
        {
            Debug.LogError("socket is null");
            return;
        }

        socket.ReceiveBufferSize = RECEIVEBUFFERSIZE;
        socket.Blocking = true;
    }

    public void Connect(string ipString, int port)
    {
        IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(ipString), port);

        socket.BeginConnect(ipe, new AsyncCallback(ConnectCallback), this);
    }

    private void ConnectCallback(IAsyncResult ar)
    {
        Debug.Log("Connected");
    }

    public void Send(object msg)
    {
        string json = LitJson.JsonMapper.ToJson(msg);
        byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
        byte[] msgBytes = new byte[jsonBytes.Length + 2];
        byte[] lenBytes = BitConverter.GetBytes((ushort)jsonBytes.Length);
        lenBytes.CopyTo(msgBytes, 0);
        jsonBytes.CopyTo(msgBytes, 2);

        socket.Send(msgBytes);
    }

    public void Disconnect()
    {
        //socket.Disconnect(false);
        socket = null;
    }

    private void Update()
    {
        if (Time.frameCount % 2 == 0)
        {
            return;
        }

        Process();
    }

    private void Process()
    {

    }

    private byte[] ConverToGoJson(byte[] bytes, int length)
    {
        int index = 1;
        int i = 0;
        var array = new byte[length / 2];

        while (index < length)
        {
            array[i] = bytes[index];
            index += 2;
            i++;
        }

        return array;
    }

    private byte[] ConvertToCSharpJson(byte[] bytes, int length)
    {
        int index = 0;
        int i = 0;
        var array = new byte[length / 2];

        while (index < length)
        {
            array[i] = bytes[index];
            i++;
            index++;
            array[i] = 0;
            i++;
        }

        return array;
    }
}