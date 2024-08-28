using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorqueFly : ObjFly
{
    [SerializeField] protected float torqueSpeed = 30f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetSpeed(torqueSpeed);
    }
}
