using LitJson;

public class OwnerDataInfo
{
    public string Name;
    public int Level;
    public int Exp;
    public int Gold;
    public int Diamond;
    public string Flights;

    public OwnerDataInfo()
    {
        Name = Global.DeviceUID;
        Level = 1;
        Exp = 0;
        Gold = 0;
        Diamond = 0;
        Flights = "";
    }
}

public class OwnerData : Singleton<OwnerData>
{
    private OwnerDataInfo info;

    public void DecodeDatas()
    {
        if (string.IsNullOrEmpty(PlayerPrefsMgr.OwnerData))
        {
            info = new OwnerDataInfo();
        }
        else
        {
            info = JsonMapper.ToObject<OwnerDataInfo>(PlayerPrefsMgr.OwnerData);
            AirPortData.ParseFlights();
        }
    }

    public void SaveAllDatas()
    {
        if (info == null)
        {
            return;
        }

        AirPortData.UpdateFlights();
        string json = JsonMapper.ToJson(info);
        if (string.IsNullOrEmpty(json))
        {
            Logger.LogError("Save OwnerData Falied! OwnerData is null!");
            return;
        }

        PlayerPrefsMgr.OwnerData = json;
    }

    public string Name
    {
        set { info.Name = value; }
        get { return info.Name; }
    }

    public int Level
    {
        set { info.Level = value; }
        get { return info.Level; }
    }

    public int Exp
    {
        set { info.Exp = value; }
        get { return info.Exp; }
    }

    public int Gold
    {
        set { info.Gold = value; }
        get { return info.Gold; }
    }

    public int Diamond
    {
        set { info.Diamond = value; }
        get { return info.Diamond; }
    }

    public string Flights
    {
        set { info.Flights = value; }
        get { return info.Flights; }
    }
}