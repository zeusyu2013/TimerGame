using System.Collections.Generic;
using UnityEngine;

public class IBuilding
{
    public string Name;
    public int Config;
    public GameObject Go;
    public Transform Trans;

    public int Level;
    public int Exp;
    public int MaxExp;
    public long UpgradeMoney;
    public int GenerateBaseMoney;
    public int GenerateTotalMoney;
    public int Employee;
    public List<int> EmployeeHeros = new List<int>();

    public BuildingInfo info;

    public virtual void OnCreate(int config)
    {
        info = BuildingConfig.GetBuildingInfo(config);
        if (info == null)
        {
            Logger.LogError("Create Building Failed! Config : " + config);
            return;
        }

        Config = info.Config;
        Name = info.Name;
        GenerateBaseMoney = info.GenerateBaseMoney;
    }

    public virtual void OnTick()
    {
        GenerateTotalMoney = GenerateBaseMoney;
    }

    public virtual void OnUpgrade()
    {
        if (Level >= info.MaxLevel)
        {
            return;
        }
    }

    public virtual void OnDestroy() { }
}