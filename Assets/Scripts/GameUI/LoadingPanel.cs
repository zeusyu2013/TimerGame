using UnityEngine.UI;

public class LoadingPanel : IUI
{
    private Slider slider;

    public override void OnCreate()
    {
        slider = GetChild<Slider>("Slider");

        DispatchMgr.Instance.RegisterEvent(Define.DISPATCHEVENT.DISPATCHEVENT_LOADINGSCHEDULE, SliderChange);
    }

    private void SliderChange(object[] args)
    {
        float schedule = 0.0f;
        if (args != null && args.Length == 1)
        {
            schedule = (float)args[0];
        }

        slider.value = schedule;

        if (slider.value >= 0.99f)
        {
            DispatchMgr.Instance.FireEvent(Define.DISPATCHEVENT.DISPATCHEVENT_LOADINGEND);
            UIMgr.Instance.Destroy("LoadingPanel");
        }
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
