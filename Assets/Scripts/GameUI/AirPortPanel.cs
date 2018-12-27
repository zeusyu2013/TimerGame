using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Tangzx.ABSystem;
using UnityEngine;
using UnityEngine.UI;

public class AirPortPanel : IUI
{
    private Text mRoleName;
    private Text mGold;
    private Text mDiamond;

    private Button mGoldButton;
    private Button mDiamondButton;

    private Slider mRoleExp;
    
    private Image [,] mFlightSprites;

    private DOTweenPath mPath;

    public override void OnCreate()
    {
        mRoleName = GetChild<Text>("RoleInfo/Text");
        mGold = GetChild<Text>("Gold/Text");
        mDiamond = GetChild<Text>("Diamond/Text");

        mRoleName.text = OwnerData.Instance.Name;
        mGold.text = OwnerData.Instance.Gold.ToString();
        mDiamond.text = OwnerData.Instance.Diamond.ToString();

        mGoldButton = GetChild<Button>("Gold/Button");
        mDiamondButton = GetChild<Button>("Diamond/Button");
        mGoldButton.onClick.AddListener(OnGoldButtonClick);
        mDiamondButton.onClick.AddListener(OnDiamondButtonClick);

        mRoleExp = GetChild<Slider>("RoleInfo/Slider");
        mRoleExp.value = GetExpRatio();

        InitFlightInfo();

        UpdateAirportInfo();

        mPath = GetChild<DOTweenPath>("Path");

        DispatchMgr.Instance.RegisterEvent(Define.DISPATCHEVENT.DISPATCHEVENT_ADDFLIGHT, AddFlight);
        DispatchMgr.Instance.RegisterEvent(Define.DISPATCHEVENT.DISPATCHEVENT_REMOVEFLIGHT, RemoveFlight);
    }

    public override void OnDestroy()
    {
        mRoleName = null;
        mGold = null;
        mDiamond = null;

        mGoldButton = null;
        mDiamondButton = null;

        mRoleExp = null;

        base.OnDestroy();
    }

    private void InitFlightInfo()
    {
        int[,] airs = AirPortData.GetAirPlanes();
        mFlightSprites = new Image[Define.AirportPlaneCount, Define.AirportPlaneCount];
        for (int i = 0; i < Define.AirportPlaneCount; ++i)
        {
            for (int j = 0; j < Define.AirportPlaneCount; ++j)
            {
                mFlightSprites[i, j] = GetChild<Image>("Content/Image_" + (i * Define.AirportPlaneCount + j) + "/Flight");

                int flightId = airs[i, j];
                if (flightId < 1)
                {
                    continue;
                }

                AssetBundleManager.Instance.Load("flightId", (AssetBundleInfo o) =>
                {
                    if (o == null)
                    {
                        return;
                    }

                    mFlightSprites[i, j].sprite = o.Require<Sprite>(this);
                });
            }
        }
    }

    private void OnGoldButtonClick()
    {
        Logger.LogInfo("Open Gold Charge UI");
    }

    private void OnDiamondButtonClick()
    {
        Logger.LogInfo("Open Diamond Charge UI");
    }

    private void AddFlight(params object[] args)
    {
        int flightId = (int)args[0];
        if (flightId < 1)
        {
            return;
        }


    }

    private void RemoveFlight(params object[] args)
    {
        int flightId = (int)args[0];
        if (flightId < 1)
        {
            return;
        }


    }

    private float GetExpRatio()
    {
        int level = OwnerData.Instance.Level;
        PlayerExpInfo info = PlayerExp.GetPlayerExpInfo(level);
        if (info == null)
        {
            return 0.0f;
        }

        if (info.Exp < 1)
        {
            return 0.0f;
        }

        return (float)OwnerData.Instance.Exp / (float)info.Exp;
    }

    private void UpdateAirportInfo()
    {
        List<int> list = AirPortData.GetAirPlanesList();
        if (list == null || list.Count < 1)
        {
            return;
        }


    }
}
