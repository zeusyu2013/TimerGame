using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMgr : Singleton<BuildingMgr>
{
    private List<IBuilding> Buildings = new List<IBuilding>();

    public void Build(int config)
    {
        GoldBuilding build = new GoldBuilding();
        build.OnCreate(config);

        if (Buildings.Contains(build))
        {
            Logger.LogError("Create Same Building! Building Config is " + config);
            return;
        }
        else
        {
            Buildings.Add(build);
        }
    }

    public void OnTick()
    {
        TimerMgr.Instance.AddTimer("BuildingTicker", TIMERTYPE.TIMERTYPE_REPEAT, 1.0f, BuildingTicker);
    }

    private void BuildingTicker()
    {
        if (Buildings == null || Buildings.Count < 1)
        {
            return;
        }

        foreach (IBuilding building in Buildings)
        {
            if (building == null)
            {
                continue;
            }

            building.OnTick();

            OwnerData.Instance.Gold += building.GenerateTotalMoney;
            Logger.LogInfo(OwnerData.Instance.Gold.ToString());
        }
    }
}
