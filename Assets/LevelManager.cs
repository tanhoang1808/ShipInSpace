using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : HoangMonoBehaviour
{
    [SerializeField] protected static LevelManager instance;
    [SerializeField] public static LevelManager Instance => instance;
    [SerializeField] protected ShipCtrl shipCtrl;
    [SerializeField] public ShipCtrl ShipCtrl => shipCtrl;
    [SerializeField] protected int expDefault = 50;
    [SerializeField] protected int expToLevelUp;

    
    protected override void Awake()
    {
        base.Awake();
        if (LevelManager.instance != null) Debug.LogWarning("Exceed Level Manager");
        instance = this;
    }
    protected virtual void Start()
    {
        expToLevelUp = expDefault * shipCtrl.ShipSO.Level;
        
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShipCtrl();
    }

    protected virtual void LoadShipCtrl()
    {
        shipCtrl = Transform.FindObjectOfType<ShipCtrl>();
    }

    public virtual void AddPlayerExp(int exp)
    {
        if (CheckLevelUp()) LevelUp();

        shipCtrl.ShipSO.exp += exp;


    }

    public virtual void LevelUp()
    {
        expToLevelUp = expDefault * shipCtrl.ShipSO.Level;
        
            shipCtrl.ShipSO.Level++;
            shipCtrl.ShipSO.exp = 0;
        
    }

    protected virtual bool CheckLevelUp()
    {
        if (shipCtrl.playerExp >= expToLevelUp) return true;
        return false;
    }

}
