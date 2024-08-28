using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipFollowPlayer : ObjFollowPlayer
{
    protected float ShipSpeed = 0.005f;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.ResetValue();
    }

    protected override void ResetValue()
    {
        SetSpeed(ShipSpeed);
    }
}
