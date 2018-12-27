using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightInfo
{
    public int flightId;
    public int flightLevel;
    public int finishGold;
    public int flightGold;
    public double flightFinishTime;
}

public class FlightConfig : IConfig
{
    private static List<FlightInfo> FlightInfos = new List<FlightInfo>();

    public override void LoadConfig(string text, LoadConfigComplete cb)
    {
        FlightInfos = LitJson.JsonMapper.ToObject<List<FlightInfo>>(text);
        if (cb != null)
        {
            cb(FlightInfos.Count > 0 ? true : false);
        }
    }

    public static FlightInfo GetFlightInfo(int id)
    {
        foreach (FlightInfo info in FlightInfos)
        {
            if (info == null)
            {
                continue;
            }

            if (info.flightId == id)
            {
                return info;
            }
        }

        return null;
    }
}
