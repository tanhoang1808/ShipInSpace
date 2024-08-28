using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : HoangMonoBehaviour
{
    [SerializeField] ShipCtrl shipCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShipCtrl();
    }

    protected virtual void LoadShipCtrl()
    {
        this.shipCtrl = GetComponentInParent<ShipCtrl>();
    }
}
