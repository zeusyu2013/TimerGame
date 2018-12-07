using System.Collections.Generic;
using UnityEngine;

public enum GAMESTAGE
{
    GAMESTAGE_NONE,
    GAMESTAGE_LOGIN,
    GAMESTAGE_MAIN,
    GAMESTAGE_MAX
}

public class GameStageMgr : MonoBehaviour
{
    private static GameStageMgr _Instance = null;
    public static GameStageMgr Instance
    {
        get { return _Instance; }
    }

    private void Awake()
    {
        _Instance = this;
    }

    private IGameStage gameStage = null;
    private Dictionary<GAMESTAGE, IGameStage> gameStageDic = new Dictionary<GAMESTAGE, IGameStage>();

    public void ChangeStage(GAMESTAGE eStage)
    {
        IGameStage stage = null;
        if (gameStageDic.ContainsKey(eStage))
        {
            stage = gameStageDic[eStage];
        }
        else
        {
            stage = GetStage(eStage);
            gameStageDic.Add(eStage, stage);
        }

        if (gameStage == null)
        {
            gameStage = stage;
            gameStage.OnEnter();
            return;
        }

        if (gameStage == stage)
        {
            return;
        }

        gameStage.OnExit();
        gameStage = stage;
        gameStage.OnEnter();
    }

    private void Update()
    {
        if (gameStage == null)
        {
            return;
        }

        gameStage.OnUpdate();
    }

    private void OnDestroy()
    {
        gameStage = null;
        gameStageDic.Clear();
    }

    #region <>私有方法<>

    private IGameStage GetStage(GAMESTAGE e)
    {
        IGameStage stage = null;
        switch (e)
        {
            case GAMESTAGE.GAMESTAGE_LOGIN:
                stage = new GameLogin();
                break;

            case GAMESTAGE.GAMESTAGE_MAIN:
                
                break;

            default:
                break;
        }

        return stage;
    }

    #endregion
}