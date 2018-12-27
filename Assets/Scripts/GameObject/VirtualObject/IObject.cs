using UnityEngine;

public class IObject : MonoBehaviour
{
    public string Name;
    public int Config;
    public GameObject GameObj;
    public Transform Trans;

    public int Level;
    public int Atk;
    public int AtkInval;
    public int EmployeeRate;

    public virtual void OnCreate() { }
    public virtual void OnAttack() { }
    public virtual void OnBeAttacked() { }
    public virtual void OnDead() { }

    /// <summary>
    /// 销毁对象
    /// </summary>
    public virtual void OnDestroy()
    {
        Name = string.Empty;
        Config = 0;
        GameObj = null;
        Trans = null;
    }
}