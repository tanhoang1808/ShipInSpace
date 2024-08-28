using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFly : ObjFly
{
    [SerializeField] protected float torqueSpeed = 25f;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetSpeed(torqueSpeed);
    }
}
