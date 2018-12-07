public class GameLogin : IGameStage
{
    public override void OnEnter()
    {
        base.OnEnter();

        // 加载配置


        // 初始化网络
        NetMgr.Instance.InitNetwork();

        DispatchMgr.Instance.RegisterEvent(Define.DISPATCHEVENT.DISPATCHEVENT_LOADINGEND, OnLoginPanelShow);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    private void OnLoginPanelShow(object[] args)
    {
        UIMgr.Instance.Create("LoginPanel");
    }
}