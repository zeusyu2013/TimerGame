public class GameLogin : IGameStage
{
    public override void OnEnter()
    {
        base.OnEnter();

        // 加载配置
        

        DispatchMgr.Instance.RegisterEvent(Define.DISPATCHEVENT.DISPATCHEVENT_LOADINGEND, OnAirPortPanelShow);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    private void OnAirPortPanelShow(object[] args)
    {
        
    }
}