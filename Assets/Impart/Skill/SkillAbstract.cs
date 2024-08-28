using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillAbstract : HoangMonoBehaviour
{
    

    [SerializeField] protected ShipCtrl shipCtrl;
    [SerializeField] public ShipCtrl ShipCtrl => shipCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShipCtrl();
    }

    protected virtual void LoadShipCtrl()
    {
        shipCtrl = Transform.FindObjectOfType<ShipCtrl>();
    }
}
